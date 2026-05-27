namespace SahalarBurada.Forms
{
    partial class FormKiraciDetay
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.pnlKart = new System.Windows.Forms.Panel();
            this.lblKiralayanTitle = new System.Windows.Forms.Label();
            this.lblAdSoyadLabel = new System.Windows.Forms.Label();
            this.lblAdSoyadValue = new System.Windows.Forms.Label();
            this.lblContactLabel = new System.Windows.Forms.Label();
            this.lblContactValue = new System.Windows.Forms.Label();
            this.lblTypeLabel = new System.Windows.Forms.Label();
            this.lblTypeValue = new System.Windows.Forms.Label();
            this.lblDateLabel = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.lblRezervasyonTitle = new System.Windows.Forms.Label();
            this.lblSahaLabel = new System.Windows.Forms.Label();
            this.lblSahaValue = new System.Windows.Forms.Label();
            this.lblTarihLabel = new System.Windows.Forms.Label();
            this.lblTarihValue = new System.Windows.Forms.Label();
            this.lblSaatLabel = new System.Windows.Forms.Label();
            this.lblSaatValue = new System.Windows.Forms.Label();
            this.lblUcretLabel = new System.Windows.Forms.Label();
            this.lblUcretValue = new System.Windows.Forms.Label();
            this.btnGeri = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlKart.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(30)))));
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(585, 95);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(25, 18);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(260, 30);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "👤 Kiracı Detay Bilgileri";
            // 
            // lblHeaderSubtitle
            // 
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(27, 54);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(217, 15);
            this.lblHeaderSubtitle.TabIndex = 1;
            this.lblHeaderSubtitle.Text = "Rezervasyon sahibi veya misafir bilgileri.";
            // 
            // pnlKart
            // 
            this.pnlKart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(252)))));
            this.pnlKart.Controls.Add(this.lblKiralayanTitle);
            this.pnlKart.Controls.Add(this.lblAdSoyadLabel);
            this.pnlKart.Controls.Add(this.lblAdSoyadValue);
            this.pnlKart.Controls.Add(this.lblContactLabel);
            this.pnlKart.Controls.Add(this.lblContactValue);
            this.pnlKart.Controls.Add(this.lblTypeLabel);
            this.pnlKart.Controls.Add(this.lblTypeValue);
            this.pnlKart.Controls.Add(this.lblDateLabel);
            this.pnlKart.Controls.Add(this.lblDateValue);
            this.pnlKart.Controls.Add(this.lblRezervasyonTitle);
            this.pnlKart.Controls.Add(this.lblSahaLabel);
            this.pnlKart.Controls.Add(this.lblSahaValue);
            this.pnlKart.Controls.Add(this.lblTarihLabel);
            this.pnlKart.Controls.Add(this.lblTarihValue);
            this.pnlKart.Controls.Add(this.lblSaatLabel);
            this.pnlKart.Controls.Add(this.lblSaatValue);
            this.pnlKart.Controls.Add(this.lblUcretLabel);
            this.pnlKart.Controls.Add(this.lblUcretValue);
            this.pnlKart.Location = new System.Drawing.Point(35, 120);
            this.pnlKart.Name = "pnlKart";
            this.pnlKart.Size = new System.Drawing.Size(515, 290);
            this.pnlKart.TabIndex = 1;
            // 
            // lblKiralayanTitle
            // 
            this.lblKiralayanTitle.AutoSize = true;
            this.lblKiralayanTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblKiralayanTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(28)))));
            this.lblKiralayanTitle.Location = new System.Drawing.Point(20, 20);
            this.lblKiralayanTitle.Name = "lblKiralayanTitle";
            this.lblKiralayanTitle.Size = new System.Drawing.Size(193, 25);
            this.lblKiralayanTitle.TabIndex = 0;
            this.lblKiralayanTitle.Text = "👤 Kiralayan Bilgileri";
            // 
            // lblAdSoyadLabel
            // 
            this.lblAdSoyadLabel.AutoSize = true;
            this.lblAdSoyadLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAdSoyadLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(110)))), ((int)(((byte)(95)))));
            this.lblAdSoyadLabel.Location = new System.Drawing.Point(20, 55);
            this.lblAdSoyadLabel.Name = "lblAdSoyadLabel";
            this.lblAdSoyadLabel.Size = new System.Drawing.Size(63, 15);
            this.lblAdSoyadLabel.TabIndex = 1;
            this.lblAdSoyadLabel.Text = "Adı Soyadı";
            // 
            // lblAdSoyadValue
            // 
            this.lblAdSoyadValue.AutoSize = true;
            this.lblAdSoyadValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAdSoyadValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(28)))));
            this.lblAdSoyadValue.Location = new System.Drawing.Point(20, 75);
            this.lblAdSoyadValue.Name = "lblAdSoyadValue";
            this.lblAdSoyadValue.Size = new System.Drawing.Size(102, 19);
            this.lblAdSoyadValue.TabIndex = 2;
            this.lblAdSoyadValue.Text = "Ahmet Yılmaz";
            // 
            // lblContactLabel
            // 
            this.lblContactLabel.AutoSize = true;
            this.lblContactLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblContactLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(110)))), ((int)(((byte)(95)))));
            this.lblContactLabel.Location = new System.Drawing.Point(20, 115);
            this.lblContactLabel.Name = "lblContactLabel";
            this.lblContactLabel.Size = new System.Drawing.Size(83, 15);
            this.lblContactLabel.TabIndex = 3;
            this.lblContactLabel.Text = "E-posta Adresi";
            // 
            // lblContactValue
            // 
            this.lblContactValue.AutoSize = true;
            this.lblContactValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblContactValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(28)))));
            this.lblContactValue.Location = new System.Drawing.Point(20, 135);
            this.lblContactValue.Name = "lblContactValue";
            this.lblContactValue.Size = new System.Drawing.Size(135, 19);
            this.lblContactValue.TabIndex = 4;
            this.lblContactValue.Text = "ahmet@gmail.com";
            // 
            // lblTypeLabel
            // 
            this.lblTypeLabel.AutoSize = true;
            this.lblTypeLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTypeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(110)))), ((int)(((byte)(95)))));
            this.lblTypeLabel.Location = new System.Drawing.Point(20, 175);
            this.lblTypeLabel.Name = "lblTypeLabel";
            this.lblTypeLabel.Size = new System.Drawing.Size(86, 15);
            this.lblTypeLabel.TabIndex = 5;
            this.lblTypeLabel.Text = "Üyelik Durumu";
            // 
            // lblTypeValue
            // 
            this.lblTypeValue.AutoSize = true;
            this.lblTypeValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTypeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(30)))));
            this.lblTypeValue.Location = new System.Drawing.Point(20, 195);
            this.lblTypeValue.Name = "lblTypeValue";
            this.lblTypeValue.Size = new System.Drawing.Size(182, 19);
            this.lblTypeValue.TabIndex = 6;
            this.lblTypeValue.Text = "Kayıtlı Üye (Hesap Sahibi)";
            // 
            // lblDateLabel
            // 
            this.lblDateLabel.AutoSize = true;
            this.lblDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(110)))), ((int)(((byte)(95)))));
            this.lblDateLabel.Location = new System.Drawing.Point(20, 235);
            this.lblDateLabel.Name = "lblDateLabel";
            this.lblDateLabel.Size = new System.Drawing.Size(109, 15);
            this.lblDateLabel.TabIndex = 7;
            this.lblDateLabel.Text = "Sisteme Kayıt Tarihi";
            // 
            // lblDateValue
            // 
            this.lblDateValue.AutoSize = true;
            this.lblDateValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(28)))));
            this.lblDateValue.Location = new System.Drawing.Point(20, 255);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(104, 19);
            this.lblDateValue.TabIndex = 8;
            this.lblDateValue.Text = "25 Mayıs 2026";
            // 
            // lblRezervasyonTitle
            // 
            this.lblRezervasyonTitle.AutoSize = true;
            this.lblRezervasyonTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblRezervasyonTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(28)))));
            this.lblRezervasyonTitle.Location = new System.Drawing.Point(275, 20);
            this.lblRezervasyonTitle.Name = "lblRezervasyonTitle";
            this.lblRezervasyonTitle.Size = new System.Drawing.Size(222, 25);
            this.lblRezervasyonTitle.TabIndex = 9;
            this.lblRezervasyonTitle.Text = "⚽ Rezervasyon Bilgileri";
            // 
            // lblSahaLabel
            // 
            this.lblSahaLabel.AutoSize = true;
            this.lblSahaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSahaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(110)))), ((int)(((byte)(95)))));
            this.lblSahaLabel.Location = new System.Drawing.Point(275, 55);
            this.lblSahaLabel.Name = "lblSahaLabel";
            this.lblSahaLabel.Size = new System.Drawing.Size(53, 15);
            this.lblSahaLabel.TabIndex = 10;
            this.lblSahaLabel.Text = "Saha Adı";
            // 
            // lblSahaValue
            // 
            this.lblSahaValue.AutoSize = true;
            this.lblSahaValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSahaValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(28)))));
            this.lblSahaValue.Location = new System.Drawing.Point(275, 75);
            this.lblSahaValue.Name = "lblSahaValue";
            this.lblSahaValue.Size = new System.Drawing.Size(131, 19);
            this.lblSahaValue.TabIndex = 11;
            this.lblSahaValue.Text = "Turanlar Halı Saha";
            // 
            // lblTarihLabel
            // 
            this.lblTarihLabel.AutoSize = true;
            this.lblTarihLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTarihLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(110)))), ((int)(((byte)(95)))));
            this.lblTarihLabel.Location = new System.Drawing.Point(275, 115);
            this.lblTarihLabel.Name = "lblTarihLabel";
            this.lblTarihLabel.Size = new System.Drawing.Size(104, 15);
            this.lblTarihLabel.TabIndex = 12;
            this.lblTarihLabel.Text = "Rezervasyon Tarihi";
            // 
            // lblTarihValue
            // 
            this.lblTarihValue.AutoSize = true;
            this.lblTarihValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTarihValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(28)))));
            this.lblTarihValue.Location = new System.Drawing.Point(275, 135);
            this.lblTarihValue.Name = "lblTarihValue";
            this.lblTarihValue.Size = new System.Drawing.Size(104, 19);
            this.lblTarihValue.TabIndex = 13;
            this.lblTarihValue.Text = "28 Mayıs 2026";
            // 
            // lblSaatLabel
            // 
            this.lblSaatLabel.AutoSize = true;
            this.lblSaatLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSaatLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(110)))), ((int)(((byte)(95)))));
            this.lblSaatLabel.Location = new System.Drawing.Point(275, 175);
            this.lblSaatLabel.Name = "lblSaatLabel";
            this.lblSaatLabel.Size = new System.Drawing.Size(81, 15);
            this.lblSaatLabel.TabIndex = 14;
            this.lblSaatLabel.Text = "Kiralama Saati";
            // 
            // lblSaatValue
            // 
            this.lblSaatValue.AutoSize = true;
            this.lblSaatValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSaatValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(28)))));
            this.lblSaatValue.Location = new System.Drawing.Point(275, 195);
            this.lblSaatValue.Name = "lblSaatValue";
            this.lblSaatValue.Size = new System.Drawing.Size(87, 19);
            this.lblSaatValue.TabIndex = 15;
            this.lblSaatValue.Text = "17:00-18:00";
            // 
            // lblUcretLabel
            // 
            this.lblUcretLabel.AutoSize = true;
            this.lblUcretLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUcretLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(110)))), ((int)(((byte)(95)))));
            this.lblUcretLabel.Location = new System.Drawing.Point(275, 235);
            this.lblUcretLabel.Name = "lblUcretLabel";
            this.lblUcretLabel.Size = new System.Drawing.Size(91, 15);
            this.lblUcretLabel.TabIndex = 16;
            this.lblUcretLabel.Text = "Ödenecek Ücret";
            this.lblUcretLabel.Click += new System.EventHandler(this.lblUcretLabel_Click);
            // 
            // lblUcretValue
            // 
            this.lblUcretValue.AutoSize = true;
            this.lblUcretValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblUcretValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(30)))));
            this.lblUcretValue.Location = new System.Drawing.Point(275, 255);
            this.lblUcretValue.Name = "lblUcretValue";
            this.lblUcretValue.Size = new System.Drawing.Size(57, 25);
            this.lblUcretValue.TabIndex = 17;
            this.lblUcretValue.Text = "350 ₺";
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(252)))));
            this.btnGeri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeri.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnGeri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGeri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(30)))));
            this.btnGeri.Location = new System.Drawing.Point(210, 430);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(165, 40);
            this.btnGeri.TabIndex = 2;
            this.btnGeri.Text = "⬅  Geri Dön";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.BtnGeri_Click);
            // 
            // FormKiraciDetay
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(585, 495);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.pnlKart);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormKiraciDetay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SahalarBurada — Kiracı Detayları";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlKart.ResumeLayout(false);
            this.pnlKart.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Panel pnlKart;
        private System.Windows.Forms.Label lblKiralayanTitle;
        private System.Windows.Forms.Label lblAdSoyadLabel;
        private System.Windows.Forms.Label lblAdSoyadValue;
        private System.Windows.Forms.Label lblContactLabel;
        private System.Windows.Forms.Label lblContactValue;
        private System.Windows.Forms.Label lblTypeLabel;
        private System.Windows.Forms.Label lblTypeValue;
        private System.Windows.Forms.Label lblDateLabel;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label lblRezervasyonTitle;
        private System.Windows.Forms.Label lblSahaLabel;
        private System.Windows.Forms.Label lblSahaValue;
        private System.Windows.Forms.Label lblTarihLabel;
        private System.Windows.Forms.Label lblTarihValue;
        private System.Windows.Forms.Label lblSaatLabel;
        private System.Windows.Forms.Label lblSaatValue;
        private System.Windows.Forms.Label lblUcretLabel;
        private System.Windows.Forms.Label lblUcretValue;
        private System.Windows.Forms.Button btnGeri;
    }
}
