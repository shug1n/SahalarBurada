using System.Windows.Forms;

namespace SahalarBurada.Forms
{
    partial class FormSahaListesi
    {
        private Panel pnlHeader;
        private Label lblHeaderBaslik;
        private Label lblHeaderAltBaslik;
        
        private Panel pnlScroll;
        private FlowLayoutPanel flowPanel;
        
        private Panel pnlAltBar;
        private Button btnGeri;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderBaslik = new System.Windows.Forms.Label();
            this.lblHeaderAltBaslik = new System.Windows.Forms.Label();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlAltBar = new System.Windows.Forms.Panel();
            this.btnGeri = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.pnlAltBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.pnlHeader.Controls.Add(this.lblHeaderBaslik);
            this.pnlHeader.Controls.Add(this.lblHeaderAltBaslik);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(880, 95);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderBaslik
            // 
            this.lblHeaderBaslik.AutoSize = true;
            this.lblHeaderBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderBaslik.ForeColor = System.Drawing.Color.White;
            this.lblHeaderBaslik.Location = new System.Drawing.Point(25, 16);
            this.lblHeaderBaslik.Name = "lblHeaderBaslik";
            this.lblHeaderBaslik.Size = new System.Drawing.Size(200, 30);
            this.lblHeaderBaslik.TabIndex = 0;
            this.lblHeaderBaslik.Text = "📋  Uygun Sahalar";
            // 
            // lblHeaderAltBaslik
            // 
            this.lblHeaderAltBaslik.AutoSize = true;
            this.lblHeaderAltBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderAltBaslik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderAltBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHeaderAltBaslik.Location = new System.Drawing.Point(27, 52);
            this.lblHeaderAltBaslik.Name = "lblHeaderAltBaslik";
            this.lblHeaderAltBaslik.Size = new System.Drawing.Size(150, 15);
            this.lblHeaderAltBaslik.TabIndex = 1;
            this.lblHeaderAltBaslik.Text = "Bulunan sahalar yükleniyor...";
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.pnlScroll.Controls.Add(this.flowPanel);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 95);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(880, 543);
            this.pnlScroll.TabIndex = 1;
            // 
            // flowPanel
            // 
            this.flowPanel.AutoSize = true;
            this.flowPanel.BackColor = System.Drawing.Color.Transparent;
            this.flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanel.Location = new System.Drawing.Point(0, 0);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.flowPanel.Size = new System.Drawing.Size(880, 543);
            this.flowPanel.TabIndex = 0;
            this.flowPanel.WrapContents = false;
            // 
            // pnlAltBar
            // 
            this.pnlAltBar.BackColor = System.Drawing.Color.White;
            this.pnlAltBar.Controls.Add(this.btnGeri);
            this.pnlAltBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAltBar.Location = new System.Drawing.Point(0, 638);
            this.pnlAltBar.Name = "pnlAltBar";
            this.pnlAltBar.Size = new System.Drawing.Size(880, 52);
            this.pnlAltBar.TabIndex = 2;
            this.pnlAltBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAltBar_Paint);
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.Color.White;
            this.btnGeri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeri.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnGeri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(240)))));
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGeri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnGeri.Location = new System.Drawing.Point(20, 7);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(130, 38);
            this.btnGeri.TabIndex = 0;
            this.btnGeri.Text = "← Geri";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.BtnGeri_Click);
            // 
            // FormSahaListesi
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(880, 690);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.pnlAltBar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSahaListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SahalarBurada — Uygun Sahalar";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();
            this.pnlAltBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
