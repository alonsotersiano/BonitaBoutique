using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonitaBoutique
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Clickbutton() 
        {
            if (UsernameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Please enter Username and Password.");
            }
            else if (UsernameTb.Text == "Admin" && PasswordTb.Text == "Admin")
            {
                Items obj = new Items();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect.");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Clickbutton();
        }

        private void UsernameTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Clickbutton();
            }
        }

        private void PasswordTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Clickbutton();
            }
        }
    }
}
