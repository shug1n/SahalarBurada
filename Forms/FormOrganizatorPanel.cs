using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormOrganizatorPanel : BaseChildForm
    {

        public FormOrganizatorPanel()
        {
            InitializeComponent();
            SetupLogic();
        }

        private void SetupLogic()
        {
            var org = Oturum.AktifOrganizator;
            lblHeaderBaslik.Text = $"🏢  {org.IsletmeAdi}";
            lblHeaderAltBaslik.Text = $"Hoş geldiniz, {org.Ad} {org.Soyad}  •  {org.Eposta}";

            if (!dgvSahalar.Columns.Contains("btnSil"))
            {
                var btnSil = new DataGridViewButtonColumn();
                btnSil.Name = "btnSil";
                btnSil.HeaderText = "İşlem";
                btnSil.Text = "Sil";
                btnSil.UseColumnTextForButtonValue = true;
                btnSil.FlatStyle = FlatStyle.Flat;
                dgvSahalar.Columns.Add(btnSil);
                dgvSahalar.CellContentClick += DgvSahalar_CellContentClick;
            }
            
            SahalariYukle();
        }

        private void DgvSahalar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSahalar.Columns[e.ColumnIndex].Name == "btnSil")
            {
                if (MessageBox.Show("Bu sahayı ve tüm rezervasyonlarını silmek istediğinize emin misiniz?", "Saha Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string sahaId = dgvSahalar.Rows[e.RowIndex].Tag.ToString();
                    DatabaseServisi.DeleteField(sahaId);
                    SahalariYukle();
                }
            }
        }

        private void pnlToolbar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(UIHelper.CBolme), 0, 59, pnlToolbar.Width, 59);
        }

        private void BtnYenile_Click(object sender, EventArgs e) => SahalariYukle();
        private void BtnCikis_Click(object sender, EventArgs e) { Oturum.CikisYap(); IsBackButtonClicked = true; this.Close(); }

        private void SahalariYukle()
        {
            var sahalar = SahaServisi.OrganizatorSahalari(Oturum.AktifOrganizator.Id);
            dgvSahalar.Rows.Clear();
            foreach (var s in sahalar)
            {
                int idx = dgvSahalar.Rows.Add(s.Ad, s.Adres, (s.Sehir + " / " + s.Ilce).Trim(' ', '/'), s.FiyatSaat.ToString("N0") + " ₺", s.EklenmeTarihi.ToString("dd.MM.yyyy"));
                dgvSahalar.Rows[idx].Tag = s.Id;
            }
            lblSahaCount.Text = sahalar.Count > 0
                ? $"Toplam {sahalar.Count} saha kayıtlı"
                : "Henüz saha eklenmemiş. 'Yeni Saha Ekle' butonu ile başlayın.";
        }

        private void BtnYeniSaha_Click(object sender, EventArgs e)
        {
            var f = new FormSahaEkle();
            this.Hide();
            f.FormClosed += (s, ev) => { this.Show(); SahalariYukle(); };
            f.Show();
        }
    }
}
