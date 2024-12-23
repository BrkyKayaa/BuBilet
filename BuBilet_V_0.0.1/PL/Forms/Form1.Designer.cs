namespace BuBilet_V_0._0._1
{
    partial class FrmBuBilet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuBilet));
            this.PnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.PnlSideBarMiddle = new System.Windows.Forms.Panel();
            this.PnlKontroller = new System.Windows.Forms.Panel();
            this.PnlSidebarTop = new Guna.UI2.WinForms.Guna2Panel();
            this.PnlSidebarBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.PnlNavbar = new Guna.UI2.WinForms.Guna2Panel();
            this.LblKullaniciID = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.guna2CbxMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2CbxMaximize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2CbxExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.TmrSideBarTransition = new System.Windows.Forms.Timer(this.components);
            this.PnlAnaPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.BtnBiletlerim = new Guna.UI2.WinForms.Guna2Button();
            this.BtnUcakSeferEkle = new Guna.UI2.WinForms.Guna2Button();
            this.BtnKontroller = new Guna.UI2.WinForms.Guna2Button();
            this.BtnOtobusEkle = new Guna.UI2.WinForms.Guna2Button();
            this.BtnOtobusSeferiEkle = new Guna.UI2.WinForms.Guna2Button();
            this.BtnSideBarControl = new Guna.UI2.WinForms.Guna2Button();
            this.BtnOtobus = new Guna.UI2.WinForms.Guna2Button();
            this.BtnUcak = new Guna.UI2.WinForms.Guna2Button();
            this.BtnBilet = new Guna.UI2.WinForms.Guna2Button();
            this.BtnCikisYap = new Guna.UI2.WinForms.Guna2Button();
            this.BtnGirisYap = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.PnlSidebar.SuspendLayout();
            this.PnlSideBarMiddle.SuspendLayout();
            this.PnlKontroller.SuspendLayout();
            this.PnlSidebarTop.SuspendLayout();
            this.PnlSidebarBottom.SuspendLayout();
            this.PnlNavbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlSidebar
            // 
            this.PnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(58)))), ((int)(((byte)(111)))));
            this.PnlSidebar.Controls.Add(this.PnlSideBarMiddle);
            this.PnlSidebar.Controls.Add(this.PnlSidebarTop);
            this.PnlSidebar.Controls.Add(this.PnlSidebarBottom);
            this.PnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlSidebar.Location = new System.Drawing.Point(0, 58);
            this.PnlSidebar.MaximumSize = new System.Drawing.Size(265, 0);
            this.PnlSidebar.MinimumSize = new System.Drawing.Size(77, 0);
            this.PnlSidebar.Name = "PnlSidebar";
            this.PnlSidebar.Size = new System.Drawing.Size(265, 961);
            this.PnlSidebar.TabIndex = 0;
            // 
            // PnlSideBarMiddle
            // 
            this.PnlSideBarMiddle.Controls.Add(this.BtnBiletlerim);
            this.PnlSideBarMiddle.Controls.Add(this.PnlKontroller);
            this.PnlSideBarMiddle.Location = new System.Drawing.Point(0, 206);
            this.PnlSideBarMiddle.Name = "PnlSideBarMiddle";
            this.PnlSideBarMiddle.Size = new System.Drawing.Size(265, 629);
            this.PnlSideBarMiddle.TabIndex = 9;
            // 
            // PnlKontroller
            // 
            this.PnlKontroller.Controls.Add(this.BtnUcakSeferEkle);
            this.PnlKontroller.Controls.Add(this.BtnKontroller);
            this.PnlKontroller.Controls.Add(this.BtnOtobusEkle);
            this.PnlKontroller.Controls.Add(this.BtnOtobusSeferiEkle);
            this.PnlKontroller.Location = new System.Drawing.Point(0, 3);
            this.PnlKontroller.MaximumSize = new System.Drawing.Size(265, 265);
            this.PnlKontroller.MinimumSize = new System.Drawing.Size(265, 60);
            this.PnlKontroller.Name = "PnlKontroller";
            this.PnlKontroller.Size = new System.Drawing.Size(265, 60);
            this.PnlKontroller.TabIndex = 16;
            // 
            // PnlSidebarTop
            // 
            this.PnlSidebarTop.Controls.Add(this.BtnSideBarControl);
            this.PnlSidebarTop.Controls.Add(this.BtnOtobus);
            this.PnlSidebarTop.Controls.Add(this.BtnUcak);
            this.PnlSidebarTop.Controls.Add(this.BtnBilet);
            this.PnlSidebarTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlSidebarTop.Location = new System.Drawing.Point(0, 0);
            this.PnlSidebarTop.Name = "PnlSidebarTop";
            this.PnlSidebarTop.Size = new System.Drawing.Size(265, 269);
            this.PnlSidebarTop.TabIndex = 2;
            // 
            // PnlSidebarBottom
            // 
            this.PnlSidebarBottom.Controls.Add(this.BtnCikisYap);
            this.PnlSidebarBottom.Controls.Add(this.BtnGirisYap);
            this.PnlSidebarBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlSidebarBottom.Location = new System.Drawing.Point(0, 841);
            this.PnlSidebarBottom.Name = "PnlSidebarBottom";
            this.PnlSidebarBottom.Size = new System.Drawing.Size(265, 120);
            this.PnlSidebarBottom.TabIndex = 8;
            // 
            // PnlNavbar
            // 
            this.PnlNavbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(58)))), ((int)(((byte)(111)))));
            this.PnlNavbar.Controls.Add(this.LblKullaniciID);
            this.PnlNavbar.Controls.Add(this.guna2CirclePictureBox1);
            this.PnlNavbar.Controls.Add(this.LblTitle);
            this.PnlNavbar.Controls.Add(this.guna2CbxMinimize);
            this.PnlNavbar.Controls.Add(this.guna2CbxMaximize);
            this.PnlNavbar.Controls.Add(this.guna2CbxExit);
            this.PnlNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlNavbar.Location = new System.Drawing.Point(0, 0);
            this.PnlNavbar.Name = "PnlNavbar";
            this.PnlNavbar.Size = new System.Drawing.Size(1919, 58);
            this.PnlNavbar.TabIndex = 1;
            // 
            // LblKullaniciID
            // 
            this.LblKullaniciID.AutoSize = true;
            this.LblKullaniciID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblKullaniciID.ForeColor = System.Drawing.Color.White;
            this.LblKullaniciID.Location = new System.Drawing.Point(725, 20);
            this.LblKullaniciID.Name = "LblKullaniciID";
            this.LblKullaniciID.Size = new System.Drawing.Size(20, 23);
            this.LblKullaniciID.TabIndex = 9;
            this.LblKullaniciID.Text = "0";
            this.LblKullaniciID.Visible = false;
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(83, 4);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(125, 50);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "BuBilet";
            // 
            // guna2CbxMinimize
            // 
            this.guna2CbxMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CbxMinimize.Animated = true;
            this.guna2CbxMinimize.BorderRadius = 5;
            this.guna2CbxMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2CbxMinimize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(58)))), ((int)(((byte)(111)))));
            this.guna2CbxMinimize.IconColor = System.Drawing.Color.White;
            this.guna2CbxMinimize.Location = new System.Drawing.Point(1761, 8);
            this.guna2CbxMinimize.Name = "guna2CbxMinimize";
            this.guna2CbxMinimize.Size = new System.Drawing.Size(48, 41);
            this.guna2CbxMinimize.TabIndex = 2;
            // 
            // guna2CbxMaximize
            // 
            this.guna2CbxMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CbxMaximize.Animated = true;
            this.guna2CbxMaximize.BorderRadius = 5;
            this.guna2CbxMaximize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2CbxMaximize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(58)))), ((int)(((byte)(111)))));
            this.guna2CbxMaximize.IconColor = System.Drawing.Color.White;
            this.guna2CbxMaximize.Location = new System.Drawing.Point(1812, 8);
            this.guna2CbxMaximize.Name = "guna2CbxMaximize";
            this.guna2CbxMaximize.Size = new System.Drawing.Size(48, 41);
            this.guna2CbxMaximize.TabIndex = 1;
            // 
            // guna2CbxExit
            // 
            this.guna2CbxExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CbxExit.Animated = true;
            this.guna2CbxExit.BorderRadius = 5;
            this.guna2CbxExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(58)))), ((int)(((byte)(111)))));
            this.guna2CbxExit.IconColor = System.Drawing.Color.White;
            this.guna2CbxExit.Location = new System.Drawing.Point(1863, 7);
            this.guna2CbxExit.Name = "guna2CbxExit";
            this.guna2CbxExit.Size = new System.Drawing.Size(48, 41);
            this.guna2CbxExit.TabIndex = 0;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.PnlNavbar;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // TmrSideBarTransition
            // 
            this.TmrSideBarTransition.Interval = 20;
            this.TmrSideBarTransition.Tick += new System.EventHandler(this.TmrSideBarTransition_Tick);
            // 
            // PnlAnaPanel
            // 
            this.PnlAnaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlAnaPanel.Location = new System.Drawing.Point(265, 58);
            this.PnlAnaPanel.Name = "PnlAnaPanel";
            this.PnlAnaPanel.Size = new System.Drawing.Size(1654, 961);
            this.PnlAnaPanel.TabIndex = 2;
            this.PnlAnaPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlAnaPanel_Paint);
            // 
            // BtnBiletlerim
            // 
            this.BtnBiletlerim.Animated = true;
            this.BtnBiletlerim.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnBiletlerim.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnBiletlerim.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnBiletlerim.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnBiletlerim.FillColor = System.Drawing.Color.Transparent;
            this.BtnBiletlerim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBiletlerim.ForeColor = System.Drawing.Color.White;
            this.BtnBiletlerim.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnBiletlerim.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnBiletlerim.HoverState.Image = global::BuBilet_V_0._0._1.Properties.Resources.icons8_my_ticket_32_hover;
            this.BtnBiletlerim.Image = global::BuBilet_V_0._0._1.Properties.Resources.icons8_my_ticket_32_normal;
            this.BtnBiletlerim.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnBiletlerim.ImageOffset = new System.Drawing.Point(10, 0);
            this.BtnBiletlerim.ImageSize = new System.Drawing.Size(32, 32);
            this.BtnBiletlerim.Location = new System.Drawing.Point(0, 567);
            this.BtnBiletlerim.Name = "BtnBiletlerim";
            this.BtnBiletlerim.Size = new System.Drawing.Size(265, 59);
            this.BtnBiletlerim.TabIndex = 11;
            this.BtnBiletlerim.Text = "   Biletlerim";
            this.BtnBiletlerim.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnBiletlerim.TextOffset = new System.Drawing.Point(10, 0);
            this.BtnBiletlerim.Visible = false;
            this.BtnBiletlerim.Click += new System.EventHandler(this.BtnBiletlerim_Click);
            // 
            // BtnUcakSeferEkle
            // 
            this.BtnUcakSeferEkle.Animated = true;
            this.BtnUcakSeferEkle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnUcakSeferEkle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnUcakSeferEkle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnUcakSeferEkle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnUcakSeferEkle.FillColor = System.Drawing.Color.Transparent;
            this.BtnUcakSeferEkle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnUcakSeferEkle.ForeColor = System.Drawing.Color.White;
            this.BtnUcakSeferEkle.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnUcakSeferEkle.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnUcakSeferEkle.HoverState.Image = global::BuBilet_V_0._0._1.Properties.Resources.icons8_confirm_32_hover;
            this.BtnUcakSeferEkle.Image = global::BuBilet_V_0._0._1.Properties.Resources.icons8_confirm_32_normal;
            this.BtnUcakSeferEkle.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnUcakSeferEkle.ImageOffset = new System.Drawing.Point(5, 0);
            this.BtnUcakSeferEkle.ImageSize = new System.Drawing.Size(32, 32);
            this.BtnUcakSeferEkle.Location = new System.Drawing.Point(13, 196);
            this.BtnUcakSeferEkle.Name = "BtnUcakSeferEkle";
            this.BtnUcakSeferEkle.Size = new System.Drawing.Size(249, 60);
            this.BtnUcakSeferEkle.TabIndex = 16;
            this.BtnUcakSeferEkle.Text = "   Uçak Seferleri";
            this.BtnUcakSeferEkle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnUcakSeferEkle.TextOffset = new System.Drawing.Point(10, 0);
            this.BtnUcakSeferEkle.Click += new System.EventHandler(this.BtnUcakSeferEkle_Click);
            // 
            // BtnKontroller
            // 
            this.BtnKontroller.Animated = true;
            this.BtnKontroller.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnKontroller.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnKontroller.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnKontroller.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnKontroller.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnKontroller.FillColor = System.Drawing.Color.Transparent;
            this.BtnKontroller.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnKontroller.ForeColor = System.Drawing.Color.White;
            this.BtnKontroller.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKontroller.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnKontroller.HoverState.Image = global::BuBilet_V_0._0._1.Properties.Resources.icons8_configuration_32_hover;
            this.BtnKontroller.Image = global::BuBilet_V_0._0._1.Properties.Resources.icons8_configuration_32_normal;
            this.BtnKontroller.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnKontroller.ImageOffset = new System.Drawing.Point(5, 0);
            this.BtnKontroller.ImageSize = new System.Drawing.Size(32, 32);
            this.BtnKontroller.Location = new System.Drawing.Point(0, 0);
            this.BtnKontroller.Name = "BtnKontroller";
            this.BtnKontroller.Size = new System.Drawing.Size(265, 60);
            this.BtnKontroller.TabIndex = 15;
            this.BtnKontroller.Text = "   Kontroller";
            this.BtnKontroller.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnKontroller.TextOffset = new System.Drawing.Point(10, 0);
            this.BtnKontroller.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // BtnOtobusEkle
            // 
            this.BtnOtobusEkle.Animated = true;
            this.BtnOtobusEkle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnOtobusEkle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnOtobusEkle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnOtobusEkle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnOtobusEkle.FillColor = System.Drawing.Color.Transparent;
            this.BtnOtobusEkle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOtobusEkle.ForeColor = System.Drawing.Color.White;
            this.BtnOtobusEkle.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnOtobusEkle.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnOtobusEkle.HoverState.Image = global::BuBilet_V_0._0._1.Properties.Resources.icons8_confirm_32_hover;
            this.BtnOtobusEkle.Image = global::BuBilet_V_0._0._1.Properties.Resources.icons8_confirm_32_normal;
            this.BtnOtobusEkle.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnOtobusEkle.ImageOffset = new System.Drawing.Point(5, 0);
            this.BtnOtobusEkle.ImageSize = new System.Drawing.Size(32, 32);
            this.BtnOtobusEkle.Location = new System.Drawing.Point(13, 130);
            this.BtnOtobusEkle.Name = "BtnOtobusEkle";
            this.BtnOtobusEkle.Size = new System.Drawing.Size(249, 60);
            this.BtnOtobusEkle.TabIndex = 14;
            this.BtnOtobusEkle.Text = "   Otobüs ve Sürücü";
            this.BtnOtobusEkle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnOtobusEkle.TextOffset = new System.Drawing.Point(10, 0);
            this.BtnOtobusEkle.Click += new System.EventHandler(this.BtnOtobusEkle_Click);
            // 
            // BtnOtobusSeferiEkle
            // 
            this.BtnOtobusSeferiEkle.Animated = true;
            this.BtnOtobusSeferiEkle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnOtobusSeferiEkle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnOtobusSeferiEkle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnOtobusSeferiEkle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnOtobusSeferiEkle.FillColor = System.Drawing.Color.Transparent;
            this.BtnOtobusSeferiEkle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOtobusSeferiEkle.ForeColor = System.Drawing.Color.White;
            this.BtnOtobusSeferiEkle.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnOtobusSeferiEkle.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnOtobusSeferiEkle.HoverState.Image = global::BuBilet_V_0._0._1.Properties.Resources.icons8_confirm_32_hover;
            this.BtnOtobusSeferiEkle.Image = global::BuBilet_V_0._0._1.Properties.Resources.icons8_confirm_32_normal;
            this.BtnOtobusSeferiEkle.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnOtobusSeferiEkle.ImageOffset = new System.Drawing.Point(5, 0);
            this.BtnOtobusSeferiEkle.ImageSize = new System.Drawing.Size(32, 32);
            this.BtnOtobusSeferiEkle.Location = new System.Drawing.Point(13, 64);
            this.BtnOtobusSeferiEkle.Name = "BtnOtobusSeferiEkle";
            this.BtnOtobusSeferiEkle.Size = new System.Drawing.Size(249, 60);
            this.BtnOtobusSeferiEkle.TabIndex = 13;
            this.BtnOtobusSeferiEkle.Text = "   Otobüs Seferleri";
            this.BtnOtobusSeferiEkle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnOtobusSeferiEkle.TextOffset = new System.Drawing.Point(10, 0);
            this.BtnOtobusSeferiEkle.Click += new System.EventHandler(this.BtnOtobusSeferiEkle_Click);
            // 
            // BtnSideBarControl
            // 
            this.BtnSideBarControl.Animated = true;
            this.BtnSideBarControl.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnSideBarControl.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnSideBarControl.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnSideBarControl.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnSideBarControl.FillColor = System.Drawing.Color.Transparent;
            this.BtnSideBarControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnSideBarControl.ForeColor = System.Drawing.Color.White;
            this.BtnSideBarControl.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnSideBarControl.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.BtnSideBarControl.Image = ((System.Drawing.Image)(resources.GetObject("BtnSideBarControl.Image")));
            this.BtnSideBarControl.Location = new System.Drawing.Point(77, 372);
            this.BtnSideBarControl.Name = "BtnSideBarControl";
            this.BtnSideBarControl.Size = new System.Drawing.Size(77, 52);
            this.BtnSideBarControl.TabIndex = 8;
            this.BtnSideBarControl.Click += new System.EventHandler(this.BtnSideBarControl_Click);
            // 
            // BtnOtobus
            // 
            this.BtnOtobus.Animated = true;
            this.BtnOtobus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnOtobus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnOtobus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnOtobus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnOtobus.FillColor = System.Drawing.Color.Transparent;
            this.BtnOtobus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOtobus.ForeColor = System.Drawing.Color.White;
            this.BtnOtobus.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnOtobus.HoverState.ForeColor = System.Drawing.Color.Transparent;
            this.BtnOtobus.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.BtnOtobus.Image = ((System.Drawing.Image)(resources.GetObject("BtnOtobus.Image")));
            this.BtnOtobus.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnOtobus.ImageOffset = new System.Drawing.Point(5, 0);
            this.BtnOtobus.ImageSize = new System.Drawing.Size(32, 32);
            this.BtnOtobus.Location = new System.Drawing.Point(0, 11);
            this.BtnOtobus.Name = "BtnOtobus";
            this.BtnOtobus.Size = new System.Drawing.Size(265, 59);
            this.BtnOtobus.TabIndex = 3;
            this.BtnOtobus.Text = "   Otobüs Bileti Bul";
            this.BtnOtobus.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnOtobus.TextOffset = new System.Drawing.Point(10, 0);
            this.BtnOtobus.Click += new System.EventHandler(this.BtnOtobus_Click);
            // 
            // BtnUcak
            // 
            this.BtnUcak.Animated = true;
            this.BtnUcak.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnUcak.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnUcak.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnUcak.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnUcak.FillColor = System.Drawing.Color.Transparent;
            this.BtnUcak.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnUcak.ForeColor = System.Drawing.Color.White;
            this.BtnUcak.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnUcak.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnUcak.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.BtnUcak.Image = ((System.Drawing.Image)(resources.GetObject("BtnUcak.Image")));
            this.BtnUcak.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnUcak.ImageOffset = new System.Drawing.Point(5, 0);
            this.BtnUcak.ImageSize = new System.Drawing.Size(32, 32);
            this.BtnUcak.Location = new System.Drawing.Point(0, 76);
            this.BtnUcak.Name = "BtnUcak";
            this.BtnUcak.Size = new System.Drawing.Size(265, 59);
            this.BtnUcak.TabIndex = 8;
            this.BtnUcak.Text = "   Uçak Bileti Bul";
            this.BtnUcak.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnUcak.TextOffset = new System.Drawing.Point(10, 0);
            this.BtnUcak.Click += new System.EventHandler(this.BtnUcak_Click);
            // 
            // BtnBilet
            // 
            this.BtnBilet.Animated = true;
            this.BtnBilet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnBilet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnBilet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnBilet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnBilet.FillColor = System.Drawing.Color.Transparent;
            this.BtnBilet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBilet.ForeColor = System.Drawing.Color.White;
            this.BtnBilet.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnBilet.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnBilet.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.BtnBilet.Image = global::BuBilet_V_0._0._1.Properties.Resources.icons8_boarding_pass_32_normal;
            this.BtnBilet.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnBilet.ImageOffset = new System.Drawing.Point(5, 0);
            this.BtnBilet.ImageSize = new System.Drawing.Size(32, 32);
            this.BtnBilet.Location = new System.Drawing.Point(0, 141);
            this.BtnBilet.Name = "BtnBilet";
            this.BtnBilet.Size = new System.Drawing.Size(265, 59);
            this.BtnBilet.TabIndex = 10;
            this.BtnBilet.Text = "   Bilet Sorgula";
            this.BtnBilet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnBilet.TextOffset = new System.Drawing.Point(10, 0);
            this.BtnBilet.Click += new System.EventHandler(this.BtnBilet_Click);
            // 
            // BtnCikisYap
            // 
            this.BtnCikisYap.Animated = true;
            this.BtnCikisYap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnCikisYap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnCikisYap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnCikisYap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnCikisYap.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCikisYap.FillColor = System.Drawing.Color.Transparent;
            this.BtnCikisYap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCikisYap.ForeColor = System.Drawing.Color.White;
            this.BtnCikisYap.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnCikisYap.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnCikisYap.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            this.BtnCikisYap.Image = ((System.Drawing.Image)(resources.GetObject("BtnCikisYap.Image")));
            this.BtnCikisYap.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnCikisYap.ImageOffset = new System.Drawing.Point(5, 0);
            this.BtnCikisYap.ImageSize = new System.Drawing.Size(32, 32);
            this.BtnCikisYap.Location = new System.Drawing.Point(0, 60);
            this.BtnCikisYap.Name = "BtnCikisYap";
            this.BtnCikisYap.Size = new System.Drawing.Size(265, 60);
            this.BtnCikisYap.TabIndex = 12;
            this.BtnCikisYap.Text = "   Çıkış Yap";
            this.BtnCikisYap.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnCikisYap.TextOffset = new System.Drawing.Point(10, 0);
            this.BtnCikisYap.Click += new System.EventHandler(this.BtnCikisYap_Click);
            // 
            // BtnGirisYap
            // 
            this.BtnGirisYap.Animated = true;
            this.BtnGirisYap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnGirisYap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnGirisYap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnGirisYap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnGirisYap.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnGirisYap.FillColor = System.Drawing.Color.Transparent;
            this.BtnGirisYap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGirisYap.ForeColor = System.Drawing.Color.White;
            this.BtnGirisYap.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnGirisYap.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnGirisYap.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
            this.BtnGirisYap.Image = global::BuBilet_V_0._0._1.Properties.Resources.icons8_log_in_32_normal;
            this.BtnGirisYap.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnGirisYap.ImageOffset = new System.Drawing.Point(4, 0);
            this.BtnGirisYap.ImageSize = new System.Drawing.Size(32, 32);
            this.BtnGirisYap.Location = new System.Drawing.Point(0, 0);
            this.BtnGirisYap.Name = "BtnGirisYap";
            this.BtnGirisYap.Size = new System.Drawing.Size(265, 60);
            this.BtnGirisYap.TabIndex = 11;
            this.BtnGirisYap.Text = "   Giriş Yap!";
            this.BtnGirisYap.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnGirisYap.TextOffset = new System.Drawing.Point(10, 0);
            this.BtnGirisYap.Click += new System.EventHandler(this.BtnGirisYap_Click);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(12, 8);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(44, 44);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 7;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // FrmBuBilet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1919, 1019);
            this.Controls.Add(this.PnlAnaPanel);
            this.Controls.Add(this.PnlSidebar);
            this.Controls.Add(this.PnlNavbar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBuBilet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BuBilet";
            this.PnlSidebar.ResumeLayout(false);
            this.PnlSideBarMiddle.ResumeLayout(false);
            this.PnlKontroller.ResumeLayout(false);
            this.PnlSidebarTop.ResumeLayout(false);
            this.PnlSidebarBottom.ResumeLayout(false);
            this.PnlNavbar.ResumeLayout(false);
            this.PnlNavbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel PnlSidebar;
        private Guna.UI2.WinForms.Guna2Panel PnlNavbar;
        private Guna.UI2.WinForms.Guna2ControlBox guna2CbxMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox guna2CbxMaximize;
        private Guna.UI2.WinForms.Guna2ControlBox guna2CbxExit;
        private Guna.UI2.WinForms.Guna2Panel PnlSidebarBottom;
        private Guna.UI2.WinForms.Guna2Panel PnlSidebarTop;
        private Guna.UI2.WinForms.Guna2Button BtnOtobus;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Button BtnUcak;
        private Guna.UI2.WinForms.Guna2Button BtnBilet;
        private Guna.UI2.WinForms.Guna2Button BtnGirisYap;
        private Guna.UI2.WinForms.Guna2Button BtnCikisYap;
        private Guna.UI2.WinForms.Guna2Button BtnSideBarControl;
        private System.Windows.Forms.Timer TmrSideBarTransition;
        private Guna.UI2.WinForms.Guna2Panel PnlAnaPanel;
        private System.Windows.Forms.Label LblTitle;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Label LblKullaniciID;
        private Guna.UI2.WinForms.Guna2Button BtnOtobusSeferiEkle;
        private Guna.UI2.WinForms.Guna2Button BtnOtobusEkle;
        private System.Windows.Forms.Panel PnlKontroller;
        private Guna.UI2.WinForms.Guna2Button BtnKontroller;
        private System.Windows.Forms.Panel PnlSideBarMiddle;
        private Guna.UI2.WinForms.Guna2Button BtnUcakSeferEkle;
        private Guna.UI2.WinForms.Guna2Button BtnBiletlerim;
    }
}

