using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H4_ADO.Net_
{
    public partial class User_frm : Form
    {
        dao.ClsUserDao dao;

        public User_frm()
        {
            InitializeComponent();
        }

        private void User_frm_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (dto.ClsUserDto u in Program.tblUser)
            {
                dataGridView1.Rows.Add(u.id, u.name, u.password, u.dob);
            }
            generateID();
        }

        private void generateID()
        {
            txtId.Text = (dao.getMaxID() + 1).ToString();
        }

        private void tsbAddNew_Click(object sender, EventArgs e)
        {
            if (Common.ClsCommon.isEmpty(txtId, txtName, txtPassword) == true) { return; }
            if (Common.ClsCommon.isInteger(txtId) == true) { return; }
            if (dao.isDupplicateID(long.Parse(txtId.Text)) == true)
            {
                txtId.BackColor = Color.Red;
                MessageBox.Show("ID already exist/duplicate!");
                txtId.BackColor = Color.White;

                return;
            }
            if (dao.isDupplicateName(txtName.Text) == true)
            {
                txtName.BackColor = Color.Red;
                MessageBox.Show("ID already exist/duplicate!");
                txtName.BackColor = Color.White;

                return;
            }
            dto.ClsUserDto dt = new dto.ClsUserDto(int.Parse(txtId.Text), txtName.Text, txtPassword.Text, dateTimePickerDob.Value);
            dao.addOneUser(dt);
            dataGridView1.Rows.Add(txtId.Text, txtName.Text, txtPassword.Text, dateTimePickerDob.Value);

            generateID();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (Common.ClsCommon.isRowSelected(dataGridView1) == false) { return; }
            DialogResult d = MessageBox.Show("Are you sure to delete this record?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                DataGridViewRow r = dataGridView1.SelectedRows[0];

                if (dao.deleteUserByID(int.Parse(r.Cells[0].Value.ToString())) == true)
                {
                    dataGridView1.Rows.Remove(r);
                }
                else
                {
                    MessageBox.Show("Delete not found!");
                }
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (Common.ClsCommon.isRowSelected(dataGridView1) == false) { return; }
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            if (tsbEdit.Text.Equals("Edit"))
            {
                txtId.Text = r.Cells[0].Value.ToString();
                txtName.Text = r.Cells[1].Value.ToString();
                txtPassword.Text = r.Cells[2].Value.ToString();
                dateTimePickerDob.Value = Convert.ToDateTime(r.Cells[3].Value);

                tsbEdit.Text = "Update";
                dataGridView1.Enabled = false;
            }
            else
            {
                if (dao.isDupplicateName(txtName.Text) == true)
                {
                    txtName.BackColor = Color.Red;
                    MessageBox.Show("ID already exist/duplicate!");
                    txtName.BackColor = Color.White;

                    return;
                }
                DialogResult d = MessageBox.Show("Update?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    dto.ClsUserDto user = new dto.ClsUserDto(int.Parse(txtId.Text), txtName.Text, txtPassword.Text, dateTimePickerDob.Value);
                    if (dao.updateRecordByID(user) == true)
                    {
                        r.Cells[1].Value = txtName.Text;
                        r.Cells[2].Value = txtPassword.Text;
                        r.Cells[3].Value = dateTimePickerDob.Value;
                        tsbEdit.Text = "Edit";
                        dataGridView1.Enabled = true;
                        txtName.Clear();
                        txtPassword.Clear();
                        txtName.Focus();
                        generateID();
                    }
                    else
                    {
                        MessageBox.Show("update not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tsbEdit.Text = "Edit";
                        dataGridView1.Enabled = true;
                        txtName.Clear();
                        txtPassword.Clear();
                        txtName.Focus();
                    }

                }
                else if (d == DialogResult.No)
                {
                    tsbEdit.Text = "Edit";
                    dataGridView1.Enabled = true;
                    txtName.Clear();
                    txtPassword.Clear();
                    txtName.Focus();
                    generateID();
                }
                else
                {
                    txtName.SelectAll(); txtName.Focus();
                }
            }
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            pnlSearch.Visible = !pnlSearch.Visible;
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            txtSearchId.Width = dataGridView1.Columns[0].Width;
            txtSearchName.Width = dataGridView1.Columns[1].Width;
        }

        int found = 0;

        private void btnFind_Click(object sender, EventArgs e)
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
                    foreach (dto.ClsUserDto u in Program.tblUser)
                    {
                        if (int.Parse(txtSearchId.Text) == u.id)
                        {
                            dataGridView1.Rows.Add(u.id, u.name, u.password, u.dob);
                            found = 1;
                        }

                    }
                }
                else if (txtSearchId.Text == "" && txtSearchName.Text != "")
                {
                    foreach (dto.ClsUserDto u in Program.tblUser)
                    {
                        if (txtSearchName.Text == u.name)
                        {
                            dataGridView1.Rows.Add(u.id, u.name, u.password, u.dob);
                            found = 1;
                            break;
                        }

                    }
                }
                else if (txtSearchId.Text != "" && txtSearchName.Text != "")
                {
                    foreach (dto.ClsUserDto u in Program.tblUser)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            txtSearchId.Clear();
            txtSearchName.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlSearch.Visible = !pnlSearch.Visible;
        }
    }
}
