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
        public void dataLookup()
        {
            if (comboBox1.Text == "File Name")
            {
                textBox1.Text = listBox1.Text.Substring(listBox1.Text.LastIndexOf(@"\") + 1);
            }
            else if (comboBox1.Text == "Enthalpies")
            {
                string file = System.IO.File.ReadAllText(listBox1.Text);
                textBox1.Text = (file.Substring(file.IndexOf("Enthalpies") + 23, 12));
            }
            else if (comboBox1.Text == "Entropies")
            {
                string file = System.IO.File.ReadAllText(listBox1.Text);
                //  textBox1.Text = (file.Substring(file.IndexOf("Entropies") + 22, 12));
                textBox1.Text = "in progress";
            }
            else if (comboBox1.Text == "Image")
            {
                string file = System.IO.File.ReadAllText(listBox1.Text);
                textBox1.Text = (file.Substring(file.IndexOf("Imag=")+5, 1));
            }

        }
        public string processData ()
        {
            if (!String.IsNullOrEmpty( folderBrowserDialog1.SelectedPath))
            {
                string csv = "File Name, Enthalpies, Imag= \n";
                foreach (string file in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                {
                    if (file.EndsWith(".log"))
                    {
                        string filetext = System.IO.File.ReadAllText(file);
                        string filename = file.Substring(file.LastIndexOf(@"\") + 1);
                        string enthalpies = filetext.Substring(filetext.IndexOf("Enthalpies") + 23, 11);
                        string imag = filetext.Substring(filetext.IndexOf("Imag=") + 5, 1);
                        csv += string.Format("{0} , {1} , {2} \n ", filename , enthalpies, imag);
                    }
                }
                return csv;
            }
            else
            {
                return "";
            }
        }
        public void ChooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(Properties.Settings.Default.lastDirectory)){ 
                    Properties.Settings.Default.lastDirectory = folderBrowserDialog1.SelectedPath;
                }
                    Properties.Settings.Default.lastDirectory = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Save();
                try
                {
                    folderBrowserDialog1.SelectedPath = Properties.Settings.Default.lastDirectory;
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
            dataLookup();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
           string x = processData();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, x);
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.lastDirectory))
            {
                folderBrowserDialog1.SelectedPath = Properties.Settings.Default.lastDirectory;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataLookup();
        }
    }
}
