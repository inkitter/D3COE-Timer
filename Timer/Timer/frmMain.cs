using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
//using System.Linq;
//using System.ComponentModel;
//using System.Data;
//using System.Threading.Tasks;

namespace Timer
{
    public partial class frmMain : Form
    {
        public class HotKeys
        {
            Dictionary<int, HotKeyCallBackHanlder> keymap = new Dictionary<int, HotKeyCallBackHanlder>();
            public delegate void HotKeyCallBackHanlder();
            public enum HotkeyModifiers
            {
                Alt = 1,
                Control = 2,
                Shift = 4,
                Win = 8
            }

            public void ProcessHotKey(Message m)
            {
                if (m.Msg == 0x312)
                {
                    int id = m.WParam.ToInt32();
                    HotKeyCallBackHanlder callback;
                    if (keymap.TryGetValue(id, out callback))
                        callback();
                }
            }
        }//全局快捷键类
        public class IniFile
        {
            private string FFileName;
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault,
            StringBuilder lpReturnedString, int nSize, string lpFileName);
            [DllImport("kernel32")]
            private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
            public IniFile(string filename) { FFileName = filename; }
            public int ReadInt(string section, string key, int def)
            { return GetPrivateProfileInt(section, key, def, FFileName); }
            public string ReadString(string section, string key, string def)
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(section, key, def, temp, 1024, FFileName); return temp.ToString();
            }
            public void WriteInt(string section, string key, int iVal)
            { WritePrivateProfileString(section, key, iVal.ToString(), FFileName); }
            public void WriteString(string section, string key, string strVal)
            { WritePrivateProfileString(section, key, strVal, FFileName); }
            public void DelKey(string section, string key)
            { WritePrivateProfileString(section, key, null, FFileName); }
            public void DelSection(string section)
            { WritePrivateProfileString(section, null, null, FFileName); }
        }//ini文件类

        public enum GWL { ExStyle = -20 }
        public enum WS_EX { Transparent = 0x20, Layered = 0x80000 }
        public enum LWA { ColorKey = 0x1, Alpha = 0x2 }
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);
        [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LWA dwFlags);        //点击穿越

        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
        [DllImport("user32.dll")]
        static extern bool RegisterHotKey(IntPtr hWnd, int id, int modifiers, Keys vk);
        [DllImport("user32.dll")]
        static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        //winAPI声明
        //HotKeys h = new HotKeys();
        //const int WM_KEYDOWN = 0x0100;
        //const int WM_KEYUP = 0x0101;
        //const int WM_CHAR = 0x0102;
        //[DllImport("user32.dll", EntryPoint = "FindWindow")]
        //private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //[DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        //private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        //[DllImport("user32.dll", EntryPoint = "PostMessage")]
        //private static extern int PostMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);
        //[DllImport("user32.dll", EntryPoint = "SendMessage")]
        //private static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);
        //[DllImport("user32.dll", EntryPoint = "WindowFromPoint")]
        //private static extern IntPtr WindowFromPoint(int px, int py);


        delegate void SetTextCallback(string text);
        private Point offset;
        private Thread tPRG=null;
        static int iCOEi = 0; //序列索引号
        static int iCOEmax = 3;
        //static int iHotkeyi = 202;
        static int[] iCOEc = new int[] { 0, 1, 2, 4, 5 }; //0=奥术 1=冰霜 2=火焰 3=神圣 4=闪电 5=物理 6=毒性
        //static Boolean bShowBtn=true;
        static int iTime,iTimeCount;
        IniFile finiset = new IniFile(".\\D3COE.ini");
        static int keyid = 202;
        //变量声明

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            iniread();
            sReset();
            Keys key = (Keys)Enum.Parse(typeof(Keys), txtHotKey.Text);
            fhotkeyChange();
            tPRG = new Thread(new ThreadStart(tPRGsub));
            tPRG.Start();
            prgBack.Parent = this;
            prgFront.Parent = prgBack;
            labUserInput.Parent = prgFront;
        }//窗口载入

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (iCOEi >= iCOEmax) { iCOEi = 0; } else { iCOEi = iCOEi + 1; }
            sReset();
        }        //重置按钮

        private void sReset()
        {
            prgFront.Left = 0;
            iTime = System.Environment.TickCount;
            iTimeCount = 1;
            sCOElab();
        }

        private void tPRGsub() //标签与进度条线程
        {
            if (prgFront.InvokeRequired)
            {
                DoDataDelegate d = tPRGsub;
                prgFront.Invoke(d);
            }
            else
            {
                while (1 == 1)
                {
                    if (System.Environment.TickCount - iTime < 4000 * iTimeCount)
                    {
                        prgFront.Left = prgFront.Left - 2;
                        Thread.Sleep(40);
                    }
                    else
                    {
                        sCOElab();  //推送到label显示系别
                        prgFront.Left = 0;
                        iTimeCount = iTimeCount + 1;
                        if (iCOEi > iCOEmax) { iCOEi = 0; } else { iCOEi++; }
                    }
                    Application.DoEvents();
                }
            }
        }
        private delegate void DoDataDelegate();

        private void lstChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //0=奥术 1=冰霜 2=火焰 3=神圣 4=闪电 5=物理 6=毒性
            try
            {
                switch (lstChar.SelectedItems[0].Text)
                {
                    case "秘术师":
                        iCOEc = new int[] { 0, 1, 2, 4 };
                        iCOEmax = 3;
                        break;
                    case "野蛮人":
                        iCOEc = new int[] { 1, 2, 4, 5 };
                        iCOEmax = 3;
                        break;
                    case "圣教军":
                        iCOEc = new int[] { 2, 3, 4, 5 };
                        iCOEmax = 3;
                        break;
                    case "巫医":
                        iCOEc = new int[] { 1, 2, 5, 6 };
                        iCOEmax = 3;
                        break;
                    case "武僧":
                        iCOEc = new int[] { 1, 2, 3, 4, 5 };
                        iCOEmax = 4;
                        break;
                    case "恶魔猎人":
                        iCOEc = new int[] { 1, 2, 4, 5};
                        iCOEmax = 3;
                        break;
                }
                iCOEi = 0;
                sReset();
            }
            catch { return; }
        }//listview切换职业循环
        private void sCOElab()
        {
            string labText="";
            Color fcolor= System.Drawing.Color.Purple, bcolor= System.Drawing.Color.DeepSkyBlue;
            switch (iCOEc[iCOEi])
            {
                case 0:
                    labText = "奥术";
                    fcolor=System.Drawing.Color.Purple;
                    break;
                case 1:
                    labText = "冰霜";
                    fcolor = System.Drawing.Color.DeepSkyBlue;
                    break;
                case 2:
                    labText = "火焰";
                    fcolor = System.Drawing.Color.Red;
                    break;
                case 3:
                    labText = "神圣";
                    fcolor = System.Drawing.Color.Yellow;
                    break;
                case 4:
                    labText = "闪电";
                    fcolor = System.Drawing.Color.White;
                    break;
                case 5:
                    labText = "物理";
                    fcolor = System.Drawing.Color.Gray;
                    break;
                case 6:
                    labText = "毒性";
                    fcolor = System.Drawing.Color.Green;
                    break;
            }
            int colindex = 0;        
            if (iCOEi < iCOEmax) { colindex = iCOEc[iCOEi + 1]; } else { colindex = iCOEc[0]; }
            switch (colindex)
            {
                case 7:
                case 0:
                    bcolor = System.Drawing.Color.Purple;
                    break;
                case 1:
                    bcolor = System.Drawing.Color.DeepSkyBlue;
                    break;
                case 2:
                    bcolor = System.Drawing.Color.Red;
                    break;
                case 3:
                    bcolor = System.Drawing.Color.Yellow;
                    break;
                case 4:
                    bcolor = System.Drawing.Color.White;
                    break;
                case 5:
                    bcolor = System.Drawing.Color.Gray;
                    break;
                case 6:
                    bcolor = System.Drawing.Color.Green;
                    break;
            }
            sSetColorSound(labText, fcolor, bcolor);
        }//设定颜色、声音
        private void sSetColorSound(string COEtype, Color prgFrontColor, Color prgBackColor)
        {
            labUserInput.Text = COEtype;
            fPlaySound(COEtype);
            labUserInput.ForeColor = prgBackColor;
            prgFront.BackColor = prgFrontColor;
            prgBack.BackColor = prgBackColor;
        }//设定颜色、声音过程
        private void fPlaySound(string playtype)     //声音播放
        {
            try
            {
                System.Media.SoundPlayer play = new System.Media.SoundPlayer();
                play.SoundLocation = Directory.GetCurrentDirectory() + "/" + playtype + ".wav";
                play.Load();
                play.Play();
                play.Dispose();
            }
            catch
            {
                //labError.Text = "Error";
            }
        }

        private void iniread()
        {
            
            try
            {
                this.Left = finiset.ReadInt("Main", "X", 1);
                this.Top = finiset.ReadInt("Main", "Y", 1);
                txtHotKey.Text = finiset.ReadString("KeyPress", "HotKey", null);
                if (txtHotKey.Text == "") { txtHotKey.Text = "F11"; }
                lstChar.Items[finiset.ReadInt("Char", "Char", 1)].Selected=true;
            }
            catch
            {
                //labError.Text = "Error";
            }
        }        //读取ini文件
        private void iniwrite()
        {
            try
            {
                finiset.WriteString("KeyPress", "HotKey", txtHotKey.Text);
                finiset.WriteInt("Main", "X", this.Left);
                finiset.WriteInt("Main", "Y", this.Top);
                finiset.WriteInt("Char", "Char", lstChar.SelectedItems[0].Index);
            }
            catch
            {
                //labError.Text = "Error";
            }
        }        //保存ini文件
        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            iniwrite();
        } //保存按钮

        protected override void WndProc(ref Message m)//监视Windows快捷键消息
        {
            const int WM_HOTKEY = 0x0312;//按快捷键
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    if (m.WParam.ToInt32()== keyid) { btnReset_Click(null, null); }
                    if (m.WParam.ToInt32() == keyid + 1) { btnCilckThrough_Click(null, null); return; }
                    break;
            }
            base.WndProc(ref m);
        }
        private void txtHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            txtHotKey.Text = e.KeyData.ToString();
            fhotkeyChange();
        }//快捷键txt改变
        private void fhotkeyChange() //快捷键过程
        {
            txtHotKey.BackColor = Color.Silver;
            Keys key = (Keys)Enum.Parse(typeof(Keys), txtHotKey.Text);
            try
            {
                UnregisterHotKey(Handle, keyid);
            }
            catch
            {

            }

            for (int i=0; i < 213; i++)
            {
                try
                {
                    if (txtHotKey.Text != "Escape")
                    {
                        RegisterHotKey(Handle, i, 0, key);
                        RegisterHotKey(Handle, i + 1, 2, key);
                    }
                }
                catch
                {
                    txtHotKey.BackColor = Color.Red;
                }
                finally
                {
                    keyid = i;
                    i = 221;
                }
            }
        }

        private void ffrmmousedown(object sender, MouseEventArgs e)  //点击任意位置移动窗体
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }
        private void ffrmmousemove(object sender, MouseEventArgs e)   //点击任意位置移动窗体
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }
        private void btnCilckThrough_Click(object sender, EventArgs e) //点击穿越与恢复
        {
            if (this.Height == 25)
            {
                this.Height = 150;
                base.OnShown(e);
                int wl = GetWindowLong(this.Handle, GWL.ExStyle);
                wl = wl | 0x80000 | 0x20;
                SetWindowLong(this.Handle, GWL.ExStyle, wl);
                SetLayeredWindowAttributes(this.Handle, 0, 128, LWA.Alpha);
                this.Opacity = 0.8;
                this.Opacity = 1;
                this.TopMost = false;
            }
            else
            {
                base.OnShown(e);
                int wl = GetWindowLong(this.Handle, GWL.ExStyle);
                wl = wl | 0x80000 | 0x20;
                SetWindowLong(this.Handle, GWL.ExStyle, wl);
                SetLayeredWindowAttributes(this.Handle, 0, 128, LWA.Alpha);
                this.Height = 25;
                this.TopMost = true;
                //this.Opacity = 0.8;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sFormClose();
        }        //下拉菜单-Exit
        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (topToolStripMenuItem.Checked == true) { 
                this.TopMost = true; 
                //this.Opacity = 0.6;
                transparentToolStripMenuItem.Visible = true;
                transparentToolStripMenuItem.Checked = false;
            }
            else { 
                this.TopMost = false; 
                this.Opacity = 1;
                transparentToolStripMenuItem.Visible = false;
                transparentToolStripMenuItem.Checked = false;
            }
        }        //下拉菜单-置顶
        private void transparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (transparentToolStripMenuItem.Checked == true){
                transparentToolStripMenuItem.Checked = false;
            }
            else
            {
                transparentToolStripMenuItem.Checked = true;
            }
            if (transparentToolStripMenuItem.Checked==true){
                this.Opacity = 0.6;
            }
            else{
                this.Opacity=1;
            }
        }//下拉菜单-透明度


        private void sFormClose()
        {
            Application.Exit();
            Environment.Exit(0);
            try
            {
                UnregisterHotKey(Handle, keyid);
            }
            catch
            {

            }
        }//退出与清理

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            sFormClose();
        }  //关闭清理

        private void labUserInput_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Height == 150) { this.Height = 25; }
            else { this.Height = 150; }
        }
    }
}
