using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;

namespace SahalarBurada.Forms
{
    public class FormSahaListesi : Form
    {
        private readonly List<HaliSaha> _sahalar;
        private readonly DateTime _tarih;
        private readonly string _saat;

        public FormSahaListesi(List<HaliSaha> sahalar, DateTime tarih, string saat)
        {
            _sahalar = sahalar; _tarih = tarih; _saat = saat;
            UIHelper.FormAyarla(this, "Uygun Sahalar", 880, 690);
            InitUI();
        }

        private void InitUI()
        {
            string baslik = $"📋  Uygun Sahalar — {_tarih:dd.MM.yyyy}  {_saat}";
            this.Controls.Add(UIHelper.HeaderPanelOlustur(baslik,
                $"{_sahalar.Count} müsait saha bulundu"));

            // Scroll paneli
            var scroll = new Panel
            {
                Location = new Point(0, 95), Size = new Size(880, 545),
                BackColor = UIHelper.CArkaplan, AutoScroll = true
            };
            var flow = new FlowLayoutPanel
            {
                AutoSize = true, FlowDirection = FlowDirection.TopDown,
                WrapContents = false, Padding = new Padding(20, 12, 20, 12),
                BackColor = Color.Transparent
            };
            foreach (var s in _sahalar)
                flow.Controls.Add(BuildSahaKartı(s));
            scroll.Controls.Add(flow);
            this.Controls.Add(scroll);

            // Alt bar
            var alt = new Panel { Dock = DockStyle.Bottom, Height = 52, BackColor = Color.White };
            alt.Paint += (s, e) =>
                e.Graphics.DrawLine(new Pen(UIHelper.CBolme), 0, 0, alt.Width, 0);
            var btnGeri = UIHelper.BtnSecondary("← Geri", 20, 7, 130, 38);
            btnGeri.Click += (s, e) => this.Close();
            alt.Controls.Add(btnGeri);
            this.Controls.Add(alt);
        }

        private Panel BuildSahaKartı(HaliSaha saha)
        {
            var kart = new Panel
            {
                Size = new Size(820, 160), Margin = new Padding(0, 0, 0, 12),
                BackColor = Color.White
            };
            kart.Paint += (s, e) =>
            {
                var p = (Panel)s;
                e.Graphics.DrawRectangle(new Pen(UIHelper.CBolme, 1), 0, 0, p.Width - 1, p.Height - 1);
                // Sol aksan çizgi
                e.Graphics.FillRectangle(new SolidBrush(UIHelper.CVurgu), 0, 0, 6, p.Height);
            };

            kart.Controls.Add(new Label
            {
                Text = "⚽  " + saha.Ad, Font = UIHelper.FAltBaslik,
                ForeColor = UIHelper.CAna, AutoSize = true, Location = new Point(22, 15)
            });
            kart.Controls.Add(new Label
            {
                Text = "📍  " + saha.Adres, Font = UIHelper.FNormal,
                ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new Point(22, 52)
            });
            kart.Controls.Add(new Label
            {
                Text = $"👥  {saha.Kapasite} kişi", Font = UIHelper.FNormal,
                ForeColor = UIHelper.CMetin, AutoSize = true, Location = new Point(22, 82)
            });
            kart.Controls.Add(new Label
            {
                Text = $"💰  {saha.FiyatSaat:N0} ₺ / saat",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = UIHelper.CAna, AutoSize = true, Location = new Point(210, 82)
            });

            if (!string.IsNullOrWhiteSpace(saha.Aciklama))
            {
                var kisa = saha.Aciklama.Length > 95
                    ? saha.Aciklama.Substring(0, 95) + "…"
                    : saha.Aciklama;
                kart.Controls.Add(new Label
                {
                    Text = kisa, Font = UIHelper.FKucukItalik,
                    ForeColor = UIHelper.CMetinAcik, AutoSize = false,
                    Size = new Size(560, 18), Location = new Point(22, 118)
                });
            }

            var sahaRef = saha;
            var btnSec = UIHelper.BtnPrimary("Seç  →", 700, 60, 100, 40);
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
                else
                    this.Show();
            };
            f.Show();
        }
    }
}
