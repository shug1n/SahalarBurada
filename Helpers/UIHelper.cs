using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SahalarBurada.Helpers
{
    public static class UIHelper
    {
        // ─── Renkler ────────────────────────────────────────────────
        public static readonly Color CAna        = Color.FromArgb(27,  94,  32);  // koyu yeşil
        public static readonly Color CIkinci     = Color.FromArgb(56, 142,  60);  // orta yeşil
        public static readonly Color CVurgu      = Color.FromArgb(76, 175,  80);  // açık yeşil
        public static readonly Color CArkaplan   = Color.FromArgb(240, 245, 240); // çok açık yeşil-gri
        public static readonly Color CKart       = Color.White;
        public static readonly Color CMetin      = Color.FromArgb(30,  30,  30);
        public static readonly Color CMetinAcik  = Color.FromArgb(100, 100, 100);
        public static readonly Color CBolme      = Color.FromArgb(218, 224, 218);
        public static readonly Color CHata       = Color.FromArgb(198,  40,  40);
        public static readonly Color CUyari      = Color.FromArgb(230, 120,   0);

        // ─── Fontlar ────────────────────────────────────────────────
        public static readonly Font FBuyukBaslik = new Font("Segoe UI", 26, FontStyle.Bold);
        public static readonly Font FBaslik      = new Font("Segoe UI", 16, FontStyle.Bold);
        public static readonly Font FAltBaslik   = new Font("Segoe UI", 13, FontStyle.Bold);
        public static readonly Font FNormalKalin = new Font("Segoe UI", 10, FontStyle.Bold);
        public static readonly Font FNormal      = new Font("Segoe UI", 10);
        public static readonly Font FKucuk       = new Font("Segoe UI",  9);
        public static readonly Font FKucukItalik = new Font("Segoe UI",  9, FontStyle.Italic);

        // ─── Form ayarı ─────────────────────────────────────────────
        public static void FormAyarla(Form f, string baslik, int w = 860, int h = 660)
        {
            f.Text = "SahalarBurada — " + baslik;
            f.Size = new Size(w, h);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.FormBorderStyle = FormBorderStyle.FixedSingle;
            f.MaximizeBox = false;
            f.BackColor = CArkaplan;
            f.Font = FNormal;
        }

        // ─── Header panel ───────────────────────────────────────────
        public static Panel HeaderPanelOlustur(string baslik, string altBaslik = null)
        {
            int h = altBaslik != null ? 95 : 70;
            var p = new Panel { Dock = DockStyle.Top, Height = h, BackColor = CAna };
            p.Paint += (s, e) =>
            {
                using (var br = new LinearGradientBrush(p.ClientRectangle,
                    Color.FromArgb(21, 71, 25), Color.FromArgb(56, 142, 60),
                    LinearGradientMode.Horizontal))
                    e.Graphics.FillRectangle(br, p.ClientRectangle);
            };
            p.Controls.Add(new Label
            {
                Text = baslik, Font = FBaslik, ForeColor = Color.White,
                AutoSize = true, Location = new Point(25, altBaslik != null ? 16 : 20),
                BackColor = Color.Transparent
            });
            if (altBaslik != null)
                p.Controls.Add(new Label
                {
                    Text = altBaslik, Font = FKucuk,
                    ForeColor = Color.FromArgb(200, 255, 255, 255),
                    AutoSize = true, Location = new Point(27, 52),
                    BackColor = Color.Transparent
                });
            return p;
        }

        // ─── Butonlar ───────────────────────────────────────────────
        public static Button BtnPrimary(string metin, int x, int y, int w, int h = 44)
        {
            var btn = new Button
            {
                Text = metin, Location = new Point(x, y), Size = new Size(w, h),
                BackColor = CAna, ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = FNormalKalin, Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = CIkinci;
            return btn;
        }

        public static Button BtnSecondary(string metin, int x, int y, int w, int h = 44)
        {
            var btn = new Button
            {
                Text = metin, Location = new Point(x, y), Size = new Size(w, h),
                BackColor = Color.White, ForeColor = CAna,
                FlatStyle = FlatStyle.Flat, Font = FNormalKalin, Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderColor = CAna;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 249, 240);
            return btn;
        }

        public static Button BtnDanger(string metin, int x, int y, int w, int h = 44)
        {
            var btn = new Button
            {
                Text = metin, Location = new Point(x, y), Size = new Size(w, h),
                BackColor = CHata, ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = FNormalKalin, Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        // ─── Label & TextBox factory ─────────────────────────────────
        public static Label LblAlan(string metin, int x, int y)
        {
            return new Label { Text = metin, Location = new Point(x, y), Font = FNormalKalin, ForeColor = CMetin, AutoSize = true };
        }

        public static Label LblNormal(string metin, int x, int y)
        {
            return new Label { Text = metin, Location = new Point(x, y), Font = FNormal, ForeColor = CMetin, AutoSize = true };
        }

        public static Label LblKucuk(string metin, int x, int y, Color? renk = null)
        {
            return new Label { Text = metin, Location = new Point(x, y), Font = FKucuk, ForeColor = renk ?? CMetinAcik, AutoSize = true };
        }

        public static TextBox TxtBox(int x, int y, int w, bool sifre = false)
        {
            var txt = new TextBox
            {
                Location = new Point(x, y), Width = w,
                Font = FNormal, BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White, ForeColor = CMetin
            };
            if (sifre) txt.PasswordChar = '●';
            return txt;
        }

        // ─── Kart paneli ─────────────────────────────────────────────
        public static Panel KartPanel(int x, int y, int w, int h)
        {
            var p = new Panel { Location = new Point(x, y), Size = new Size(w, h), BackColor = Color.White };
            p.Paint += (s, e) =>
                e.Graphics.DrawRectangle(new Pen(CBolme, 1), 0, 0, p.Width - 1, p.Height - 1);
            return p;
        }

        // ─── DataGridView ayarı ──────────────────────────────────────
        public static void DGVAyarla(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = CBolme;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 40;
            dgv.RowTemplate.Height = 36;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = CAna;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = FNormalKalin;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.Font = FNormal;
            dgv.DefaultCellStyle.ForeColor = CMetin;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 247);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 201);
            dgv.DefaultCellStyle.SelectionForeColor = CMetin;
        }
    }
}
