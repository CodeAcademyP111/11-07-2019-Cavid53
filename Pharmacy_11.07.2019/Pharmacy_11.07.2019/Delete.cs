using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy_11._07._2019.Models;

namespace Pharmacy_11._07._2019
{
    
    public partial class Delete : Form
    {
        private DataGridView dgv;
        private Pharmacy pharmacy;

        public Delete(Pharmacy p,DataGridView d)
        {
           
            InitializeComponent();
            pharmacy = p;
            dgv = d;
            cmbMedicine.DataSource = pharmacy.GetMedicines();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //int.Parse(cmbMedicine.SelectedValue.ToString().Substring(0, 4).Trim());
            
                int id = int.Parse(cmbMedicine.SelectedValue.ToString().Substring(0, 2).Trim());
                pharmacy.DeleteMedicines(id);
                cmbMedicine.DataSource = null;
                cmbMedicine.DataSource = pharmacy.GetMedicines();

                dgv.DataSource = null;
                dgv.DataSource = pharmacy.GetMedicines();

        }

    }
}
