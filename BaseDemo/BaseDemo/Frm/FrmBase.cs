using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseDemo.Frm;
using BaseDemo.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace BaseDemo {

    public partial class FrmBase : WeifenLuo.WinFormsUI.Docking.DockContent {

        #region 属性

        /// <summary>
        /// 登录用户
        /// </summary>
        protected string AdminName {
            get => tsclblLoginUser.Text;
            set => tsclblLoginUser.Text = value;
        }

        /// <summary>
        /// DockImage配置文件路径
        /// </summary>
        private string _dockPanelConfigPath = Directory.GetCurrentDirectory() + "\\Files\\DockPanel";

        private readonly string _dockPanelConfigFileName = "\\DockPanel.config";

        /// <summary>
        /// 委托函数
        /// </summary>
        private DeserializeDockContent m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);

        /// <summary>
        /// 窗体对象
        /// </summary>
        private static readonly FrmLeft FrmLeft = new FrmLeft();

        private static readonly FrmMain FrmMain = new FrmMain();

        private static readonly FrmOutput FrmOutput = new FrmOutput();

        private static readonly FrmTest FrmTest = new FrmTest();

        #endregion 属性

        #region 构造函数

        public FrmBase() {
            if (!DesignMode) {
                //窗体屏幕居中
                this.StartPosition = FormStartPosition.CenterScreen;
                InitializeComponent();

                ToMaximizeForm();
                TraverseButton();
                RefreshTime();
                FrmLoadOptimization();
            }
        }

        #endregion 构造函数

        #region 窗体移动

        private bool beginMove = false; //初始化鼠标位置
        private int currentXPosition;
        private int currentYPosition;

        protected void FrmBase_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                beginMove = true;
                currentXPosition = MousePosition.X; //鼠标的x坐标为当前窗体左上角x坐标
                currentYPosition = MousePosition.Y; //鼠标的y坐标为当前窗体左上角y坐标
            }
        }

        protected void FrmBase_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                currentXPosition = 0; //设置初始状态
                currentYPosition = 0;
                beginMove = false;
            }
        }

        protected void FrmBase_MouseMove(object sender, MouseEventArgs e) {
            if (beginMove) {
                this.Left += MousePosition.X - currentXPosition; //根据鼠标x坐标确定窗体的左边坐标x
                this.Top += MousePosition.Y - currentYPosition; //根据鼠标的y坐标窗体的顶部，即Y坐标
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }

        #endregion 窗体移动

        #region 窗体优化

        /// <summary>
        /// 窗体优化
        /// </summary>
        private void FrmLoadOptimization() {
            //缓解窗体加载卡顿
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        protected override CreateParams CreateParams //防止改变窗口大小时控件闪烁
        {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #endregion 窗体优化

        #region 窗体UI

        /// <summary>
        /// 窗体最大化
        /// </summary>
        protected void ToMaximizeForm() {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        /// <summary>
        /// 按钮无边框
        /// </summary>
        protected void TraverseButton() {
            //按钮无边框
            foreach (Control tmp in this.Controls) {
                if (tmp is Button btn) {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                }
            }
        }

        /// <summary>
        /// 时间刷新
        /// </summary>
        protected void RefreshTime() {
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            stclblNowTime.Text = DateTime.Now.ToLocalTime().ToString();
        }

        #endregion 窗体UI

        #region 窗体关闭

        private void FrmBase_FormClosing(object sender, FormClosingEventArgs e) {
            if (!Directory.Exists(_dockPanelConfigPath)) {
                try {
                    Directory.CreateDirectory(_dockPanelConfigPath);
                } catch (Exception ex) {
                }
            }
            dockPanel1.SaveAsXml(_dockPanelConfigPath + _dockPanelConfigFileName);
        }

        #endregion 窗体关闭

        #region 窗体加载

        private void FrmBase_Load(object sender, EventArgs e) {
            if (File.Exists(_dockPanelConfigPath + _dockPanelConfigFileName))
                dockPanel1.LoadFromXml(_dockPanelConfigPath + _dockPanelConfigFileName, m_deserializeDockContent);
        }

        /// <summary>
        /// 配置委托函数
        /// </summary>
        /// <param name="persistString"></param>
        /// <returns></returns>
        private static IDockContent GetContentFromPersistString(string persistString) {
            if (persistString == typeof(FrmLeft).ToString()) {
                return FrmLeft;
            } else if (persistString == typeof(FrmMain).ToString()) {
                return FrmMain;
            } else if (persistString == typeof(FrmOutput).ToString()) {
                return FrmOutput;
            } else if (persistString == typeof(FrmTest).ToString()) {
                return FrmTest;
            } else {
                return null;
            }
        }

        private void 菜单栏ToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmLeft.Show(this.dockPanel1, DockState.DockLeft);
        }

        private void 主窗体ToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmMain.Show(this.dockPanel1, DockState.Document);
        }

        private void 输出ToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmOutput.Show(this.dockPanel1, DockState.DockBottom);
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmTest.Show(this.dockPanel1);
        }

        #endregion 窗体加载
    }
}