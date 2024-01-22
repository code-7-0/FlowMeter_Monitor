namespace FlowMeter_Monitor
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barRun = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barLargeButtonItem7 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barComCfg = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barSetting = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barCalibration = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDebug = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barCollect = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barExport = new DevExpress.XtraBars.BarLargeButtonItem();
            this.skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barStop = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.lblFlowFb = new System.Windows.Forms.Label();
            this.lbConcCh02 = new System.Windows.Forms.Label();
            this.lblFlowSet = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusFWVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusDevTemp = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusCom = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusCollectnum = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnWkmodeClean = new CCWin.SkinControl.SkinButton();
            this.btnWkmodeClose = new CCWin.SkinControl.SkinButton();
            this.btnWkmodeAuto = new CCWin.SkinControl.SkinButton();
            this.picWMAuto = new System.Windows.Forms.PictureBox();
            this.picWMClose = new System.Windows.Forms.PictureBox();
            this.picWMClean = new System.Windows.Forms.PictureBox();
            this.lblWMAuto = new System.Windows.Forms.Label();
            this.lblWMClose = new System.Windows.Forms.Label();
            this.lblWMClean = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFlowUnit = new System.Windows.Forms.Label();
            this.lblFlowRange = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMfcType = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblOutPutType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCtrlSource = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFlowSet = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFlowSetPC = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDevAddr = new System.Windows.Forms.TextBox();
            this.btnDevAddrSet = new CCWin.SkinControl.SkinButton();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWMAuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWMClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWMClean)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barRun,
            this.barStop,
            this.barComCfg,
            this.barSetting,
            this.skinDropDownButtonItem1,
            this.barCalibration,
            this.barDebug,
            this.barLargeButtonItem7,
            this.barButtonItem1,
            this.barExport,
            this.barCollect});
            this.barManager1.MaxItemId = 22;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 3";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barRun, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barLargeButtonItem7, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barComCfg, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSetting, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barCalibration, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barDebug, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barCollect, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.skinDropDownButtonItem1)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 3";
            // 
            // barRun
            // 
            this.barRun.Caption = "   启动   ";
            this.barRun.Id = 0;
            this.barRun.ImageOptions.Image = global::FlowMeter_Monitor.Properties.Resources.play_32x32;
            this.barRun.Name = "barRun";
            this.barRun.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barRun_ItemClick);
            // 
            // barLargeButtonItem7
            // 
            this.barLargeButtonItem7.Caption = "   停止   ";
            this.barLargeButtonItem7.Id = 13;
            this.barLargeButtonItem7.ImageOptions.Image = global::FlowMeter_Monitor.Properties.Resources.stop_32x32;
            this.barLargeButtonItem7.Name = "barLargeButtonItem7";
            this.barLargeButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barStop_ItemClick);
            // 
            // barComCfg
            // 
            this.barComCfg.Caption = "   通讯   ";
            this.barComCfg.Id = 2;
            this.barComCfg.ImageOptions.Image = global::FlowMeter_Monitor.Properties.Resources.bocontact_32x32;
            this.barComCfg.Name = "barComCfg";
            this.barComCfg.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barComCfg_ItemClick);
            // 
            // barSetting
            // 
            this.barSetting.Caption = "   参数   ";
            this.barSetting.Id = 3;
            this.barSetting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSetting.ImageOptions.Image")));
            this.barSetting.Name = "barSetting";
            this.barSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSetting_ItemClick);
            // 
            // barCalibration
            // 
            this.barCalibration.Caption = "   校准   ";
            this.barCalibration.Id = 5;
            this.barCalibration.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barCalibration.ImageOptions.Image")));
            this.barCalibration.Name = "barCalibration";
            this.barCalibration.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCalibration_ItemClick);
            // 
            // barDebug
            // 
            this.barDebug.Caption = "   数据   ";
            this.barDebug.Id = 6;
            this.barDebug.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barDebug.ImageOptions.Image")));
            this.barDebug.Name = "barDebug";
            this.barDebug.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDebug_ItemClick);
            // 
            // barCollect
            // 
            this.barCollect.Caption = "流量采集";
            this.barCollect.Id = 17;
            this.barCollect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barCollect.ImageOptions.Image")));
            this.barCollect.Name = "barCollect";
            this.barCollect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCollect_ItemClick);
            // 
            // barExport
            // 
            this.barExport.Caption = "导出/停止";
            this.barExport.Id = 15;
            this.barExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barExport.ImageOptions.Image")));
            this.barExport.Name = "barExport";
            this.barExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barExport_ItemClick);
            // 
            // skinDropDownButtonItem1
            // 
            this.skinDropDownButtonItem1.Id = 4;
            this.skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1010, 80);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 721);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1010, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 80);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 641);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1010, 80);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 641);
            // 
            // barStop
            // 
            this.barStop.Caption = "  停止  ";
            this.barStop.Id = 1;
            this.barStop.ImageOptions.Image = global::FlowMeter_Monitor.Properties.Resources.stop_32x32;
            this.barStop.Name = "barStop";
            this.barStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barStop_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 20;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // lblFlowFb
            // 
            this.lblFlowFb.Font = new System.Drawing.Font("Stencil", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlowFb.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblFlowFb.Location = new System.Drawing.Point(231, 24);
            this.lblFlowFb.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFlowFb.Name = "lblFlowFb";
            this.lblFlowFb.Size = new System.Drawing.Size(247, 85);
            this.lblFlowFb.TabIndex = 51;
            this.lblFlowFb.Text = "888.8";
            this.lblFlowFb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbConcCh02
            // 
            this.lbConcCh02.AutoSize = true;
            this.lbConcCh02.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbConcCh02.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbConcCh02.Location = new System.Drawing.Point(119, 127);
            this.lbConcCh02.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbConcCh02.Name = "lbConcCh02";
            this.lbConcCh02.Size = new System.Drawing.Size(121, 29);
            this.lbConcCh02.TabIndex = 46;
            this.lbConcCh02.Text = "设定流量:";
            this.lbConcCh02.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFlowSet
            // 
            this.lblFlowSet.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlowSet.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblFlowSet.Location = new System.Drawing.Point(243, 117);
            this.lblFlowSet.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFlowSet.Name = "lblFlowSet";
            this.lblFlowSet.Size = new System.Drawing.Size(213, 49);
            this.lblFlowSet.TabIndex = 52;
            this.lblFlowSet.Text = "888.8";
            this.lblFlowSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("华文中宋", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(123, 54);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(116, 27);
            this.label17.TabIndex = 50;
            this.label17.Text = "实测流量:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusFWVersion,
            this.statusDevTemp,
            this.statusCom,
            this.statusCollectnum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 681);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1010, 40);
            this.statusStrip1.TabIndex = 66;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusFWVersion
            // 
            this.statusFWVersion.AutoSize = false;
            this.statusFWVersion.BackColor = System.Drawing.Color.Transparent;
            this.statusFWVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusFWVersion.ForeColor = System.Drawing.Color.Black;
            this.statusFWVersion.Name = "statusFWVersion";
            this.statusFWVersion.Size = new System.Drawing.Size(200, 35);
            this.statusFWVersion.Text = "固件版本：";
            this.statusFWVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusDevTemp
            // 
            this.statusDevTemp.AutoSize = false;
            this.statusDevTemp.BackColor = System.Drawing.Color.Transparent;
            this.statusDevTemp.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusDevTemp.ForeColor = System.Drawing.Color.Black;
            this.statusDevTemp.Name = "statusDevTemp";
            this.statusDevTemp.Size = new System.Drawing.Size(200, 35);
            this.statusDevTemp.Text = "温度：";
            this.statusDevTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusCom
            // 
            this.statusCom.AutoSize = false;
            this.statusCom.BackColor = System.Drawing.Color.Transparent;
            this.statusCom.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusCom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.statusCom.ForeColor = System.Drawing.Color.Black;
            this.statusCom.Image = global::FlowMeter_Monitor.Properties.Resources.LedGreen;
            this.statusCom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusCom.Name = "statusCom";
            this.statusCom.Size = new System.Drawing.Size(264, 35);
            this.statusCom.Text = "statusCom";
            this.statusCom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusCom.DoubleClick += new System.EventHandler(this.statusCom_DoubleClick);
            // 
            // statusCollectnum
            // 
            this.statusCollectnum.AutoSize = false;
            this.statusCollectnum.BackColor = System.Drawing.Color.Transparent;
            this.statusCom.ForeColor = System.Drawing.Color.Black;
            this.statusCollectnum.Name = "statusCollectnum";
            this.statusCollectnum.Size = new System.Drawing.Size(200, 35);
            this.statusCollectnum.Text = "流量采集条数：";
            this.statusCollectnum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnWkmodeClean
            // 
            this.btnWkmodeClean.BackColor = System.Drawing.Color.Transparent;
            this.btnWkmodeClean.BaseColor = System.Drawing.Color.Black;
            this.btnWkmodeClean.BorderColor = System.Drawing.Color.Silver;
            this.btnWkmodeClean.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnWkmodeClean.DownBack = null;
            this.btnWkmodeClean.Font = new System.Drawing.Font("方正姚体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWkmodeClean.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnWkmodeClean.Location = new System.Drawing.Point(176, 192);
            this.btnWkmodeClean.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWkmodeClean.MouseBack = null;
            this.btnWkmodeClean.Name = "btnWkmodeClean";
            this.btnWkmodeClean.NormlBack = null;
            this.btnWkmodeClean.Radius = 30;
            this.btnWkmodeClean.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnWkmodeClean.Size = new System.Drawing.Size(82, 51);
            this.btnWkmodeClean.TabIndex = 83;
            this.btnWkmodeClean.Text = "清洗";
            this.btnWkmodeClean.UseVisualStyleBackColor = false;
            this.btnWkmodeClean.Click += new System.EventHandler(this.btnWkmodeClean_Click);
            // 
            // btnWkmodeClose
            // 
            this.btnWkmodeClose.BackColor = System.Drawing.Color.Transparent;
            this.btnWkmodeClose.BaseColor = System.Drawing.Color.Black;
            this.btnWkmodeClose.BorderColor = System.Drawing.Color.Silver;
            this.btnWkmodeClose.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnWkmodeClose.DownBack = null;
            this.btnWkmodeClose.Font = new System.Drawing.Font("方正姚体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWkmodeClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnWkmodeClose.Location = new System.Drawing.Point(323, 192);
            this.btnWkmodeClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWkmodeClose.MouseBack = null;
            this.btnWkmodeClose.Name = "btnWkmodeClose";
            this.btnWkmodeClose.NormlBack = null;
            this.btnWkmodeClose.Radius = 30;
            this.btnWkmodeClose.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnWkmodeClose.Size = new System.Drawing.Size(82, 51);
            this.btnWkmodeClose.TabIndex = 83;
            this.btnWkmodeClose.Text = "关闭";
            this.btnWkmodeClose.UseVisualStyleBackColor = false;
            this.btnWkmodeClose.Click += new System.EventHandler(this.btnWkmodeClose_Click);
            // 
            // btnWkmodeAuto
            // 
            this.btnWkmodeAuto.BackColor = System.Drawing.Color.Transparent;
            this.btnWkmodeAuto.BaseColor = System.Drawing.Color.Black;
            this.btnWkmodeAuto.BorderColor = System.Drawing.Color.Silver;
            this.btnWkmodeAuto.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnWkmodeAuto.DownBack = null;
            this.btnWkmodeAuto.Font = new System.Drawing.Font("方正姚体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWkmodeAuto.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnWkmodeAuto.Location = new System.Drawing.Point(29, 192);
            this.btnWkmodeAuto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWkmodeAuto.MouseBack = null;
            this.btnWkmodeAuto.Name = "btnWkmodeAuto";
            this.btnWkmodeAuto.NormlBack = null;
            this.btnWkmodeAuto.Radius = 30;
            this.btnWkmodeAuto.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnWkmodeAuto.Size = new System.Drawing.Size(82, 51);
            this.btnWkmodeAuto.TabIndex = 83;
            this.btnWkmodeAuto.Text = "阀控";
            this.btnWkmodeAuto.UseVisualStyleBackColor = false;
            this.btnWkmodeAuto.Click += new System.EventHandler(this.btnWkmodeAuto_Click);
            // 
            // picWMAuto
            // 
            this.picWMAuto.Image = global::FlowMeter_Monitor.Properties.Resources.LedRed;
            this.picWMAuto.Location = new System.Drawing.Point(51, 80);
            this.picWMAuto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picWMAuto.Name = "picWMAuto";
            this.picWMAuto.Size = new System.Drawing.Size(37, 41);
            this.picWMAuto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWMAuto.TabIndex = 88;
            this.picWMAuto.TabStop = false;
            // 
            // picWMClose
            // 
            this.picWMClose.Image = global::FlowMeter_Monitor.Properties.Resources.LedRed;
            this.picWMClose.Location = new System.Drawing.Point(346, 80);
            this.picWMClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picWMClose.Name = "picWMClose";
            this.picWMClose.Size = new System.Drawing.Size(37, 41);
            this.picWMClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWMClose.TabIndex = 88;
            this.picWMClose.TabStop = false;
            // 
            // picWMClean
            // 
            this.picWMClean.Image = global::FlowMeter_Monitor.Properties.Resources.LedRed;
            this.picWMClean.Location = new System.Drawing.Point(199, 80);
            this.picWMClean.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picWMClean.Name = "picWMClean";
            this.picWMClean.Size = new System.Drawing.Size(37, 41);
            this.picWMClean.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWMClean.TabIndex = 88;
            this.picWMClean.TabStop = false;
            // 
            // lblWMAuto
            // 
            this.lblWMAuto.AutoSize = true;
            this.lblWMAuto.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWMAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWMAuto.Location = new System.Drawing.Point(41, 125);
            this.lblWMAuto.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWMAuto.Name = "lblWMAuto";
            this.lblWMAuto.Size = new System.Drawing.Size(63, 29);
            this.lblWMAuto.TabIndex = 89;
            this.lblWMAuto.Text = "阀控";
            // 
            // lblWMClose
            // 
            this.lblWMClose.AutoSize = true;
            this.lblWMClose.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWMClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWMClose.Location = new System.Drawing.Point(336, 125);
            this.lblWMClose.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWMClose.Name = "lblWMClose";
            this.lblWMClose.Size = new System.Drawing.Size(63, 29);
            this.lblWMClose.TabIndex = 90;
            this.lblWMClose.Text = "关闭";
            // 
            // lblWMClean
            // 
            this.lblWMClean.AutoSize = true;
            this.lblWMClean.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWMClean.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWMClean.Location = new System.Drawing.Point(189, 125);
            this.lblWMClean.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWMClean.Name = "lblWMClean";
            this.lblWMClean.Size = new System.Drawing.Size(63, 29);
            this.lblWMClean.TabIndex = 91;
            this.lblWMClean.Text = "清洗";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(119, 279);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 29);
            this.label3.TabIndex = 92;
            this.label3.Text = "流量单位:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFlowUnit
            // 
            this.lblFlowUnit.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlowUnit.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblFlowUnit.Location = new System.Drawing.Point(243, 269);
            this.lblFlowUnit.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFlowUnit.Name = "lblFlowUnit";
            this.lblFlowUnit.Size = new System.Drawing.Size(213, 49);
            this.lblFlowUnit.TabIndex = 93;
            this.lblFlowUnit.Text = "%";
            this.lblFlowUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFlowRange
            // 
            this.lblFlowRange.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlowRange.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblFlowRange.Location = new System.Drawing.Point(243, 193);
            this.lblFlowRange.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFlowRange.Name = "lblFlowRange";
            this.lblFlowRange.Size = new System.Drawing.Size(213, 49);
            this.lblFlowRange.TabIndex = 99;
            this.lblFlowRange.Text = "888.8";
            this.lblFlowRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(119, 203);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 29);
            this.label4.TabIndex = 98;
            this.label4.Text = "流量量程:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMfcType);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblOutPutType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblCtrlSource);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbConcCh02);
            this.groupBox1.Controls.Add(this.lblFlowRange);
            this.groupBox1.Controls.Add(this.lblFlowFb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblFlowSet);
            this.groupBox1.Controls.Add(this.lblFlowUnit);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gray;
            this.groupBox1.Location = new System.Drawing.Point(9, 90);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(494, 581);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "流量&&控制";
            // 
            // lblMfcType
            // 
            this.lblMfcType.Font = new System.Drawing.Font("华文中宋", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMfcType.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblMfcType.Location = new System.Drawing.Point(245, 507);
            this.lblMfcType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMfcType.Name = "lblMfcType";
            this.lblMfcType.Size = new System.Drawing.Size(213, 30);
            this.lblMfcType.TabIndex = 105;
            this.lblMfcType.Text = "0-5V";
            this.lblMfcType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(66, 507);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 29);
            this.label10.TabIndex = 104;
            this.label10.Text = "MFC信号类型:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOutPutType
            // 
            this.lblOutPutType.Font = new System.Drawing.Font("华文中宋", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutPutType.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblOutPutType.Location = new System.Drawing.Point(245, 431);
            this.lblOutPutType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOutPutType.Name = "lblOutPutType";
            this.lblOutPutType.Size = new System.Drawing.Size(213, 30);
            this.lblOutPutType.TabIndex = 103;
            this.lblOutPutType.Text = "0-5V";
            this.lblOutPutType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(27, 431);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 29);
            this.label6.TabIndex = 102;
            this.label6.Text = "输入输出信号类型:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCtrlSource
            // 
            this.lblCtrlSource.Font = new System.Drawing.Font("华文中宋", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCtrlSource.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblCtrlSource.Location = new System.Drawing.Point(243, 355);
            this.lblCtrlSource.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCtrlSource.Name = "lblCtrlSource";
            this.lblCtrlSource.Size = new System.Drawing.Size(213, 30);
            this.lblCtrlSource.TabIndex = 101;
            this.lblCtrlSource.Text = "内设";
            this.lblCtrlSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(119, 355);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 29);
            this.label2.TabIndex = 100;
            this.label2.Text = "控制方式:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFlowSet
            // 
            this.btnFlowSet.BackColor = System.Drawing.Color.Transparent;
            this.btnFlowSet.BaseColor = System.Drawing.Color.Black;
            this.btnFlowSet.BorderColor = System.Drawing.Color.Silver;
            this.btnFlowSet.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnFlowSet.DownBack = null;
            this.btnFlowSet.Font = new System.Drawing.Font("方正姚体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFlowSet.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFlowSet.Location = new System.Drawing.Point(321, 46);
            this.btnFlowSet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFlowSet.MouseBack = null;
            this.btnFlowSet.Name = "btnFlowSet";
            this.btnFlowSet.NormlBack = null;
            this.btnFlowSet.Radius = 4;
            this.btnFlowSet.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnFlowSet.Size = new System.Drawing.Size(82, 42);
            this.btnFlowSet.TabIndex = 105;
            this.btnFlowSet.Text = "设置";
            this.btnFlowSet.UseVisualStyleBackColor = false;
            this.btnFlowSet.Click += new System.EventHandler(this.btnFlowSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(39, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 29);
            this.label1.TabIndex = 103;
            this.label1.Text = "设定流量(PC)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFlowSetPC
            // 
            this.tbFlowSetPC.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFlowSetPC.Location = new System.Drawing.Point(199, 49);
            this.tbFlowSetPC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbFlowSetPC.Name = "tbFlowSetPC";
            this.tbFlowSetPC.Size = new System.Drawing.Size(85, 36);
            this.tbFlowSetPC.TabIndex = 102;
            this.tbFlowSetPC.Text = "0";
            this.tbFlowSetPC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBox_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblWMClean);
            this.groupBox2.Controls.Add(this.lblWMClose);
            this.groupBox2.Controls.Add(this.lblWMAuto);
            this.groupBox2.Controls.Add(this.picWMClean);
            this.groupBox2.Controls.Add(this.picWMClose);
            this.groupBox2.Controls.Add(this.picWMAuto);
            this.groupBox2.Controls.Add(this.btnWkmodeAuto);
            this.groupBox2.Controls.Add(this.btnWkmodeClose);
            this.groupBox2.Controls.Add(this.btnWkmodeClean);
            this.groupBox2.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.Gray;
            this.groupBox2.Location = new System.Drawing.Point(510, 90);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(494, 289);
            this.groupBox2.TabIndex = 105;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工作模式&&控制";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FlowMeter_Monitor.Properties.Resources.Sevenstar;
            this.pictureBox1.Location = new System.Drawing.Point(755, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 110;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbFlowSetPC);
            this.groupBox3.Controls.Add(this.btnFlowSet);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.Gray;
            this.groupBox3.Location = new System.Drawing.Point(510, 382);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(494, 129);
            this.groupBox3.TabIndex = 115;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "流量设定";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tbDevAddr);
            this.groupBox4.Controls.Add(this.btnDevAddrSet);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox4.ForeColor = System.Drawing.Color.Gray;
            this.groupBox4.Location = new System.Drawing.Point(510, 518);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(494, 153);
            this.groupBox4.TabIndex = 116;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "通讯地址";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(15, 112);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(401, 50);
            this.label7.TabIndex = 106;
            this.label7.Text = "注：1.通讯地址表示设备通讯地址。\r\n       2.修改设备通讯地址，编辑好数值，点击\"设置\"即可。";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbDevAddr
            // 
            this.tbDevAddr.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDevAddr.Location = new System.Drawing.Point(199, 49);
            this.tbDevAddr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDevAddr.Name = "tbDevAddr";
            this.tbDevAddr.Size = new System.Drawing.Size(85, 36);
            this.tbDevAddr.TabIndex = 102;
            this.tbDevAddr.Text = "0";
            this.tbDevAddr.TextChanged += new System.EventHandler(this.tbDevAddr_TextChanged);
            this.tbDevAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBox_KeyPress);
            // 
            // btnDevAddrSet
            // 
            this.btnDevAddrSet.BackColor = System.Drawing.Color.Transparent;
            this.btnDevAddrSet.BaseColor = System.Drawing.Color.Black;
            this.btnDevAddrSet.BorderColor = System.Drawing.Color.Silver;
            this.btnDevAddrSet.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnDevAddrSet.DownBack = null;
            this.btnDevAddrSet.Font = new System.Drawing.Font("方正姚体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDevAddrSet.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDevAddrSet.Location = new System.Drawing.Point(321, 46);
            this.btnDevAddrSet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDevAddrSet.MouseBack = null;
            this.btnDevAddrSet.Name = "btnDevAddrSet";
            this.btnDevAddrSet.NormlBack = null;
            this.btnDevAddrSet.Radius = 4;
            this.btnDevAddrSet.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnDevAddrSet.Size = new System.Drawing.Size(82, 42);
            this.btnDevAddrSet.TabIndex = 105;
            this.btnDevAddrSet.Text = "设置";
            this.btnDevAddrSet.UseVisualStyleBackColor = false;
            this.btnDevAddrSet.Click += new System.EventHandler(this.btnDevAddrSet_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(83, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 29);
            this.label5.TabIndex = 103;
            this.label5.Text = "通讯地址";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 721);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWMAuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWMClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWMClean)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem barRun;
        private DevExpress.XtraBars.BarLargeButtonItem barStop;
        private DevExpress.XtraBars.BarLargeButtonItem barComCfg;
        private DevExpress.XtraBars.BarLargeButtonItem barSetting;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem1;
        private System.Windows.Forms.Label lblFlowFb;
        private System.Windows.Forms.Label lbConcCh02;
        private System.Windows.Forms.Label lblFlowSet;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusFWVersion;
        private System.Windows.Forms.ToolStripStatusLabel statusCom;
        private CCWin.SkinControl.SkinButton btnWkmodeAuto;
        private CCWin.SkinControl.SkinButton btnWkmodeClose;
        private CCWin.SkinControl.SkinButton btnWkmodeClean;
        private System.Windows.Forms.Label lblWMClean;
        private System.Windows.Forms.Label lblWMClose;
        private System.Windows.Forms.Label lblWMAuto;
        private System.Windows.Forms.PictureBox picWMClean;
        private System.Windows.Forms.PictureBox picWMClose;
        private System.Windows.Forms.PictureBox picWMAuto;
        private System.Windows.Forms.Label lblFlowUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFlowRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel statusDevTemp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraBars.BarLargeButtonItem barCalibration;
        private DevExpress.XtraBars.BarLargeButtonItem barDebug;
        private System.Windows.Forms.Label lblCtrlSource;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFlowSetPC;
        private CCWin.SkinControl.SkinButton btnFlowSet;
        private System.Windows.Forms.Label lblMfcType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblOutPutType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbDevAddr;
        private CCWin.SkinControl.SkinButton btnDevAddrSet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraBars.BarLargeButtonItem barExport;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarLargeButtonItem barCollect;
        private System.Windows.Forms.ToolStripStatusLabel statusCollectnum;
    }
}

