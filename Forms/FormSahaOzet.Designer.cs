using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;

namespace SahalarBurada.Forms
{
    partial class FormSahaOzet
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            UIHelper.FormAyarla(this, "Saha Özeti", 680, 660);

            pnlOzetHeader = UIHelper.HeaderPanelOlustur("📄  Saha Özeti", "Bilgileri kontrol edin; onaylayarak kaydedebilirsiniz");

            // Scroll — Dock.Fill (otomatik boyut, butonlar kesilmez)
            pnlOzetScroll = new Panel { Dock = DockStyle.Fill, BackColor = UIHelper.CArkaplan, AutoScroll = true };

            int x = 32, y = 18;

            // Özet kartı
            pnlOzetKart = UIHelper.KartPanel(x, y, 614, 432);
            pnlOzetKart.Paint += (s, e) =>
            {
                var p = (Panel)s;
                e.Graphics.DrawRectangle(new System.Drawing.Pen(UIHelper.CBolme, 1), 0, 0, p.Width - 1, p.Height - 1);
                e.Graphics.FillRectangle(new System.Drawing.SolidBrush(UIHelper.CVurgu), 0, 0, 6, p.Height);
            };
            pnlOzetKart.Controls.Add(new Label { Text = "📋 Saha Bilgileri Özeti", Font = UIHelper.FAltBaslik, ForeColor = UIHelper.CAna, AutoSize = true, Location = new Point(18, 14) });

            // Bilgi satırları
            int ky = 52;
            void Row(string lbl, out Label valLbl, int h = 26)
            {
                pnlOzetKart.Controls.Add(new Label { Text = lbl, Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, Location = new Point(20, ky), Size = new Size(145, h) });
                valLbl = new Label { Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik, Location = new Point(170, ky), AutoSize = false, Size = new Size(430, h) };
                pnlOzetKart.Controls.Add(valLbl);
                ky += h + 6;
            }

            Row("Saha Adı:",       out lblOzetSahaAdi);
            Row("Adres:",          out lblOzetAdres);
            Row("Kapasite:",       out lblOzetKapasite);
            Row("Fiyat/Saat:",     out lblOzetFiyat);
            Row("Müsait Günler:",  out lblOzetGunler,  h: 40);
            Row("Müsait Saatler:", out lblOzetSaatler);
            Row("Açıklama:",       out lblOzetAciklama, h: 48);

            pnlOzetScroll.Controls.Add(pnlOzetKart);
            y += 450;

            // Uyarı
            lblOzetNot = new Label
            {
                Text = "ℹ  Bilgiler doğru mu? Onayladıktan sonra sisteme kaydedilir.",
                Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CMetinAcik,
                AutoSize = true, Location = new Point(x, y)
            };
            pnlOzetScroll.Controls.Add(lblOzetNot);
            y += 28;

            // Butonlar
            btnOzetDuzenle = UIHelper.BtnSecondary("✏  Düzenle",        x,         y, 160, 46); btnOzetDuzenle.Name = "btnOzetDuzenle"; btnOzetDuzenle.Click += (s, e) => this.Close();
            btnOzetKaydet  = UIHelper.BtnPrimary("✅  Onayla ve Kaydet", x + 180,   y, 250, 46); btnOzetKaydet.Name  = "btnOzetKaydet";  btnOzetKaydet.Click  += BtnKaydet_Click;
            pnlOzetScroll.Controls.Add(btnOzetDuzenle);
            pnlOzetScroll.Controls.Add(btnOzetKaydet);

            this.Controls.Add(pnlOzetScroll);
            this.Controls.Add(pnlOzetHeader);
            this.ResumeLayout(false);
        }

        private Panel pnlOzetHeader, pnlOzetScroll, pnlOzetKart;
        private Label lblOzetSahaAdi, lblOzetAdres, lblOzetKapasite, lblOzetFiyat;
        private Label lblOzetGunler, lblOzetSaatler, lblOzetAciklama, lblOzetNot;
        private Button btnOzetDuzenle, btnOzetKaydet;
    }
}
