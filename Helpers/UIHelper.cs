using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SahalarBurada.Helpers
{
    public static class UIHelper
    {
        // ─── Renkler ────────────────────────────────────────────────
        public static readonly Color CAna        = Color.FromArgb(25,  88,  30);   // derin yeşil
        public static readonly Color CIkinci     = Color.FromArgb(46, 125,  50);   // orta yeşil
        public static readonly Color CVurgu      = Color.FromArgb(67, 160,  71);   // açık yeşil
        public static readonly Color CArkaplan   = Color.FromArgb(245, 248, 245);  // çok hafif yeşil-krem
        public static readonly Color CKart       = Color.FromArgb(252, 254, 252);  // kırık beyaz kart
        public static readonly Color CMetin      = Color.FromArgb(28,  36,  28);   // koyu yeşil-siyah
        public static readonly Color CMetinAcik  = Color.FromArgb(95, 110,  95);   // yeşilimsi gri
        public static readonly Color CBolme      = Color.FromArgb(210, 220, 210);  // hafif yeşilimsi ayraç
        public static readonly Color CHata       = Color.FromArgb(185,  35,  35);  // kırmızı
        public static readonly Color CUyari      = Color.FromArgb(215, 110,   0);  // turuncu
        public static readonly Color CHeaderGradStart = Color.FromArgb(18,  68,  22);   // header başlangıç
        public static readonly Color CHeaderGradEnd   = Color.FromArgb(46, 125,  50);   // header bitiş
        public static readonly Color CGolge      = Color.FromArgb(20, 0, 30, 0);   // hafif gölge için

        // ─── Fontlar ────────────────────────────────────────────────
        public static readonly Font FBuyukBaslik = new Font("Segoe UI", 26, FontStyle.Bold);
        public static readonly Font FBaslik      = new Font("Segoe UI", 16, FontStyle.Bold);
        public static readonly Font FAltBaslik   = new Font("Segoe UI", 13, FontStyle.Bold);
        public static readonly Font FNormalKalin = new Font("Segoe UI", 10, FontStyle.Bold);
        public static readonly Font FNormal      = new Font("Segoe UI", 10);
        public static readonly Font FKucuk       = new Font("Segoe UI",  9);
        public static readonly Font FKucukItalik = new Font("Segoe UI",  9, FontStyle.Italic);

        // ─── Form ayarı ─────────────────────────────────────────────
        public static void FormAyarla(Form f, string baslik, int w = 1000, int h = 700)
        {
            f.Text = "SahalarBurada — " + baslik;
            f.Size = new Size(w, h);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.FormBorderStyle = FormBorderStyle.FixedSingle;
            f.MaximizeBox = false;
            f.BackColor = CArkaplan;
            f.Font = FNormal;
        }

        public static Panel CenterControlsInCard(Control container, Control[] contents, bool addCardBackground = true)
        {
            int minX = int.MaxValue, minY = int.MaxValue;
            int maxX = 0, maxY = 0;
            foreach (var c in contents)
            {
                if (c.Left < minX) minX = c.Left;
                if (c.Top < minY) minY = c.Top;
                if (c.Right > maxX) maxX = c.Right;
                if (c.Bottom > maxY) maxY = c.Bottom;
            }

            int cardW = maxX - minX + (addCardBackground ? 60 : 0);
            int cardH = maxY - minY + (addCardBackground ? 60 : 0);

            var card = new Panel
            {
                Size = new Size(cardW, cardH),
                BackColor = addCardBackground ? CKart : Color.Transparent
            };

            if (addCardBackground)
            {
                card.Paint += (s, e) =>
                {
                    var g = e.Graphics;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using (var pen = new Pen(CBolme, 1))
                        g.DrawRectangle(pen, 1, 1, cardW - 3, cardH - 3);
                    // Sol vurgu çizgisi
                    using (var br = new SolidBrush(CVurgu))
                        g.FillRectangle(br, 0, 0, 4, cardH);
                };
            }

            foreach (var c in contents)
            {
                container.Controls.Remove(c);
                c.Location = new Point(c.Left - minX + (addCardBackground ? 30 : 0), c.Top - minY + (addCardBackground ? 30 : 0));
                
                if (addCardBackground && c is Panel)
                {
                    c.BackColor = CKart;
                }
                
                card.Controls.Add(c);
            }

            container.Controls.Add(card);

            Action centerCard = () =>
            {
                int topOffset = 0;
                foreach (Control c in container.Controls)
                    if (c != card && c.Dock == DockStyle.Top) topOffset += c.Height;

                int availableH = container.ClientSize.Height - topOffset;
                card.Location = new Point(
                    (container.ClientSize.Width - cardW) / 2,
                    Math.Max(topOffset, topOffset + (availableH - cardH) / 2)
                );
            };

            centerCard();
            container.Resize += (s, e) => centerCard();
            
            card.BringToFront(); // Ensure card doesn't hide behind anything else

            return card;
        }

        // ─── Header panel ───────────────────────────────────────────
        public static Panel HeaderPanelOlustur(string baslik, string altBaslik = null)
        {
            int h = altBaslik != null ? 95 : 70;
            var p = new Panel { Dock = DockStyle.Top, Height = h, BackColor = CAna };
            p.Paint += (s, e) =>
            {
                var g = e.Graphics;
                // Derin gradient
                using (var br = new LinearGradientBrush(p.ClientRectangle,
                    CHeaderGradStart, CHeaderGradEnd,
                    LinearGradientMode.Horizontal))
                    g.FillRectangle(br, p.ClientRectangle);
                // Alt ince aydınlık çizgi
                using (var pen = new Pen(Color.FromArgb(60, 255, 255, 255), 1))
                    g.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
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
                    ForeColor = Color.FromArgb(180, 255, 255, 255),
                    AutoSize = true, Location = new Point(27, 54),
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
                BackColor = CKart, ForeColor = CAna,
                FlatStyle = FlatStyle.Flat, Font = FNormalKalin, Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderColor = CIkinci;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 245, 235);
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
                BackColor = Color.FromArgb(250, 252, 250), ForeColor = CMetin
            };
            if (sifre) txt.PasswordChar = '●';
            return txt;
        }

        // ─── Kart paneli ─────────────────────────────────────────────
        public static Panel KartPanel(int x, int y, int w, int h)
        {
            var p = new Panel { Location = new Point(x, y), Size = new Size(w, h), BackColor = CKart };
            p.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var pen = new Pen(CBolme, 1))
                    e.Graphics.DrawRectangle(pen, 1, 1, p.Width - 3, p.Height - 3);
                using (var br = new SolidBrush(CVurgu))
                    e.Graphics.FillRectangle(br, 0, 0, 4, p.Height);
            };
            return p;
        }

        // ─── DataGridView ayarı ──────────────────────────────────────
        public static void DGVAyarla(DataGridView dgv)
        {
            dgv.BackgroundColor = CKart;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = CBolme;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 42;
            dgv.RowTemplate.Height = 38;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = CAna;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = FNormalKalin;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgv.DefaultCellStyle.Font = FNormal;
            dgv.DefaultCellStyle.ForeColor = CMetin;
            dgv.DefaultCellStyle.BackColor = CKart;
            dgv.DefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(243, 248, 243);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(195, 228, 195);
            dgv.DefaultCellStyle.SelectionForeColor = CMetin;
        }


        // ─── Placeholder (İpucu Metni) ───────────────────────────────
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public static void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholderText);
        }

        public static void EnableEnterKeySelection(Form form)
        {
            if (form == null) return;
            EnableEnterKeySelectionForControls(form.Controls);
        }

        private static void EnableEnterKeySelectionForControls(Control.ControlCollection controls)
        {
            if (controls == null) return;
            foreach (Control c in controls)
            {
                if (c is CheckBox chk)
                {
                    chk.KeyDown += (sender, e) =>
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            chk.Checked = !chk.Checked;
                            e.Handled = true;
                            e.SuppressKeyPress = true;
                        }
                    };
                }
                else if (c is ComboBox cmb)
                {
                    cmb.KeyDown += (sender, e) =>
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (cmb.DroppedDown)
                            {
                                cmb.DroppedDown = false;
                                e.Handled = true;
                                e.SuppressKeyPress = true;
                            }
                            else
                            {
                                cmb.DroppedDown = true;
                                e.Handled = true;
                                e.SuppressKeyPress = true;
                            }
                        }
                    };
                }

                if (c.HasChildren)
                {
                    EnableEnterKeySelectionForControls(c.Controls);
                }
            }
        }
    }
}
