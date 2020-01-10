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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public Form4(string Alias)
        {
            InitializeComponent();
            label_of_use.Text = Alias;
        }
        // 用于做出水印提示的效果
        private void textChanged(object sender, EventArgs e)
        {
            if (sender.Equals(changed_alias))
                label_of_use.Visible = changed_alias.Text.Length < 1;
        }
        // 用于做出水印提示的效果
        private void label_Click(object sender, EventArgs e)
        {
            if (sender.Equals(label_of_use))
                changed_alias.Focus();
        }

        // 用于传回新修改的备注名
        public delegate void TextEventHandler(string strText);
        public TextEventHandler TextHandler;

        // 要返回修改后的字符串
        // 然后关闭
        private void button_OK_Click(object sender, EventArgs e)
        {
            if (null != TextHandler)
            {
                TextHandler.Invoke(changed_alias.Text);
                DialogResult = DialogResult.OK;
            }
        }

        // 返回没有修改的字符串
        // 然后关闭
        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            button_cancel_Click(sender, e);
        }
    }
}
