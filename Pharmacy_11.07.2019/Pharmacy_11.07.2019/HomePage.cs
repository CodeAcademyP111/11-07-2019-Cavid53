using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Pharmacy_11._07._2019.Models;


namespace Pharmacy_11._07._2019
{
    public partial class HomePage:Form
    {
        private Form login;
        private Pharmacy _pharmacy;
        public HomePage( Login l)
        {
            InitializeComponent();
            login = l;
            l.Hide();
            Pharmacy pharmacy = new Pharmacy("Zeferan","Ehmedli");
            _pharmacy = pharmacy;
            dgvMedicine.DataSource = _pharmacy.GetMedicines();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            string name = txtMedicine.Text.Trim();
            string price =txtPrice.Text.Trim();
            if (name == "" || price=="")
            {
                MessageBox.Show("Cells is empty !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Medicine medicine = new Medicine()
            {
                Name = name,
                Price = price +" Azn"
            };
            _pharmacy.AddMedicines(medicine);
            RefreshData();

        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete(_pharmacy,dgvMedicine );
            delete.Show();
        }
        private int ID;
        private void DgvMedicine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Visible = true;
            btnCreate.Visible = false;
            int id =(int)dgvMedicine.Rows[e.RowIndex].Cells[0].Value;
            ID = id;

            Medicine medicine = _pharmacy.GetMedicine(id);
            txtMedicine.Text = medicine.Name;
            txtPrice.Text = medicine.Price;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtMedicine.Text.Trim();
            string price = txtPrice.Text.Trim();
            if (name == "" || price == "")
            {
                MessageBox.Show("Cells is empty !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _pharmacy.UpdateMedicines(ID, name, price);

            RefreshData();
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnCreate.Visible = true;
        }
        public void RefreshData()
        {
            dgvMedicine.DataSource = null;
            dgvMedicine.DataSource = _pharmacy.GetMedicines();

            txtMedicine.Text = null;
            txtPrice.Text = null;
        }

        private void HomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Close();
        }
    }
}
