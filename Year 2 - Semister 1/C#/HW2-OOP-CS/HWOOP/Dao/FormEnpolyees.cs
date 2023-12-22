using HWOOP.Common;
using HWOOP.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HWOOP.Dao
{
    public partial class FormEnpolyees : Form
    {
        ClsEnpolyeesDao dao;
        public FormEnpolyees()
        {
            InitializeComponent();
            dao = new ClsEnpolyeesDao(true);

        }

        private void FormEnpolyees_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (ClsEnpolyee u in Program.tblEnpolyees)
            {
                dataGridView1.Rows.Add(u.id, u.name, u.gender, u.dob, u.salary, u.password);
            }
            generateID();

        }
        private void generateID()
        {
            txtId.Text = (ClsEnpolyeesDao.getMaxID() + 1).ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Common.ClsCommon.isEmpty(txtId, txtName, txtGander, txtSalary, txtPassword) == true) { return; }
            if (Common.ClsCommon.isInteger(txtId) == true) { return; }
            if (ClsEnpolyeesDao.isDupplicateID(long.Parse(txtId.Text)) == true)
            {
                txtId.BackColor = Color.Red;
                MessageBox.Show("ID already exist/duplicate!");
                txtId.BackColor = Color.White;

                return;
            }

            if (ClsEnpolyeesDao.isDupplicateName(txtName.Text) == true)
            {
                txtName.BackColor = Color.Red;
                MessageBox.Show("ID already exist/duplicate!");
                txtName.BackColor = Color.White;

                return;
            }
            ClsEnpolyee dt = new ClsEnpolyee(txtSalary.Text, int.Parse(txtId.Text), txtName.Text, txtPassword.Text, txtGander.Text, dateTimePickerDob3.Value);
            ClsEnpolyeesDao.addOneUser(dt);
            dataGridView1.Rows.Add(txtId.Text, txtName.Text, txtSalary.Text, txtPassword.Text, txtGander.Text, dateTimePickerDob3.Value);

            generateID();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ClsCommon.isRowSelected(dataGridView1) == false) { return; }
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            if (btnUpdate.Text.Equals("Edit"))
            {
                txtId.Text = r.Cells[0].Value.ToString();
                txtName.Text = r.Cells[1].Value.ToString();
                txtGander.Text = r.Cells[2].Value.ToString();
                //dateTimePickerDob.Value = Convert.ToDateTime(r.Cells[3].Value);
                txtSalary.Text = r.Cells[4].Value.ToString();
                txtPassword.Text = r.Cells[5].Value.ToString();



                btnUpdate.Text = "Update";
                dataGridView1.Enabled = false;
            }
            else
            {
                if (ClsEnpolyeesDao.isDupplicateName(txtName.Text) == true)
                {
                    txtName.BackColor = Color.Red;
                    MessageBox.Show("ID already exist/duplicate!");
                    txtName.BackColor = Color.White;

                    return;
                }
                DialogResult d = MessageBox.Show("Update?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    ClsEnpolyee user = new ClsEnpolyee(txtSalary.Text, int.Parse(txtId.Text), txtName.Text, txtPassword.Text, txtGander.Text, dateTimePickerDob3.Value);
                    if (ClsEnpolyeesDao.updateRecordByID(user) == true)
                    {
                        r.Cells[1].Value = txtName.Text;
                        r.Cells[2].Value = txtGander.Text;
                        //     r.Cells[3].Value = dateTimePickerDob.Value;
                        r.Cells[4].Value = txtSalary.Text;
                        r.Cells[5].Value = txtPassword.Text;

                        btnUpdate.Text = "Edit";
                        dataGridView1.Enabled = true;
                        txtName.Clear();
                        txtSalary.Clear();
                        txtGander.Clear();
                        txtPassword.Clear();
                        txtName.Focus();
                        generateID();
                    }
                    else
                    {
                        MessageBox.Show("update not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnUpdate.Text = "Edit";
                        dataGridView1.Enabled = true;
                        txtName.Clear();
                        txtPassword.Clear();
                        txtGander.Clear();
                        txtSalary.Clear();
                        txtName.Focus();
                    }

                }
                else if (d == DialogResult.No)
                {
                    btnUpdate.Text = "Edit";
                    dataGridView1.Enabled = true;
                    txtName.Clear();
                    txtPassword.Clear();
                    txtGander.Clear();
                    txtSalary.Clear();
                    txtName.Focus();
                    generateID();
                }
                else
                {
                    txtName.SelectAll(); txtName.Focus();
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ClsCommon.isRowSelected(dataGridView1) == false) { return; }
            DialogResult d = MessageBox.Show("Are you sure to delete this record?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                DataGridViewRow r = dataGridView1.SelectedRows[0];

                if (ClsEnpolyeesDao.deleteUserByID(int.Parse(r.Cells[0].Value.ToString())) == true)
                {
                    dataGridView1.Rows.Remove(r);
                }
                else
                {
                    MessageBox.Show("Delete not found!");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            panlsearch.Visible = !panlsearch.Visible;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            txtSearchId.Width = dataGridView1.Columns[0].Width;
            txtSearchName.Width = dataGridView1.Columns[1].Width;
            txtSearchPwd.Width = dataGridView1.Columns[2].Width;
        }
        int found = 0;
        private void btnSearch1_Click(object sender, EventArgs e)
        {
            found = 0;
            dataGridView1.Rows.Clear();

            if (txtSearchId.Text == "" && txtSearchName.Text == "")
            {
                MessageBox.Show("this box is emty Please input first....!!!");
                found = 1;
            }
            if (found == 0)
            {
                found = 0;
                if (txtSearchId.Text != "" && txtSearchName.Text == "")
                {
                    foreach (ClsEnpolyee u in Program.tblEnpolyees)
                    {
                        if (int.Parse(txtSearchId.Text) == u.id)
                        {
                            dataGridView1.Rows.Add(u.id, u.name, u.password);
                            found = 1;
                        }

                    }
                }
                else if (txtSearchId.Text == "" && txtSearchName.Text != "")
                {
                    foreach (ClsEnpolyee u in Program.tblEnpolyees)
                    {
                        if (txtSearchName.Text == u.name)
                        {
                            dataGridView1.Rows.Add(u.id, u.name, u.password);
                            found = 1;
                            break;
                        }

                    }
                }
                else if (txtSearchId.Text != "" && txtSearchName.Text != "")
                {
                    foreach (ClsEnpolyee u in Program.tblEnpolyees)
                    {
                        if (txtSearchName.Text == u.name && int.Parse(txtSearchId.Text) == u.id)
                        {
                            dataGridView1.Rows.Add(u.id, u.name, u.password, u.dob);
                            found = 1;
                            break;
                        }
                    }
                }
                if (found == 0)
                {
                    MessageBox.Show("Data not found!!!");
                }
            }
        }
    }
}