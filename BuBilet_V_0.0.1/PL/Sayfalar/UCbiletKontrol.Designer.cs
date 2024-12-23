namespace BuBilet_V_0._0._1.Sayfalar
{
    partial class UCbiletKontrol
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlAnaPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.BtnBiletAra = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPNR = new Guna.UI2.WinForms.Guna2TextBox();
            this.PnlAnaPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlAnaPanel
            // 
            this.PnlAnaPanel.Controls.Add(this.BtnBiletAra);
            this.PnlAnaPanel.Controls.Add(this.label1);
            this.PnlAnaPanel.Controls.Add(this.TxtPNR);
            this.PnlAnaPanel.Location = new System.Drawing.Point(418, 168);
            this.PnlAnaPanel.Name = "PnlAnaPanel";
            this.PnlAnaPanel.Size = new System.Drawing.Size(1057, 528);
            this.PnlAnaPanel.TabIndex = 1;
            // 
            // BtnBiletAra
            // 
            this.BtnBiletAra.Animated = true;
            this.BtnBiletAra.AutoRoundedCorners = true;
            this.BtnBiletAra.BorderRadius = 26;
            this.BtnBiletAra.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnBiletAra.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnBiletAra.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnBiletAra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnBiletAra.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(155)))), ((int)(((byte)(120)))));
            this.BtnBiletAra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBiletAra.ForeColor = System.Drawing.Color.White;
            this.BtnBiletAra.Location = new System.Drawing.Point(358, 291);
            this.BtnBiletAra.Name = "BtnBiletAra";
            this.BtnBiletAra.Size = new System.Drawing.Size(372, 54);
            this.BtnBiletAra.TabIndex = 6;
            this.BtnBiletAra.Text = "Bilet Ara";
            this.BtnBiletAra.Click += new System.EventHandler(this.BtnBileAra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(257, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "BİLET NUMARANIZ:";
            // 
            // TxtPNR
            // 
            this.TxtPNR.BorderRadius = 19;
            this.TxtPNR.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtPNR.DefaultText = "";
            this.TxtPNR.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtPNR.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtPNR.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPNR.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPNR.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPNR.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtPNR.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPNR.Location = new System.Drawing.Point(473, 206);
            this.TxtPNR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtPNR.Name = "TxtPNR";
            this.TxtPNR.PasswordChar = '\0';
            this.TxtPNR.PlaceholderText = "PNR BİLGİSİ";
            this.TxtPNR.SelectedText = "";
            this.TxtPNR.Size = new System.Drawing.Size(435, 48);
            this.TxtPNR.TabIndex = 0;
            // 
            // UCbiletKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.PnlAnaPanel);
            this.Name = "UCbiletKontrol";
            this.Size = new System.Drawing.Size(1653, 964);
            this.PnlAnaPanel.ResumeLayout(false);
            this.PnlAnaPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel PnlAnaPanel;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox TxtPNR;
        private Guna.UI2.WinForms.Guna2Button BtnBiletAra;
    }
}
