namespace HWOOP.Dao
{
    partial class FormEnpolyees
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnUpdate = new Button();
            btnSearch = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            refreshToolStripMenuItem = new ToolStripMenuItem();
            txtSalary = new TextBox();
            txtGander = new TextBox();
            txtName = new TextBox();
            txtId = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtPassword = new TextBox();
            label6 = new Label();
            dateTimePickerDob3 = new DateTimePicker();
            panel1 = new Panel();
            panlsearch = new Panel();
            btnSearch1 = new Button();
            txtSearchPwd = new TextBox();
            txtSearchName = new TextBox();
            txtSearchId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panlsearch.SuspendLayout();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(558, 54);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(128, 46);
            btnUpdate.TabIndex = 29;
            btnUpdate.Text = "Edit";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(558, 116);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(128, 46);
            btnSearch.TabIndex = 28;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(424, 116);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(128, 46);
            btnDelete.TabIndex = 27;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(424, 54);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 46);
            btnAdd.TabIndex = 26;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridView1.Location = new Point(10, 295);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(800, 533);
            dataGridView1.TabIndex = 25;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.ColumnWidthChanged += dataGridView1_ColumnWidthChanged;
            // 
            // Column1
            // 
            Column1.HeaderText = "ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Name";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Gander";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "DOB";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "Salary";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 125;
            // 
            // Column6
            // 
            Column6.HeaderText = "password";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 125;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { refreshToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(152, 28);
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.ShortcutKeys = Keys.F5;
            refreshToolStripMenuItem.Size = new Size(151, 24);
            refreshToolStripMenuItem.Text = "Refresh";
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(81, 142);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(260, 27);
            txtSalary.TabIndex = 24;
            // 
            // txtGander
            // 
            txtGander.Location = new Point(81, 73);
            txtGander.Name = "txtGander";
            txtGander.Size = new Size(260, 27);
            txtGander.TabIndex = 22;
            // 
            // txtName
            // 
            txtName.Location = new Point(81, 41);
            txtName.Name = "txtName";
            txtName.Size = new Size(260, 27);
            txtName.TabIndex = 21;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(81, 12);
            txtId.Name = "txtId";
            txtId.Size = new Size(260, 27);
            txtId.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 142);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 19;
            label5.Text = "salary";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 104);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 18;
            label4.Text = "DOB";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 73);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 17;
            label3.Text = "Gander";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 41);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 16;
            label2.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 9);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 15;
            label1.Text = "ID";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(81, 175);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(260, 27);
            txtPassword.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(-2, 178);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 31;
            label6.Text = "password";
            // 
            // dateTimePickerDob3
            // 
            dateTimePickerDob3.Location = new Point(81, 106);
            dateTimePickerDob3.Name = "dateTimePickerDob3";
            dateTimePickerDob3.Size = new Size(260, 27);
            dateTimePickerDob3.TabIndex = 32;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtGander);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(dateTimePickerDob3);
            panel1.Controls.Add(txtId);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(txtSalary);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(12, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(798, 214);
            panel1.TabIndex = 33;
            // 
            // panlsearch
            // 
            panlsearch.Controls.Add(btnSearch1);
            panlsearch.Controls.Add(txtSearchPwd);
            panlsearch.Controls.Add(txtSearchName);
            panlsearch.Controls.Add(txtSearchId);
            panlsearch.Location = new Point(12, 241);
            panlsearch.Name = "panlsearch";
            panlsearch.Size = new Size(798, 48);
            panlsearch.TabIndex = 34;
            panlsearch.Visible = false;
            // 
            // btnSearch1
            // 
            btnSearch1.Dock = DockStyle.Left;
            btnSearch1.Location = new Point(530, 0);
            btnSearch1.Name = "btnSearch1";
            btnSearch1.Size = new Size(94, 48);
            btnSearch1.TabIndex = 35;
            btnSearch1.Text = "search";
            btnSearch1.UseVisualStyleBackColor = true;
            btnSearch1.Click += btnSearch1_Click;
            // 
            // txtSearchPwd
            // 
            txtSearchPwd.Dock = DockStyle.Left;
            txtSearchPwd.Location = new Point(351, 0);
            txtSearchPwd.Name = "txtSearchPwd";
            txtSearchPwd.Size = new Size(179, 27);
            txtSearchPwd.TabIndex = 2;
            // 
            // txtSearchName
            // 
            txtSearchName.Dock = DockStyle.Left;
            txtSearchName.Location = new Point(169, 0);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new Size(182, 27);
            txtSearchName.TabIndex = 1;
            // 
            // txtSearchId
            // 
            txtSearchId.Dock = DockStyle.Left;
            txtSearchId.Location = new Point(0, 0);
            txtSearchId.Name = "txtSearchId";
            txtSearchId.Size = new Size(169, 27);
            txtSearchId.TabIndex = 0;
            txtSearchId.TextChanged += textBox1_TextChanged;
            // 
            // FormEnpolyees
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 563);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(dataGridView1);
            Controls.Add(panlsearch);
            Controls.Add(panel1);
            Name = "FormEnpolyees";
            Text = "FormEnpolyees";
            Load += FormEnpolyees_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panlsearch.ResumeLayout(false);
            panlsearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnUpdate;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnAdd;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DateTimePicker dateTimePickerDob;
        private TextBox txtSalary;
        private TextBox txtDob;
        private TextBox txtGander;
        private TextBox txtName;
        private TextBox txtId;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridViewTextBoxColumn Column6;
        private TextBox txtPassword;
        private Label label6;
        private DateTimePicker dateTimePickerDob3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private Panel panel1;
        private Panel panlsearch;
        private TextBox txtSearchPwd;
        private TextBox txtSearchName;
        private TextBox txtSearchId;
        private Button btnSearch1;
    }
}