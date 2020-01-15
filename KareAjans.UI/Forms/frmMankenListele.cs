using KareAjans.BLL;
using KareAjans.UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KareAjans.UI
{
    public partial class frmMankenListele : Form
    {
        private DataTable dt;
        public frmMankenListele()
        {
            InitializeComponent();
        }


        private void frmMankenListele_Load(object sender, EventArgs e)
        {
            Refreshh();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgmMankenList.SelectedRows.Count > 0)
            {
                DataGridViewRow selected = dgmMankenList.SelectedRows[0];
                int mankenID = (int)selected.Cells["MankenID"].Value;
                frmManken frmManken = new frmManken(mankenID);
                frmManken.Owner = this;
                frmManken.ShowDialog();
            }
         
        }
        public void Refreshh()
        {

            MankenBLL mankenBLL = new MankenBLL();
            SqlDataAdapter adapter = mankenBLL.MankenAdapter();
            dt = new DataTable();
            adapter.Fill(dt);
            dgmMankenList.DataSource = dt;
        }

        private void btnYorumEkle_Click(object sender, EventArgs e)
        {
            if (dgmMankenList.SelectedRows.Count > 0)
            {
                DataGridViewRow selected = dgmMankenList.SelectedRows[0];
                int mankenID = (int)selected.Cells["MankenID"].Value;
                DataRow row = null;

                foreach (DataRow item in dgmMankenList.Rows)
                {
                    if ((int)item["MankenID"] == mankenID)
                    {
                        row = item;
                        break;
                    }
                }
                row["Yorum"] = txtYorum.Text;
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //yazdırma
            //if (dgmMankenList.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow selected = dgmMankenList.SelectedRows[0];
            //    int mankenID = (int)selected.Cells["MankenID"].Value;
            //    FileStream fs = new FileStream("Yazdir.txt",FileMode.Open,FileAccess.Write);
            //}
        }
    }
}
