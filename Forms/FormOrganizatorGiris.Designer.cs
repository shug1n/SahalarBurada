using System.Windows.Forms;

namespace SahalarBurada.Forms
{
    partial class FormOrganizatorGiris
    {
        private Panel pnlHeader;
        private Label lblHeaderBaslik;
        private Label lblHeaderAltBaslik;
        
        private Panel pnlTabBar;
        private Button btnTabGiris;
        private Button btnTabKayit;

        private Panel pnlGiris;
        private Label lblEpostaGiris;
        private TextBox txtGirisEposta;
        private Label lblSifreGiris;
        private TextBox txtGirisSifre;
        private Label lblDemoNot;
        private Label lblGirisHata;
        private Button btnGirisYap;

        private Panel pnlKayit;
        private Label lblIsletme;
        private TextBox txtIsletme;
        private Label lblAd;
        private TextBox txtAd;
        private Label lblSoyad;
        private TextBox txtSoyad;
        private Label lblEpostaKayit;
        private TextBox txtEposta;
        private Label lblSifreKayit;
        private TextBox txtSifre;
        private Label lblSifreTekrar;
        private TextBox txtSifreTekrar;
        private Label lblKayitHata;
        private Button btnKayitOl;

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
            this.pnlTabBar = new System.Windows.Forms.Panel();
            this.btnTabGiris = new System.Windows.Forms.Button();
            this.btnTabKayit = new System.Windows.Forms.Button();
            this.pnlGiris = new System.Windows.Forms.Panel();
            this.lblEpostaGiris = new System.Windows.Forms.Label();
            this.txtGirisEposta = new System.Windows.Forms.TextBox();
            this.lblSifreGiris = new System.Windows.Forms.Label();
            this.txtGirisSifre = new System.Windows.Forms.TextBox();
            this.lblDemoNot = new System.Windows.Forms.Label();
            this.lblGirisHata = new System.Windows.Forms.Label();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.pnlKayit = new System.Windows.Forms.Panel();
            this.lblIsletme = new System.Windows.Forms.Label();
            this.txtIsletme = new System.Windows.Forms.TextBox();
            this.lblAd = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.lblEpostaKayit = new System.Windows.Forms.Label();
            this.txtEposta = new System.Windows.Forms.TextBox();
            this.lblSifreKayit = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.lblSifreTekrar = new System.Windows.Forms.Label();
            this.txtSifreTekrar = new System.Windows.Forms.TextBox();
            this.lblKayitHata = new System.Windows.Forms.Label();
            this.btnKayitOl = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlTabBar.SuspendLayout();
            this.pnlGiris.SuspendLayout();
            this.pnlKayit.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(560, 95);
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
            this.lblHeaderBaslik.Size = new System.Drawing.Size(225, 30);
            this.lblHeaderBaslik.TabIndex = 0;
            this.lblHeaderBaslik.Text = "🏢  Organizatör Girişi";
            // 
            // lblHeaderAltBaslik
            // 
            this.lblHeaderAltBaslik.AutoSize = true;
            this.lblHeaderAltBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderAltBaslik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderAltBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHeaderAltBaslik.Location = new System.Drawing.Point(27, 52);
            this.lblHeaderAltBaslik.Name = "lblHeaderAltBaslik";
            this.lblHeaderAltBaslik.Size = new System.Drawing.Size(268, 15);
            this.lblHeaderAltBaslik.TabIndex = 1;
            this.lblHeaderAltBaslik.Text = "İşletme hesabınızla giriş yapın veya kayıt olun";
            // 
            // pnlTabBar
            // 
            this.pnlTabBar.BackColor = System.Drawing.Color.White;
            this.pnlTabBar.Controls.Add(this.btnTabGiris);
            this.pnlTabBar.Controls.Add(this.btnTabKayit);
            this.pnlTabBar.Location = new System.Drawing.Point(0, 95);
            this.pnlTabBar.Name = "pnlTabBar";
            this.pnlTabBar.Size = new System.Drawing.Size(560, 50);
            this.pnlTabBar.TabIndex = 1;
            this.pnlTabBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTabBar_Paint);
            // 
            // btnTabGiris
            // 
            this.btnTabGiris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnTabGiris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabGiris.FlatAppearance.BorderSize = 0;
            this.btnTabGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabGiris.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTabGiris.ForeColor = System.Drawing.Color.White;
            this.btnTabGiris.Location = new System.Drawing.Point(0, 0);
            this.btnTabGiris.Name = "btnTabGiris";
            this.btnTabGiris.Size = new System.Drawing.Size(280, 49);
            this.btnTabGiris.TabIndex = 0;
            this.btnTabGiris.Text = "Giriş Yap";
            this.btnTabGiris.UseVisualStyleBackColor = false;
            this.btnTabGiris.Click += new System.EventHandler(this.btnTabGiris_Click);
            // 
            // btnTabKayit
            // 
            this.btnTabKayit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.btnTabKayit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabKayit.FlatAppearance.BorderSize = 0;
            this.btnTabKayit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabKayit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTabKayit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnTabKayit.Location = new System.Drawing.Point(280, 0);
            this.btnTabKayit.Name = "btnTabKayit";
            this.btnTabKayit.Size = new System.Drawing.Size(280, 49);
            this.btnTabKayit.TabIndex = 1;
            this.btnTabKayit.Text = "Kayıt Ol";
            this.btnTabKayit.UseVisualStyleBackColor = false;
            this.btnTabKayit.Click += new System.EventHandler(this.btnTabKayit_Click);
            // 
            // pnlGiris
            // 
            this.pnlGiris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.pnlGiris.Controls.Add(this.lblEpostaGiris);
            this.pnlGiris.Controls.Add(this.txtGirisEposta);
            this.pnlGiris.Controls.Add(this.lblSifreGiris);
            this.pnlGiris.Controls.Add(this.txtGirisSifre);
            this.pnlGiris.Controls.Add(this.lblDemoNot);
            this.pnlGiris.Controls.Add(this.lblGirisHata);
            this.pnlGiris.Controls.Add(this.btnGirisYap);
            this.pnlGiris.Location = new System.Drawing.Point(0, 145);
            this.pnlGiris.Name = "pnlGiris";
            this.pnlGiris.Size = new System.Drawing.Size(560, 390);
            this.pnlGiris.TabIndex = 2;
            // 
            // lblEpostaGiris
            // 
            this.lblEpostaGiris.AutoSize = true;
            this.lblEpostaGiris.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEpostaGiris.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblEpostaGiris.Location = new System.Drawing.Point(50, 25);
            this.lblEpostaGiris.Name = "lblEpostaGiris";
            this.lblEpostaGiris.Size = new System.Drawing.Size(63, 19);
            this.lblEpostaGiris.TabIndex = 0;
            this.lblEpostaGiris.Text = "E-posta:";
            // 
            // txtGirisEposta
            // 
            this.txtGirisEposta.BackColor = System.Drawing.Color.White;
            this.txtGirisEposta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGirisEposta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGirisEposta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtGirisEposta.Location = new System.Drawing.Point(50, 50);
            this.txtGirisEposta.Name = "txtGirisEposta";
            this.txtGirisEposta.Size = new System.Drawing.Size(460, 25);
            this.txtGirisEposta.TabIndex = 1;
            // 
            // lblSifreGiris
            // 
            this.lblSifreGiris.AutoSize = true;
            this.lblSifreGiris.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSifreGiris.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSifreGiris.Location = new System.Drawing.Point(50, 100);
            this.lblSifreGiris.Name = "lblSifreGiris";
            this.lblSifreGiris.Size = new System.Drawing.Size(44, 19);
            this.lblSifreGiris.TabIndex = 2;
            this.lblSifreGiris.Text = "Şifre:";
            // 
            // txtGirisSifre
            // 
            this.txtGirisSifre.BackColor = System.Drawing.Color.White;
            this.txtGirisSifre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGirisSifre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGirisSifre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtGirisSifre.Location = new System.Drawing.Point(50, 125);
            this.txtGirisSifre.Name = "txtGirisSifre";
            this.txtGirisSifre.PasswordChar = '●';
            this.txtGirisSifre.Size = new System.Drawing.Size(460, 25);
            this.txtGirisSifre.TabIndex = 3;
            // 
            // lblDemoNot
            // 
            this.lblDemoNot.AutoSize = true;
            this.lblDemoNot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDemoNot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblDemoNot.Location = new System.Drawing.Point(50, 170);
            this.lblDemoNot.Name = "lblDemoNot";
            this.lblDemoNot.Size = new System.Drawing.Size(169, 15);
            this.lblDemoNot.TabIndex = 4;
            this.lblDemoNot.Text = "Demo: demo@org.com  /  123456";
            // 
            // lblGirisHata
            // 
            this.lblGirisHata.AutoSize = true;
            this.lblGirisHata.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGirisHata.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblGirisHata.Location = new System.Drawing.Point(50, 195);
            this.lblGirisHata.Name = "lblGirisHata";
            this.lblGirisHata.Size = new System.Drawing.Size(33, 15);
            this.lblGirisHata.TabIndex = 5;
            this.lblGirisHata.Text = "Hata";
            this.lblGirisHata.Visible = false;
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnGirisYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGirisYap.FlatAppearance.BorderSize = 0;
            this.btnGirisYap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnGirisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGirisYap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGirisYap.ForeColor = System.Drawing.Color.White;
            this.btnGirisYap.Location = new System.Drawing.Point(50, 220);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(460, 48);
            this.btnGirisYap.TabIndex = 6;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.UseVisualStyleBackColor = false;
            this.btnGirisYap.Click += new System.EventHandler(this.BtnGiris_Click);
            // 
            // pnlKayit
            // 
            this.pnlKayit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.pnlKayit.Controls.Add(this.lblIsletme);
            this.pnlKayit.Controls.Add(this.txtIsletme);
            this.pnlKayit.Controls.Add(this.lblAd);
            this.pnlKayit.Controls.Add(this.txtAd);
            this.pnlKayit.Controls.Add(this.lblSoyad);
            this.pnlKayit.Controls.Add(this.txtSoyad);
            this.pnlKayit.Controls.Add(this.lblEpostaKayit);
            this.pnlKayit.Controls.Add(this.txtEposta);
            this.pnlKayit.Controls.Add(this.lblSifreKayit);
            this.pnlKayit.Controls.Add(this.txtSifre);
            this.pnlKayit.Controls.Add(this.lblSifreTekrar);
            this.pnlKayit.Controls.Add(this.txtSifreTekrar);
            this.pnlKayit.Controls.Add(this.lblKayitHata);
            this.pnlKayit.Controls.Add(this.btnKayitOl);
            this.pnlKayit.Location = new System.Drawing.Point(0, 145);
            this.pnlKayit.Name = "pnlKayit";
            this.pnlKayit.Size = new System.Drawing.Size(560, 490);
            this.pnlKayit.TabIndex = 3;
            this.pnlKayit.Visible = false;
            // 
            // lblIsletme
            // 
            this.lblIsletme.AutoSize = true;
            this.lblIsletme.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIsletme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblIsletme.Location = new System.Drawing.Point(50, 15);
            this.lblIsletme.Name = "lblIsletme";
            this.lblIsletme.Size = new System.Drawing.Size(95, 19);
            this.lblIsletme.TabIndex = 0;
            this.lblIsletme.Text = "İşletme Adı: *";
            // 
            // txtIsletme
            // 
            this.txtIsletme.BackColor = System.Drawing.Color.White;
            this.txtIsletme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIsletme.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtIsletme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtIsletme.Location = new System.Drawing.Point(50, 40);
            this.txtIsletme.Name = "txtIsletme";
            this.txtIsletme.Size = new System.Drawing.Size(460, 25);
            this.txtIsletme.TabIndex = 1;
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAd.Location = new System.Drawing.Point(50, 85);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(32, 19);
            this.lblAd.TabIndex = 2;
            this.lblAd.Text = "Ad:";
            // 
            // txtAd
            // 
            this.txtAd.BackColor = System.Drawing.Color.White;
            this.txtAd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtAd.Location = new System.Drawing.Point(50, 110);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(210, 25);
            this.txtAd.TabIndex = 3;
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoyad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSoyad.Location = new System.Drawing.Point(280, 85);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(54, 19);
            this.lblSoyad.TabIndex = 4;
            this.lblSoyad.Text = "Soyad:";
            // 
            // txtSoyad
            // 
            this.txtSoyad.BackColor = System.Drawing.Color.White;
            this.txtSoyad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoyad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoyad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtSoyad.Location = new System.Drawing.Point(280, 110);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(210, 25);
            this.txtSoyad.TabIndex = 5;
            // 
            // lblEpostaKayit
            // 
            this.lblEpostaKayit.AutoSize = true;
            this.lblEpostaKayit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEpostaKayit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblEpostaKayit.Location = new System.Drawing.Point(50, 155);
            this.lblEpostaKayit.Name = "lblEpostaKayit";
            this.lblEpostaKayit.Size = new System.Drawing.Size(63, 19);
            this.lblEpostaKayit.TabIndex = 6;
            this.lblEpostaKayit.Text = "E-posta:";
            // 
            // txtEposta
            // 
            this.txtEposta.BackColor = System.Drawing.Color.White;
            this.txtEposta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEposta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEposta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtEposta.Location = new System.Drawing.Point(50, 180);
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(460, 25);
            this.txtEposta.TabIndex = 7;
            // 
            // lblSifreKayit
            // 
            this.lblSifreKayit.AutoSize = true;
            this.lblSifreKayit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSifreKayit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSifreKayit.Location = new System.Drawing.Point(50, 225);
            this.lblSifreKayit.Name = "lblSifreKayit";
            this.lblSifreKayit.Size = new System.Drawing.Size(44, 19);
            this.lblSifreKayit.TabIndex = 8;
            this.lblSifreKayit.Text = "Şifre:";
            // 
            // txtSifre
            // 
            this.txtSifre.BackColor = System.Drawing.Color.White;
            this.txtSifre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSifre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSifre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtSifre.Location = new System.Drawing.Point(50, 250);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '●';
            this.txtSifre.Size = new System.Drawing.Size(460, 25);
            this.txtSifre.TabIndex = 9;
            // 
            // lblSifreTekrar
            // 
            this.lblSifreTekrar.AutoSize = true;
            this.lblSifreTekrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSifreTekrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSifreTekrar.Location = new System.Drawing.Point(50, 295);
            this.lblSifreTekrar.Name = "lblSifreTekrar";
            this.lblSifreTekrar.Size = new System.Drawing.Size(91, 19);
            this.lblSifreTekrar.TabIndex = 10;
            this.lblSifreTekrar.Text = "Şifre Tekrar:";
            // 
            // txtSifreTekrar
            // 
            this.txtSifreTekrar.BackColor = System.Drawing.Color.White;
            this.txtSifreTekrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSifreTekrar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSifreTekrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtSifreTekrar.Location = new System.Drawing.Point(50, 320);
            this.txtSifreTekrar.Name = "txtSifreTekrar";
            this.txtSifreTekrar.PasswordChar = '●';
            this.txtSifreTekrar.Size = new System.Drawing.Size(460, 25);
            this.txtSifreTekrar.TabIndex = 11;
            // 
            // lblKayitHata
            // 
            this.lblKayitHata.AutoSize = true;
            this.lblKayitHata.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKayitHata.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblKayitHata.Location = new System.Drawing.Point(50, 365);
            this.lblKayitHata.Name = "lblKayitHata";
            this.lblKayitHata.Size = new System.Drawing.Size(33, 15);
            this.lblKayitHata.TabIndex = 12;
            this.lblKayitHata.Text = "Hata";
            this.lblKayitHata.Visible = false;
            // 
            // btnKayitOl
            // 
            this.btnKayitOl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnKayitOl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKayitOl.FlatAppearance.BorderSize = 0;
            this.btnKayitOl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnKayitOl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKayitOl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKayitOl.ForeColor = System.Drawing.Color.White;
            this.btnKayitOl.Location = new System.Drawing.Point(50, 390);
            this.btnKayitOl.Name = "btnKayitOl";
            this.btnKayitOl.Size = new System.Drawing.Size(460, 48);
            this.btnKayitOl.TabIndex = 13;
            this.btnKayitOl.Text = "Kayıt Ol";
            this.btnKayitOl.UseVisualStyleBackColor = false;
            this.btnKayitOl.Click += new System.EventHandler(this.BtnKayit_Click);
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
            this.btnGeri.Location = new System.Drawing.Point(20, 592);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(110, 35);
            this.btnGeri.TabIndex = 4;
            this.btnGeri.Text = "← Geri";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.BtnGeri_Click);
            // 
            // FormOrganizatorGiris
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(560, 640);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.pnlKayit);
            this.Controls.Add(this.pnlGiris);
            this.Controls.Add(this.pnlTabBar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormOrganizatorGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SahalarBurada — Organizatör Girişi";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTabBar.ResumeLayout(false);
            this.pnlGiris.ResumeLayout(false);
            this.pnlGiris.PerformLayout();
            this.pnlKayit.ResumeLayout(false);
            this.pnlKayit.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
