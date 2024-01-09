using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void SqlConnectTest()
        {
            string connectionString = "your_connection_string_here";
            string query = "SELECT * FROM YourTable";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                // Create a DataSet to hold the data
                DataSet dataSet = new DataSet();

                // Fill the DataSet with data from the database
                dataAdapter.Fill(dataSet, "YourTable");


                // Update the database with the changes
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataSet, "YourTable");
            }
        }

        public void DataTest()
        {
            // Create a new DataSet
            DataSet dataSet = new DataSet("MyDataSet");

            // Create a new DataTable
            DataTable dataTable = new DataTable("MyDataTable");

            // Create columns for the DataTable
            DataColumn idColumn = new DataColumn("ID", typeof(int));
            DataColumn nameColumn = new DataColumn("Name", typeof(string));
            DataColumn ageColumn = new DataColumn("Age", typeof(int));

            // Add the columns to the DataTable
            dataTable.Columns.Add(idColumn);
            dataTable.Columns.Add(nameColumn);
            dataTable.Columns.Add(ageColumn);

            // Add the DataTable to the DataSet
            dataSet.Tables.Add(dataTable);

            // Create a new DataRow
            DataRow newRow1 = dataTable.NewRow();
            newRow1["ID"] = 1;
            newRow1["Name"] = "John Doe";
            newRow1["Age"] = 30;

            // Add the DataRow to the DataTable
            dataTable.Rows.Add(newRow1);

            // Create another DataRow
            DataRow newRow2 = dataTable.NewRow();
            newRow2["ID"] = 2;
            newRow2["Name"] = "Jane Smith";
            newRow2["Age"] = 25;

            // Add the DataRow to the DataTable
            dataTable.Rows.Add(newRow2);

            // Display the data in the DataSet
        }
    }
}
