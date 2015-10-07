namespace Timer
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "秘术师"}, -1, System.Drawing.Color.Blue, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "野蛮人"}, -1, System.Drawing.Color.Red, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "圣教军"}, -1, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "巫医"}, -1, System.Drawing.Color.BlueViolet, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "武僧"}, -1, System.Drawing.Color.Yellow, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "恶魔猎人"}, -1, System.Drawing.Color.DarkGreen, System.Drawing.Color.Empty, null);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnReset = new System.Windows.Forms.Button();
            this.MnuRBC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labUserInput = new System.Windows.Forms.Label();
            this.txtHotKey = new System.Windows.Forms.TextBox();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.timPRG = new System.Windows.Forms.Timer(this.components);
            this.lstChar = new System.Windows.Forms.ListView();
            this.btnCilckThrough = new System.Windows.Forms.Button();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.秘术师ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prgBack = new System.Windows.Forms.Label();
            this.prgFront = new System.Windows.Forms.Label();
            this.MnuRBC.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Violet;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(145, 28);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(55, 30);
            this.btnReset.TabIndex = 2;
            this.btnReset.TabStop = false;
            this.btnReset.Text = "Reset";
            this.btnReset.UseMnemonic = false;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // MnuRBC
            // 
            this.MnuRBC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.topToolStripMenuItem,
            this.transparentToolStripMenuItem,
            this.toolStripMenuItem2,
            this.秘术师ToolStripMenuItem});
            this.MnuRBC.Name = "MnuRBC";
            this.MnuRBC.Size = new System.Drawing.Size(147, 98);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.CheckOnClick = true;
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.topToolStripMenuItem.Text = "Stay Top";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.topToolStripMenuItem_Click);
            // 
            // transparentToolStripMenuItem
            // 
            this.transparentToolStripMenuItem.Name = "transparentToolStripMenuItem";
            this.transparentToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.transparentToolStripMenuItem.Text = "Transparent";
            this.transparentToolStripMenuItem.Visible = false;
            this.transparentToolStripMenuItem.Click += new System.EventHandler(this.transparentToolStripMenuItem_Click);
            // 
            // labUserInput
            // 
            this.labUserInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labUserInput.BackColor = System.Drawing.Color.Transparent;
            this.labUserInput.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labUserInput.Location = new System.Drawing.Point(69, 0);
            this.labUserInput.Name = "labUserInput";
            this.labUserInput.Size = new System.Drawing.Size(67, 25);
            this.labUserInput.TabIndex = 3;
            this.labUserInput.Text = "lab";
            this.labUserInput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labUserInput.UseMnemonic = false;
            //this.labUserInput.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labUserInput_MouseDoubleClick);
            // 
            // txtHotKey
            // 
            this.txtHotKey.Location = new System.Drawing.Point(105, 28);
            this.txtHotKey.Name = "txtHotKey";
            this.txtHotKey.ReadOnly = true;
            this.txtHotKey.Size = new System.Drawing.Size(34, 21);
            this.txtHotKey.TabIndex = 19;
            this.txtHotKey.Text = "F11";
            this.txtHotKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotKey_KeyDown);
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(96, 55);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(43, 19);
            this.btnSaveSetting.TabIndex = 20;
            this.btnSaveSetting.Text = "Save";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // lstChar
            // 
            this.lstChar.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lstChar.AutoArrange = false;
            this.lstChar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lstChar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstChar.CausesValidation = false;
            this.lstChar.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstChar.FullRowSelect = true;
            this.lstChar.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstChar.HideSelection = false;
            this.lstChar.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.lstChar.LabelWrap = false;
            this.lstChar.Location = new System.Drawing.Point(24, 45);
            this.lstChar.Margin = new System.Windows.Forms.Padding(0);
            this.lstChar.MultiSelect = false;
            this.lstChar.Name = "lstChar";
            this.lstChar.Scrollable = false;
            this.lstChar.ShowGroups = false;
            this.lstChar.ShowItemToolTips = true;
            this.lstChar.Size = new System.Drawing.Size(56, 132);
            this.lstChar.TabIndex = 24;
            this.lstChar.TabStop = false;
            this.lstChar.UseCompatibleStateImageBehavior = false;
            this.lstChar.View = System.Windows.Forms.View.List;
            this.lstChar.SelectedIndexChanged += new System.EventHandler(this.lstChar_SelectedIndexChanged);
            // 
            // btnCilckThrough
            // 
            this.btnCilckThrough.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCilckThrough.FlatAppearance.BorderSize = 0;
            this.btnCilckThrough.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Violet;
            this.btnCilckThrough.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCilckThrough.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCilckThrough.Location = new System.Drawing.Point(145, 64);
            this.btnCilckThrough.Name = "btnCilckThrough";
            this.btnCilckThrough.Size = new System.Drawing.Size(55, 28);
            this.btnCilckThrough.TabIndex = 25;
            this.btnCilckThrough.TabStop = false;
            this.btnCilckThrough.Text = "穿越";
            this.btnCilckThrough.UseMnemonic = false;
            this.btnCilckThrough.UseVisualStyleBackColor = false;
            this.btnCilckThrough.Click += new System.EventHandler(this.btnCilckThrough_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(143, 6);
            // 
            // 秘术师ToolStripMenuItem
            // 
            this.秘术师ToolStripMenuItem.Name = "秘术师ToolStripMenuItem";
            this.秘术师ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.秘术师ToolStripMenuItem.Text = "秘术师";
            // 
            // prgBack
            // 
            this.prgBack.BackColor = System.Drawing.Color.LightGray;
            this.prgBack.Location = new System.Drawing.Point(0, 0);
            this.prgBack.Name = "prgBack";
            this.prgBack.Size = new System.Drawing.Size(200, 25);
            this.prgBack.TabIndex = 26;
            // 
            // prgFront
            // 
            this.prgFront.BackColor = System.Drawing.Color.Blue;
            this.prgFront.Location = new System.Drawing.Point(0, 0);
            this.prgFront.Name = "prgFront";
            this.prgFront.Size = new System.Drawing.Size(200, 25);
            this.prgFront.TabIndex = 27;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(200, 150);
            this.ContextMenuStrip = this.MnuRBC;
            this.ControlBox = false;
            this.Controls.Add(this.labUserInput);
            this.Controls.Add(this.prgFront);
            this.Controls.Add(this.prgBack);
            this.Controls.Add(this.btnCilckThrough);
            this.Controls.Add(this.lstChar);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.txtHotKey);
            this.Controls.Add(this.btnReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "全能法戒计时";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ffrmmousedown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ffrmmousemove);
            this.MnuRBC.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ContextMenuStrip MnuRBC;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topToolStripMenuItem;
        private System.Windows.Forms.Label labUserInput;
        private System.Windows.Forms.ToolStripMenuItem transparentToolStripMenuItem;
        private System.Windows.Forms.TextBox txtHotKey;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.Timer timPRG;
        private System.Windows.Forms.ListView lstChar;
        private System.Windows.Forms.Button btnCilckThrough;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 秘术师ToolStripMenuItem;
        private System.Windows.Forms.Label prgBack;
        private System.Windows.Forms.Label prgFront;
    }
}

