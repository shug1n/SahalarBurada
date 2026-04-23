using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SahalarBurada.Helpers;

namespace SahalarBurada.Forms
{
    public class FormAnaEkran : Form
    {
        public FormAnaEkran()
        {
            UIHelper.FormAyarla(this, "Ana Sayfa", 1020, 690);
            this.Text = "SahalarBurada — Halı Saha Kiralama Platformu";
            InitUI();
        }

        private void InitUI()
        {
            // ── Header ──────────────────────────────────────────────
            var header = new Panel { Dock = DockStyle.Top, Height = 155, BackColor = UIHelper.CAna };
            header.Paint += (s, e) =>
            {
                using (var br = new LinearGradientBrush(header.ClientRectangle,
                    Color.FromArgb(18, 62, 22), Color.FromArgb(46, 125, 50),
                    LinearGradientMode.Horizontal))
                    e.Graphics.FillRectangle(br, header.ClientRectangle);
            };
            header.Controls.Add(new Label
            {
                Text = "⚽ SahalarBurada",
                Font = new Font("Segoe UI", 32, FontStyle.Bold),
                ForeColor = Color.White, AutoSize = true,
                Location = new Point(50, 28), BackColor = Color.Transparent
            });
            header.Controls.Add(new Label
            {
                Text = "Türkiye'nin Hızlı Halı Saha Kiralama Platformu",
                Font = new Font("Segoe UI", 11.5f),
                ForeColor = Color.FromArgb(200, 255, 255, 255),
                AutoSize = true, Location = new Point(53, 90), BackColor = Color.Transparent
            });

            // ── İçerik ──────────────────────────────────────────────
            var tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1,
                BackColor = UIHelper.CArkaplan, Padding = new Padding(40, 30, 40, 30)
            };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            tbl.Controls.Add(BuildKiracıCard(), 0, 0);
            tbl.Controls.Add(BuildOrgCard(), 1, 0);

            this.Controls.Add(tbl);
            this.Controls.Add(header);
        }

        private Panel BuildKiracıCard()
        {
            var card = new Panel
            {
                Dock = DockStyle.Fill, BackColor = Color.White,
                Margin = new Padding(0, 0, 14, 0)
            };
            card.Paint += PaintKartKenar;

            card.Controls.Add(new Label
            {
                Text = "🧑‍🤝‍🧑", Font = new Font("Segoe UI Emoji", 36),
                AutoSize = true, Location = new Point(35, 30), BackColor = Color.Transparent
            });
            card.Controls.Add(new Label
            {
                Text = "Halı Saha Kirala", Font = UIHelper.FBaslik,
                ForeColor = UIHelper.CAna, AutoSize = true, Location = new Point(35, 108)
            });
            card.Controls.Add(new Label
            {
                Text = "Müsait sahaları kolayca bul ve hemen rezervasyon yap.\nGiriş yapmadan da saha arayabilirsin!",
                Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik,
                AutoSize = true, MaximumSize = new Size(340, 0), Location = new Point(35, 148)
            });

            var sep = new Panel { Location = new Point(35, 215), Size = new Size(340, 1), BackColor = UIHelper.CBolme };
            card.Controls.Add(sep);

            var btnMac = UIHelper.BtnPrimary("⚽   Maç Ara / Kirala  (Giriş Gerektirmez)", 35, 232, 350, 50);
            btnMac.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnMac.Click += (s, e) => NavSahaAra();
            card.Controls.Add(btnMac);

            var btnGiris = UIHelper.BtnSecondary("👤   Giriş Yap / Kayıt Ol", 35, 298, 350, 44);
            btnGiris.Click += (s, e) => NavKiracıGiris();
            card.Controls.Add(btnGiris);

            return card;
        }

        private Panel BuildOrgCard()
        {
            var card = new Panel
            {
                Dock = DockStyle.Fill, BackColor = Color.White,
                Margin = new Padding(14, 0, 0, 0)
            };
            card.Paint += PaintKartKenar;

            card.Controls.Add(new Label
            {
                Text = "🏢", Font = new Font("Segoe UI Emoji", 36),
                AutoSize = true, Location = new Point(35, 30), BackColor = Color.Transparent
            });
            card.Controls.Add(new Label
            {
                Text = "Organizatör Girişi", Font = UIHelper.FBaslik,
                ForeColor = UIHelper.CAna, AutoSize = true, Location = new Point(35, 108)
            });
            card.Controls.Add(new Label
            {
                Text = "İşletmenizi sisteme kaydedin, halı sahalarınızı\nyönetin ve rezervasyonları takip edin.",
                Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik,
                AutoSize = true, MaximumSize = new Size(340, 0), Location = new Point(35, 148)
            });

            var sep = new Panel { Location = new Point(35, 215), Size = new Size(340, 1), BackColor = UIHelper.CBolme };
            card.Controls.Add(sep);

            var btnGiris = UIHelper.BtnPrimary("🏢   Giriş Yap / Kayıt Ol", 35, 232, 350, 50);
            btnGiris.Click += (s, e) => NavOrgGiris();
            card.Controls.Add(btnGiris);

            card.Controls.Add(new Label
            {
                Text = "ℹ  İşletme girişi zorunludur",
                Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CUyari,
                AutoSize = true, Location = new Point(35, 300)
            });

            // Demo hint
            card.Controls.Add(new Label
            {
                Text = "Demo: demo@org.com  /  123456",
                Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CMetinAcik,
                AutoSize = true, Location = new Point(35, 322)
            });

            return card;
        }

        private void PaintKartKenar(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var p = (Panel)sender;
            using (var pen = new Pen(UIHelper.CBolme, 1))
                e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
        }

        // ── Navigasyon ───────────────────────────────────────────────
        private void NavSahaAra()
        {
            var f = new FormSahaAra();
            this.Hide();
            f.FormClosed += (s, e) => this.Show();
            f.Show();
        }

        private void NavKiracıGiris()
        {
            var f = new FormKiracıGiris();
            this.Hide();
            f.FormClosed += (s, e) => this.Show();
            f.Show();
        }

        private void NavOrgGiris()
        {
            var f = new FormOrganizatorGiris();
            this.Hide();
            f.FormClosed += (s, e) => this.Show();
            f.Show();
        }
    }
}
