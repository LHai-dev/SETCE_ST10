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
    public partial class ComputerForm : Form
    {
        public ComputerForm()
        {
            InitializeComponent();
        }

        private void ComputerForm_Load(object sender, EventArgs e)
        {
            foreach (ClsComputer u in Program.clsComputter)
            {
                dataGridView1.Rows.Add(u.computerName, u.year, u.price, u.brand, u.core);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClsComputer clsComputer = new ClsComputer
                ();
            string[] row = { clsComputer.computerName = txtName.Text,
            clsComputer.price = txtprice.Text,
            clsComputer.brand = txtbrand.Text,

            clsComputer.core = txtcore.Text,
        };
            dataGridView1.Rows.Add (row);
        }
    }
}
