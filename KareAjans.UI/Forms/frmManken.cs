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
using KareAjans.BLL;
using KareAjans.DAL;
using KareAjans.Entities.EntityClasses;

namespace KareAjans.UI.Forms
{
    public partial class frmManken : Form
    {
        List<string> countryList = new List<string>();
        CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        RegionInfo region;
        private Manken _manken;
        Kullanici kullanici;
        MankenBLL mankenBLL;
        public frmManken(int mankenID) // Güncellemek İçin Açıldıgında
        {
            InitializeComponent();
            _manken = new Manken();  //_userControllerçGetManken(Guid mankenID)
            btnGüncelle.Text = "Güncelle";
            Mudur mudur = new Mudur();
            kullanici = new Kullanici();
            kullanici.Kisi = mudur;
            if (kullanici.Kisi.GetType() == typeof(Mudur))
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
            this.Text = "Manken Güncelle";
            lblBaslik.Visible = false;
            FillList(mankenID);
        }
    
        public frmManken() // Yeni Manken 
        {
            InitializeComponent();
            _manken = new Manken();
            panel1.Visible = false;
            lblguncelle.Visible = false;
            btnGüncelle.Text = "Ekle";
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            List<Adres> adreses = new List<Adres>();
            Adres adres1 = new Adres();
            _manken.Ad = txtName.Text;
            _manken.Soyad = txtSurname.Text;
            adres1.AcikAdres = txtAdres.Text;
            adres1.Sehir = txtSehir.Text;
            adres1.Ulke = cmbUlke.Text;
            adreses.Add(adres1);
            _manken.Adres = adreses;
            _manken.Telefon = new List<string>() { txtTel1.Text, txtTel2.Text };
            _manken.KategoriID = Convert.ToInt32(cmbKategori.Text);
            _manken.AyakkabiNo = decimal.Parse(cbAyakkabıNo.Text);
            _manken.Beden = short.Parse(cbBeden.Text);
            _manken.Kilo = nmKilo.Value;
            _manken.SacRengi = cbSacRengi.Text;
            _manken.GözRengi = CbGözRengi.Text;
            _manken.AKtifMi = Convert.ToBoolean(comboBox1.SelectedItem);
            _manken.SehirDisiDurumu = chSehırDısıEvet.Checked == true ? true : false;
            _manken.Ehliyet = chEhliyetEvet.Checked == true ? true : false;
            _manken.Dil = new List<string>() { txtLanguage.Text, txtLanguage2.Text, txtLanguage3.Text };
            _manken.Ozellik = txtÖzellik.Text;
            if (btnGüncelle.Text == "Güncelle")
            {
                mankenBLL = new MankenBLL();
                int result = mankenBLL.MankenGuncelle(_manken);
                IslemSonucu(result, "Güncelleme");
                frmMankenListele frm = this.Owner as frmMankenListele;
                frm.Refreshh();
            }
            else
            {
                mankenBLL = new MankenBLL();
                int result = mankenBLL.MankenEkle(_manken, txtmail.Text, txtsifre.Text);
                IslemSonucu(result, "Ekleme");
            }
           
            this.Close();
        }

        public void IslemSonucu(int result, string text)
        {
            if (result > 0)
            {
                MessageBox.Show($"{text} işlemi başarılı");
            }
            else
            {
                MessageBox.Show($"{text} işlemi başarısız");
            }

        }
        private void FrmManken_Load(object sender, EventArgs e)
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

        public void FillList(int mankenID)
        {
            DBHelper dBHelper = new DBHelper();
            KullaniciBLL kullaniciBLL = new KullaniciBLL();
            _manken = MankenDAL.MankenAdArama(mankenID);
            List<Adres> adress = new List<Adres>();
  
            Kullanici kullanici = kullaniciBLL.KullaniciGetir(mankenID);
            txtmail.Text = kullanici.Mail;
            txtsifre.Text = kullanici.Sifre;
            txtAdres.Text = _manken.Adres[0].AcikAdres ?? " ";
            txtName.Text = _manken.Ad;
            txtSurname.Text = _manken.Soyad;
            txtTel1.Text = _manken.Telefon[0] ?? " ";
            txtTel2.Text = _manken.Telefon[1] ?? " ";
            cmbUlke.Text = _manken.Adres[0].Ulke ;
            cmbKategori.Text = _manken.KategoriID.ToString();
            txtSehir.Text = _manken.Adres[0].Sehir;
            cbAyakkabıNo.Text = _manken.AyakkabiNo.ToString();
            cbBeden.Text = _manken.Beden.ToString();
            nmKilo.Value = _manken.Kilo;
            cbSacRengi.Text = _manken.SacRengi;
            CbGözRengi.Text = _manken.GözRengi;
            comboBox1.Text = _manken.AKtifMi.ToString();
            chSehırDısıEvet.Checked = _manken.SehirDisiDurumu;
            chEhliyetEvet.Checked = _manken.Ehliyet;
            txtLanguage.Text = _manken.Dil[0] ?? " ";
            txtLanguage2.Text = _manken.Dil[1] ?? " ";
            txtLanguage3.Text = _manken.Dil[2] ?? " ";
            txtÖzellik.Text = _manken.Ozellik;
        }
    }
}
