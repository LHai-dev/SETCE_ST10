using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class employeeForm : Form
    {
        public employeeForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClsEmployee clsEmployee = new ClsEmployee();
            int id;
            int.TryParse(txtId.Text, out id);
            int stuId;
            int.TryParse(txtstuid.Text, out stuId);
            clsEmployee.std_id = stuId;
            clsEmployee.id = id;


            string[] row = {txtId.Text,
            clsEmployee.name = txtName.Text,
            clsEmployee.gender = txtGender.Text,
            txtstuid.Text,
            clsEmployee.password = txtpassword.Text,
            clsEmployee.pob = txtdob.Text,
            clsEmployee.currentAddress = txtAddress.Text
        };
            dataGridView1.Rows.Add(row);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
