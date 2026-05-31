using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormProfilGuncelle : BaseChildForm
    {
        private readonly bool _isOrganizer;
        
        private Panel pnlHeader;
        private Panel pnlKart;
        private Label lblHata;
        private Button btnKaydet;
        private Button btnGeri;

        // Form inputs
        private TextBox txtIsletme;
        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtEposta;
        private TextBox txtTelefon;
        private TextBox txtSifre;
        private TextBox txtSifreTekrar;

        public FormProfilGuncelle()
        {
            _isOrganizer = Oturum.AktifOrganizator != null;
            InitializeComponent();
            
            this.ClientSize = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "SahalarBurada — Profil Ayarları";

            SetupForm();
            LoadCurrentData();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfilGuncelle));
            this.SuspendLayout();
            // 
            // FormProfilGuncelle
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormProfilGuncelle";
            this.ResumeLayout(false);

        }

        private void SetupForm()
        {
            // 1. Create Header
            pnlHeader = UIHelper.HeaderPanelOlustur("👤  Profilimi Düzenle", "Kişisel bilgilerinizi ve hesabınızı güncelleyin.");
            this.Controls.Add(pnlHeader);

            // 2. Create card panel
            pnlKart = new Panel
            {
                Size = new Size(740, _isOrganizer ? 480 : 410),
                BackColor = UIHelper.CKart
            };

            pnlKart.HandleCreated += (s, e) => { UIHelper.SetRoundedCorners(pnlKart, 12); };
            pnlKart.Resize += (s, e) => { UIHelper.SetRoundedCorners(pnlKart, 12); };

            pnlKart.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var path = UIHelper.GetRoundedRectanglePath(new Rectangle(0, 0, pnlKart.Width - 1, pnlKart.Height - 1), 12))
                {
                    using (var pen = new Pen(UIHelper.CBolme, 1.5f))
                    {
                        g.DrawPath(pen, path);
                    }
                }
                using (var br = new SolidBrush(UIHelper.CVurgu))
                    g.FillRectangle(br, 0, 0, 6, pnlKart.Height);
            };

            // 3. Populate Card Controls
            int yOffset = 25;

            if (_isOrganizer)
            {
                pnlKart.Controls.Add(UIHelper.LblAlan("İşletme Adı: *", 30, yOffset));
                txtIsletme = UIHelper.TxtBox(30, yOffset + 22, 680);
                pnlKart.Controls.Add(txtIsletme);
                yOffset += 70;
            }

            // Left Column
            pnlKart.Controls.Add(UIHelper.LblAlan("Ad: *", 30, yOffset));
            txtAd = UIHelper.TxtBox(30, yOffset + 22, 310);
            pnlKart.Controls.Add(txtAd);

            pnlKart.Controls.Add(UIHelper.LblAlan("Soyad: *", 30, yOffset + 70));
            txtSoyad = UIHelper.TxtBox(30, yOffset + 92, 310);
            pnlKart.Controls.Add(txtSoyad);

            pnlKart.Controls.Add(UIHelper.LblAlan("E-posta Adresi: *", 30, yOffset + 140));
            txtEposta = UIHelper.TxtBox(30, yOffset + 162, 310);
            pnlKart.Controls.Add(txtEposta);

            pnlKart.Controls.Add(UIHelper.LblAlan("Telefon Numarası: *", 30, yOffset + 210));
            txtTelefon = UIHelper.TxtBox(30, yOffset + 232, 310);
            pnlKart.Controls.Add(txtTelefon);
            UIHelper.SetPlaceholder(txtTelefon, "Örn: 0532 123 45 67");

            // Right Column
            pnlKart.Controls.Add(UIHelper.LblAlan("Yeni Şifre (Değiştirmek istemiyorsanız boş bırakın):", 380, yOffset));
            txtSifre = UIHelper.TxtBox(380, yOffset + 22, 330, true);
            pnlKart.Controls.Add(txtSifre);

            var lblSifreNot = new Label
            {
                Text = "ℹ️ Şifre en az 6 karakter içermelidir.",
                Location = new Point(380, yOffset + 50),
                Size = new Size(330, 16),
                Font = new Font("Segoe UI", 8.25F, FontStyle.Italic),
                ForeColor = Color.DimGray,
                AutoSize = false
            };
            pnlKart.Controls.Add(lblSifreNot);

            pnlKart.Controls.Add(UIHelper.LblAlan("Yeni Şifre (Tekrar):", 380, yOffset + 70));
            txtSifreTekrar = UIHelper.TxtBox(380, yOffset + 92, 330, true);
            pnlKart.Controls.Add(txtSifreTekrar);

            // Error label
            lblHata = new Label
            {
                AutoSize = true,
                Font = UIHelper.FKucuk,
                ForeColor = UIHelper.CHata,
                Location = new Point(30, yOffset + 285),
                Text = "Hata Mesajı",
                Visible = false
            };
            pnlKart.Controls.Add(lblHata);

            // Save button
            btnKaydet = UIHelper.BtnPrimary("💾  Bilgileri Güncelle", 380, yOffset + 212, 330, 45);
            btnKaydet.Click += BtnKaydet_Click;
            pnlKart.Controls.Add(btnKaydet);

            // Back button
            btnGeri = UIHelper.BtnSecondary("⬅  Geri Dön", 30, this.ClientSize.Height - 60, 160, 40);
            btnGeri.Click += BtnGeri_Click;
            this.Controls.Add(btnGeri);

            // Center card symmetrically
            UIHelper.CenterControlsInCard(this, new Control[] { pnlKart }, false);
        }

        private void LoadCurrentData()
        {
            if (_isOrganizer)
            {
                var org = Oturum.AktifOrganizator;
                txtIsletme.Text = org.IsletmeAdi;
                txtAd.Text = org.Ad;
                txtSoyad.Text = org.Soyad;
                txtEposta.Text = org.Eposta;
                txtTelefon.Text = org.Telefon ?? "";
            }
            else
            {
                var user = Oturum.AktifKullanici;
                txtAd.Text = user.Ad;
                txtSoyad.Text = user.Soyad;
                txtEposta.Text = user.Eposta;
                txtTelefon.Text = user.Telefon ?? "";
            }
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            this.IsBackButtonClicked = true;
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            lblHata.Visible = false;

            // Common validations
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text) || 
                string.IsNullOrWhiteSpace(txtEposta.Text) || string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                lblHata.Text = "Lütfen tüm zorunlu (*) alanları doldurun.";
                lblHata.Visible = true;
                return;
            }

            if (_isOrganizer && string.IsNullOrWhiteSpace(txtIsletme.Text))
            {
                lblHata.Text = "Lütfen işletme adını doldurun.";
                lblHata.Visible = true;
                return;
            }

            // Phone number formatting/validation
            string telefon = txtTelefon.Text.Trim();
            string cleanPhone = telefon.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            if (!System.Text.RegularExpressions.Regex.IsMatch(cleanPhone, @"^0?5\d{9}$"))
            {
                lblHata.Text = "Lütfen geçerli bir Türkiye cep telefonu numarası giriniz.";
                lblHata.Visible = true;
                return;
            }

            // Password update logic
            string newPassword = txtSifre.Text;
            string newPasswordConfirm = txtSifreTekrar.Text;
            bool changePassword = !string.IsNullOrEmpty(newPassword);

            if (changePassword)
            {
                // Check if new password is equal to the old one
                string currentHash = _isOrganizer ? Oturum.AktifOrganizator.SifreHash : Oturum.AktifKullanici.SifreHash;
                if (SifreHelper.Dogrula(newPassword, currentHash))
                {
                    lblHata.Text = "Yeni şifreniz eski şifreniz ile aynı olamaz.";
                    lblHata.Visible = true;
                    return;
                }

                if (newPassword != newPasswordConfirm)
                {
                    lblHata.Text = "Şifreler uyuşmuyor.";
                    lblHata.Visible = true;
                    return;
                }
                if (newPassword.Length < 6)
                {
                    lblHata.Text = "Şifre en az 6 karakter olmalıdır.";
                    lblHata.Visible = true;
                    return;
                }
            }

            string eposta = txtEposta.Text.Trim();

            if (_isOrganizer)
            {
                var org = Oturum.AktifOrganizator;

                // Validate email uniqueness if changed
                if (!org.Eposta.Equals(eposta, StringComparison.OrdinalIgnoreCase) && DatabaseServisi.CheckOrganizerExists(eposta))
                {
                    lblHata.Text = "Bu e-posta adresi zaten başka bir organizatör tarafından kullanılıyor.";
                    lblHata.Visible = true;
                    return;
                }

                org.IsletmeAdi = txtIsletme.Text.Trim();
                org.Ad = txtAd.Text.Trim();
                org.Soyad = txtSoyad.Text.Trim();
                org.Eposta = eposta;
                org.Telefon = cleanPhone;
                
                if (changePassword)
                {
                    org.SifreHash = SifreHelper.Hash(newPassword);
                }

                DatabaseServisi.UpdateOrganizer(org);
                MessageBox.Show("Profil bilgileriniz başarıyla güncellendi!", "Başarılı ✅", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var user = Oturum.AktifKullanici;

                // Validate email uniqueness if changed
                if (!user.Eposta.Equals(eposta, StringComparison.OrdinalIgnoreCase) && DatabaseServisi.CheckUserExists(eposta))
                {
                    lblHata.Text = "Bu e-posta adresi zaten başka bir kullanıcı tarafından kullanılıyor.";
                    lblHata.Visible = true;
                    return;
                }

                user.Ad = txtAd.Text.Trim();
                user.Soyad = txtSoyad.Text.Trim();
                user.Eposta = eposta;
                user.Telefon = cleanPhone;

                if (changePassword)
                {
                    user.SifreHash = SifreHelper.Hash(newPassword);
                }

                DatabaseServisi.UpdateUser(user);
                MessageBox.Show("Profil bilgileriniz başarıyla güncellendi!", "Başarılı ✅", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.IsBackButtonClicked = true;
            this.Close();
        }
    }
}
