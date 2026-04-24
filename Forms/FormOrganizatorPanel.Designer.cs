using System.Windows.Forms;

namespace SahalarBurada.Forms
{
    partial class FormOrganizatorPanel
    {
        private Panel pnlHeader;
        private Label lblHeaderBaslik;
        private Label lblHeaderAltBaslik;

        private Panel pnlToolbar;
        private Button btnYeni;
        private Button btnYenile;
        private Button btnCikis;

        private Panel pnlContent;
        private Label lblSahalarim;
        private Label lblSahaCount;
        private DataGridView dgvSahalar;
        private DataGridViewTextBoxColumn colAd;
        private DataGridViewTextBoxColumn colAdres;
        private DataGridViewTextBoxColumn colKapasite;
        private DataGridViewTextBoxColumn colFiyat;
        private DataGridViewTextBoxColumn colTarih;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderBaslik = new System.Windows.Forms.Label();
            this.lblHeaderAltBaslik = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnYeni = new System.Windows.Forms.Button();
            this.btnYenile = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblSahalarim = new System.Windows.Forms.Label();
            this.lblSahaCount = new System.Windows.Forms.Label();
            this.dgvSahalar = new System.Windows.Forms.DataGridView();
            this.colAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKapasite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSahalar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.pnlHeader.Controls.Add(this.lblHeaderBaslik);
            this.pnlHeader.Controls.Add(this.lblHeaderAltBaslik);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(960, 95);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderBaslik
            // 
            this.lblHeaderBaslik.AutoSize = true;
            this.lblHeaderBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderBaslik.ForeColor = System.Drawing.Color.White;
            this.lblHeaderBaslik.Location = new System.Drawing.Point(25, 16);
            this.lblHeaderBaslik.Name = "lblHeaderBaslik";
            this.lblHeaderBaslik.Size = new System.Drawing.Size(200, 30);
            this.lblHeaderBaslik.TabIndex = 0;
            this.lblHeaderBaslik.Text = "🏢  İşletme Adı";
            // 
            // lblHeaderAltBaslik
            // 
            this.lblHeaderAltBaslik.AutoSize = true;
            this.lblHeaderAltBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderAltBaslik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderAltBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHeaderAltBaslik.Location = new System.Drawing.Point(27, 52);
            this.lblHeaderAltBaslik.Name = "lblHeaderAltBaslik";
            this.lblHeaderAltBaslik.Size = new System.Drawing.Size(150, 15);
            this.lblHeaderAltBaslik.TabIndex = 1;
            this.lblHeaderAltBaslik.Text = "Hoş geldiniz...";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.btnYeni);
            this.pnlToolbar.Controls.Add(this.btnYenile);
            this.pnlToolbar.Controls.Add(this.btnCikis);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 95);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(960, 60);
            this.pnlToolbar.TabIndex = 1;
            this.pnlToolbar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlToolbar_Paint);
            // 
            // btnYeni
            // 
            this.btnYeni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnYeni.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYeni.FlatAppearance.BorderSize = 0;
            this.btnYeni.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnYeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeni.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYeni.ForeColor = System.Drawing.Color.White;
            this.btnYeni.Location = new System.Drawing.Point(20, 10);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(185, 40);
            this.btnYeni.TabIndex = 0;
            this.btnYeni.Text = "➕   Yeni Saha Ekle";
            this.btnYeni.UseVisualStyleBackColor = false;
            this.btnYeni.Click += new System.EventHandler(this.BtnYeniSaha_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.BackColor = System.Drawing.Color.White;
            this.btnYenile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYenile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnYenile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(240)))));
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYenile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYenile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnYenile.Location = new System.Drawing.Point(218, 10);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(110, 40);
            this.btnYenile.TabIndex = 1;
            this.btnYenile.Text = "🔄  Yenile";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.BtnYenile_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCikis.FlatAppearance.BorderSize = 0;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(840, 10);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(110, 40);
            this.btnCikis.TabIndex = 2;
            this.btnCikis.Text = "Çıkış Yap";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.BtnCikis_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.pnlContent.Controls.Add(this.lblSahalarim);
            this.pnlContent.Controls.Add(this.lblSahaCount);
            this.pnlContent.Controls.Add(this.dgvSahalar);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 155);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(960, 535);
            this.pnlContent.TabIndex = 2;
            // 
            // lblSahalarim
            // 
            this.lblSahalarim.AutoSize = true;
            this.lblSahalarim.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblSahalarim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSahalarim.Location = new System.Drawing.Point(22, 18);
            this.lblSahalarim.Name = "lblSahalarim";
            this.lblSahalarim.Size = new System.Drawing.Size(99, 25);
            this.lblSahalarim.TabIndex = 0;
            this.lblSahalarim.Text = "Sahalarım";
            // 
            // lblSahaCount
            // 
            this.lblSahaCount.AutoSize = true;
            this.lblSahaCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSahaCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblSahaCount.Location = new System.Drawing.Point(22, 46);
            this.lblSahaCount.Name = "lblSahaCount";
            this.lblSahaCount.Size = new System.Drawing.Size(120, 15);
            this.lblSahaCount.TabIndex = 1;
            this.lblSahaCount.Text = "Toplam 0 saha kayıtlı";
            // 
            // dgvSahalar
            // 
            this.dgvSahalar.AllowUserToAddRows = false;
            this.dgvSahalar.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(247)))));
            this.dgvSahalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSahalar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSahalar.BackgroundColor = System.Drawing.Color.White;
            this.dgvSahalar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSahalar.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvSahalar.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.dgvSahalar.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvSahalar.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSahalar.ColumnHeadersHeight = 40;
            this.dgvSahalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSahalar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAd,
            this.colAdres,
            this.colKapasite,
            this.colFiyat,
            this.colTarih});
            this.dgvSahalar.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvSahalar.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvSahalar.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.dgvSahalar.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvSahalar.EnableHeadersVisualStyles = false;
            this.dgvSahalar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            this.dgvSahalar.Location = new System.Drawing.Point(22, 72);
            this.dgvSahalar.MultiSelect = false;
            this.dgvSahalar.Name = "dgvSahalar";
            this.dgvSahalar.ReadOnly = true;
            this.dgvSahalar.RowHeadersVisible = false;
            this.dgvSahalar.RowTemplate.Height = 36;
            this.dgvSahalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSahalar.Size = new System.Drawing.Size(912, 440);
            this.dgvSahalar.TabIndex = 2;
            // 
            // colAd
            // 
            this.colAd.HeaderText = "Saha Adı";
            this.colAd.Name = "colAd";
            this.colAd.ReadOnly = true;
            // 
            // colAdres
            // 
            this.colAdres.HeaderText = "Adres";
            this.colAdres.Name = "colAdres";
            this.colAdres.ReadOnly = true;
            // 
            // colKapasite
            // 
            this.colKapasite.HeaderText = "Kapasite";
            this.colKapasite.Name = "colKapasite";
            this.colKapasite.ReadOnly = true;
            // 
            // colFiyat
            // 
            this.colFiyat.HeaderText = "Fiyat/Saat";
            this.colFiyat.Name = "colFiyat";
            this.colFiyat.ReadOnly = true;
            // 
            // colTarih
            // 
            this.colTarih.HeaderText = "Eklenme Tarihi";
            this.colTarih.Name = "colTarih";
            this.colTarih.ReadOnly = true;
            // 
            // FormOrganizatorPanel
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(960, 690);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormOrganizatorPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SahalarBurada — Organizatör Paneli";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSahalar)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
