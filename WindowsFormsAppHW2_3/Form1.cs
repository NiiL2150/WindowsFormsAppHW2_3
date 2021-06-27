using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppHW2_3
{
    public partial class Form1 : Form
    {
        public string filePath = String.Empty;
        public string initialText = String.Empty;
        public int opened = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = $"All files(*.*)|*.*| Text files (*.txt)|*.txt"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                filePath = openFileDialog.FileName;
                initialText = sr.ReadToEnd();
                textBox1.Text = initialText;
                button2.Enabled = true;
                label1.Text = filePath;
                sr.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            opened++;
            Form2 form = new Form2();
            if (form.Show(this) == DialogResult.OK)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = initialText;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (opened != 0);
        }
    }
}
