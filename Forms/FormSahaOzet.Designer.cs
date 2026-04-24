using System.Windows.Forms;

namespace SahalarBurada.Forms
{
    partial class FormSahaOzet
    {
        private Panel pnlHeader;
        private Label lblHeaderBaslik;
        private Label lblHeaderAltBaslik;
        
        private Panel pnlScroll;
        private Panel pnlKart;
        private Label lblKartBaslik;
        private Label lblAdLabel;
        private Label lblAdDeger;
        private Label lblAdresLabel;
        private Label lblAdresDeger;
        private Label lblKapasiteLabel;
        private Label lblKapasiteDeger;
        private Label lblFiyatLabel;
        private Label lblFiyatDeger;
        private Label lblGunlerLabel;
        private Label lblGunlerDeger;
        private Label lblSaatlerLabel;
        private Label lblSaatlerDeger;
        private Label lblAciklamaLabel;
        private Label lblAciklamaDeger;
        private Label lblBilgi;
        private Button btnDuzenle;
        private Button btnKaydet;

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
            this.pnlKart = new System.Windows.Forms.Panel();
            this.lblKartBaslik = new System.Windows.Forms.Label();
            this.lblAdLabel = new System.Windows.Forms.Label();
            this.lblAdDeger = new System.Windows.Forms.Label();
            this.lblAdresLabel = new System.Windows.Forms.Label();
            this.lblAdresDeger = new System.Windows.Forms.Label();
            this.lblKapasiteLabel = new System.Windows.Forms.Label();
            this.lblKapasiteDeger = new System.Windows.Forms.Label();
            this.lblFiyatLabel = new System.Windows.Forms.Label();
            this.lblFiyatDeger = new System.Windows.Forms.Label();
            this.lblGunlerLabel = new System.Windows.Forms.Label();
            this.lblGunlerDeger = new System.Windows.Forms.Label();
            this.lblSaatlerLabel = new System.Windows.Forms.Label();
            this.lblSaatlerDeger = new System.Windows.Forms.Label();
            this.lblAciklamaLabel = new System.Windows.Forms.Label();
            this.lblAciklamaDeger = new System.Windows.Forms.Label();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.pnlKart.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(680, 95);
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
            this.lblHeaderBaslik.Size = new System.Drawing.Size(155, 30);
            this.lblHeaderBaslik.TabIndex = 0;
            this.lblHeaderBaslik.Text = "📄  Saha Özeti";
            // 
            // lblHeaderAltBaslik
            // 
            this.lblHeaderAltBaslik.AutoSize = true;
            this.lblHeaderAltBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderAltBaslik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderAltBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHeaderAltBaslik.Location = new System.Drawing.Point(27, 52);
            this.lblHeaderAltBaslik.Name = "lblHeaderAltBaslik";
            this.lblHeaderAltBaslik.Size = new System.Drawing.Size(306, 15);
            this.lblHeaderAltBaslik.TabIndex = 1;
            this.lblHeaderAltBaslik.Text = "Bilgileri kontrol edin; onaylayarak kaydedebilirsiniz";
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.pnlScroll.Controls.Add(this.pnlKart);
            this.pnlScroll.Controls.Add(this.lblBilgi);
            this.pnlScroll.Controls.Add(this.btnDuzenle);
            this.pnlScroll.Controls.Add(this.btnKaydet);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 95);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(680, 565);
            this.pnlScroll.TabIndex = 1;
            // 
            // pnlKart
            // 
            this.pnlKart.BackColor = System.Drawing.Color.White;
            this.pnlKart.Controls.Add(this.lblKartBaslik);
            this.pnlKart.Controls.Add(this.lblAdLabel);
            this.pnlKart.Controls.Add(this.lblAdDeger);
            this.pnlKart.Controls.Add(this.lblAdresLabel);
            this.pnlKart.Controls.Add(this.lblAdresDeger);
            this.pnlKart.Controls.Add(this.lblKapasiteLabel);
            this.pnlKart.Controls.Add(this.lblKapasiteDeger);
            this.pnlKart.Controls.Add(this.lblFiyatLabel);
            this.pnlKart.Controls.Add(this.lblFiyatDeger);
            this.pnlKart.Controls.Add(this.lblGunlerLabel);
            this.pnlKart.Controls.Add(this.lblGunlerDeger);
            this.pnlKart.Controls.Add(this.lblSaatlerLabel);
            this.pnlKart.Controls.Add(this.lblSaatlerDeger);
            this.pnlKart.Controls.Add(this.lblAciklamaLabel);
            this.pnlKart.Controls.Add(this.lblAciklamaDeger);
            this.pnlKart.Location = new System.Drawing.Point(32, 18);
            this.pnlKart.Name = "pnlKart";
            this.pnlKart.Size = new System.Drawing.Size(614, 432);
            this.pnlKart.TabIndex = 0;
            this.pnlKart.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlKart_Paint);
            // 
            // lblKartBaslik
            // 
            this.lblKartBaslik.AutoSize = true;
            this.lblKartBaslik.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblKartBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.lblKartBaslik.Location = new System.Drawing.Point(18, 14);
            this.lblKartBaslik.Name = "lblKartBaslik";
            this.lblKartBaslik.Size = new System.Drawing.Size(199, 25);
            this.lblKartBaslik.TabIndex = 0;
            this.lblKartBaslik.Text = "📋 Saha Bilgileri Özeti";
            // 
            // lblAdLabel
            // 
            this.lblAdLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAdLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAdLabel.Location = new System.Drawing.Point(20, 52);
            this.lblAdLabel.Name = "lblAdLabel";
            this.lblAdLabel.Size = new System.Drawing.Size(145, 26);
            this.lblAdLabel.TabIndex = 1;
            this.lblAdLabel.Text = "Saha Adı:";
            // 
            // lblAdDeger
            // 
            this.lblAdDeger.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAdDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblAdDeger.Location = new System.Drawing.Point(170, 52);
            this.lblAdDeger.Name = "lblAdDeger";
            this.lblAdDeger.Size = new System.Drawing.Size(430, 26);
            this.lblAdDeger.TabIndex = 2;
            this.lblAdDeger.Text = "-";
            // 
            // lblAdresLabel
            // 
            this.lblAdresLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAdresLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAdresLabel.Location = new System.Drawing.Point(20, 84);
            this.lblAdresLabel.Name = "lblAdresLabel";
            this.lblAdresLabel.Size = new System.Drawing.Size(145, 26);
            this.lblAdresLabel.TabIndex = 3;
            this.lblAdresLabel.Text = "Adres:";
            // 
            // lblAdresDeger
            // 
            this.lblAdresDeger.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAdresDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblAdresDeger.Location = new System.Drawing.Point(170, 84);
            this.lblAdresDeger.Name = "lblAdresDeger";
            this.lblAdresDeger.Size = new System.Drawing.Size(430, 26);
            this.lblAdresDeger.TabIndex = 4;
            this.lblAdresDeger.Text = "-";
            // 
            // lblKapasiteLabel
            // 
            this.lblKapasiteLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKapasiteLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblKapasiteLabel.Location = new System.Drawing.Point(20, 116);
            this.lblKapasiteLabel.Name = "lblKapasiteLabel";
            this.lblKapasiteLabel.Size = new System.Drawing.Size(145, 26);
            this.lblKapasiteLabel.TabIndex = 5;
            this.lblKapasiteLabel.Text = "Kapasite:";
            // 
            // lblKapasiteDeger
            // 
            this.lblKapasiteDeger.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKapasiteDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblKapasiteDeger.Location = new System.Drawing.Point(170, 116);
            this.lblKapasiteDeger.Name = "lblKapasiteDeger";
            this.lblKapasiteDeger.Size = new System.Drawing.Size(430, 26);
            this.lblKapasiteDeger.TabIndex = 6;
            this.lblKapasiteDeger.Text = "-";
            // 
            // lblFiyatLabel
            // 
            this.lblFiyatLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFiyatLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblFiyatLabel.Location = new System.Drawing.Point(20, 148);
            this.lblFiyatLabel.Name = "lblFiyatLabel";
            this.lblFiyatLabel.Size = new System.Drawing.Size(145, 26);
            this.lblFiyatLabel.TabIndex = 7;
            this.lblFiyatLabel.Text = "Fiyat/Saat:";
            // 
            // lblFiyatDeger
            // 
            this.lblFiyatDeger.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFiyatDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblFiyatDeger.Location = new System.Drawing.Point(170, 148);
            this.lblFiyatDeger.Name = "lblFiyatDeger";
            this.lblFiyatDeger.Size = new System.Drawing.Size(430, 26);
            this.lblFiyatDeger.TabIndex = 8;
            this.lblFiyatDeger.Text = "-";
            // 
            // lblGunlerLabel
            // 
            this.lblGunlerLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGunlerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblGunlerLabel.Location = new System.Drawing.Point(20, 180);
            this.lblGunlerLabel.Name = "lblGunlerLabel";
            this.lblGunlerLabel.Size = new System.Drawing.Size(145, 40);
            this.lblGunlerLabel.TabIndex = 9;
            this.lblGunlerLabel.Text = "Müsait Günler:";
            // 
            // lblGunlerDeger
            // 
            this.lblGunlerDeger.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGunlerDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblGunlerDeger.Location = new System.Drawing.Point(170, 180);
            this.lblGunlerDeger.Name = "lblGunlerDeger";
            this.lblGunlerDeger.Size = new System.Drawing.Size(430, 40);
            this.lblGunlerDeger.TabIndex = 10;
            this.lblGunlerDeger.Text = "-";
            // 
            // lblSaatlerLabel
            // 
            this.lblSaatlerLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSaatlerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSaatlerLabel.Location = new System.Drawing.Point(20, 226);
            this.lblSaatlerLabel.Name = "lblSaatlerLabel";
            this.lblSaatlerLabel.Size = new System.Drawing.Size(145, 26);
            this.lblSaatlerLabel.TabIndex = 11;
            this.lblSaatlerLabel.Text = "Müsait Saatler:";
            // 
            // lblSaatlerDeger
            // 
            this.lblSaatlerDeger.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSaatlerDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblSaatlerDeger.Location = new System.Drawing.Point(170, 226);
            this.lblSaatlerDeger.Name = "lblSaatlerDeger";
            this.lblSaatlerDeger.Size = new System.Drawing.Size(430, 26);
            this.lblSaatlerDeger.TabIndex = 12;
            this.lblSaatlerDeger.Text = "-";
            // 
            // lblAciklamaLabel
            // 
            this.lblAciklamaLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAciklamaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAciklamaLabel.Location = new System.Drawing.Point(20, 258);
            this.lblAciklamaLabel.Name = "lblAciklamaLabel";
            this.lblAciklamaLabel.Size = new System.Drawing.Size(145, 48);
            this.lblAciklamaLabel.TabIndex = 13;
            this.lblAciklamaLabel.Text = "Açıklama:";
            // 
            // lblAciklamaDeger
            // 
            this.lblAciklamaDeger.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAciklamaDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblAciklamaDeger.Location = new System.Drawing.Point(170, 258);
            this.lblAciklamaDeger.Name = "lblAciklamaDeger";
            this.lblAciklamaDeger.Size = new System.Drawing.Size(430, 48);
            this.lblAciklamaDeger.TabIndex = 14;
            this.lblAciklamaDeger.Text = "-";
            // 
            // lblBilgi
            // 
            this.lblBilgi.AutoSize = true;
            this.lblBilgi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblBilgi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblBilgi.Location = new System.Drawing.Point(32, 468);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(325, 15);
            this.lblBilgi.TabIndex = 1;
            this.lblBilgi.Text = "ℹ  Bilgiler doğru mu? Onayladıktan sonra sisteme kaydedilir.";
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.BackColor = System.Drawing.Color.White;
            this.btnDuzenle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDuzenle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnDuzenle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(240)))));
            this.btnDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuzenle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDuzenle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnDuzenle.Location = new System.Drawing.Point(32, 496);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(160, 46);
            this.btnDuzenle.TabIndex = 2;
            this.btnDuzenle.Text = "✏  Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = false;
            this.btnDuzenle.Click += new System.EventHandler(this.BtnDuzenle_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(212, 496);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(250, 46);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "✅  Onayla ve Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // FormSahaOzet
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(680, 660);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSahaOzet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SahalarBurada — Saha Özeti";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();
            this.pnlKart.ResumeLayout(false);
            this.pnlKart.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
