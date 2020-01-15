using KareAjans.BLL;
using KareAjans.DTO;
using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KareAjans.UI.Forms
{
    public partial class frmLogin : Form
    {
        private KullaniciBLL _userController;
        private LoginDTO login;

        public frmLogin()
        {
            InitializeComponent();
            _userController = new KullaniciBLL();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {

            login = new LoginDTO();
            login.Mail = txtUsername.Text;
            login.Sifre = txtPassword.Text;

            Kullanici result = _userController.Giris(login);

            if (result.Kisi.GetType() == typeof(Manken))
            {
                frmManken manken = new frmManken(result.KullaniciID);
                manken.Owner = this;
                manken.Show();
                this.Hide();
            }
            else if (result.Kisi.GetType() == typeof(Mudur))
            {
                Mudur mudur = result.Kisi as Mudur;
                if (mudur.Unvan == "Operasyon Muduru")
                {
                    frmOrganizasyon org = new frmOrganizasyon();
                    org.Owner = this;
                    org.Show();
                    this.Hide();
                }
                else
                {
                    frmMuhasebe muhasebe = new frmMuhasebe();
                    muhasebe.Owner = this;
                    muhasebe.Show();
                    this.Hide();
                }
            }
            BeniHatirla();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (File.Exists("KareAjansKullanicilar.psg"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream("KareAjansKullanicilar.psg", FileMode.Open, FileAccess.Read);
                login = bf.Deserialize(fs) as LoginDTO;
                fs.Close();

                txtUsername.Text = login.Mail;
                txtPassword.Text = login.Sifre;
                chkbeniHatirla.Checked = true;
            }
        }

        public void BeniHatirla()
        {
            if (chkbeniHatirla.Checked)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream("KareAjansKullanicilar.psg",FileMode.Create,FileAccess.Write);
                bf.Serialize(fs, login);
                fs.Close();
            }
            else
            {
                if (File.Exists("KareAjansKullanicilar.psg"))
                {
                    File.Delete("KareAjansKullanicilar.psg");
                }
            }
        }
        private void frmLogin_VisibleChanged(object sender, EventArgs e)
        {
      
        }
    }
}
