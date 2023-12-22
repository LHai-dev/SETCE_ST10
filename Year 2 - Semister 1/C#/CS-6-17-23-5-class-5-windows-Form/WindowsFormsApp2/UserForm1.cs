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
    public partial class UserForm1 : Form
    {
        public UserForm1()
        {
            InitializeComponent();
        }

        private void UserForm1_Load(object sender, EventArgs e)
        {
            foreach (ClsUser u in Program.clsUser)
            {
                dataGridView1.Rows.Add(u.id, u.name, u.gender);


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClsUser user = new ClsUser();
            int id;

            if (int.TryParse(txtId.Text, out id))
            {
                user.id = id;
            }
            
            string[] row = {txtId.Text, user.name = txtName.Text, user.gender = txtGender.Text };

            dataGridView1 .Rows.Add(row);
        }
    }
}
