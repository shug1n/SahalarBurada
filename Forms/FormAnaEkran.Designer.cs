using System.Windows.Forms;

namespace SahalarBurada.Forms
{
    partial class FormAnaEkran
    {
        private Panel pnlHeader;
        private Label lblLogo;
        private Label lblSlogan;
        private TableLayoutPanel tblCards;
        private Panel pnlKiraci;
        private Panel pnlOrg;
        private Panel pnlKiraciSep;
        private Panel pnlOrgSep;
        private Label lblKiraciIkon;
        private Label lblKiraciBaslik;
        private Label lblKiraciAciklama;
        private Button btnMacAra;
        private Button btnKiraciGiris;
        private Label lblOrgIkon;
        private Label lblOrgBaslik;
        private Label lblOrgAciklama;
        private Button btnOrgGiris;
        private Label lblOrgNot;
        private Label lblOrgDemo;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Tasarımcı tarafından oluşturulan bu yöntem — yalnızca form boyutunu tanımlar.
        /// Tüm kontrol kodları FormAnaEkran.cs → SetupUI() içindedir.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblSlogan = new System.Windows.Forms.Label();
            this.tblCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKiraci = new System.Windows.Forms.Panel();
            this.lblKiraciIkon = new System.Windows.Forms.Label();
            this.lblKiraciBaslik = new System.Windows.Forms.Label();
            this.lblKiraciAciklama = new System.Windows.Forms.Label();
            this.pnlKiraciSep = new System.Windows.Forms.Panel();
            this.btnMacAra = new System.Windows.Forms.Button();
            this.btnKiraciGiris = new System.Windows.Forms.Button();
            this.pnlOrg = new System.Windows.Forms.Panel();
            this.lblOrgIkon = new System.Windows.Forms.Label();
            this.lblOrgBaslik = new System.Windows.Forms.Label();
            this.lblOrgAciklama = new System.Windows.Forms.Label();
            this.pnlOrgSep = new System.Windows.Forms.Panel();
            this.btnOrgGiris = new System.Windows.Forms.Button();
            this.lblOrgNot = new System.Windows.Forms.Label();
            this.lblOrgDemo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tblCards.SuspendLayout();
            this.pnlKiraci.SuspendLayout();
            this.pnlOrg.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.pnlHeader.Controls.Add(this.lblLogo);
            this.pnlHeader.Controls.Add(this.lblSlogan);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1020, 155);
            this.pnlHeader.TabIndex = 1;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlHeader_Paint);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(38, 28);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(377, 59);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "⚽SahalarBurada";
            // 
            // lblSlogan
            // 
            this.lblSlogan.AutoSize = true;
            this.lblSlogan.BackColor = System.Drawing.Color.Transparent;
            this.lblSlogan.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.lblSlogan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblSlogan.Location = new System.Drawing.Point(65, 87);
            this.lblSlogan.Name = "lblSlogan";
            this.lblSlogan.Size = new System.Drawing.Size(328, 21);
            this.lblSlogan.TabIndex = 1;
            this.lblSlogan.Text = "Türkiye\'nin Hızlı Halı Saha Kiralama Platformu";
            // 
            // tblCards
            // 
            this.tblCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.tblCards.ColumnCount = 2;
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCards.Controls.Add(this.pnlKiraci, 0, 0);
            this.tblCards.Controls.Add(this.pnlOrg, 1, 0);
            this.tblCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCards.Location = new System.Drawing.Point(0, 155);
            this.tblCards.Name = "tblCards";
            this.tblCards.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);
            this.tblCards.RowCount = 1;
            this.tblCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblCards.Size = new System.Drawing.Size(1020, 535);
            this.tblCards.TabIndex = 0;
            // 
            // pnlKiraci
            // 
            this.pnlKiraci.BackColor = System.Drawing.Color.White;
            this.pnlKiraci.Controls.Add(this.label1);
            this.pnlKiraci.Controls.Add(this.lblKiraciIkon);
            this.pnlKiraci.Controls.Add(this.lblKiraciBaslik);
            this.pnlKiraci.Controls.Add(this.lblKiraciAciklama);
            this.pnlKiraci.Controls.Add(this.pnlKiraciSep);
            this.pnlKiraci.Controls.Add(this.btnMacAra);
            this.pnlKiraci.Controls.Add(this.btnKiraciGiris);
            this.pnlKiraci.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKiraci.Location = new System.Drawing.Point(40, 30);
            this.pnlKiraci.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlKiraci.Name = "pnlKiraci";
            this.pnlKiraci.Size = new System.Drawing.Size(456, 475);
            this.pnlKiraci.TabIndex = 0;
            this.pnlKiraci.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintKartKenar);
            // 
            // lblKiraciIkon
            // 
            this.lblKiraciIkon.AutoSize = true;
            this.lblKiraciIkon.BackColor = System.Drawing.Color.Transparent;
            this.lblKiraciIkon.Font = new System.Drawing.Font("Segoe UI Emoji", 36F);
            this.lblKiraciIkon.Location = new System.Drawing.Point(35, 30);
            this.lblKiraciIkon.Name = "lblKiraciIkon";
            this.lblKiraciIkon.Size = new System.Drawing.Size(93, 64);
            this.lblKiraciIkon.TabIndex = 0;
            this.lblKiraciIkon.Text = "🧑‍🤝‍🧑";
            // 
            // lblKiraciBaslik
            // 
            this.lblKiraciBaslik.AutoSize = true;
            this.lblKiraciBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKiraciBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.lblKiraciBaslik.Location = new System.Drawing.Point(35, 108);
            this.lblKiraciBaslik.Name = "lblKiraciBaslik";
            this.lblKiraciBaslik.Size = new System.Drawing.Size(174, 30);
            this.lblKiraciBaslik.TabIndex = 1;
            this.lblKiraciBaslik.Text = "Halı Saha Kirala";
            // 
            // lblKiraciAciklama
            // 
            this.lblKiraciAciklama.AutoSize = true;
            this.lblKiraciAciklama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKiraciAciklama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblKiraciAciklama.Location = new System.Drawing.Point(35, 148);
            this.lblKiraciAciklama.MaximumSize = new System.Drawing.Size(340, 0);
            this.lblKiraciAciklama.Name = "lblKiraciAciklama";
            this.lblKiraciAciklama.Size = new System.Drawing.Size(318, 57);
            this.lblKiraciAciklama.TabIndex = 2;
            this.lblKiraciAciklama.Text = "Müsait sahaları kolayca bul ve hemen rezervasyon yap.\nGiriş yapmadan da saha aray" +
    "abilirsin!";
            // 
            // pnlKiraciSep
            // 
            this.pnlKiraciSep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            this.pnlKiraciSep.Location = new System.Drawing.Point(35, 215);
            this.pnlKiraciSep.Name = "pnlKiraciSep";
            this.pnlKiraciSep.Size = new System.Drawing.Size(340, 1);
            this.pnlKiraciSep.TabIndex = 3;
            // 
            // btnMacAra
            // 
            this.btnMacAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnMacAra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMacAra.FlatAppearance.BorderSize = 0;
            this.btnMacAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMacAra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMacAra.ForeColor = System.Drawing.Color.White;
            this.btnMacAra.Location = new System.Drawing.Point(35, 232);
            this.btnMacAra.Name = "btnMacAra";
            this.btnMacAra.Size = new System.Drawing.Size(350, 50);
            this.btnMacAra.TabIndex = 4;
            this.btnMacAra.Text = "⚽   Maç Ara / Kirala  (Giriş Gerektirmez)";
            this.btnMacAra.UseVisualStyleBackColor = false;
            this.btnMacAra.Click += new System.EventHandler(this.BtnMacAra_Click);
            // 
            // btnKiraciGiris
            // 
            this.btnKiraciGiris.BackColor = System.Drawing.Color.White;
            this.btnKiraciGiris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKiraciGiris.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnKiraciGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiraciGiris.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKiraciGiris.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnKiraciGiris.Location = new System.Drawing.Point(35, 298);
            this.btnKiraciGiris.Name = "btnKiraciGiris";
            this.btnKiraciGiris.Size = new System.Drawing.Size(350, 44);
            this.btnKiraciGiris.TabIndex = 5;
            this.btnKiraciGiris.Text = "👤   Giriş Yap / Kayıt Ol";
            this.btnKiraciGiris.UseVisualStyleBackColor = false;
            this.btnKiraciGiris.Click += new System.EventHandler(this.BtnKiraciGiris_Click);
            // 
            // pnlOrg
            // 
            this.pnlOrg.BackColor = System.Drawing.Color.White;
            this.pnlOrg.Controls.Add(this.lblOrgIkon);
            this.pnlOrg.Controls.Add(this.lblOrgBaslik);
            this.pnlOrg.Controls.Add(this.lblOrgAciklama);
            this.pnlOrg.Controls.Add(this.pnlOrgSep);
            this.pnlOrg.Controls.Add(this.btnOrgGiris);
            this.pnlOrg.Controls.Add(this.lblOrgNot);
            this.pnlOrg.Controls.Add(this.lblOrgDemo);
            this.pnlOrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrg.Location = new System.Drawing.Point(524, 30);
            this.pnlOrg.Margin = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.pnlOrg.Name = "pnlOrg";
            this.pnlOrg.Size = new System.Drawing.Size(456, 475);
            this.pnlOrg.TabIndex = 1;
            this.pnlOrg.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintKartKenar);
            // 
            // lblOrgIkon
            // 
            this.lblOrgIkon.AutoSize = true;
            this.lblOrgIkon.BackColor = System.Drawing.Color.Transparent;
            this.lblOrgIkon.Font = new System.Drawing.Font("Segoe UI Emoji", 36F);
            this.lblOrgIkon.Location = new System.Drawing.Point(35, 30);
            this.lblOrgIkon.Name = "lblOrgIkon";
            this.lblOrgIkon.Size = new System.Drawing.Size(93, 64);
            this.lblOrgIkon.TabIndex = 0;
            this.lblOrgIkon.Text = "🏢";
            // 
            // lblOrgBaslik
            // 
            this.lblOrgBaslik.AutoSize = true;
            this.lblOrgBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblOrgBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.lblOrgBaslik.Location = new System.Drawing.Point(35, 108);
            this.lblOrgBaslik.Name = "lblOrgBaslik";
            this.lblOrgBaslik.Size = new System.Drawing.Size(229, 30);
            this.lblOrgBaslik.TabIndex = 1;
            this.lblOrgBaslik.Text = "İşletme / Saha Sahibi";
            // 
            // lblOrgAciklama
            // 
            this.lblOrgAciklama.AutoSize = true;
            this.lblOrgAciklama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOrgAciklama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblOrgAciklama.Location = new System.Drawing.Point(35, 148);
            this.lblOrgAciklama.MaximumSize = new System.Drawing.Size(340, 0);
            this.lblOrgAciklama.Name = "lblOrgAciklama";
            this.lblOrgAciklama.Size = new System.Drawing.Size(332, 38);
            this.lblOrgAciklama.TabIndex = 2;
            this.lblOrgAciklama.Text = "Halı sahanızı sisteme ekleyin, rezervasyonları yönetin ve gelirinizi artırın.";
            // 
            // pnlOrgSep
            // 
            this.pnlOrgSep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            this.pnlOrgSep.Location = new System.Drawing.Point(35, 215);
            this.pnlOrgSep.Name = "pnlOrgSep";
            this.pnlOrgSep.Size = new System.Drawing.Size(340, 1);
            this.pnlOrgSep.TabIndex = 3;
            // 
            // btnOrgGiris
            // 
            this.btnOrgGiris.BackColor = System.Drawing.Color.White;
            this.btnOrgGiris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrgGiris.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnOrgGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrgGiris.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOrgGiris.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnOrgGiris.Location = new System.Drawing.Point(35, 232);
            this.btnOrgGiris.Name = "btnOrgGiris";
            this.btnOrgGiris.Size = new System.Drawing.Size(350, 44);
            this.btnOrgGiris.TabIndex = 4;
            this.btnOrgGiris.Text = "🏢   Giriş Yap / Kayıt Ol";
            this.btnOrgGiris.UseVisualStyleBackColor = false;
            this.btnOrgGiris.Click += new System.EventHandler(this.BtnOrgGiris_Click);
            // 
            // lblOrgNot
            // 
            this.lblOrgNot.AutoSize = true;
            this.lblOrgNot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblOrgNot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblOrgNot.Location = new System.Drawing.Point(35, 290);
            this.lblOrgNot.Name = "lblOrgNot";
            this.lblOrgNot.Size = new System.Drawing.Size(237, 15);
            this.lblOrgNot.TabIndex = 5;
            this.lblOrgNot.Text = "Tamamen ücretsiz ve komisyonsuz platform.";
            // 
            // lblOrgDemo
            // 
            this.lblOrgDemo.AutoSize = true;
            this.lblOrgDemo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblOrgDemo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblOrgDemo.Location = new System.Drawing.Point(35, 310);
            this.lblOrgDemo.Name = "lblOrgDemo";
            this.lblOrgDemo.Size = new System.Drawing.Size(204, 15);
            this.lblOrgDemo.TabIndex = 6;
            this.lblOrgDemo.Text = "Saha sahipleri için özel kontrol paneli.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label1.Location = new System.Drawing.Point(36, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bilgilerinizi kaydederek bir sonraki ziyaretinizde vakit kazanın.";
            // 
            // FormAnaEkran
            // 
            this.ClientSize = new System.Drawing.Size(1020, 690);
            this.Controls.Add(this.tblCards);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAnaEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SahalarBurada — Halı Saha Kiralama Platformu";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tblCards.ResumeLayout(false);
            this.pnlKiraci.ResumeLayout(false);
            this.pnlKiraci.PerformLayout();
            this.pnlOrg.ResumeLayout(false);
            this.pnlOrg.PerformLayout();
            this.ResumeLayout(false);

        }
        private void BtnMacAra_Click(object sender, System.EventArgs e) => NavSahaAra();
        private void BtnKiraciGiris_Click(object sender, System.EventArgs e) => NavKiracıGiris();
        private void BtnOrgGiris_Click(object sender, System.EventArgs e) => NavOrgGiris();
        private void PnlHeader_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { /* gradient */ }
        private void PaintKartKenar(object sender, System.Windows.Forms.PaintEventArgs e) { /* border */ }

        private Label label1;
    }

}
