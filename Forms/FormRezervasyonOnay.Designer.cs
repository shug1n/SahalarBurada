using System.Windows.Forms;

namespace SahalarBurada.Forms
{
    partial class FormRezervasyonOnay
    {
        private Panel pnlHeader;
        private Label lblHeaderBaslik;
        private Label lblHeaderAltBaslik;
        
        private Panel pnlScroll;

        private Panel pnlDetay;
        private Label lblDetayBaslik;
        private Label lblSahaLabel;
        private Label lblSahaDeger;
        private Label lblAdresLabel;
        private Label lblAdresDeger;
        private Label lblTarihLabel;
        private Label lblTarihDeger;
        private Label lblSaatLabel;
        private Label lblSaatDeger;
        private Label lblFiyatLabel;
        private Label lblFiyatDeger;

        private Panel pnlMisafir;
        private Label lblMisafirBaslik;
        private Label lblMisafirUyari;
        private Label lblMisafirAdLabel;
        private TextBox txtMisafirAd;
        private Label lblMisafirTelLabel;
        private TextBox txtMisafirTelefon;

        private Label lblAktifKullanici;
        private Label lblHata;
        private Button btnGeri;
        private Button btnOnayla;

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
            this.pnlDetay = new System.Windows.Forms.Panel();
            this.lblDetayBaslik = new System.Windows.Forms.Label();
            this.lblSahaLabel = new System.Windows.Forms.Label();
            this.lblSahaDeger = new System.Windows.Forms.Label();
            this.lblAdresLabel = new System.Windows.Forms.Label();
            this.lblAdresDeger = new System.Windows.Forms.Label();
            this.lblTarihLabel = new System.Windows.Forms.Label();
            this.lblTarihDeger = new System.Windows.Forms.Label();
            this.lblSaatLabel = new System.Windows.Forms.Label();
            this.lblSaatDeger = new System.Windows.Forms.Label();
            this.lblFiyatLabel = new System.Windows.Forms.Label();
            this.lblFiyatDeger = new System.Windows.Forms.Label();
            this.pnlMisafir = new System.Windows.Forms.Panel();
            this.lblMisafirBaslik = new System.Windows.Forms.Label();
            this.lblMisafirUyari = new System.Windows.Forms.Label();
            this.lblMisafirAdLabel = new System.Windows.Forms.Label();
            this.txtMisafirAd = new System.Windows.Forms.TextBox();
            this.lblMisafirTelLabel = new System.Windows.Forms.Label();
            this.txtMisafirTelefon = new System.Windows.Forms.TextBox();
            this.lblAktifKullanici = new System.Windows.Forms.Label();
            this.lblHata = new System.Windows.Forms.Label();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.pnlDetay.SuspendLayout();
            this.pnlMisafir.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(640, 95);
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
            this.lblHeaderBaslik.Size = new System.Drawing.Size(262, 30);
            this.lblHeaderBaslik.TabIndex = 0;
            this.lblHeaderBaslik.Text = "✅  Rezervasyon Onayı";
            // 
            // lblHeaderAltBaslik
            // 
            this.lblHeaderAltBaslik.AutoSize = true;
            this.lblHeaderAltBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderAltBaslik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderAltBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHeaderAltBaslik.Location = new System.Drawing.Point(27, 52);
            this.lblHeaderAltBaslik.Name = "lblHeaderAltBaslik";
            this.lblHeaderAltBaslik.Size = new System.Drawing.Size(199, 15);
            this.lblHeaderAltBaslik.TabIndex = 1;
            this.lblHeaderAltBaslik.Text = "Bilgileri kontrol edin ve onaylayın";
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.pnlScroll.Controls.Add(this.pnlDetay);
            this.pnlScroll.Controls.Add(this.pnlMisafir);
            this.pnlScroll.Controls.Add(this.lblAktifKullanici);
            this.pnlScroll.Controls.Add(this.lblHata);
            this.pnlScroll.Controls.Add(this.btnGeri);
            this.pnlScroll.Controls.Add(this.btnOnayla);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 95);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(640, 505);
            this.pnlScroll.TabIndex = 1;
            // 
            // pnlDetay
            // 
            this.pnlDetay.BackColor = System.Drawing.Color.White;
            this.pnlDetay.Controls.Add(this.lblDetayBaslik);
            this.pnlDetay.Controls.Add(this.lblSahaLabel);
            this.pnlDetay.Controls.Add(this.lblSahaDeger);
            this.pnlDetay.Controls.Add(this.lblAdresLabel);
            this.pnlDetay.Controls.Add(this.lblAdresDeger);
            this.pnlDetay.Controls.Add(this.lblTarihLabel);
            this.pnlDetay.Controls.Add(this.lblTarihDeger);
            this.pnlDetay.Controls.Add(this.lblSaatLabel);
            this.pnlDetay.Controls.Add(this.lblSaatDeger);
            this.pnlDetay.Controls.Add(this.lblFiyatLabel);
            this.pnlDetay.Controls.Add(this.lblFiyatDeger);
            this.pnlDetay.Location = new System.Drawing.Point(35, 18);
            this.pnlDetay.Name = "pnlDetay";
            this.pnlDetay.Size = new System.Drawing.Size(568, 192);
            this.pnlDetay.TabIndex = 0;
            this.pnlDetay.Paint += new System.Windows.Forms.PaintEventHandler(this.Pnl_PaintBorder);
            // 
            // lblDetayBaslik
            // 
            this.lblDetayBaslik.AutoSize = true;
            this.lblDetayBaslik.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblDetayBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.lblDetayBaslik.Location = new System.Drawing.Point(16, 12);
            this.lblDetayBaslik.Name = "lblDetayBaslik";
            this.lblDetayBaslik.Size = new System.Drawing.Size(222, 25);
            this.lblDetayBaslik.TabIndex = 0;
            this.lblDetayBaslik.Text = "📋 Rezervasyon Detayları";
            // 
            // lblSahaLabel
            // 
            this.lblSahaLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSahaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSahaLabel.Location = new System.Drawing.Point(16, 48);
            this.lblSahaLabel.Name = "lblSahaLabel";
            this.lblSahaLabel.Size = new System.Drawing.Size(125, 22);
            this.lblSahaLabel.TabIndex = 1;
            this.lblSahaLabel.Text = "⚽ Saha:";
            // 
            // lblSahaDeger
            // 
            this.lblSahaDeger.AutoSize = true;
            this.lblSahaDeger.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSahaDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblSahaDeger.Location = new System.Drawing.Point(145, 48);
            this.lblSahaDeger.Name = "lblSahaDeger";
            this.lblSahaDeger.Size = new System.Drawing.Size(15, 19);
            this.lblSahaDeger.TabIndex = 2;
            this.lblSahaDeger.Text = "-";
            // 
            // lblAdresLabel
            // 
            this.lblAdresLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAdresLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAdresLabel.Location = new System.Drawing.Point(16, 74);
            this.lblAdresLabel.Name = "lblAdresLabel";
            this.lblAdresLabel.Size = new System.Drawing.Size(125, 22);
            this.lblAdresLabel.TabIndex = 3;
            this.lblAdresLabel.Text = "📍 Adres:";
            // 
            // lblAdresDeger
            // 
            this.lblAdresDeger.AutoSize = true;
            this.lblAdresDeger.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAdresDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblAdresDeger.Location = new System.Drawing.Point(145, 74);
            this.lblAdresDeger.Name = "lblAdresDeger";
            this.lblAdresDeger.Size = new System.Drawing.Size(15, 19);
            this.lblAdresDeger.TabIndex = 4;
            this.lblAdresDeger.Text = "-";
            // 
            // lblTarihLabel
            // 
            this.lblTarihLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTarihLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTarihLabel.Location = new System.Drawing.Point(16, 100);
            this.lblTarihLabel.Name = "lblTarihLabel";
            this.lblTarihLabel.Size = new System.Drawing.Size(125, 22);
            this.lblTarihLabel.TabIndex = 5;
            this.lblTarihLabel.Text = "📅 Tarih:";
            // 
            // lblTarihDeger
            // 
            this.lblTarihDeger.AutoSize = true;
            this.lblTarihDeger.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTarihDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTarihDeger.Location = new System.Drawing.Point(145, 100);
            this.lblTarihDeger.Name = "lblTarihDeger";
            this.lblTarihDeger.Size = new System.Drawing.Size(15, 19);
            this.lblTarihDeger.TabIndex = 6;
            this.lblTarihDeger.Text = "-";
            // 
            // lblSaatLabel
            // 
            this.lblSaatLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSaatLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSaatLabel.Location = new System.Drawing.Point(16, 126);
            this.lblSaatLabel.Name = "lblSaatLabel";
            this.lblSaatLabel.Size = new System.Drawing.Size(125, 22);
            this.lblSaatLabel.TabIndex = 7;
            this.lblSaatLabel.Text = "🕐 Saat:";
            // 
            // lblSaatDeger
            // 
            this.lblSaatDeger.AutoSize = true;
            this.lblSaatDeger.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSaatDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblSaatDeger.Location = new System.Drawing.Point(145, 126);
            this.lblSaatDeger.Name = "lblSaatDeger";
            this.lblSaatDeger.Size = new System.Drawing.Size(15, 19);
            this.lblSaatDeger.TabIndex = 8;
            this.lblSaatDeger.Text = "-";
            // 
            // lblFiyatLabel
            // 
            this.lblFiyatLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFiyatLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblFiyatLabel.Location = new System.Drawing.Point(16, 152);
            this.lblFiyatLabel.Name = "lblFiyatLabel";
            this.lblFiyatLabel.Size = new System.Drawing.Size(125, 22);
            this.lblFiyatLabel.TabIndex = 9;
            this.lblFiyatLabel.Text = "💰 Fiyat:";
            // 
            // lblFiyatDeger
            // 
            this.lblFiyatDeger.AutoSize = true;
            this.lblFiyatDeger.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFiyatDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblFiyatDeger.Location = new System.Drawing.Point(145, 152);
            this.lblFiyatDeger.Name = "lblFiyatDeger";
            this.lblFiyatDeger.Size = new System.Drawing.Size(15, 19);
            this.lblFiyatDeger.TabIndex = 10;
            this.lblFiyatDeger.Text = "-";
            // 
            // pnlMisafir
            // 
            this.pnlMisafir.BackColor = System.Drawing.Color.White;
            this.pnlMisafir.Controls.Add(this.lblMisafirBaslik);
            this.pnlMisafir.Controls.Add(this.lblMisafirUyari);
            this.pnlMisafir.Controls.Add(this.lblMisafirAdLabel);
            this.pnlMisafir.Controls.Add(this.txtMisafirAd);
            this.pnlMisafir.Controls.Add(this.lblMisafirTelLabel);
            this.pnlMisafir.Controls.Add(this.txtMisafirTelefon);
            this.pnlMisafir.Location = new System.Drawing.Point(35, 226);
            this.pnlMisafir.Name = "pnlMisafir";
            this.pnlMisafir.Size = new System.Drawing.Size(568, 160);
            this.pnlMisafir.TabIndex = 1;
            this.pnlMisafir.Visible = false;
            this.pnlMisafir.Paint += new System.Windows.Forms.PaintEventHandler(this.Pnl_PaintBorder);
            // 
            // lblMisafirBaslik
            // 
            this.lblMisafirBaslik.AutoSize = true;
            this.lblMisafirBaslik.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblMisafirBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.lblMisafirBaslik.Location = new System.Drawing.Point(16, 12);
            this.lblMisafirBaslik.Name = "lblMisafirBaslik";
            this.lblMisafirBaslik.Size = new System.Drawing.Size(180, 25);
            this.lblMisafirBaslik.TabIndex = 0;
            this.lblMisafirBaslik.Text = "👤 İletişim Bilgileri";
            // 
            // lblMisafirUyari
            // 
            this.lblMisafirUyari.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblMisafirUyari.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.lblMisafirUyari.Location = new System.Drawing.Point(16, 42);
            this.lblMisafirUyari.Name = "lblMisafirUyari";
            this.lblMisafirUyari.Size = new System.Drawing.Size(536, 18);
            this.lblMisafirUyari.TabIndex = 1;
            this.lblMisafirUyari.Text = "⚠  Organizatör sizinle iletişime geçebilmek için bu bilgilere ihtiyaç duyar.";
            // 
            // lblMisafirAdLabel
            // 
            this.lblMisafirAdLabel.AutoSize = true;
            this.lblMisafirAdLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMisafirAdLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblMisafirAdLabel.Location = new System.Drawing.Point(16, 70);
            this.lblMisafirAdLabel.Name = "lblMisafirAdLabel";
            this.lblMisafirAdLabel.Size = new System.Drawing.Size(77, 19);
            this.lblMisafirAdLabel.TabIndex = 2;
            this.lblMisafirAdLabel.Text = "Ad Soyad:";
            // 
            // txtMisafirAd
            // 
            this.txtMisafirAd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMisafirAd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMisafirAd.Location = new System.Drawing.Point(130, 66);
            this.txtMisafirAd.Name = "txtMisafirAd";
            this.txtMisafirAd.Size = new System.Drawing.Size(420, 25);
            this.txtMisafirAd.TabIndex = 3;
            // 
            // lblMisafirTelLabel
            // 
            this.lblMisafirTelLabel.AutoSize = true;
            this.lblMisafirTelLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMisafirTelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblMisafirTelLabel.Location = new System.Drawing.Point(16, 110);
            this.lblMisafirTelLabel.Name = "lblMisafirTelLabel";
            this.lblMisafirTelLabel.Size = new System.Drawing.Size(62, 19);
            this.lblMisafirTelLabel.TabIndex = 4;
            this.lblMisafirTelLabel.Text = "Telefon:";
            // 
            // txtMisafirTelefon
            // 
            this.txtMisafirTelefon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMisafirTelefon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMisafirTelefon.Location = new System.Drawing.Point(130, 106);
            this.txtMisafirTelefon.Name = "txtMisafirTelefon";
            this.txtMisafirTelefon.Size = new System.Drawing.Size(420, 25);
            this.txtMisafirTelefon.TabIndex = 5;
            // 
            // lblAktifKullanici
            // 
            this.lblAktifKullanici.AutoSize = true;
            this.lblAktifKullanici.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAktifKullanici.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAktifKullanici.Location = new System.Drawing.Point(35, 226);
            this.lblAktifKullanici.Name = "lblAktifKullanici";
            this.lblAktifKullanici.Size = new System.Drawing.Size(126, 19);
            this.lblAktifKullanici.TabIndex = 2;
            this.lblAktifKullanici.Text = "👤 Kullanıcı adına...";
            this.lblAktifKullanici.Visible = false;
            // 
            // lblHata
            // 
            this.lblHata.AutoSize = true;
            this.lblHata.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHata.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblHata.Location = new System.Drawing.Point(35, 260);
            this.lblHata.Name = "lblHata";
            this.lblHata.Size = new System.Drawing.Size(33, 15);
            this.lblHata.TabIndex = 3;
            this.lblHata.Text = "Hata";
            this.lblHata.Visible = false;
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
            this.btnGeri.Location = new System.Drawing.Point(35, 290);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(170, 46);
            this.btnGeri.TabIndex = 4;
            this.btnGeri.Text = "← Geri Dön";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.BtnGeri_Click);
            // 
            // btnOnayla
            // 
            this.btnOnayla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnOnayla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOnayla.FlatAppearance.BorderSize = 0;
            this.btnOnayla.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnOnayla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnayla.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOnayla.ForeColor = System.Drawing.Color.White;
            this.btnOnayla.Location = new System.Drawing.Point(225, 290);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(270, 46);
            this.btnOnayla.TabIndex = 5;
            this.btnOnayla.Text = "✅  Onayla ve Kaydet";
            this.btnOnayla.UseVisualStyleBackColor = false;
            this.btnOnayla.Click += new System.EventHandler(this.BtnOnayla_Click);
            // 
            // FormRezervasyonOnay
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(640, 600);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormRezervasyonOnay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SahalarBurada — Rezervasyon Onayı";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();
            this.pnlDetay.ResumeLayout(false);
            this.pnlDetay.PerformLayout();
            this.pnlMisafir.ResumeLayout(false);
            this.pnlMisafir.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
