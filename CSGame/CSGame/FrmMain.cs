using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace CSGame
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        #region 窗口加载时
        int WG;
        int HG;
        private void Form1_Load(object sender, EventArgs e)
        {
            //双缓冲
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            UpdateStyles();
            //使窗体局中
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);
            WG = ScreenArea.Width;
            HG = ScreenArea.Height;
            this.Left = (WG - this.Width) / 2;
            this.Top = (HG - this.Height) / 2;
            //绘画十字
            Bitmap btm = new Bitmap(20, 20);
            Graphics g = Graphics.FromImage(btm);
            g.DrawLine(Pens.Red, new Point(this.Width / 2, 0), new Point(this.Width / 2, this.Height));
            g.DrawLine(Pens.Red, new Point(0, this.Height / 2), new Point(this.Width, this.Height / 2));
            //不规则无毛边窗体
            SetBits(btm);
            //使窗口有鼠标穿透功能
            CanPenetrate();
        }
        #endregion

        #region 使窗口有鼠标穿透功能
        /// <summary>
        /// 使窗口有鼠标穿透功能
        /// </summary>
        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_EXSTYLE = (-20);
        private void CanPenetrate()
        {
            uint intExTemp = Win32.GetWindowLong(this.Handle, GWL_EXSTYLE);
            uint oldGWLEx = Win32.SetWindowLong(this.Handle, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED);
        }
        #endregion

        #region 不规则无毛边窗体
        public void SetBits(Bitmap bitmap)
        {
            if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");

            IntPtr oldBits = IntPtr.Zero;
            IntPtr screenDC = Win32.GetDC(IntPtr.Zero);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr memDc = Win32.CreateCompatibleDC(screenDC);

            try
            {
                Win32.Point topLoc = new Win32.Point(Left, Top);
                Win32.Size bitMapSize = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.BLENDFUNCTION blendFunc = new Win32.BLENDFUNCTION();
                Win32.Point srcLoc = new Win32.Point(0, 0);

                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBits = Win32.SelectObject(memDc, hBitmap);

                blendFunc.BlendOp = Win32.AC_SRC_OVER;
                blendFunc.SourceConstantAlpha = 255;
                blendFunc.AlphaFormat = Win32.AC_SRC_ALPHA;
                blendFunc.BlendFlags = 0;

                Win32.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, Win32.ULW_ALPHA);
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBits);
                    Win32.DeleteObject(hBitmap);
                }
                Win32.ReleaseDC(IntPtr.Zero, screenDC);
                Win32.DeleteDC(memDc);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cParms;
            }
        }
        #endregion

        #region 实现方法与计时器事件
        /// <summary>
        /// 是否正在射击
        /// </summary>
        bool isSorting = false;
        int hdc = 0;
        private void timCs_Tick(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder(512);
            GetWindowText(GetForegroundWindow(), s, s.Capacity);
            if (s.ToString() == "CrossFire")
            {
                //如果正在射击，就不去检测。
                if (isSorting){return;}
                for (int x = 365; x < 400; x++)
                {
                    //获取某点坐标的颜色。。
                    int c = GetPixel(hdc, x, 350);
                    //如果颜色值C 是-1 ，那么HD错误，重新获取hdc。
                    if (c == -1)
                    {
                        hdc = getHDC(x, 350);
                        return;
                    }
                    //是否是红色
                    if (isRed(c))
                    {
                        //开始射击
                        isSorting = true;
                        MouseClicks();
                        Thread.Sleep(100);
                        MouseClicks();
                        Thread.Sleep(100);
                        MouseClicks();
                        Thread.Sleep(100);
                        isSorting = false;
                        return;
                    }
                }

                //使窗体局中
                Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);
                WG = ScreenArea.Width;
                HG = ScreenArea.Height;
                this.Left = (WG - this.Width) / 2;
                this.Top = (HG - this.Height) / 2;
                this.TopMost = true;
            }
        }

        //执行一次左键点击
        public void MouseClicks()
        {
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }

        /// <summary>
        /// 获取HDC
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int getHDC(int x, int y)
        {
            int h = WindowFromPoint(x, y);
            int HDC = GetDC(h);//5+1+a+s+p+x
            ScreenToClient(h, ref P);
            return HDC;
        }

        /// <summary>
        /// 这个颜色C，是否是红色。
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool isRed(int c)
        {
            try
            {
                int red = c % 256;
                int green = (c / 256) % 256;
                int blue = c / 256 / 256;
                if (red > 140 && green < 70 && blue < 70)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
            }
            return false;
        }
        #endregion

        #region 调用系统dll方法
        //获取活动窗体名称
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        public static extern int GetWindowText(IntPtr hwnd, StringBuilder lpString, int cch);

        [DllImport("user32.dll")]
        private static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int GetDC(int hwnd);
        [DllImport("gdi32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int GetPixel(int hdc, int X, int y);
        private struct POINTAPI //确定坐标
        {
            private int X;
            private int y;
        }
        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }
        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)] //确定坐标
        private static extern int ReleaseDC(int hwnd, int hdc);
        POINTAPI P; //确定坐标

        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int ScreenToClient(int hwnd, ref POINTAPI lpPoint);
        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int WindowFromPoint(int xPoint, int yPoint);
        #endregion
    }
}
