using System.Windows.Forms;

namespace SahalarBurada.Forms
{
    partial class FormSahaEkle
    {
        private Panel pnlHeader;
        private Label lblHeaderBaslik;
        private Label lblHeaderAltBaslik;
        
        private Panel pnlScroll;
        private Label lblAd;
        private TextBox txtAd;
        private Label lblAdres;
        private TextBox txtAdres;
        private Label lblKapasite;
        private NumericUpDown nudKapasite;
        private Label lblFiyat;
        private NumericUpDown nudFiyat;
        private Label lblGunler;
        private CheckedListBox clbGunler;
        private Label lblSaatler;
        private CheckedListBox clbSaatler;
        private Label lblAciklama;
        private TextBox txtAciklama;
        private Label lblHata;
        private Button btnGeri;
        private Button btnOzet;

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
            this.lblAd = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.lblAdres = new System.Windows.Forms.Label();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.lblKapasite = new System.Windows.Forms.Label();
            this.nudKapasite = new System.Windows.Forms.NumericUpDown();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.nudFiyat = new System.Windows.Forms.NumericUpDown();
            this.lblGunler = new System.Windows.Forms.Label();
            this.clbGunler = new System.Windows.Forms.CheckedListBox();
            this.lblSaatler = new System.Windows.Forms.Label();
            this.clbSaatler = new System.Windows.Forms.CheckedListBox();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.lblHata = new System.Windows.Forms.Label();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnOzet = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKapasite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFiyat)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(700, 95);
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
            this.lblHeaderBaslik.Size = new System.Drawing.Size(193, 30);
            this.lblHeaderBaslik.TabIndex = 0;
            this.lblHeaderBaslik.Text = "➕  Yeni Saha Ekle";
            // 
            // lblHeaderAltBaslik
            // 
            this.lblHeaderAltBaslik.AutoSize = true;
            this.lblHeaderAltBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderAltBaslik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderAltBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHeaderAltBaslik.Location = new System.Drawing.Point(27, 52);
            this.lblHeaderAltBaslik.Name = "lblHeaderAltBaslik";
            this.lblHeaderAltBaslik.Size = new System.Drawing.Size(227, 15);
            this.lblHeaderAltBaslik.TabIndex = 1;
            this.lblHeaderAltBaslik.Text = "Halı saha bilgilerini eksiksiz doldurun";
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.pnlScroll.Controls.Add(this.lblAd);
            this.pnlScroll.Controls.Add(this.txtAd);
            this.pnlScroll.Controls.Add(this.lblAdres);
            this.pnlScroll.Controls.Add(this.txtAdres);
            this.pnlScroll.Controls.Add(this.lblKapasite);
            this.pnlScroll.Controls.Add(this.nudKapasite);
            this.pnlScroll.Controls.Add(this.lblFiyat);
            this.pnlScroll.Controls.Add(this.nudFiyat);
            this.pnlScroll.Controls.Add(this.lblGunler);
            this.pnlScroll.Controls.Add(this.clbGunler);
            this.pnlScroll.Controls.Add(this.lblSaatler);
            this.pnlScroll.Controls.Add(this.clbSaatler);
            this.pnlScroll.Controls.Add(this.lblAciklama);
            this.pnlScroll.Controls.Add(this.txtAciklama);
            this.pnlScroll.Controls.Add(this.lblHata);
            this.pnlScroll.Controls.Add(this.btnGeri);
            this.pnlScroll.Controls.Add(this.btnOzet);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 95);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(700, 685);
            this.pnlScroll.TabIndex = 1;
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAd.Location = new System.Drawing.Point(32, 18);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(84, 19);
            this.lblAd.TabIndex = 0;
            this.lblAd.Text = "Saha Adı: *";
            // 
            // txtAd
            // 
            this.txtAd.BackColor = System.Drawing.Color.White;
            this.txtAd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtAd.Location = new System.Drawing.Point(32, 44);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(636, 25);
            this.txtAd.TabIndex = 1;
            // 
            // lblAdres
            // 
            this.lblAdres.AutoSize = true;
            this.lblAdres.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAdres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAdres.Location = new System.Drawing.Point(32, 90);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(68, 19);
            this.lblAdres.TabIndex = 2;
            this.lblAdres.Text = "Adres: *";
            // 
            // txtAdres
            // 
            this.txtAdres.BackColor = System.Drawing.Color.White;
            this.txtAdres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdres.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAdres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtAdres.Location = new System.Drawing.Point(32, 116);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(636, 25);
            this.txtAdres.TabIndex = 3;
            // 
            // lblKapasite
            // 
            this.lblKapasite.AutoSize = true;
            this.lblKapasite.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKapasite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblKapasite.Location = new System.Drawing.Point(32, 162);
            this.lblKapasite.Name = "lblKapasite";
            this.lblKapasite.Size = new System.Drawing.Size(127, 19);
            this.lblKapasite.TabIndex = 4;
            this.lblKapasite.Text = "Kapasite (kişi): *";
            // 
            // nudKapasite
            // 
            this.nudKapasite.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudKapasite.Location = new System.Drawing.Point(32, 188);
            this.nudKapasite.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.nudKapasite.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            this.nudKapasite.Name = "nudKapasite";
            this.nudKapasite.Size = new System.Drawing.Size(295, 25);
            this.nudKapasite.TabIndex = 5;
            this.nudKapasite.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFiyat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblFiyat.Location = new System.Drawing.Point(349, 162);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(124, 19);
            this.lblFiyat.TabIndex = 6;
            this.lblFiyat.Text = "Fiyat / Saat (₺): *";
            // 
            // nudFiyat
            // 
            this.nudFiyat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudFiyat.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            this.nudFiyat.Location = new System.Drawing.Point(349, 188);
            this.nudFiyat.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.nudFiyat.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            this.nudFiyat.Name = "nudFiyat";
            this.nudFiyat.Size = new System.Drawing.Size(295, 25);
            this.nudFiyat.TabIndex = 7;
            this.nudFiyat.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // lblGunler
            // 
            this.lblGunler.AutoSize = true;
            this.lblGunler.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGunler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblGunler.Location = new System.Drawing.Point(32, 237);
            this.lblGunler.Name = "lblGunler";
            this.lblGunler.Size = new System.Drawing.Size(117, 19);
            this.lblGunler.TabIndex = 8;
            this.lblGunler.Text = "Müsait Günler: *";
            // 
            // clbGunler
            // 
            this.clbGunler.BackColor = System.Drawing.Color.White;
            this.clbGunler.CheckOnClick = true;
            this.clbGunler.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.clbGunler.FormattingEnabled = true;
            this.clbGunler.Location = new System.Drawing.Point(32, 263);
            this.clbGunler.Name = "clbGunler";
            this.clbGunler.Size = new System.Drawing.Size(295, 148);
            this.clbGunler.TabIndex = 9;
            // 
            // lblSaatler
            // 
            this.lblSaatler.AutoSize = true;
            this.lblSaatler.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSaatler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSaatler.Location = new System.Drawing.Point(349, 237);
            this.lblSaatler.Name = "lblSaatler";
            this.lblSaatler.Size = new System.Drawing.Size(119, 19);
            this.lblSaatler.TabIndex = 10;
            this.lblSaatler.Text = "Müsait Saatler: *";
            // 
            // clbSaatler
            // 
            this.clbSaatler.BackColor = System.Drawing.Color.White;
            this.clbSaatler.CheckOnClick = true;
            this.clbSaatler.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.clbSaatler.FormattingEnabled = true;
            this.clbSaatler.Location = new System.Drawing.Point(349, 263);
            this.clbSaatler.Name = "clbSaatler";
            this.clbSaatler.Size = new System.Drawing.Size(295, 148);
            this.clbSaatler.TabIndex = 11;
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAciklama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAciklama.Location = new System.Drawing.Point(32, 432);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(75, 19);
            this.lblAciklama.TabIndex = 12;
            this.lblAciklama.Text = "Açıklama:";
            // 
            // txtAciklama
            // 
            this.txtAciklama.BackColor = System.Drawing.Color.White;
            this.txtAciklama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAciklama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAciklama.Location = new System.Drawing.Point(32, 458);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAciklama.Size = new System.Drawing.Size(636, 80);
            this.txtAciklama.TabIndex = 13;
            // 
            // lblHata
            // 
            this.lblHata.AutoSize = true;
            this.lblHata.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHata.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblHata.Location = new System.Drawing.Point(32, 554);
            this.lblHata.Name = "lblHata";
            this.lblHata.Size = new System.Drawing.Size(33, 15);
            this.lblHata.TabIndex = 14;
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
            this.btnGeri.Location = new System.Drawing.Point(32, 580);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(145, 44);
            this.btnGeri.TabIndex = 15;
            this.btnGeri.Text = "← Geri";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.BtnGeri_Click);
            // 
            // btnOzet
            // 
            this.btnOzet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnOzet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOzet.FlatAppearance.BorderSize = 0;
            this.btnOzet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnOzet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOzet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOzet.ForeColor = System.Drawing.Color.White;
            this.btnOzet.Location = new System.Drawing.Point(192, 580);
            this.btnOzet.Name = "btnOzet";
            this.btnOzet.Size = new System.Drawing.Size(300, 44);
            this.btnOzet.TabIndex = 16;
            this.btnOzet.Text = "📄  Form Özetini Görüntüle";
            this.btnOzet.UseVisualStyleBackColor = false;
            this.btnOzet.Click += new System.EventHandler(this.BtnOzet_Click);
            // 
            // FormSahaEkle
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(700, 780);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSahaEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SahalarBurada — Yeni Saha Ekle";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKapasite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFiyat)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
