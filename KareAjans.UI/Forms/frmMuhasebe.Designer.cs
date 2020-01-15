namespace KareAjans.UI.Forms
{
    partial class frmMuhasebe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMuhasebe));
            this.lblHarcama = new System.Windows.Forms.Label();
            this.lblKar = new System.Windows.Forms.Label();
            this.lblToplam = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGenelToplam = new System.Windows.Forms.Label();
            this.lblÖdeme = new System.Windows.Forms.Label();
            this.cbOrganizasyon = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblguncelle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHarcama
            // 
            this.lblHarcama.AutoSize = true;
            this.lblHarcama.Location = new System.Drawing.Point(816, 402);
            this.lblHarcama.Name = "lblHarcama";
            this.lblHarcama.Size = new System.Drawing.Size(41, 15);
            this.lblHarcama.TabIndex = 13;
            this.lblHarcama.Text = "label1";
            // 
            // lblKar
            // 
            this.lblKar.AutoSize = true;
            this.lblKar.Location = new System.Drawing.Point(726, 477);
            this.lblKar.Name = "lblKar";
            this.lblKar.Size = new System.Drawing.Size(41, 15);
            this.lblKar.TabIndex = 14;
            this.lblKar.Text = "label1";
            // 
            // lblToplam
            // 
            this.lblToplam.AutoSize = true;
            this.lblToplam.Location = new System.Drawing.Point(627, 402);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new System.Drawing.Size(54, 15);
            this.lblToplam.TabIndex = 15;
            this.lblToplam.Text = "Toplam :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(648, 477);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Kar :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(592, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Genel Toplam :";
            // 
            // lblGenelToplam
            // 
            this.lblGenelToplam.AutoSize = true;
            this.lblGenelToplam.Location = new System.Drawing.Point(726, 437);
            this.lblGenelToplam.Name = "lblGenelToplam";
            this.lblGenelToplam.Size = new System.Drawing.Size(41, 15);
            this.lblGenelToplam.TabIndex = 18;
            this.lblGenelToplam.Text = "label1";
            // 
            // lblÖdeme
            // 
            this.lblÖdeme.AutoSize = true;
            this.lblÖdeme.Location = new System.Drawing.Point(726, 402);
            this.lblÖdeme.Name = "lblÖdeme";
            this.lblÖdeme.Size = new System.Drawing.Size(41, 15);
            this.lblÖdeme.TabIndex = 19;
            this.lblÖdeme.Text = "label1";
            // 
            // cbOrganizasyon
            // 
            this.cbOrganizasyon.FormattingEnabled = true;
            this.cbOrganizasyon.Location = new System.Drawing.Point(45, 420);
            this.cbOrganizasyon.Name = "cbOrganizasyon";
            this.cbOrganizasyon.Size = new System.Drawing.Size(194, 23);
            this.cbOrganizasyon.TabIndex = 11;
            this.cbOrganizasyon.SelectedIndexChanged += new System.EventHandler(this.cbOrganizasyon_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Organizasyon Adına Filtre";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(905, 282);
            this.dataGridView1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.lblguncelle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 63);
            this.panel1.TabIndex = 20;
            // 
            // lblguncelle
            // 
            this.lblguncelle.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblguncelle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblguncelle.Location = new System.Drawing.Point(3, 32);
            this.lblguncelle.Name = "lblguncelle";
            this.lblguncelle.Size = new System.Drawing.Size(351, 31);
            this.lblguncelle.TabIndex = 2;
            this.lblguncelle.Text = "Organizasyon Hesap";
            // 
            // frmMuhasebe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(933, 520);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHarcama);
            this.Controls.Add(this.lblKar);
            this.Controls.Add(this.lblToplam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGenelToplam);
            this.Controls.Add(this.lblÖdeme);
            this.Controls.Add(this.cbOrganizasyon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMuhasebe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muhasebe";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHarcama;
        private System.Windows.Forms.Label lblKar;
        private System.Windows.Forms.Label lblToplam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGenelToplam;
        private System.Windows.Forms.Label lblÖdeme;
        private System.Windows.Forms.ComboBox cbOrganizasyon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblguncelle;
    }
}