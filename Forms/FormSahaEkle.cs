using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;

namespace SahalarBurada.Forms
{
    public partial class FormSahaEkle : Form
    {
        private TextBox txtAd, txtAdres, txtAciklama;
        private NumericUpDown nudKapasite, nudFiyat;
        private CheckedListBox clbGunler, clbSaatler;
        private Label lblHata;

        public FormSahaEkle()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            UIHelper.FormAyarla(this, "Yeni Saha Ekle", 700, 780);
            this.Controls.Add(UIHelper.HeaderPanelOlustur("➕  Yeni Saha Ekle", "Halı saha bilgilerini eksiksiz doldurun"));

            var scroll = new Panel { Dock = DockStyle.Fill, BackColor = UIHelper.CArkaplan, AutoScroll = true };
            int x = 32, y = 18, wF = 636, wH = 295;

            scroll.Controls.Add(UIHelper.LblAlan("Saha Adı: *", x, y));
            txtAd = UIHelper.TxtBox(x, y + 26, wF); scroll.Controls.Add(txtAd); y += 72;

            scroll.Controls.Add(UIHelper.LblAlan("Adres: *", x, y));
            txtAdres = UIHelper.TxtBox(x, y + 26, wF); scroll.Controls.Add(txtAdres); y += 72;

            scroll.Controls.Add(UIHelper.LblAlan("Kapasite (kişi): *", x, y));
            nudKapasite = new NumericUpDown { Location = new Point(x, y + 26), Size = new Size(wH, 28), Font = UIHelper.FNormal, Minimum = 2, Maximum = 30, Value = 14 };
            scroll.Controls.Add(nudKapasite);

            scroll.Controls.Add(UIHelper.LblAlan("Fiyat / Saat (₺): *", x + wH + 22, y));
            nudFiyat = new NumericUpDown { Location = new Point(x + wH + 22, y + 26), Size = new Size(wH, 28), Font = UIHelper.FNormal, Minimum = 50, Maximum = 9999, Value = 300, Increment = 50 };
            scroll.Controls.Add(nudFiyat); y += 75;

            scroll.Controls.Add(UIHelper.LblAlan("Müsait Günler: *", x, y));
            clbGunler = new CheckedListBox { Location = new Point(x, y + 26), Size = new Size(wH, 148), Font = UIHelper.FNormal, CheckOnClick = true, BackColor = Color.White };
            foreach (var g in new[] { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" })
                clbGunler.Items.Add(g, true);
            scroll.Controls.Add(clbGunler);

            scroll.Controls.Add(UIHelper.LblAlan("Müsait Saatler: *", x + wH + 22, y));
            clbSaatler = new CheckedListBox { Location = new Point(x + wH + 22, y + 26), Size = new Size(wH, 148), Font = UIHelper.FNormal, CheckOnClick = true, BackColor = Color.White };
            for (int i = 8; i <= 22; i++) clbSaatler.Items.Add(i.ToString("D2") + ":00", true);
            scroll.Controls.Add(clbSaatler); y += 195;

            scroll.Controls.Add(UIHelper.LblAlan("Açıklama:", x, y));
            txtAciklama = new TextBox { Location = new Point(x, y + 26), Size = new Size(wF, 80), Font = UIHelper.FNormal, Multiline = true, BorderStyle = BorderStyle.FixedSingle, BackColor = Color.White, ScrollBars = ScrollBars.Vertical };
            scroll.Controls.Add(txtAciklama); y += 122;

            lblHata = new Label { Location = new Point(x, y), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false };
            scroll.Controls.Add(lblHata); y += 26;

            var btnGeri   = UIHelper.BtnSecondary("← Geri", x, y, 145, 44);
            btnGeri.Click += (s, e) => this.Close();
            var btnOzet   = UIHelper.BtnPrimary("📄  Form Özetini Görüntüle", x + 160, y, 300, 44);
            btnOzet.Click += BtnOzet_Click;
            scroll.Controls.Add(btnGeri);
            scroll.Controls.Add(btnOzet);

            this.Controls.Add(scroll);
        }

        private void BtnOzet_Click(object sender, EventArgs e)
        {
            lblHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtAdres.Text))
            { lblHata.Text = "Saha adı ve adres zorunludur."; lblHata.Visible = true; return; }

            var gunler  = new List<string>();
            var saatler = new List<string>();
            foreach (var item in clbGunler.CheckedItems)  gunler.Add(item.ToString());
            foreach (var item in clbSaatler.CheckedItems) saatler.Add(item.ToString());
            if (gunler.Count == 0 || saatler.Count == 0)
            { lblHata.Text = "En az bir gün ve bir saat seçmelisiniz."; lblHata.Visible = true; return; }

            var saha = new HaliSaha { OrganizatorId = Oturum.AktifOrganizator.Id, Ad = txtAd.Text.Trim(), Adres = txtAdres.Text.Trim(), Kapasite = (int)nudKapasite.Value, FiyatSaat = (double)nudFiyat.Value, MüsaitGunler = gunler, MüsaitSaatler = saatler, Aciklama = txtAciklama.Text.Trim() };
            var f = new FormSahaOzet(saha);
            this.Hide();
            f.FormClosed += (s, ev) => { if (f.DialogResult == System.Windows.Forms.DialogResult.OK) this.Close(); else this.Show(); };
            f.Show();
        }
    }
}
