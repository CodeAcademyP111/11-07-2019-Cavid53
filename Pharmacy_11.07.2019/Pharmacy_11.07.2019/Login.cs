using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_11._07._2019
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (name != "Cavid" || password != "12345")
            {
                MessageBox.Show("Please enter the password or name","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            HomePage home = new HomePage(this);
            home.Show();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chcPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
