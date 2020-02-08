using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IslaBank2019.Model;
using IslaBank2019.Services;

namespace IslaBank2019
{
    public partial class Branches : Form
    {
        public Branches()
        {
            InitializeComponent();
        }

        private void txtBrstn_TextChanged(object sender, EventArgs e)
        {
              List<CheckModel> Acheck = new List<CheckModel>();
            DatabaseConnectionsServices dbconnection = new DatabaseConnectionsServices();
           // var listofchecksAccount = Acheck.Select(a => a.AccountNo).ToList();
            if (txtBrstn.Text.Length == 9)
            {
                dbconnection.GetNameifExisting(Acheck);
                for (int i = 0; i < Acheck.Count; i++)
                {
                    if (txtBrstn.Text == Acheck[i].AccountNo)
                    {
                        txtBranchName.Text = Acheck[i].BranchName.ToString();
                        txtAddress1.Text = Acheck[i].Address1.ToString();
                        txtAddress2.Text = Acheck[i].Address2.ToString();
                        txtAddress3.Text = Acheck[i].Address3.ToString();
                        txtAddress4.Text = Acheck[i].Address4.ToString();
                        txtAddress5.Text = Acheck[i].Address5.ToString();
                        txtAddress6.Text = Acheck[i].Address6.ToString();
                    }
                }
            }
        }

        private void Branches_Load(object sender, EventArgs e)
        {
            txtBrstn.MaxLength = 9;
            txtAddress1.MaxLength = 50;
            txtAddress2.MaxLength = 50;
            txtAddress3.MaxLength = 50;
            txtAddress4.MaxLength = 50;
            txtAddress5.MaxLength = 50;
            txtAddress6.MaxLength = 50;
          
        }

        private void txtBrstn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
