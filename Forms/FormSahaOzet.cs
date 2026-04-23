using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormSahaOzet : Form
    {
        private readonly HaliSaha _saha;

        public FormSahaOzet(HaliSaha saha)
        {
            _saha = saha;
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            UIHelper.FormAyarla(this, "Saha Özeti", 680, 660);
            this.Controls.Add(UIHelper.HeaderPanelOlustur("📄  Saha Özeti", "Bilgileri kontrol edin; onaylayarak kaydedebilirsiniz"));

            var scroll = new Panel { Dock = DockStyle.Fill, BackColor = UIHelper.CArkaplan, AutoScroll = true };
            int x = 32, y = 18;

            // Özet kartı
            var kart = UIHelper.KartPanel(x, y, 614, 432);
            kart.Paint += (s, e) =>
            {
                var p = (Panel)s;
                e.Graphics.DrawRectangle(new Pen(UIHelper.CBolme, 1), 0, 0, p.Width - 1, p.Height - 1);
                e.Graphics.FillRectangle(new SolidBrush(UIHelper.CVurgu), 0, 0, 6, p.Height);
            };
            kart.Controls.Add(new Label { Text = "📋 Saha Bilgileri Özeti", Font = UIHelper.FAltBaslik, ForeColor = UIHelper.CAna, AutoSize = true, Location = new Point(18, 14) });

            int ky = 52;
            void BilgiSatiri(string etiket, string deger, int h = 26)
            {
                kart.Controls.Add(new Label { Text = etiket, Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, Location = new Point(20, ky), Size = new Size(145, h) });
                kart.Controls.Add(new Label { Text = deger,  Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik, Location = new Point(170, ky), AutoSize = false, Size = new Size(430, h) });
                ky += h + 6;
            }
            BilgiSatiri("Saha Adı:",       _saha.Ad);
            BilgiSatiri("Adres:",           _saha.Adres);
            BilgiSatiri("Kapasite:",        _saha.Kapasite + " kişi");
            BilgiSatiri("Fiyat/Saat:",      _saha.FiyatSaat.ToString("N0") + " ₺");
            BilgiSatiri("Müsait Günler:",   string.Join(", ", _saha.MüsaitGunler), 40);
            BilgiSatiri("Müsait Saatler:",  $"{_saha.MüsaitSaatler.Count} dilim  ({_saha.MüsaitSaatler[0]} → {_saha.MüsaitSaatler[_saha.MüsaitSaatler.Count - 1]})");
            BilgiSatiri("Açıklama:",        string.IsNullOrWhiteSpace(_saha.Aciklama) ? "—" : _saha.Aciklama, 48);

            scroll.Controls.Add(kart);
            y += 450;

            scroll.Controls.Add(new Label { Text = "ℹ  Bilgiler doğru mu? Onayladıktan sonra sisteme kaydedilir.", Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new Point(x, y) });
            y += 28;

            var btnDuzenle = UIHelper.BtnSecondary("✏  Düzenle",         x,       y, 160, 46);
            btnDuzenle.Click += (s, e) => this.Close();
            var btnKaydet  = UIHelper.BtnPrimary("✅  Onayla ve Kaydet", x + 180, y, 250, 46);
            btnKaydet.Click += BtnKaydet_Click;
            scroll.Controls.Add(btnDuzenle);
            scroll.Controls.Add(btnKaydet);

            this.Controls.Add(scroll);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SahaServisi.SahaEkle(_saha);
            MessageBox.Show($"'{_saha.Ad}' sahası başarıyla sisteme eklendi!\n\nMüsait günler: {_saha.MüsaitGunler.Count} gün\nMüsait saatler: {_saha.MüsaitSaatler.Count} dilim", "Saha Eklendi ✅", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
