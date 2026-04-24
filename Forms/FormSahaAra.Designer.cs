using System.Windows.Forms;

namespace SahalarBurada.Forms
{
    partial class FormSahaAra
    {
        private Panel pnlHeader;
        private Label lblHeaderBaslik;
        private Label lblHeaderAltBaslik;
        private Panel pnlContent;
        private Label lblKullanici;
        private Label lblTarih;
        private DateTimePicker dtpTarih;
        private Label lblSaat;
        private ComboBox cmbSaat;
        private Label lblHata;
        private Button btnListele;
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblKullanici = new System.Windows.Forms.Label();
            this.lblTarih = new System.Windows.Forms.Label();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.lblSaat = new System.Windows.Forms.Label();
            this.cmbSaat = new System.Windows.Forms.ComboBox();
            this.lblHata = new System.Windows.Forms.Label();
            this.btnListele = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(540, 95);
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
            this.lblHeaderBaslik.Text = "📅  Saha Ara";
            // 
            // lblHeaderAltBaslik
            // 
            this.lblHeaderAltBaslik.AutoSize = true;
            this.lblHeaderAltBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderAltBaslik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderAltBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHeaderAltBaslik.Location = new System.Drawing.Point(27, 52);
            this.lblHeaderAltBaslik.Name = "lblHeaderAltBaslik";
            this.lblHeaderAltBaslik.Size = new System.Drawing.Size(262, 15);
            this.lblHeaderAltBaslik.TabIndex = 1;
            this.lblHeaderAltBaslik.Text = "Tarih ve saat seçerek müsait sahaları listeleyin";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.pnlContent.Controls.Add(this.lblKullanici);
            this.pnlContent.Controls.Add(this.lblTarih);
            this.pnlContent.Controls.Add(this.dtpTarih);
            this.pnlContent.Controls.Add(this.lblSaat);
            this.pnlContent.Controls.Add(this.cmbSaat);
            this.pnlContent.Controls.Add(this.lblHata);
            this.pnlContent.Controls.Add(this.btnListele);
            this.pnlContent.Controls.Add(this.btnGeri);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(540, 375);
            this.pnlContent.TabIndex = 1;
            // 
            // lblKullanici
            // 
            this.lblKullanici.AutoSize = true;
            this.lblKullanici.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblKullanici.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblKullanici.Location = new System.Drawing.Point(50, 20);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(206, 15);
            this.lblKullanici.TabIndex = 0;
            this.lblKullanici.Text = "👤 Misafir olarak arama yapıyorsunuz";
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTarih.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTarih.Location = new System.Drawing.Point(50, 55);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(84, 19);
            this.lblTarih.TabIndex = 1;
            this.lblTarih.Text = "Tarih Seçin:";
            // 
            // dtpTarih
            // 
            this.dtpTarih.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTarih.Location = new System.Drawing.Point(50, 80);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(440, 25);
            this.dtpTarih.TabIndex = 2;
            // 
            // lblSaat
            // 
            this.lblSaat.AutoSize = true;
            this.lblSaat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSaat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSaat.Location = new System.Drawing.Point(50, 130);
            this.lblSaat.Name = "lblSaat";
            this.lblSaat.Size = new System.Drawing.Size(81, 19);
            this.lblSaat.TabIndex = 3;
            this.lblSaat.Text = "Saat Seçin:";
            // 
            // cmbSaat
            // 
            this.cmbSaat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSaat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSaat.FormattingEnabled = true;
            this.cmbSaat.Location = new System.Drawing.Point(50, 155);
            this.cmbSaat.Name = "cmbSaat";
            this.cmbSaat.Size = new System.Drawing.Size(440, 25);
            this.cmbSaat.TabIndex = 4;
            // 
            // lblHata
            // 
            this.lblHata.AutoSize = true;
            this.lblHata.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHata.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblHata.Location = new System.Drawing.Point(50, 205);
            this.lblHata.Name = "lblHata";
            this.lblHata.Size = new System.Drawing.Size(33, 15);
            this.lblHata.TabIndex = 5;
            this.lblHata.Text = "Hata";
            this.lblHata.Visible = false;
            // 
            // btnListele
            // 
            this.btnListele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnListele.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnListele.FlatAppearance.BorderSize = 0;
            this.btnListele.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListele.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnListele.ForeColor = System.Drawing.Color.White;
            this.btnListele.Location = new System.Drawing.Point(50, 230);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(440, 52);
            this.btnListele.TabIndex = 6;
            this.btnListele.Text = "🔍   Sahaları Listele";
            this.btnListele.UseVisualStyleBackColor = false;
            this.btnListele.Click += new System.EventHandler(this.BtnListele_Click);
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
            this.btnGeri.Location = new System.Drawing.Point(50, 302);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(130, 38);
            this.btnGeri.TabIndex = 7;
            this.btnGeri.Text = "← Geri";
            this.btnGeri.UseVisualStyleBackColor = false;
            // 
            // FormSahaAra
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(540, 470);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSahaAra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SahalarBurada — Saha Ara";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
