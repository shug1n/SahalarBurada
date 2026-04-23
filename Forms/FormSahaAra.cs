using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormSahaAra : Form
    {
        private DateTimePicker dtpTarih;
        private ComboBox cmbSaat;
        private Label lblHata;

        public FormSahaAra()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            UIHelper.FormAyarla(this, "Saha Ara", 540, 470);
            this.Controls.Add(UIHelper.HeaderPanelOlustur("📅  Saha Ara", "Tarih ve saat seçerek müsait sahaları listeleyin"));

            var content = new Panel { Dock = DockStyle.Fill, BackColor = UIHelper.CArkaplan };

            var lblKullanici = new Label { Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new Point(50, 20) };
            this.Shown += (s, e) => lblKullanici.Text = Oturum.GirisYapildi
                ? $"👤 Hoş geldiniz, {Oturum.AktifKullanici.Ad} {Oturum.AktifKullanici.Soyad}"
                : "👤 Misafir olarak arama yapıyorsunuz";

            content.Controls.Add(lblKullanici);
            content.Controls.Add(UIHelper.LblAlan("Tarih Seçin:", 50, 55));
            dtpTarih = new DateTimePicker { Location = new Point(50, 80), Width = 440, Font = UIHelper.FNormal, Format = DateTimePickerFormat.Long, MinDate = DateTime.Today };
            content.Controls.Add(dtpTarih);

            content.Controls.Add(UIHelper.LblAlan("Saat Seçin:", 50, 130));
            cmbSaat = new ComboBox { Location = new Point(50, 155), Width = 440, Font = UIHelper.FNormal, DropDownStyle = ComboBoxStyle.DropDownList };
            for (int i = 8; i <= 22; i++) cmbSaat.Items.Add(i.ToString("D2") + ":00");
            cmbSaat.SelectedIndex = 6;
            content.Controls.Add(cmbSaat);

            lblHata = new Label { Location = new Point(50, 205), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false };
            content.Controls.Add(lblHata);

            var btnListele = UIHelper.BtnPrimary("🔍   Sahaları Listele", 50, 230, 440, 52);
            btnListele.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnListele.Click += BtnListele_Click;
            content.Controls.Add(btnListele);

            var btnGeri = UIHelper.BtnSecondary("← Geri", 50, 302, 130, 38);
            btnGeri.Click += (s, e) => this.Close();
            content.Controls.Add(btnGeri);

            this.Controls.Add(content);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            lblHata.Visible = false;
            var tarih = dtpTarih.Value.Date;
            var saat  = cmbSaat.SelectedItem?.ToString();
            if (saat == null) { lblHata.Text = "Lütfen saat seçin."; lblHata.Visible = true; return; }

            var sahalar = SahaServisi.UygunSahalariGetir(tarih, saat);
            if (sahalar.Count == 0)
            { lblHata.Text = "Seçilen tarih ve saatte müsait saha bulunmamaktadır."; lblHata.Visible = true; return; }

            var f = new FormSahaListesi(sahalar, tarih, saat);
            this.Hide();
            f.FormClosed += (s2, e2) =>
            {
                if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                { this.DialogResult = System.Windows.Forms.DialogResult.OK; this.Close(); }
                else this.Show();
            };
            f.Show();
        }
    }
}
