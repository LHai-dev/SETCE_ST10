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
    public partial class Form1 : Form
    {
        ListView lv = new ListView();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (ClsCar u in Program.clsCars)
            {
                dataGridView1.Rows.Add(u.cid,u.year, u.chair, u.color,u.weight,u.model);


            }
            foreach (ClsCar u in Program.clsCars)
            {
                dataGridView1.Rows.Add(u.cid, u.year, u.chair, u.color, u.weight, u.model);


            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ClsCar clsCar = new ClsCar();

            clsCar.color = txtColor.Text;
            clsCar.weight = txtWeight.Text;
            clsCar.chair = txtChair.TextLength;
            int year;

            if(int.TryParse(txtYear.Text, out year))
            {
                clsCar.year = year;
            }

            int carId;
            
            if (int.TryParse(txtCarId.Text, out carId))
            {
                clsCar.cid = carId;
            }
            else
            {
                Console.WriteLine("not ok");
                // Handle the case where the conversion fails
                // Display an error message or provide a default value, etc.
            }
            string[] row = { txtCarId.Text,txtYear.Text,txtColor.Text,txtWeight.Text,txtChair.Text  };
            dataGridView1.Rows.Add(row);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ID_Click(object sender, EventArgs e)
        {

        }
    }
}
