using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CSGame
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        //注册热键的api 
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint control, Keys vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        //窗口加载时
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //注册热键(窗体句柄,热键ID,辅助键,实键)
            RegisterHotKey(this.Handle, 334, 0, Keys.F10);
            RegisterHotKey(this.Handle, 335, 0, Keys.F11);
        }

        //拦截窗体消息
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0312:    //这个是window消息定义的注册的热键消息 
                    if (m.WParam.ToString().Equals("334"))  //开启辅助 
                    {
                        btnGo.PerformClick();
                    }
                    else if (m.WParam.ToString().Equals("335"))  //关闭辅助 
                    {
                        btnStop.PerformClick();
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        //窗体关闭时
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //注消热键(句柄,热键ID)
            UnregisterHotKey(this.Handle, 334);
            UnregisterHotKey(this.Handle, 335);
        }

        FrmMain frm;
        //开始辅助
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (frm == null)
            {
                frm = new FrmMain();
                frm.Show();
                Console.Beep();
                this.WindowState = FormWindowState.Minimized;
            }
        }

        //停止辅助
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (frm != null)
            {
                frm.Close();
                frm = null;
                Console.Beep();
            }
        }
    }
}
