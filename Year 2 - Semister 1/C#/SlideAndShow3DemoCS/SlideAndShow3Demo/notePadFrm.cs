using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlideAndShow3Demo
{
    public partial class notePadFrm : Form
    {
        public notePadFrm()
        {
            InitializeComponent();
        }

      
        String filePath = "";
        private string currentFilePath; // Variable to store the current file path

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text File|*.txt";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                 filePath = openFileDialog.FileName;
                richTextBox1.Text = System.IO.File.ReadAllText(filePath);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(filePath) == true)
            {
                //over rigth
                System.IO.File.WriteAllText(filePath,richTextBox1.Text);
                MessageBox.Show("Saved!");
            }
            else
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file|*.txt";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                System.IO.File.Create(filePath).Close();
                System.IO.File.WriteAllText(filePath, richTextBox1.Text);
                MessageBox.Show("save!");
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implement your logic for creating a new file or resetting the current file
            currentFilePath = string.Empty; // Reset the current file path
            MessageBox.Show("New file created.");
        }
    }
}
