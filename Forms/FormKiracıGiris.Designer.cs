using System.Windows.Forms;

namespace SahalarBurada.Forms
{
    partial class FormKiracıGiris
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
        private Label lblGirisHata;
        private Button btnGirisYap;
        private Label lblAltNotGiris;

        private Panel pnlKayit;
        private Label lblAd;
        private TextBox txtKayitAd;
        private Label lblSoyad;
        private TextBox txtKayitSoyad;
        private Label lblEpostaKayit;
        private TextBox txtKayitEposta;
        private Label lblSifreKayit;
        private TextBox txtKayitSifre;
        private Label lblSifreTekrar;
        private TextBox txtKayitSifreTekrar;
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
            this.lblGirisHata = new System.Windows.Forms.Label();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.lblAltNotGiris = new System.Windows.Forms.Label();
            this.pnlKayit = new System.Windows.Forms.Panel();
            this.lblAd = new System.Windows.Forms.Label();
            this.txtKayitAd = new System.Windows.Forms.TextBox();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.txtKayitSoyad = new System.Windows.Forms.TextBox();
            this.lblEpostaKayit = new System.Windows.Forms.Label();
            this.txtKayitEposta = new System.Windows.Forms.TextBox();
            this.lblSifreKayit = new System.Windows.Forms.Label();
            this.txtKayitSifre = new System.Windows.Forms.TextBox();
            this.lblSifreTekrar = new System.Windows.Forms.Label();
            this.txtKayitSifreTekrar = new System.Windows.Forms.TextBox();
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
            this.lblHeaderBaslik.Size = new System.Drawing.Size(202, 30);
            this.lblHeaderBaslik.TabIndex = 0;
            this.lblHeaderBaslik.Text = "👤  Kullanıcı Girişi";
            // 
            // lblHeaderAltBaslik
            // 
            this.lblHeaderAltBaslik.AutoSize = true;
            this.lblHeaderAltBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderAltBaslik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderAltBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHeaderAltBaslik.Location = new System.Drawing.Point(27, 52);
            this.lblHeaderAltBaslik.Name = "lblHeaderAltBaslik";
            this.lblHeaderAltBaslik.Size = new System.Drawing.Size(270, 15);
            this.lblHeaderAltBaslik.TabIndex = 1;
            this.lblHeaderAltBaslik.Text = "Halı saha kiralamak için giriş yapın veya kayıt olun";
            // 
            // pnlTabBar
            // 
            this.pnlTabBar.BackColor = System.Drawing.Color.White;
            this.pnlTabBar.Controls.Add(this.btnTabGiris);
            this.pnlTabBar.Controls.Add(this.btnTabKayit);
            this.pnlTabBar.Location = new System.Drawing.Point(0, 95);
            this.pnlTabBar.Name = "pnlTabBar";
            this.pnlTabBar.Size = new System.Drawing.Size(540, 50);
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
            this.btnTabGiris.Size = new System.Drawing.Size(270, 49);
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
            this.btnTabKayit.Location = new System.Drawing.Point(270, 0);
            this.btnTabKayit.Name = "btnTabKayit";
            this.btnTabKayit.Size = new System.Drawing.Size(270, 49);
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
            this.pnlGiris.Controls.Add(this.lblGirisHata);
            this.pnlGiris.Controls.Add(this.btnGirisYap);
            this.pnlGiris.Controls.Add(this.lblAltNotGiris);
            this.pnlGiris.Location = new System.Drawing.Point(0, 145);
            this.pnlGiris.Name = "pnlGiris";
            this.pnlGiris.Size = new System.Drawing.Size(540, 390);
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
            this.txtGirisEposta.Size = new System.Drawing.Size(440, 25);
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
            this.txtGirisSifre.Size = new System.Drawing.Size(440, 25);
            this.txtGirisSifre.TabIndex = 3;
            // 
            // lblGirisHata
            // 
            this.lblGirisHata.AutoSize = true;
            this.lblGirisHata.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGirisHata.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblGirisHata.Location = new System.Drawing.Point(50, 172);
            this.lblGirisHata.Name = "lblGirisHata";
            this.lblGirisHata.Size = new System.Drawing.Size(32, 15);
            this.lblGirisHata.TabIndex = 4;
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
            this.btnGirisYap.Location = new System.Drawing.Point(50, 198);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(440, 48);
            this.btnGirisYap.TabIndex = 5;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.UseVisualStyleBackColor = false;
            this.btnGirisYap.Click += new System.EventHandler(this.BtnGiris_Click);
            // 
            // lblAltNotGiris
            // 
            this.lblAltNotGiris.AutoSize = true;
            this.lblAltNotGiris.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAltNotGiris.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblAltNotGiris.Location = new System.Drawing.Point(50, 262);
            this.lblAltNotGiris.Name = "lblAltNotGiris";
            this.lblAltNotGiris.Size = new System.Drawing.Size(258, 15);
            this.lblAltNotGiris.TabIndex = 6;
            this.lblAltNotGiris.Text = "Hesabınız yok mu? \'Kayıt Ol\' sekmesine tıklayın.";
            // 
            // pnlKayit
            // 
            this.pnlKayit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.pnlKayit.Controls.Add(this.lblAd);
            this.pnlKayit.Controls.Add(this.txtKayitAd);
            this.pnlKayit.Controls.Add(this.lblSoyad);
            this.pnlKayit.Controls.Add(this.txtKayitSoyad);
            this.pnlKayit.Controls.Add(this.lblEpostaKayit);
            this.pnlKayit.Controls.Add(this.txtKayitEposta);
            this.pnlKayit.Controls.Add(this.lblSifreKayit);
            this.pnlKayit.Controls.Add(this.txtKayitSifre);
            this.pnlKayit.Controls.Add(this.lblSifreTekrar);
            this.pnlKayit.Controls.Add(this.txtKayitSifreTekrar);
            this.pnlKayit.Controls.Add(this.lblKayitHata);
            this.pnlKayit.Controls.Add(this.btnKayitOl);
            this.pnlKayit.Location = new System.Drawing.Point(0, 145);
            this.pnlKayit.Name = "pnlKayit";
            this.pnlKayit.Size = new System.Drawing.Size(540, 440);
            this.pnlKayit.TabIndex = 3;
            this.pnlKayit.Visible = false;
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAd.Location = new System.Drawing.Point(50, 18);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(32, 19);
            this.lblAd.TabIndex = 0;
            this.lblAd.Text = "Ad:";
            // 
            // txtKayitAd
            // 
            this.txtKayitAd.BackColor = System.Drawing.Color.White;
            this.txtKayitAd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKayitAd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtKayitAd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtKayitAd.Location = new System.Drawing.Point(50, 43);
            this.txtKayitAd.Name = "txtKayitAd";
            this.txtKayitAd.Size = new System.Drawing.Size(200, 25);
            this.txtKayitAd.TabIndex = 1;
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoyad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSoyad.Location = new System.Drawing.Point(270, 18);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(55, 19);
            this.lblSoyad.TabIndex = 2;
            this.lblSoyad.Text = "Soyad:";
            // 
            // txtKayitSoyad
            // 
            this.txtKayitSoyad.BackColor = System.Drawing.Color.White;
            this.txtKayitSoyad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKayitSoyad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtKayitSoyad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtKayitSoyad.Location = new System.Drawing.Point(270, 43);
            this.txtKayitSoyad.Name = "txtKayitSoyad";
            this.txtKayitSoyad.Size = new System.Drawing.Size(200, 25);
            this.txtKayitSoyad.TabIndex = 3;
            // 
            // lblEpostaKayit
            // 
            this.lblEpostaKayit.AutoSize = true;
            this.lblEpostaKayit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEpostaKayit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblEpostaKayit.Location = new System.Drawing.Point(50, 90);
            this.lblEpostaKayit.Name = "lblEpostaKayit";
            this.lblEpostaKayit.Size = new System.Drawing.Size(63, 19);
            this.lblEpostaKayit.TabIndex = 4;
            this.lblEpostaKayit.Text = "E-posta:";
            // 
            // txtKayitEposta
            // 
            this.txtKayitEposta.BackColor = System.Drawing.Color.White;
            this.txtKayitEposta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKayitEposta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtKayitEposta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtKayitEposta.Location = new System.Drawing.Point(50, 115);
            this.txtKayitEposta.Name = "txtKayitEposta";
            this.txtKayitEposta.Size = new System.Drawing.Size(440, 25);
            this.txtKayitEposta.TabIndex = 5;
            // 
            // lblSifreKayit
            // 
            this.lblSifreKayit.AutoSize = true;
            this.lblSifreKayit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSifreKayit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSifreKayit.Location = new System.Drawing.Point(50, 160);
            this.lblSifreKayit.Name = "lblSifreKayit";
            this.lblSifreKayit.Size = new System.Drawing.Size(44, 19);
            this.lblSifreKayit.TabIndex = 6;
            this.lblSifreKayit.Text = "Şifre:";
            // 
            // txtKayitSifre
            // 
            this.txtKayitSifre.BackColor = System.Drawing.Color.White;
            this.txtKayitSifre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKayitSifre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtKayitSifre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtKayitSifre.Location = new System.Drawing.Point(50, 185);
            this.txtKayitSifre.Name = "txtKayitSifre";
            this.txtKayitSifre.PasswordChar = '●';
            this.txtKayitSifre.Size = new System.Drawing.Size(440, 25);
            this.txtKayitSifre.TabIndex = 7;
            // 
            // lblSifreTekrar
            // 
            this.lblSifreTekrar.AutoSize = true;
            this.lblSifreTekrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSifreTekrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSifreTekrar.Location = new System.Drawing.Point(50, 230);
            this.lblSifreTekrar.Name = "lblSifreTekrar";
            this.lblSifreTekrar.Size = new System.Drawing.Size(92, 19);
            this.lblSifreTekrar.TabIndex = 8;
            this.lblSifreTekrar.Text = "Şifre Tekrar:";
            // 
            // txtKayitSifreTekrar
            // 
            this.txtKayitSifreTekrar.BackColor = System.Drawing.Color.White;
            this.txtKayitSifreTekrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKayitSifreTekrar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtKayitSifreTekrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtKayitSifreTekrar.Location = new System.Drawing.Point(50, 255);
            this.txtKayitSifreTekrar.Name = "txtKayitSifreTekrar";
            this.txtKayitSifreTekrar.PasswordChar = '●';
            this.txtKayitSifreTekrar.Size = new System.Drawing.Size(440, 25);
            this.txtKayitSifreTekrar.TabIndex = 9;
            // 
            // lblKayitHata
            // 
            this.lblKayitHata.AutoSize = true;
            this.lblKayitHata.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKayitHata.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblKayitHata.Location = new System.Drawing.Point(50, 300);
            this.lblKayitHata.Name = "lblKayitHata";
            this.lblKayitHata.Size = new System.Drawing.Size(32, 15);
            this.lblKayitHata.TabIndex = 10;
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
            this.btnKayitOl.Location = new System.Drawing.Point(50, 325);
            this.btnKayitOl.Name = "btnKayitOl";
            this.btnKayitOl.Size = new System.Drawing.Size(440, 48);
            this.btnKayitOl.TabIndex = 11;
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
            this.btnGeri.Location = new System.Drawing.Point(20, 540);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(110, 35);
            this.btnGeri.TabIndex = 4;
            this.btnGeri.Text = "← Geri";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.BtnGeri_Click);
            // 
            // FormKiracıGiris
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(540, 590);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.pnlKayit);
            this.Controls.Add(this.pnlGiris);
            this.Controls.Add(this.pnlTabBar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormKiracıGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SahalarBurada — Kullanıcı Girişi";
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
