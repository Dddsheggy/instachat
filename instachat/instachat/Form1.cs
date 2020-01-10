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
    public partial class Form1 : Form
    {
        IPAddress server = IPAddress.Parse("166.111.140.57");     // 服务器IP地址
        int port = 8000;                                          // 端口号
        string username;                                          // 用户名
        string pwd;                                               // 密码
        Socket client;                                            // C-S中的client端

        public Form1()
        {
            InitializeComponent();
            //password.Text = "net2019";
            //id.Text = "2017011010";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 用于做出水印提示的效果
        private void textChanged(object sender, EventArgs e)
        {
            if (sender.Equals(id))
                idlabel.Visible = id.Text.Length < 1;
            else if(sender.Equals(password))
            {
                pwdlabel.Visible = password.Text.Length < 1;
                password.PasswordChar = '*';
            }
        }

        // 用于做出水印提示的效果
        private void label_Click(object sender,EventArgs e)
        {
            if (sender.Equals(idlabel))
                id.Focus();
            else if (sender.Equals(pwdlabel))
                password.Focus();
        }

        

        private void button_log_in_Click(object sender, EventArgs e)
        {
            IPEndPoint ip_port = new IPEndPoint(server, port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            username = id.Text.ToString();
            pwd = password.Text.ToString();
            

            // 处理连接异常
            try
            {
                client.Connect(ip_port);
            }
            catch(SocketException)
            {
                MessageBox.Show("网络故障，请检查后重连", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // 处理错误输入
            if(username=="")
            {
                MessageBox.Show("请输入用户名", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(pwd=="")
            {
                MessageBox.Show("请输入密码", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string log_info = username + '_' + pwd;
            byte[] log_bt = new byte[1024];
            log_bt = Encoding.ASCII.GetBytes(log_info);
            // 处理连接超时
            try
            {
                client.Send(log_bt, log_bt.Length, 0);
            }
            catch(Exception)
            {
                MessageBox.Show("连接超时，请重连", "连接超时", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            byte[] server_bt = new byte[1024];
            int num = client.Receive(server_bt, server_bt.Length, 0);
            string server_info = Encoding.Default.GetString(server_bt, 0, num);
            // 处理无法匹配
            if (server_info!="lol")
            {
                MessageBox.Show("账号或密码错误，请检查", "匹配错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //成功登录后打开主窗口界面
            Form2 form2 = new Form2(username, client);
            form2.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
            this.Dispose();
            this.Close();
        }
    }
}
