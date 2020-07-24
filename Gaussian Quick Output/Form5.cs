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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.ComFileProgram = true;

            }
            else
            {
                Properties.Settings.Default.ComFileProgram = false;
            }
            Properties.Settings.Default.fileTypeSearch = comboBox1.Text;
            MessageBox.Show("Gaussian Quick Output will now search for files with the " + comboBox1.Text + " extension");
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.fileTypeSearch != null)
                comboBox1.Text = Properties.Settings.Default.fileTypeSearch;

                checkBox1.Checked = Properties.Settings.Default.ComFileProgram;
        }
    }
}
