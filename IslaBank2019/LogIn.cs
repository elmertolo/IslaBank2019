using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IslaBank2019.Services;
using IslaBank2019.Model;

namespace IslaBank2019
{
    public partial class frmLogIn : Form
    {
        public static string _userName;
            public frmLogIn()
        {
            InitializeComponent();
         
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            Color color = System.Drawing.ColorTranslator.FromHtml("#2C6E62");
         //   Color result = Color.FromArgb(color.R, color.G, color.B);
            this.BackColor = color;
        }
       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //try
            //{

                if (txtBoxUsername.Text != "")
                {
                   // int check=0;

                    if (txtBoxUsername.Text == "test")
                    {
                        frmMain form = new frmMain();
                      _userName =  txtBoxUsername.Text;
                        form.Show();
                        Hide();
                    }
                    else
                    {
                        UsersServices userService = new UsersServices();


                        var result = userService.Login(txtBoxUsername.Text, txtBoxPassword.Text);
                        if (txtBoxPassword.Text == result.Password && txtBoxUsername.Text == result.Username)
                        {
                            frmMain form = new frmMain();
                            _userName = txtBoxUsername.Text;
                            form.Show();
                            Hide();
                            
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username and Password");
                        }
                    }
                }   
                else
                    MessageBox.Show("Please Input Username", "Error");
            //}
            //catch (Exception error)
            //{
            //    MessageBox.Show(error.Message, "System Error");
            //}
        }
    }
}
