using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;

namespace SahalarBurada.Forms
{
    public partial class FormSahaListesi : Form
    {
        private readonly List<HaliSaha> _sahalar;
        private readonly DateTime _tarih;
        private readonly string _saat;

        public FormSahaListesi(List<HaliSaha> sahalar, DateTime tarih, string saat)
        {
            _sahalar = sahalar; _tarih = tarih; _saat = saat;
            InitializeComponent();
            YukleKartlar();
        }

        private void YukleKartlar()
        {
            // Header güncelle
            pnlSahaListesiHeader.Controls.Clear();
            var h = UIHelper.HeaderPanelOlustur(
                $"📋  Uygun Sahalar — {_tarih:dd.MM.yyyy}  {_saat}",
                $"{_sahalar.Count} müsait saha bulundu");
            pnlSahaListesiHeader.Dock = DockStyle.None;
            foreach (Control c in h.Controls) pnlSahaListesiHeader.Controls.Add(c);
            pnlSahaListesiHeader.BackColor = h.BackColor;
            pnlSahaListesiHeader.Height    = h.Height;
            pnlSahaListesiHeader.Paint    += (s, e) => h.Invalidate();

            // Kartları oluştur
            flowSahalar.Controls.Clear();
            foreach (var s in _sahalar)
                flowSahalar.Controls.Add(BuildSahaKartı(s));
        }

        private Panel BuildSahaKartı(HaliSaha saha)
        {
            var kart = new Panel { Size = new Size(820, 160), Margin = new Padding(0, 0, 0, 12), BackColor = Color.White };
            kart.Paint += (s, e) =>
            {
                var p = (Panel)s;
                e.Graphics.DrawRectangle(new Pen(UIHelper.CBolme, 1), 0, 0, p.Width - 1, p.Height - 1);
                e.Graphics.FillRectangle(new SolidBrush(UIHelper.CVurgu), 0, 0, 6, p.Height);
            };
            kart.Controls.Add(new Label { Text = "⚽  " + saha.Ad, Font = UIHelper.FAltBaslik, ForeColor = UIHelper.CAna, AutoSize = true, Location = new Point(22, 15) });
            kart.Controls.Add(new Label { Text = "📍  " + saha.Adres, Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new Point(22, 52) });
            kart.Controls.Add(new Label { Text = $"👥  {saha.Kapasite} kişi", Font = UIHelper.FNormal, ForeColor = UIHelper.CMetin, AutoSize = true, Location = new Point(22, 82) });
            kart.Controls.Add(new Label { Text = $"💰  {saha.FiyatSaat:N0} ₺ / saat", Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = UIHelper.CAna, AutoSize = true, Location = new Point(210, 82) });
            if (!string.IsNullOrWhiteSpace(saha.Aciklama))
            {
                var kisa = saha.Aciklama.Length > 95 ? saha.Aciklama.Substring(0, 95) + "…" : saha.Aciklama;
                kart.Controls.Add(new Label { Text = kisa, Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CMetinAcik, AutoSize = false, Size = new Size(560, 18), Location = new Point(22, 118) });
            }
            var sahaRef = saha;
            var btnSec  = UIHelper.BtnPrimary("Seç  →", 700, 60, 100, 40);
            btnSec.Click += (s, e) => SahaSecildi(sahaRef);
            kart.Controls.Add(btnSec);
            return kart;
        }

        private void SahaSecildi(HaliSaha saha)
        {
            var f = new FormRezervasyonOnay(saha, _tarih, _saat);
            this.Hide();
            f.FormClosed += (s, e) =>
            {
                if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                { this.DialogResult = System.Windows.Forms.DialogResult.OK; this.Close(); }
                else this.Show();
            };
            f.Show();
        }
    }
}
