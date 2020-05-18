using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Gaussian_Quick_Output
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }
        public void ChooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                   foreach (string file in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                    {
                        if (file.EndsWith(".log"))
                        {
                            listBox1.Items.Add(file);
                        }
                    }
                }
                catch (Exception f)
                {
                    MessageBox.Show(f.ToString());
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string file = System.IO.File.ReadAllText(listBox1.Text);
            MessageBox.Show(file.Substring(file.IndexOf("Enthalpies"),30));

        }
    }
}
