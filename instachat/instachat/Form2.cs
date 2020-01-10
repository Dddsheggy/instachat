using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace instachat
{
    // 需要完成查询好友状态、下线这两种C-S操作
    // 在P2P中作为服务器接收别的客户发来的消息
    // 自己作为客户通过P2P发送是在Form3中实现
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        public string username;                      // 用户名
        Socket client;                               // 本机套接字
        IPAddress my_ip;                             // 本机IP

        // 监听端口
        int listen_port;
        Socket tcp_server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public string chatname = string.Empty;

        // 初始化函数
        public Form2(string usr, Socket clt)
        {
            InitializeComponent();
            // 由登录界面传入
            username = usr;
            client = clt;
            label1.Text = username + "'s " + "Contacts";
            // 获取本机IP地址
            IPAddress[] ip_addrs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip_addr in ip_addrs)
            {
                if (ip_addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    my_ip = ip_addr;
                    break;
                }
            }
            // 创建好友列表
            // 本地存储联系人的路径
            string filepath = @".\" + username + ".txt";
            //string filepath = @"C:\Users\Dddsh\Desktop\chat\" + username + ".txt";
            if (!File.Exists(filepath))
            {
                FileStream contacts = new FileStream(filepath, FileMode.Create);
                contacts.Close();
            }
            // 读取好友信息
            StreamReader rinfo = new StreamReader(filepath, Encoding.UTF8);
            this.contacts_list.BeginUpdate();
            String sinfo = rinfo.ReadLine();
            while (sinfo != null)
            {
                string[] tmp_info = new string[4];
                tmp_info[0] = sinfo;
                sinfo = rinfo.ReadLine();
                tmp_info[1] = sinfo;

                // 先全部记为离线状态
                tmp_info[2] = "*";
                tmp_info[3] = "off";
                ListViewItem tmp_item = new ListViewItem(tmp_info);
                this.contacts_list.Items.Add(tmp_item);
                sinfo = rinfo.ReadLine();
            }
            this.contacts_list.EndUpdate();
            rinfo.Close();
            // 检查在线好友，修改对应状态
            foreach (ListViewItem it in contacts_list.Items)
            {
                string receive_info = Search_ID(it.SubItems[0].Text);
                // !="n"表示在线
                if (receive_info != "n")
                {
                    it.SubItems[2].Text = receive_info;
                    it.SubItems[3].Text = "on";
                }
            }

            // Tcp协议异步通讯类(服务器端)
            // Tcp协议异步监听
            // 同一台电脑登录不同用户采用不同的端口号
            string tmp_str1 = username.Substring(username.Length - 3, 3);
            string tmp_str2 = username.Substring(0, 1);
            int tmp_port = int.Parse(tmp_str1) + int.Parse(tmp_str2);
            //listen_port = tmp_port + 3017;
            listen_port = 5000;
            // 可以重复使用
            tcp_server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            IPEndPoint serverIP = new IPEndPoint(IPAddress.Any, listen_port);
            //IPEndPoint serverIP = new IPEndPoint(my_ip, listen_port);
            tcp_server.Bind(serverIP);
            // 耳朵数100
            tcp_server.Listen(100);
            AsynAccept(tcp_server);
        }

        // 异步连接客户端
        private void AsynAccept(Socket tcp_server)
        {
            tcp_server.BeginAccept(asyncResult =>
            {
                Socket tcp_client = tcp_server.EndAccept(asyncResult);
                // 继续监听其余连接
                AsynAccept(tcp_server);
                // 接收消息
                AsynReceive(tcp_client);
            }, null);
        }

        // 异步接收客户端消息
        private void AsynReceive(Socket tcp_client)
        {
            byte[] data = new byte[1024];
            try
            {
                tcp_client.BeginReceive(data, 0, data.Length, SocketFlags.None,
                    asyncResult =>
                   {
                       int len = tcp_client.EndReceive(asyncResult);
                       string receive_info = Encoding.UTF8.GetString(data, 0, len);                     
                       Socket[] connection = new Socket[1];
                       connection[0] = tcp_client;

                       // 本地存储联系人的路径
                       Console.WriteLine(chatname);
                       string filepath = @".\" +username + ".txt";
                       //string filepath = @"C:\Users\Dddsh\Desktop\chat\" + username + ".txt";
                       // 读取好友信息
                       StreamReader rinfo = new StreamReader(filepath, Encoding.Default);
                       String sinfo = rinfo.ReadLine();
                       string tmp_info = null;
                       int is_pal = 0;
                       while (sinfo != null)
                       {
                           if(sinfo==receive_info)
                           {
                               is_pal = 1;
                               sinfo = rinfo.ReadLine();
                               tmp_info = sinfo;
                               break;
                           }                          
                           sinfo = rinfo.ReadLine();
                       }
                       rinfo.Close();

                       // 为了显示聊天对象的信息
                       string info = username + "," + receive_info;
                       

                       string Alias = "me";
                       if(is_pal==1)
                       {
                           Alias += "," + tmp_info;
                       }
                       else
                       {
                           Alias += "," + "Stranger";
                       }


                       Thread server_client = new Thread(() => Application.Run(new Form3(info, Alias, connection, 1, "Chatting with:")));
                       server_client.SetApartmentState(System.Threading.ApartmentState.STA);
                       server_client.Start();
                   }, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        bool is_checking = false;
        // 输入要查询的id
        // 返回该id对应的IP(以string的格式)
        public string Search_ID(string search_id)
        {
            bool is_checking = true;
            // 查询格式
            string search_info = "q" + search_id;
            byte[] search_bt = new byte[1024];
            search_bt = Encoding.ASCII.GetBytes(search_info);
            // 处理连接异常
            try
            {
                client.Send(search_bt);
            }
            catch (Exception)
            {
                MessageBox.Show("无法连接至服务器，请稍候再试", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                is_checking = false;
                return ("");
            }
            // 处理接收到的信息
            byte[] receive_bt = new byte[1024];
            int num = client.Receive(receive_bt);
            string receive_info = Encoding.Default.GetString(receive_bt, 0, num);
            is_checking = false;
            return receive_info;
        }

        // 聊天函数，对单聊和群聊都适用
        private Socket group_Chat(string usr, string broad_info)
        {
            string usr_ip = Search_ID(usr);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(usr_ip), listen_port);
            //IPEndPoint ip = new IPEndPoint(IPAddress.Parse(usr_ip), listen_port);
            Socket usr_tcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Socket usr_tcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Udp);
            usr_tcp.Connect(ip);
            byte[] data = Encoding.UTF8.GetBytes(broad_info);
            usr_tcp.Send(data);
            return usr_tcp;
        }

        // 聊天函数，对单聊和群聊都适用
        private void for_all_chat(string title)
        {
            int membernum = 0;                                                 // 参与聊天的人数          
            string broad_info;                                                 // 广播信息           
            string members = username;                                         // 成员名
            string Alias = "me";                                               // 发起方的备注
            Socket[] clients = new Socket[contacts_list.SelectedItems.Count];  // 各个成员对应的套接字

            foreach (ListViewItem it in contacts_list.SelectedItems)
            {
                // 向每个对象广播发起方及除Ta自己外别的成员
                broad_info = username;
                foreach (ListViewItem it1 in contacts_list.SelectedItems)
                {
                    if (it.SubItems[0].Text != it1.SubItems[0].Text)
                    {
                        broad_info = broad_info + "," + it1.SubItems[0].Text;
                    }
                }
                // 所有聊天成员信息
                members = members + "," + it.SubItems[0].Text;
                Alias = Alias + "," + it.SubItems[1].Text;
                clients[membernum] = group_Chat(it.SubItems[0].Text, broad_info);
                membernum++;
            }
            Thread server_client = new Thread(() => Application.Run(new Form3(members, Alias, clients, membernum, title)));
            server_client.SetApartmentState(System.Threading.ApartmentState.STA);
            server_client.Start();
        }

        // 查询某个用户的username，将其状态添加到联系人列表中
        // 如果在线能够显示IP和状态"on"
        // 否则不能显示IP，状态为"off"
        private void button_search_Click(object sender, EventArgs e)
        {
            // 想要查的username
            string search_id;
            // 查到的结果
            string receive_info;
            // 对方信息
            string[] tmp_info = new string[4];
            // 欲添加对象是否不在列表中
            bool is_new = true;
            bool is_self = false;

            // 防止在上一次查询未结束时再次查询
            if (is_checking == true)
            {
                MessageBox.Show("上次查询尚未结束，请稍候再试", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            search_id = id_to_search.Text.ToString();
            // 如果欲添加对象已经在列表中
            if(search_id==username)
            {
                MessageBox.Show("你输入了自己的学号", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                is_self = true;
                id_to_search.Clear();
            }

            foreach (ListViewItem it in contacts_list.Items)
            {
                if (search_id == it.SubItems[0].Text)
                {
                    MessageBox.Show("Ta已经是你的好友了", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    id_to_search.Clear();
                    is_new = false;
                    break;
                }
            }

            if (is_new&&is_self==false)
            {
                receive_info = Search_ID(search_id);
                // 为"n"表示不在线
                // 为""表示在线
                // 否则是错误的输入(输入非学号格式的username及输入学号找不到)
                if (receive_info == "n")
                {
                    tmp_info[0] = search_id;
                    tmp_info[1] = search_id;
                    tmp_info[2] = "*";
                    tmp_info[3] = "off";
                    id_to_search.Clear();
                    ListViewItem tmp_item = new ListViewItem(tmp_info);
                    contacts_list.Items.Add(tmp_item);
                }
                else if (receive_info == "Please send the correct message." || receive_info == "Incorrect No.")
                {
                    MessageBox.Show("输入有误，请检查", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }            
                else
                {
                    tmp_info[0] = search_id;
                    tmp_info[1] = search_id;
                    tmp_info[2] = receive_info;
                    tmp_info[3] = "on";
                    id_to_search.Clear();
                    ListViewItem tmp_item = new ListViewItem(tmp_info);
                    contacts_list.Items.Add(tmp_item);
                    //return;
                }
                
            }
            // 本地存储联系人的路径
            string filepath = @".\" + username + ".txt";
            //string filepath = @"C:\Users\Dddsh\Desktop\chat\" + username + ".txt";
            // 把之前的本地联系人表清空
            // 把关闭时的contacts_list抄进去
            System.IO.File.WriteAllText(filepath, string.Empty);
            StreamWriter winfo = new StreamWriter(filepath, true);
            foreach (ListViewItem it in contacts_list.Items)
            {
                winfo.WriteLine(it.SubItems[0].Text);
                winfo.WriteLine(it.SubItems[1].Text);
            }
            winfo.Flush();
            winfo.Close();

        }

        // 刷新好友状态
        private void button_refresh_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem it in contacts_list.Items)
            {
                string receive_info;
                receive_info = Search_ID(it.SubItems[0].Text);
                if (receive_info != "n")
                {
                    it.SubItems[2].Text = receive_info;
                    it.SubItems[3].Text = "on";
                }
                else
                {
                    it.SubItems[2].Text = "*";
                    it.SubItems[3].Text = "off";
                }
            }
            // 本地存储联系人的路径
            string filepath = @".\" + username + ".txt";
            //string filepath = @"C:\Users\Dddsh\Desktop\chat\" + username + ".txt";
            // 把之前的本地联系人表清空
            // 把关闭时的contacts_list抄进去
            System.IO.File.WriteAllText(filepath, string.Empty);
            StreamWriter winfo = new StreamWriter(filepath, true);
            foreach (ListViewItem it in contacts_list.Items)
            {
                winfo.WriteLine(it.SubItems[0].Text);
                winfo.WriteLine(it.SubItems[1].Text);
            }
            winfo.Flush();
            winfo.Close();
        }

        // 删除好友
        private void button_delete_Click(object sender, EventArgs e)
        {
            //一个确认问话
            DialogResult dr = MessageBox.Show("确定要删除吗？", "确认删除", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (ListViewItem it in contacts_list.SelectedItems)
                {
                    it.Remove();
                }
            }
            // 本地存储联系人的路径
            string filepath = @".\" + username + ".txt";
            //string filepath = @"C:\Users\Dddsh\Desktop\chat\" + username + ".txt";
            // 把之前的本地联系人表清空
            // 把关闭时的contacts_list抄进去
            System.IO.File.WriteAllText(filepath, string.Empty);
            StreamWriter winfo = new StreamWriter(filepath, true);
            foreach (ListViewItem it in contacts_list.Items)
            {
                winfo.WriteLine(it.SubItems[0].Text);
                winfo.WriteLine(it.SubItems[1].Text);
            }
            winfo.Flush();
            winfo.Close();
        }

        // 选择一个人单聊
        private void button_chat_Click(object sender, EventArgs e)
        {
            // 提示信息,没有选中
            if (contacts_list.SelectedItems.Count == 0)
            {
                MessageBox.Show("没有选中聊天对象", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 提示信息,选中太多
            if (contacts_list.SelectedItems.Count > 1)
            {
                MessageBox.Show("只能选择一个对象", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // 先刷新
                button_refresh_Click(sender, e);
                // 处理有人不在线的情况
                foreach (ListViewItem it in contacts_list.SelectedItems)
                {
                    if (it.SubItems[3].Text == "off")
                    {
                        MessageBox.Show("您选择的好友不在线", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    chatname = it.SubItems[0].Text;

                    for_all_chat("Chatting with:");
                }
            }
        }

        // 选择两个及以上人群聊
        private void button_group_chat_Click(object sender, EventArgs e)
        {
            // 提示信息,没有选中
            if (contacts_list.SelectedItems.Count == 0)
            {
                MessageBox.Show("没有选中聊天对象", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 提示信息,选中太少
            if (contacts_list.SelectedItems.Count == 1)
            {
                MessageBox.Show("两个人不叫群聊", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // 先刷新
                button_refresh_Click(sender, e);
                // 处理有人不在线的情况
                foreach (ListViewItem it in contacts_list.SelectedItems)
                {
                    if (it.SubItems[3].Text == "off")
                    {
                        MessageBox.Show("您选择的好友不在线", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                string tmp_str = string.Empty;
                string group_name = string.Empty;
                Form5 form5 = new Form5();
                form5.TextHandler = (str) => { tmp_str = str; };
                DialogResult dr = form5.ShowDialog();
                group_name = tmp_str;
                for_all_chat(group_name);
            }
        }

        // 退出当前账号，保存本次登陆期间产生的联系人信息更新
        // 返回登录界面
        private void button_logout_Click(object sender, EventArgs e)
        {
            string logout_info = "logout" + username;
            byte[] logout_bt = new byte[1024];
            logout_bt = Encoding.ASCII.GetBytes(logout_info);

            try
            {
                client.Send(logout_bt, logout_bt.Length, 0);
            }
            catch (Exception)
            {
                MessageBox.Show("网络连接错误，请检查", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            byte[] receive_bt = new byte[1024];
            int num = client.Receive(receive_bt, receive_bt.Length, 0);
            string receive_info = Encoding.Default.GetString(receive_bt, 0, num);
            if (receive_info != "loo")
            {
                MessageBox.Show("退出失败", "无法退出", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 本地存储联系人的路径
            string filepath = @".\" + username + ".txt";
            //string filepath = @"C:\Users\Dddsh\Desktop\chat\" + username + ".txt";
            // 把之前的本地联系人表清空
            // 把关闭时的contacts_list抄进去
            System.IO.File.WriteAllText(filepath, string.Empty);
            StreamWriter winfo = new StreamWriter(filepath, true);
            foreach (ListViewItem it in contacts_list.Items)
            {
                winfo.WriteLine(it.SubItems[0].Text);
                winfo.WriteLine(it.SubItems[1].Text);
            }
            winfo.Flush();
            winfo.Close();
            // 释放内存关闭窗口
            // 若要关闭所有进程退回至登录窗口关闭
            this.Dispose();
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        // 按叉号与按退出登录按钮效果相同
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            button_logout_Click(sender, e);
        }

        // 修改备注
        private void button_change_alias_Click(object sender, EventArgs e)
        {
            if (contacts_list.SelectedItems.Count == 0)
            {
                MessageBox.Show("没有选中对象", "错误操作", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (contacts_list.SelectedItems.Count > 1)
            {
                MessageBox.Show("选中太多对象", "错误操作", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                foreach (ListViewItem it in contacts_list.SelectedItems)
                {
                    string tmp_str = string.Empty;
                    Form4 form4 = new Form4(it.SubItems[1].Text);
                    form4.TextHandler = (str) => { tmp_str = str; };
                    DialogResult dr = form4.ShowDialog();
                    it.SubItems[1].Text = tmp_str;
                }
            }
            // 本地存储联系人的路径
            string filepath = @".\" + username + ".txt";
            //string filepath = @"C:\Users\Dddsh\Desktop\chat\" + username + ".txt";
            // 把之前的本地联系人表清空
            // 把关闭时的contacts_list抄进去
            System.IO.File.WriteAllText(filepath, string.Empty);
            StreamWriter winfo = new StreamWriter(filepath, true);
            foreach (ListViewItem it in contacts_list.Items)
            {
                winfo.WriteLine(it.SubItems[0].Text);
                winfo.WriteLine(it.SubItems[1].Text);
            }
            winfo.Flush();
            winfo.Close();
        }
    }
}
