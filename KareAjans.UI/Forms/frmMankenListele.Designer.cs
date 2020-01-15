namespace KareAjans.UI
{
    partial class frmMankenListele
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMankenListele));
            this.dgmMankenList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtYorum = new System.Windows.Forms.TextBox();
            this.btnYorumEkle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblguncelle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgmMankenList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgmMankenList
            // 
            this.dgmMankenList.AllowUserToAddRows = false;
            this.dgmMankenList.AllowUserToDeleteRows = false;
            this.dgmMankenList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgmMankenList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgmMankenList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgmMankenList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgmMankenList.Location = new System.Drawing.Point(9, 108);
            this.dgmMankenList.Name = "dgmMankenList";
            this.dgmMankenList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgmMankenList.Size = new System.Drawing.Size(1051, 389);
            this.dgmMankenList.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItem1.Text = "Güncelle";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItem2.Text = "Yazdır";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // txtYorum
            // 
            this.txtYorum.Location = new System.Drawing.Point(790, 78);
            this.txtYorum.Name = "txtYorum";
            this.txtYorum.Size = new System.Drawing.Size(164, 20);
            this.txtYorum.TabIndex = 2;
            // 
            // btnYorumEkle
            // 
            this.btnYorumEkle.BackColor = System.Drawing.Color.OrangeRed;
            this.btnYorumEkle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYorumEkle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYorumEkle.ForeColor = System.Drawing.SystemColors.Window;
            this.btnYorumEkle.Location = new System.Drawing.Point(960, 73);
            this.btnYorumEkle.Name = "btnYorumEkle";
            this.btnYorumEkle.Size = new System.Drawing.Size(100, 29);
            this.btnYorumEkle.TabIndex = 3;
            this.btnYorumEkle.Text = "Yorum Ekle";
            this.btnYorumEkle.UseVisualStyleBackColor = false;
            this.btnYorumEkle.Click += new System.EventHandler(this.btnYorumEkle_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.lblguncelle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 55);
            this.panel1.TabIndex = 6;
            // 
            // lblguncelle
            // 
            this.lblguncelle.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblguncelle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblguncelle.Location = new System.Drawing.Point(3, 28);
            this.lblguncelle.Name = "lblguncelle";
            this.lblguncelle.Size = new System.Drawing.Size(301, 27);
            this.lblguncelle.TabIndex = 2;
            this.lblguncelle.Text = "Manken Listesi";
            // 
            // frmMankenListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1071, 510);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnYorumEkle);
            this.Controls.Add(this.txtYorum);
            this.Controls.Add(this.dgmMankenList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMankenListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manken Listesi";
            this.Load += new System.EventHandler(this.frmMankenListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgmMankenList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgmMankenList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox txtYorum;
        private System.Windows.Forms.Button btnYorumEkle;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblguncelle;
    }
}