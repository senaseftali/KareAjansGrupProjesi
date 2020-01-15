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
using KareAjans.BLL;
using KareAjans.DTO;

namespace KareAjans.UI.Forms
{

    public partial class frmMuhasebe : Form
    {
        private DataTable dt;
        public frmMuhasebe()
        {
            InitializeComponent();
            FillOrganizasyon();
        }

        private void FrmMuhasebe_Load(object sender, EventArgs e)
        {
            FillOrganizasyon();
        }

        private void cbOrganizasyon_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillForm(Convert.ToInt32(cbOrganizasyon.SelectedIndex + 1));
        }
        public void FillOrganizasyon()
        {
            List<OrganizasyonDTO> organizasyon = new List<OrganizasyonDTO>();
            OrganizasyonBLL organizasyondto = new OrganizasyonBLL();
            organizasyon = organizasyondto.OrganizasyonlarıGetir();
            cbOrganizasyon.ValueMember = "OrganizasyonID";
            cbOrganizasyon.DisplayMember = "Ad";
            cbOrganizasyon.DataSource = organizasyon;
        }
        public void FillForm(int orgId)
        {
            OrganizasyonBLL organizasyon = new OrganizasyonBLL();
            SqlDataAdapter adapter = organizasyon.MuhasebeAdapterGetir(orgId);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            int ödenecek = 0;
            int harcama = 0;
            OrganizasyonBLL organizasyonBll = new OrganizasyonBLL();
            OrganizasyonDTO organizasyonGelir = organizasyonBll.OrganizasyonGelirGetir(orgId);
            decimal ToplamGelir = organizasyonGelir.OrganizasyonGelir;
            foreach (DataRow dtRow in dt.Rows)
            {
                ödenecek += Convert.ToInt32(dtRow["Odenecek"]);
                harcama += Convert.ToInt32(dtRow["Harcama"]);
            }

            lblÖdeme.Text = ödenecek.ToString();
            lblHarcama.Text = harcama.ToString();
            lblGenelToplam.Text = (ödenecek + harcama).ToString();
            lblKar.Text = $"{ToplamGelir} - {ödenecek} - {harcama} = {ToplamGelir - ödenecek - harcama}";
        }
    }
}
