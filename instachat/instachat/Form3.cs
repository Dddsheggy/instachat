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
    public partial class Form3 : Form
    {
        // 聊天界面
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        string[] members;                                              // 所有成员的学号
        string[] Aliases;                                              // 所有成员的备注
        Socket[] all_sockets;                                          // 所有需要socket的成员的socket
        int socket_num;                                                // socket数目
        private ManualResetEvent inter = new ManualResetEvent(false);
        //private delegate void client(Socket file);
        private delegate void client(Socket file);
        public Bitmap btm;
        public string fileuse;

        public Form3(string ids, string nics,Socket[] connections, int membernum,string title)
        {
            InitializeComponent();
            StickerList.Hide();
            members = ids.Split(',');
            Aliases = nics.Split(',');
            Text = "instachat";          

            // 聊天对象列表
            if (members.Length==2)
            {
                TextBox_memebers.AppendText(title + "\n");
                TextBox_memebers.AppendText(Aliases[1] + "(" + members[1] + ")"+"\n");
            }
            else
            {
                TextBox_memebers.AppendText("Group Name:\n");
                TextBox_memebers.ForeColor = Color.Lime;
                TextBox_memebers.AppendText(title + "\n" + "\n");
                TextBox_memebers.ForeColor = Color.Black;
                TextBox_memebers.AppendText("Members are:\n");
                for (int i=0;i<members.Length;i++)
                {
                    TextBox_memebers.AppendText(Aliases[i] + "(" + members[i] + ")" + "\n");
                }
            }

            all_sockets = connections;
            socket_num = membernum;
            AsynReceive(all_sockets);
        }

        // 异步客户端接收消息
        public void AsynReceive(Socket[] tcp_client)
        {
            byte[] data = new byte[1024];
            try 
            {
                foreach(Socket sc in tcp_client)
                {
                    sc.BeginReceive(data, 0, data.Length, SocketFlags.None,
                        asyncResult =>
                        {
                            int len = 0;
                            try
                            {
                                len = sc.EndReceive(asyncResult);
                                if (len == 0)
                                {
                                    //this.Dispose();
                                    //this.Close();
                                    this.Hide();
                                    //return;
                                }
                                string[] t = Encoding.UTF8.GetString(data, 0, len).Split('|');
                                string receive_str = t[0];

                                
                                foreach(Socket sc1 in tcp_client)
                                {
                                    if (sc1 != sc)
                                        AsynSend(sc1, receive_str);
                                }

                                if (receive_str=="--file--")
                                {
                                    fileuse = t[1];
                                    inter.Reset();
                                    client cl = new client(file_Receive);
                                    Invoke(cl, new object[] { sc });
                                    inter.WaitOne();
                                }
                                else if(receive_str=="--shake--")
                                {
                                    Shake s = new Shake(start_shaking);
                                    Invoke(s, new object[] { });
                                }
                                else if(receive_str.Length==14 && receive_str.Substring(0, 11) =="--sticker--")
                                {
                                    TextBox_chat.SelectionAlignment = HorizontalAlignment.Left;
                                    string tmp = receive_str.Substring(12, 2);
                                    if (tmp=="01")
                                        btm = new Bitmap(s1.BackgroundImage);
                                    else if(tmp == "02")
                                        btm = new Bitmap(s2.BackgroundImage);
                                    else if (tmp == "03")
                                        btm = new Bitmap(s3.BackgroundImage);
                                    else if (tmp == "04")
                                        btm = new Bitmap(s4.BackgroundImage);
                                    else if (tmp == "05")
                                        btm = new Bitmap(s5.BackgroundImage);
                                    else if (tmp == "06")
                                        btm = new Bitmap(s6.BackgroundImage);
                                    else if (tmp == "07")
                                        btm = new Bitmap(s7.BackgroundImage);
                                    else if (tmp == "08")
                                        btm = new Bitmap(s8.BackgroundImage);
                                    else if (tmp == "09")
                                        btm = new Bitmap(s9.BackgroundImage);
                                    else if (tmp == "10")
                                        btm = new Bitmap(s10.BackgroundImage);
                                    else if (tmp == "11")
                                        btm = new Bitmap(s11.BackgroundImage);
                                    else if (tmp == "12")
                                        btm = new Bitmap(s12.BackgroundImage);
                                    else if (tmp == "13")
                                        btm = new Bitmap(s13.BackgroundImage);
                                    else if (tmp == "14")
                                        btm = new Bitmap(s14.BackgroundImage);
                                    else if (tmp == "15")
                                        btm = new Bitmap(s15.BackgroundImage);
                                    else
                                        btm = new Bitmap(s16.BackgroundImage);
                                    Sticker s = new Sticker(start_sticker);
                                    Invoke(s, new object[] { });
                                }
                                else
                                {
                                    while(is_sending)
                                    { };
                                    is_sending = true;
                                    TextBox_chat.SelectionAlignment = HorizontalAlignment.Left;
                                    string whole = Aliases[1] + "(" + members[1] + ")" + "   " + DateTime.Now.ToString() + "\n";
                                    TextBox_chat.AppendText(whole);
                                    TextBox_chat.AppendText(receive_str);
                                    is_sending = false;
                                }

                                AsynReceive(tcp_client);
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // 异步发送消息
        public void AsynSend(Socket tcp_client, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            tcp_client.BeginSend(data, 0, data.Length, SocketFlags.None,
                asyncResult =>
                {
                    try
                    {
                        int len = tcp_client.EndSend(asyncResult);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }, null);
        }

        // 是否正在发送
        // 如果上一次发送还没结束就再次发送应该有提示信息
        bool is_sending = false;
        private void button_send_Click(object sender, EventArgs e)
        {
            try 
            {
                if(TextBox_send.Text=="")
                {
                    MessageBox.Show("发送内容不能为空", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string text = TextBox_send.Text;
                while (is_sending) { };
                is_sending = true;
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n" + text + "\n";              
                TextBox_chat.AppendText(whole);

                whole = text + "\n";
                is_sending = false;
                TextBox_send.Clear();
                foreach(Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // 离开当前会话
        private void button_leave_Click(object sender, EventArgs e)
        {
            // 弹出询问
            DialogResult dr = MessageBox.Show("确定要离开吗？", "确认离开", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (Socket sc in all_sockets)
                {
                    if (!sc.Connected)
                        continue;
                    sc.Shutdown(SocketShutdown.Both);
                    //sc.Close();
                }
                this.Hide();
                
            }
            //this.Dispose();
            //this.Close();

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            button_leave_Click(sender, e);
        }

        // 发送文件
        private void button_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();
            if (openFile1.ShowDialog() == DialogResult.OK)
            {
                string pathname = openFile1.FileName;
                byte[] data1 = Encoding.UTF8.GetBytes("--file--|"+pathname);
                FileInfo sendFile = new FileInfo(pathname);
                FileStream sendStream = sendFile.OpenRead();
                int packetSize = 1024 * 1024;
                int packetCount = (int)(sendFile.Length / ((long)packetSize));
                int lastPacketData = (int)(sendFile.Length - ((long)packetSize * packetCount));
                byte[] data = new byte[packetSize];
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data1);
                    //sc.SendFile(pathname, null, null, TransmitFileOptions.UseDefaultWorkerThread);
                    SendVarData(sc, System.Text.Encoding.Unicode.GetBytes(packetSize.ToString()));
                    SendVarData(sc, System.Text.Encoding.Unicode.GetBytes((packetCount + 1).ToString()));
                    for (int i = 0; i < packetCount; i++)
                    {
                        sendStream.Read(data, 0, data.Length);
                        SendVarData(sc, data);
                    }
                    if (lastPacketData != 0)
                    {
                        data = new byte[lastPacketData];
                        sendStream.Read(data, 0, data.Length);
                        SendVarData(sc, data);
                    }
                }
                //foreach (Socket sc in all_sockets)
                //{
                //    sc.Send(pathname_bt);
                //}
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Center;
                TextBox_chat.AppendText("发送文件" + pathname + "\n");
            }
            else
                return;
        }

        public int SendVarData(Socket s, byte[] data)
        {
            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            sent = s.Send(datasize);

            while (total < size)
            {
                sent = s.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }
            return total;
        }

        public byte[] ReceiveVarData(Socket s)
        {
            int total = 0;
            int recv;
            byte[] datasize = new byte[4];
            recv = s.Receive(datasize, 0, 4, SocketFlags.None);
            int size = BitConverter.ToInt32(datasize, 0);
            int dataleft = size;
            byte[] data = new byte[size];
            while (total < size)
            {
                recv = s.Receive(data, total, dataleft, SocketFlags.None);
                if (recv == 0)
                {
                    data = null;
                    break;
                }
                total += recv;
                dataleft -= recv;
            }
            return data;
        }



        // 接收文件
        public void file_Receive(Socket file_listener)
        {
            DialogResult dr = MessageBox.Show("文件请求，是否同意？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //int len = 15000000;
            //byte[] volume = new byte[len];
            bool is_right = false;
            //int tmp_bt;
            //int toll_bt;

            // 同意接收，选择路径
            if (dr==DialogResult.Yes)
            {
                SaveFileDialog saveFile1 = new SaveFileDialog();
                
                string[] s1 = fileuse.Split('\\');
                saveFile1.FileName = s1[s1.Length - 1];

                if (saveFile1.ShowDialog() == DialogResult.OK)
                {
                    is_right = true;
                    string pathname = saveFile1.FileName;
                    string totalSize;//文件大小
                    int totalCount = 0;//总的包数量
                    int receiveCount = 0;//统计已收的包数量
                    FileStream fs = new FileStream(pathname, FileMode.Create, FileAccess.Write);
                    totalSize = System.Text.Encoding.Unicode.GetString(ReceiveVarData(file_listener));
                    //总的包数量
                    totalCount = int.Parse(System.Text.Encoding.Unicode.GetString(ReceiveVarData(file_listener)));
                    while (true)
                    {
                        byte[] data = ReceiveVarData(file_listener);


                        receiveCount++;
                        fs.Write(data, 0, data.Length);


                        if (receiveCount == totalCount)
                        {
                            fs.Write(data, 0, data.Length);
                            TextBox_chat.SelectionAlignment = HorizontalAlignment.Center;
                            TextBox_chat.AppendText("文件已被成功接收\n");
                            break;
                        }

                    }
                    fs.Close();
                }
            }
            // 不同意接收
            // 或者同意接收后没有选择正确可行的路径
            // 不接收
            if(!is_right)
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Center;
                TextBox_chat.AppendText("拒收了别人发来的文件\n");
                string[] s1 = fileuse.Split('\\');
                string pathname = @".\trash\" + s1[s1.Length - 1];
                FileStream fs = new FileStream(pathname, FileMode.Create, FileAccess.Write);
                string totalSize;//文件大小
                int totalCount = 0;//总的包数量
                int receiveCount = 0;//统计已收的包数量
                
                totalSize = System.Text.Encoding.Unicode.GetString(ReceiveVarData(file_listener));
                //总的包数量
                totalCount = int.Parse(System.Text.Encoding.Unicode.GetString(ReceiveVarData(file_listener)));
                while (true)
                {
                    byte[] data = ReceiveVarData(file_listener);
                    receiveCount++;
                    fs.Write(data, 0, data.Length);


                    if (receiveCount == totalCount)
                    {
                        fs.Write(data, 0, data.Length);
                        TextBox_chat.SelectionAlignment = HorizontalAlignment.Center;
                        TextBox_chat.AppendText("文件被放入垃圾文件夹\n");
                        break;
                    }

                }
                fs.Close();
            }
            // ???
            inter.Set();
        }


        // 为实现窗口抖动
        public delegate void Shake();
        public void start_shaking()
        {
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X + 10, this.Location.Y + 10);
            Thread.Sleep(50);
            this.Location = new Point(this.Location.X - 10, this.Location.Y - 10);
            Thread.Sleep(50);
            this.Location = new Point(this.Location.X + 10, this.Location.Y + 10);
            Thread.Sleep(50);
            this.Location = new Point(this.Location.X - 10, this.Location.Y - 10);
            Thread.Sleep(50);
            this.Location = new Point(this.Location.X + 5, this.Location.Y - 5);
            timer1.Stop();
        }

        // 窗口抖动
        private void button_shake_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];
            data = Encoding.UTF8.GetBytes("--shake--");
            foreach(Socket sc in all_sockets)
            {
                sc.Send(data);
            }
            Shake s = new Shake(start_shaking);
            Invoke(s, new object[] { });
        }


        // 修改输入字体
        private void button_font_Click(object sender, EventArgs e)
        {
            DialogResult dr = fontDialog1.ShowDialog();
            if (dr==DialogResult.OK)
            {
                TextBox_send.SelectionFont = fontDialog1.Font;
            }

        }

        // 修改输入字体的颜色
        private void button_color_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog1.ShowDialog();
            if(dr==DialogResult.OK)
            {
                TextBox_send.SelectionColor = colorDialog1.Color;
            }
        }

        // 清空输入栏
        private void button_clear_Click(object sender, EventArgs e)
        {
            TextBox_send.Clear();
        }

        // 为了发表情
        private void button_sticker_Click(object sender, EventArgs e)
        {
            StickerList.Show();
        }
        public delegate void Sticker();
        public void start_sticker()
        {
            Clipboard.Clear();
            Clipboard.SetImage(btm);
            TextBox_chat.Paste();
            TextBox_chat.AppendText("\n");
        }
        #region
        private void s1_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s01");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s1.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s2_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s02");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s2.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s3_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s03");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s3.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s4_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s04");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s4.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s5_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s05");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s5.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s6_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s06");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s6.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s7_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s07");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s7.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s8_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s08");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s8.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s9_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s09");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s9.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s10_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s10");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s10.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s11_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s11");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s11.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s12_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s12");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s12.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s13_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s13");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s13.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s14_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s14");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s14.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s15_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s15");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s15.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void s16_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                string whole = "Sticker!" + "\n";
                byte[] data = Encoding.UTF8.GetBytes("--sticker--s16");
                string title = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n";
                TextBox_chat.AppendText(title);
                TextBox_chat.AppendText(whole);
                //Clipboard.Clear();
                btm = new Bitmap(s16.BackgroundImage);
                //Clipboard.SetImage(btm);
                TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                //TextBox_chat.Paste();
                foreach (Socket sc in all_sockets)
                {
                    AsynSend(sc, whole);
                }
                foreach (Socket sc in all_sockets)
                {
                    sc.Send(data);
                }
                Sticker s = new Sticker(start_sticker);
                Invoke(s, new object[] { });
                StickerList.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        private void ChangeFontStyle(FontStyle style)
        {
            if (style != FontStyle.Bold && style != FontStyle.Italic &&
                style != FontStyle.Underline)
                throw new System.InvalidProgramException("字体格式错误");
            RichTextBox tempRichTextBox = new RichTextBox();  //将要存放被选中文本的副本  
            int curRtbStart = TextBox_send.SelectionStart;
            int len = TextBox_send.SelectionLength;
            int tempRtbStart = 0;
            Font font = TextBox_send.SelectionFont;
            if (len <= 1 && font != null) //与上边的那段代码类似，功能相同  
            {
                if (style == FontStyle.Bold && font.Bold ||
                    style == FontStyle.Italic && font.Italic ||
                    style == FontStyle.Underline && font.Underline)
                {
                    TextBox_send.SelectionFont = new Font(font, font.Style ^ style);
                }
                else if (style == FontStyle.Bold && !font.Bold ||
                         style == FontStyle.Italic && !font.Italic ||
                         style == FontStyle.Underline && !font.Underline)
                {
                    TextBox_send.SelectionFont = new Font(font, font.Style | style);
                }
                return;
            }
            tempRichTextBox.Rtf = TextBox_send.SelectedRtf;
            tempRichTextBox.Select(len - 1, 1); //选中副本中的最后一个文字  
                                                //克隆被选中的文字Font，这个tempFont主要是用来判断  
                                                //最终被选中的文字是否要加粗、去粗、斜体、去斜、下划线、去下划线  
            Font tempFont = (Font)tempRichTextBox.SelectionFont.Clone();

            //清空2和3  
            for (int i = 0; i < len; i++)
            {
                tempRichTextBox.Select(tempRtbStart + i, 1);  //每次选中一个，逐个进行加粗或去粗  
                if (style == FontStyle.Bold && tempFont.Bold ||
                    style == FontStyle.Italic && tempFont.Italic ||
                    style == FontStyle.Underline && tempFont.Underline)
                {
                    tempRichTextBox.SelectionFont =
                        new Font(tempRichTextBox.SelectionFont,
                                 tempRichTextBox.SelectionFont.Style ^ style);
                }
                else if (style == FontStyle.Bold && !tempFont.Bold ||
                         style == FontStyle.Italic && !tempFont.Italic ||
                         style == FontStyle.Underline && !tempFont.Underline)
                {
                    tempRichTextBox.SelectionFont =
                        new Font(tempRichTextBox.SelectionFont,
                                 tempRichTextBox.SelectionFont.Style | style);
                }
            }
            tempRichTextBox.Select(tempRtbStart, len);
            TextBox_send.SelectedRtf = tempRichTextBox.SelectedRtf; //将设置格式后的副本拷贝给原型  
            TextBox_send.Select(curRtbStart, len);
        }

        private void button_B_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(FontStyle.Bold);
        }

        private void button_I_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(FontStyle.Italic);
        }

        private void button_U_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(FontStyle.Underline);
        }

        private void button_send_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button_send_KeyDown(object sender, KeyEventArgs e)
        {
           
        }


        private void TextBox_send_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    if (TextBox_send.Text == ""|| TextBox_send.Text == "\n")
                    {
                        MessageBox.Show("发送内容不能为空", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string text = TextBox_send.Text;
                    while (is_sending) { };
                    is_sending = true;
                    TextBox_chat.SelectionAlignment = HorizontalAlignment.Right;
                    string whole = Aliases[0] + "(" + members[0] + ")" + "   " + DateTime.Now.ToString() + "\n" + text + "\n";
                    TextBox_chat.AppendText(whole);

                    whole = text + "\n";
                    is_sending = false;
                    TextBox_send.Clear();
                    foreach (Socket sc in all_sockets)
                    {
                        AsynSend(sc, whole);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("连接失效", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
