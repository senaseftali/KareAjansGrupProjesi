using KareAjans.BLL;
using KareAjans.DTO;
using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KareAjans.UI.Forms
{
    public partial class frmOrganizasyonEkle : Form
    {
        List<string> countryList = new List<string>();
        CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        RegionInfo region;
        OrganizasyonGelir organizasyonGelir;
        public List<OrganizasyonGider> organizasyonGiders;
        private Organizasyon yeniOrganizasyon;
        public frmOrganizasyonEkle()
        {
            InitializeComponent();
            organizasyonGelir = new OrganizasyonGelir();
            organizasyonGiders = new List<OrganizasyonGider>();
            yeniOrganizasyon = new Organizasyon();
        }

        private void btnBitir_Click(object sender, EventArgs e)
        {
            OrganizasyonBLL organizasyonBll = new OrganizasyonBLL();
            organizasyonBll.OrganizasyonEkle(yeniOrganizasyon);
            //foreach (OrganizasyonGider organizasyonGider in organizasyonGiders)
            //{
            //    OrganizasyonBLL organizasyonBll1 = new OrganizasyonBLL();
            //    organizasyonBll1.OrganizasyonGiderEkle(organizasyonGider);
            //}
            this.Close();
        }
        public void GiderDoldur(OrganizasyonGider organizasyonGider)
        {
            organizasyonGiders.Add(organizasyonGider);
        }

        private void btnMankenEkle_Click(object sender, EventArgs e)
        {
            OrganizasyonBLL organizasyonBll = new OrganizasyonBLL();
            OrganizasyonDTO organizasyon = new OrganizasyonDTO();

            Adres adres = new Adres();
            organizasyon.OrganizasyonID = Convert.ToInt32(organizasyonBll.SonOrganizasyonID() +1);
            organizasyon.Ad = textBox1.Text;
            organizasyon.BaslangicTArihi = dateTimePicker1.Value;
            organizasyon.BitisTarihi = dateTimePicker2.Value;
            organizasyon.OrganizasyonGelir = numericUpDown1.Value;
            organizasyon.Kat3KişiSayısı = (int)numericUpDown3.Value;
            adres.Sehir = txtSehir.Text;
            adres.AcikAdres = txtAdres.Text;
            adres.Ulke = cmbUlke.Text;
            organizasyon.Adres = adres;
            frmOrganizasyonDetayEkle organizasyonDetay = new frmOrganizasyonDetayEkle(organizasyon);
            organizasyonDetay.Owner = this;
            organizasyonDetay.ShowDialog();
            organizasyonGelir.Butce = numericUpDown1.Value;
            organizasyonGelir.OrganizasyonID = organizasyonBll.SonOrganizasyonID() + 1;
            yeniOrganizasyon = OrganizasyonOlustur(organizasyon);
           
        }
        public Organizasyon OrganizasyonOlustur(OrganizasyonDTO organizasyonDto)
        {
            Organizasyon organizasyon = new Organizasyon();
            organizasyon.OrganizasyonGider = organizasyonGiders;
            organizasyon.Ad = organizasyonDto.Ad;
            organizasyon.BaslangicTArihi = organizasyonDto.BaslangicTArihi;
            organizasyon.BitisTarihi = organizasyonDto.BitisTarihi;
            // organizasyon.MusteriID = müsteribll.müsterigetir(ad);
            organizasyon.OrganizasyonID = organizasyonDto.OrganizasyonID;
            organizasyon.OrganizasyonAdres = new List<Adres>() { organizasyonDto.Adres };
            organizasyon.OrganizasyonGelir = new List<OrganizasyonGelir>() { new OrganizasyonGelir() { OrganizasyonID = organizasyonDto.OrganizasyonID, Butce = organizasyonDto.OrganizasyonGelir } };
            return organizasyon;
        }

        private void frmOrganizasyonEkle_Load(object sender, EventArgs e)
        {
            foreach (CultureInfo item in cultures)
            {
                region = new RegionInfo(item.LCID);
                if (!(countryList.Contains(region.EnglishName)))
                {
                    countryList.Add(region.EnglishName);
                    cmbUlke.Items.Add(region.EnglishName);
                }
            }
        }
    }
}
