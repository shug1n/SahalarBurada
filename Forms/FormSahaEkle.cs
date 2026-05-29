using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormSahaEkle : BaseChildForm
    {
        private NumericUpDown numKapasite;
        private readonly HaliSaha _duzenlenenSaha;

        public FormSahaEkle(HaliSaha duzenlenenSaha = null)
        {
            _duzenlenenSaha = duzenlenenSaha;
            InitializeComponent();
            this.ClientSize = new Size(1000, 700);

            pnlScroll.Controls.Remove(btnGeri);
            pnlScroll.Controls.Remove(btnOzet);
            this.Controls.Add(btnGeri);
            this.Controls.Add(btnOzet);
            btnGeri.BringToFront();
            btnOzet.BringToFront();

            pnlScroll.Dock = DockStyle.None;
            pnlScroll.Location = new Point(0, 95);
            pnlScroll.Size = new Size(1000, 700 - 95 - 80);

            this.Resize += (s, e) => {
                btnGeri.Location = new Point(30, this.ClientSize.Height - 60);
                btnOzet.Location = new Point(190, this.ClientSize.Height - 60);
                pnlScroll.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 95 - 80);
            };
            btnGeri.Location = new Point(30, this.ClientSize.Height - 60);
            btnOzet.Location = new Point(190, this.ClientSize.Height - 60);

            // Shift controls below Y=280 down by 70 pixels
            foreach (Control c in pnlScroll.Controls)
            {
                if (c.Top >= 300)
                {
                    c.Top += 70;
                }
            }

            // Create Kapasite label and control programmatically
            var lblKapasite = new Label
            {
                Text = "Maksimum Kapasite (Kişi Sayısı): *",
                Location = new Point(32, 300),
                Size = new Size(295, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                AutoSize = true
            };

            this.numKapasite = new NumericUpDown
            {
                Name = "numKapasite",
                Location = new Point(32, 326),
                Size = new Size(295, 25),
                Font = new Font("Segoe UI", 10),
                Minimum = 1,
                Maximum = 999, // Capacity limit removed (increased to 999)
                Value = 14
            };

            pnlScroll.Controls.Add(lblKapasite);
            pnlScroll.Controls.Add(this.numKapasite);

            var allControls = new List<Control>();
            foreach (Control c in pnlScroll.Controls) allControls.Add(c);
            UIHelper.CenterControlsInCard(pnlScroll, allControls.ToArray());

            UIHelper.SetPlaceholder(txtFiyat, "3000");
            UIHelper.SetPlaceholder(txtTelefon, "Örn: 0532 123 45 67");
            SetupLogic();

            if (_duzenlenenSaha != null)
            {
                lblHeaderBaslik.Text = "✏️  Sahayı Düzenle";
                lblHeaderAltBaslik.Text = "Halı saha bilgilerini güncelleyin";
                
                txtAd.Text = _duzenlenenSaha.Ad;
                txtAdres.Text = _duzenlenenSaha.Adres;
                txtFiyat.Text = _duzenlenenSaha.FiyatSaat.ToString();
                txtTelefon.Text = _duzenlenenSaha.Telefon;
                txtAciklama.Text = _duzenlenenSaha.Aciklama;
                numKapasite.Value = _duzenlenenSaha.Kapasite;

                // Load sehir and ilce
                cmbSehir.SelectedItem = _duzenlenenSaha.Sehir;
                cmbIlce.SelectedItem = _duzenlenenSaha.Ilce;

                // Load gunler
                for (int i = 0; i < clbGunler.Items.Count; i++)
                {
                    clbGunler.SetItemChecked(i, _duzenlenenSaha.MüsaitGunler.Contains(clbGunler.Items[i].ToString()));
                }

                // Load saatler
                for (int i = 0; i < clbSaatler.Items.Count; i++)
                {
                    clbSaatler.SetItemChecked(i, _duzenlenenSaha.MüsaitSaatler.Contains(clbSaatler.Items[i].ToString()));
                }
            }
        }

        private void SetupLogic()
        {
            foreach (var g in new[] { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" })
                clbGunler.Items.Add(g, true);

            var saatlerListesi = new List<string>
            {
                "00:00-01:00", "01:00-02:00", "02:00-03:00", "03:00-04:00",
                "04:00-05:00", "05:00-06:00", "06:00-07:00", "07:00-08:00",
                "08:00-09:00", "09:00-10:00", "10:00-11:00", "11:00-12:00",
                "12:00-13:00", "13:00-14:00", "14:00-15:00", "15:00-16:00",
                "16:00-17:00", "17:00-18:00", "18:00-19:00", "19:00-20:00",
                "20:00-21:00", "21:00-22:00", "22:00-23:00", "23:00-00:00"
            };
            foreach (var s in saatlerListesi)
                clbSaatler.Items.Add(s, true);

            // İl listesini yükle
            cmbSehir.Items.Clear();
            foreach (var il in TurkiyeVerisi.Iller())
                cmbSehir.Items.Add(il);

            // İl değişince ilçeleri güncelle
            cmbSehir.SelectedIndexChanged += (s, e) =>
            {
                cmbIlce.Items.Clear();
                if (cmbSehir.SelectedItem != null)
                    foreach (var ilce in TurkiyeVerisi.Ilceler(cmbSehir.SelectedItem.ToString()))
                        cmbIlce.Items.Add(ilce);
                if (cmbIlce.Items.Count > 0) cmbIlce.SelectedIndex = 0;
            };
        }

        private void BtnGeri_Click(object sender, EventArgs e) { IsBackButtonClicked = true; this.Close(); }

        private void BtnOzet_Click(object sender, EventArgs e)
        {
            lblHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtAdres.Text))
            { lblHata.Text = "Saha adı ve adres zorunludur."; lblHata.Visible = true; return; }

            if (_duzenlenenSaha == null || !_duzenlenenSaha.Ad.Equals(txtAd.Text.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                if (SahaServisi.SahaIsmiVarMi(Oturum.AktifOrganizator.Id, txtAd.Text.Trim()))
                { lblHata.Text = "Bu isimde bir sahanız zaten mevcut."; lblHata.Visible = true; return; }
            }

            if (cmbSehir.SelectedItem == null || cmbIlce.SelectedItem == null)
            { lblHata.Text = "Şehir ve ilçe seçimi zorunludur."; lblHata.Visible = true; return; }

            var gunler  = new List<string>();
            var saatler = new List<string>();
            foreach (var item in clbGunler.CheckedItems)  gunler.Add(item.ToString());
            foreach (var item in clbSaatler.CheckedItems) saatler.Add(item.ToString());
            if (gunler.Count == 0 || saatler.Count == 0)
            { lblHata.Text = "En az bir gün ve bir saat seçmelisiniz."; lblHata.Visible = true; return; }

            double fiyat = 3000;
            if (!string.IsNullOrWhiteSpace(txtFiyat.Text))
            {
                if (!double.TryParse(txtFiyat.Text.Trim(), out fiyat) || fiyat <= 0)
                {
                    lblHata.Text = "Saatlik fiyat alanına geçerli bir pozitif sayı girmelisiniz.";
                    lblHata.Visible = true;
                    return;
                }
            }

            string telefon = txtTelefon.Text.Trim();
            if (string.IsNullOrEmpty(telefon))
            {
                lblHata.Text = "İletişim için telefon numarası zorunludur.";
                lblHata.Visible = true;
                return;
            }
            string cleanPhone = telefon.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            if (!System.Text.RegularExpressions.Regex.IsMatch(cleanPhone, @"^0?5\d{9}$"))
            {
                lblHata.Text = "Lütfen geçerli bir Türkiye cep telefonu numarası giriniz.";
                lblHata.Visible = true;
                return;
            }

            HaliSaha saha = _duzenlenenSaha;
            if (saha == null)
            {
                saha = new HaliSaha
                {
                    OrganizatorId = Oturum.AktifOrganizator.Id,
                    Ad            = txtAd.Text.Trim(),
                    Sehir         = cmbSehir.SelectedItem?.ToString(),
                    Ilce          = cmbIlce.SelectedItem?.ToString(),
                    Adres         = txtAdres.Text.Trim(),
                    FiyatSaat     = fiyat,
                    MüsaitGunler  = gunler,
                    MüsaitSaatler = saatler,
                    Aciklama      = txtAciklama.Text.Trim(),
                    Telefon       = cleanPhone,
                    Kapasite      = (int)numKapasite.Value
                };
            }
            else
            {
                saha.Ad            = txtAd.Text.Trim();
                saha.Sehir         = cmbSehir.SelectedItem?.ToString();
                saha.Ilce          = cmbIlce.SelectedItem?.ToString();
                saha.Adres         = txtAdres.Text.Trim();
                saha.FiyatSaat     = fiyat;
                saha.MüsaitGunler  = gunler;
                saha.MüsaitSaatler = saatler;
                saha.Aciklama      = txtAciklama.Text.Trim();
                saha.Telefon       = cleanPhone;
                saha.Kapasite      = (int)numKapasite.Value;
            }
            var f = new FormSahaOzet(saha);
            this.Hide();
            f.FormClosed += (s, ev) => { if (f.DialogResult == System.Windows.Forms.DialogResult.OK) { this.IsBackButtonClicked = true; this.Close(); } else this.Show(); };
            f.Show();
        }
    }
}
