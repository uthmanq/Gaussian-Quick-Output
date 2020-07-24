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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string file in Form1.fileList)
            {
                
                string filetext = System.IO.File.ReadAllText(file);
               filetext = filetext.Replace(textBox1.Text, textBox2.Text);
                System.IO.File.WriteAllText(file, filetext);
            }
            this.Close();

        }
    }
}
