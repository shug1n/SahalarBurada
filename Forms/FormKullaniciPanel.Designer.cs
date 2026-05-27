namespace SahalarBurada.Forms
{
    partial class FormKullaniciPanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnYeniArama = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvRezervasyonlar = new System.Windows.Forms.DataGridView();
            this.pnlGridContainer = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervasyonlar)).BeginInit();
            this.pnlGridContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = SahalarBurada.Helpers.UIHelper.CAna;
            this.pnlHeader.Controls.Add(this.btnYeniArama);
            this.pnlHeader.Controls.Add(this.btnCikis);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 95;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 95);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnYeniArama
            // 
            this.btnYeniArama.BackColor = SahalarBurada.Helpers.UIHelper.CIkinci;
            this.btnYeniArama.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYeniArama.FlatAppearance.BorderSize = 0;
            this.btnYeniArama.FlatAppearance.MouseOverBackColor = SahalarBurada.Helpers.UIHelper.CVurgu;
            this.btnYeniArama.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniArama.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnYeniArama.ForeColor = System.Drawing.Color.White;
            this.btnYeniArama.Location = new System.Drawing.Point(690, 28);
            this.btnYeniArama.Name = "btnYeniArama";
            this.btnYeniArama.Size = new System.Drawing.Size(165, 38);
            this.btnYeniArama.TabIndex = 0;
            this.btnYeniArama.Text = "⚽  Yeni Saha Ara";
            this.btnYeniArama.UseVisualStyleBackColor = false;
            this.btnYeniArama.Click += new System.EventHandler(this.BtnYeniArama_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCikis.FlatAppearance.BorderSize = 0;
            this.btnCikis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(865, 28);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(105, 38);
            this.btnCikis.TabIndex = 1;
            this.btnCikis.Text = "Çıkış Yap";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.BtnCikis_Click);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = SahalarBurada.Helpers.UIHelper.CArkaplan;
            this.pnlToolbar.Controls.Add(this.lblCount);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height = 52;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 95);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1000, 52);
            this.pnlToolbar.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = SahalarBurada.Helpers.UIHelper.CMetin;
            this.lblCount.Location = new System.Drawing.Point(35, 15);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(142, 20);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Rezervasyonlarınız";
            // 
            // dgvRezervasyonlar
            // 
            this.dgvRezervasyonlar.AllowUserToAddRows = false;
            this.dgvRezervasyonlar.AllowUserToDeleteRows = false;
            this.dgvRezervasyonlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRezervasyonlar.BackgroundColor = SahalarBurada.Helpers.UIHelper.CKart;
            this.dgvRezervasyonlar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRezervasyonlar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRezervasyonlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRezervasyonlar.GridColor = SahalarBurada.Helpers.UIHelper.CBolme;
            this.dgvRezervasyonlar.Location = new System.Drawing.Point(30, 12);
            this.dgvRezervasyonlar.Name = "dgvRezervasyonlar";
            this.dgvRezervasyonlar.RowHeadersVisible = false;
            this.dgvRezervasyonlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRezervasyonlar.Size = new System.Drawing.Size(940, 511);
            this.dgvRezervasyonlar.TabIndex = 0;
            this.dgvRezervasyonlar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRezervasyonlar_CellContentClick);
            // 
            // pnlGridContainer
            // 
            this.pnlGridContainer.BackColor = SahalarBurada.Helpers.UIHelper.CArkaplan;
            this.pnlGridContainer.Controls.Add(this.dgvRezervasyonlar);
            this.pnlGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridContainer.Location = new System.Drawing.Point(0, 147);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Padding = new System.Windows.Forms.Padding(30, 12, 30, 30);
            this.pnlGridContainer.Size = new System.Drawing.Size(1000, 553);
            this.pnlGridContainer.TabIndex = 2;
            // 
            // FormKullaniciPanel
            // 
            this.BackColor = SahalarBurada.Helpers.UIHelper.CArkaplan;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.pnlGridContainer);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FormKullaniciPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Paneli";
            this.pnlHeader.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervasyonlar)).EndInit();
            this.pnlGridContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnYeniArama;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvRezervasyonlar;
        private System.Windows.Forms.Panel pnlGridContainer;
    }
}
