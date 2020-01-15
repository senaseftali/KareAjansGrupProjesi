using KareAjans.BLL;
using KareAjans.DTO;
using KareAjans.Entities.EntityClasses;
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
    public partial class frmOrganizasyonDetayEkle : Form
    {
        private List<MankenAdDTO> fullName;
        private frmOrganizasyonEkle organizasyonEkle;
        private DataTable dt;
        private MankenBLL manken;
        private List<OrganizasyonGider> organizasyonGiders;
        private OrganizasyonDTO organizasyonDto;
        public frmOrganizasyonDetayEkle(OrganizasyonDTO organizasyon)
        {
            InitializeComponent();
           

            organizasyonDto = organizasyon;
            organizasyonGiders = new List<OrganizasyonGider>();
            manken = new MankenBLL();
            fullName = manken.MankenAdDTOGetir();
        }

        private void frmOrganizasyonDetayEkle_Load(object sender, EventArgs e)
        {
            
            MankenBLL mankenBll = new MankenBLL();
            SqlDataAdapter adapter = mankenBll.UygunMankenGetirAdapter();
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manken manken = new Manken();
            int mankenID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            MankenBLL mankenBll = new MankenBLL();
            manken = mankenBll.MankenGetir(mankenID);
            OrganizasyonBLL organizasyonBll = new OrganizasyonBLL();
            int organizasyonID = organizasyonBll.SonOrganizasyonID() + 1;
            OrganizasyonGider organizasyonGider = new OrganizasyonGider();
            OrganizasyonGelir organizasyonGelir = new OrganizasyonGelir();
            organizasyonGider.OrganizasyonID = organizasyonID;
            organizasyonGider.MankenID = manken.MankenID;
            organizasyonGider.Manken = manken;
            organizasyonGider.GelirYuzdesi = manken.KategoriID == 3 ? (decimal)0.2 : 0m;
            organizasyonGider.GunlukUcret = manken.KategoriID == 3 ? 0m : manken.KategoriID == 2 ? 100m : 40m;
            organizasyonGider.OgunUcreti = manken.Adres[0].Sehir == organizasyonDto.Yer ? 10m : 20m;
            organizasyonGider.KonaklamaUcreti = manken.Adres[0].Sehir == organizasyonDto.Yer ? 0m : 40m;
            organizasyonGider.Butce = organizasyonDto.OrganizasyonGelir;
            organizasyonGider.GunSayisi = (short)organizasyonDto.OrganızasyonGünSayısı;
            organizasyonGider.KategoriUcKisiSayisi = organizasyonDto.Kat3KişiSayısı;
            organizasyonGelir.Butce = organizasyonGider.Butce;
            manken.Durum = false;
            mankenBll.MankenGuncelle(manken);
            dt.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            organizasyonEkle = this.Owner as frmOrganizasyonEkle;
            organizasyonEkle.GiderDoldur(organizasyonGider);
            organizasyonGiders.Add(organizasyonGider);
            //Manken manken = new Manken();
            //int mankenID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            //MankenBLL mankenBll = new MankenBLL();
            //manken = mankenBll.MankenGetir(mankenID);
            //OrganizasyonBLL organizasyonBll = new OrganizasyonBLL();
            //int organizasyonID = organizasyonBll.SonOrganizasyonID();
            //OrganizasyonGider organizasyonGider = new OrganizasyonGider();
            //organizasyonGider.OrganizasyonID = organizasyonID;
            //organizasyonGider.MankenID = manken.MankenID;
            //organizasyonGider.Manken = manken;
            //organizasyonGider.GelirYuzdesi = manken.KategoriID == 3 ? (decimal) : 0m;
            //organizasyonGider.GunlukUcret = 10m;
            //organizasyonGider.OgunUcreti = manken.Adres[0].Sehir == organizasyonDto.Yer ? 10m : 20m;
            //organizasyonGider.KonaklamaUcreti = manken.Adres[0].Sehir == organizasyonDto.Yer ? 0m : manken.KategoriID == 3 ? 0m : manken.KategoriID == 2 ? 100m : 40m;
            //organizasyonGider.Butce = organizasyonDto.OrganizasyonGelir;
            //organizasyonGider.GunSayisi = (short)organizasyonDto.OrganızasyonGünSayısı;
            //organizasyonGider.KategoriUcKisiSayisi = organizasyonDto.Kat3KişiSayısı;
            //manken.Durum = false;
            //mankenBll.MankenGuncelle(manken);
            //dt.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            //organizasyonEkle = this.Owner as frmOrganizasyonEkle;
            //organizasyonEkle.GiderDoldur(organizasyonGider);
            //organizasyonGiders.Add(organizasyonGider);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrganizasyonBLL organizasyonBll = new OrganizasyonBLL();
            this.Close();
        }
    }
}
