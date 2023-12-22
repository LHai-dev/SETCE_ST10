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
    public partial class animalForm : Form
    {
        public animalForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClsAnimal clsAnimal = new ClsAnimal();


            string[] row = { clsAnimal.name = txtnamew.Text,
            clsAnimal.gender = txtgender2.Text,
            clsAnimal.speed = txtspeed.Text,
            clsAnimal.color = textcolor.Text
        };
            dataGridView1.Rows.Add(row);
        }

        private void animalForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
