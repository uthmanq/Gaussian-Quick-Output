using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaussian_Quick_Output
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string[] lines = Form1.dataset.Split(new[] { '\r', '\n' });
            foreach (string s in lines)
                MessageBox.Show(s);
            
            if (lines.Length > 0)
            {
                string firstline = lines[0];
                string[] headerLabels = firstline.Split(',');
                foreach (string headerWord in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord));

                }
                for (int r = 1; r < lines.Length-1; r++)
                {
                    string line = lines[r];
                    string [] lineArray = line.Split(',');
                    dt.Rows.Add(lineArray);
                }
                    
            }
            if (dt.Rows.Count>0)
            {
                dataGridView1.DataSource = dt;
            }
        }
    }
}
