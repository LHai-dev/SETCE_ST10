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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        String rootPath = Application.StartupPath + @"\images";
        List<String> lSiImage = new List<String>();
        int currebtInd = -1;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(rootPath))
            {
                System.IO.Directory.CreateDirectory(rootPath);
            }
            lSiImage.Clear();
            String[] allFile = System.IO.Directory.GetFiles(rootPath);
            foreach(String file in allFile)
            {
                lSiImage.Add(file);
            }
            if(lSiImage.Count > 0) {
                currebtInd = 0;
                showImage();
            }
        }
        void showImage()
        {
            pictureBox1.ImageLocation = lSiImage[currebtInd];
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Picture|*.png;*jpg;*.jpng|All File|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String[] filePath = ofd.FileNames;
                foreach (String file in filePath)
                {
                    //file = c:\abc\abc.png
                    String filename = System.IO.Path.GetFileName(file);
                    System.IO.File.Copy(file, rootPath+@"\"+filename, true);

                }
                MessageBox.Show("Import Images Completed!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(lSiImage.Count == 0) { return; }
            currebtInd = 0;
            showImage();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (lSiImage.Count == 0) return;
            currebtInd = lSiImage.Count-1;
            showImage();
        }

        private void btnPerv_Click(object sender, EventArgs e)
        {
            if (lSiImage.Count == 0) return;
            currebtInd --;
            if(currebtInd < 0)
            {
                btnLast_Click(null,null);
            }
            showImage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (lSiImage.Count == 0) return;
            currebtInd++;
            if (currebtInd >(lSiImage.Count - 1) )
            {
                currebtInd = 0;
            }
            showImage();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
