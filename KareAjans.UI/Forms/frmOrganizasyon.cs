using KareAjans.BLL;
using KareAjans.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KareAjans.UI.Forms
{
    public partial class frmOrganizasyon : Form
    {
        private DataTable dt;
        bool guvenliCikis = false;
        public frmOrganizasyon()
        {
            InitializeComponent();
            FillMankenler();
            FillOrganizasyon();
        }


        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void CbSutun_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void FillMankenler()
        {
            List<MankenAdDTO> fullName = new List<MankenAdDTO>();
            MankenBLL manken = new MankenBLL();
            fullName = manken.MankenAdDTOGetir();
            cbFiltrelenen.ValueMember = "MankenID";
            cbFiltrelenen.DisplayMember = "FullName";
            cbFiltrelenen.DataSource = fullName;
        }

        public void FillOrganizasyon()
        {
            List<OrganizasyonDTO> organizasyon = new List<OrganizasyonDTO>();
            OrganizasyonBLL organizasyondto = new OrganizasyonBLL();
            organizasyon = organizasyondto.OrganizasyonlarıGetir();
            cbSutun.ValueMember = "OrganizasyonID";
            cbSutun.DisplayMember = "Ad";
            cbSutun.DataSource = organizasyon;
        }

        private void FrmOrganizasyon_Load(object sender, EventArgs e)
        {
            OrganizasyonBLL organizasyonBLL = new OrganizasyonBLL();
            SqlDataAdapter adapter = organizasyonBLL.OrganizasyonAdapter();
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void güvenliÇıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guvenliCikis = true;
            this.Owner.Show();
            this.Close();
        }

        private void frmOrganizasyon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (guvenliCikis)
            {
                return;
            }
            DialogResult result = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Kare Ajans", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Owner.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManken manken = new frmManken();
            manken.Owner = this;
            manken.ShowDialog();
        }

        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMankenListele frmMankenListele = new frmMankenListele();
            frmMankenListele.Owner = this;
            frmMankenListele.ShowDialog();
        }

        private void ekleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOrganizasyonEkle frmOrganizasyonEkle = new frmOrganizasyonEkle();
            frmOrganizasyonEkle.Owner = this;
            frmOrganizasyonEkle.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataView view = new DataView(dt);
            view.RowFilter = $"Manken like '%{cbFiltrelenen.Text}%'";
            dataGridView1.DataSource = view;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataView view = new DataView(dt);
            view.RowFilter = $"[Organizasyon Adı] like '%{cbSutun.Text}%' ";
            dataGridView1.DataSource = view;
        }
    }
}
