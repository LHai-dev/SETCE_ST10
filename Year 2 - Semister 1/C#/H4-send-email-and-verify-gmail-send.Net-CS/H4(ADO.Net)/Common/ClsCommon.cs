using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H4_ADO.Net_.Common
{
    internal class ClsCommon
    {
        public static Boolean isRowSelected(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pes select row first");
                return false;
            }
            return true;
        }

        public static Boolean isEmpty(params TextBox[] txts)
        {
            foreach (TextBox txt in txts)
            {
                if (txt.Text == "")
                {
                    txt.BackColor = Color.Red;
                    MessageBox.Show("This box cannot empty");
                    txt.BackColor = Color.White;
                    txt.Focus();
                    return true;
                }
            }
            return false;
        }

        public static Boolean isInteger(params TextBox[] txts)
        {
            foreach (TextBox txt in txts)
            {
                int testInt;
                Boolean result = int.TryParse(txt.Text, out testInt);
                if (result == false)
                {
                    txt.BackColor = Color.Red;
                    MessageBox.Show("This box must be integer!");
                    txt.BackColor = Color.White;
                    txt.Focus();
                    return true;
                }
            }
            return false;
        }
    }
}
