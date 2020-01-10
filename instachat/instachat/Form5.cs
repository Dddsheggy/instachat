using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace instachat
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
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
                TextHandler.Invoke(group_name_text.Text);
                DialogResult = DialogResult.OK;
            }
        }

        // 返回没有修改的字符串
        // 然后关闭
        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            button_cancel_Click(sender, e);
        }

        
    }
}
