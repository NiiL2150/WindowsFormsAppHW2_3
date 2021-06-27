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
    public partial class Form2 : Form
    {
        Form1 parentForm = null;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public DialogResult Show(Form1 form)
        {
            parentForm = form;
            textBox1.Text = parentForm.initialText;
            base.Show();
            return this.DialogResult;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.opened--;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            parentForm.initialText = textBox1.Text;
            parentForm.textBox1.Text = textBox1.Text;
            StreamWriter sw = new StreamWriter(parentForm.filePath);
            sw.Write(textBox1.Text);
            sw.Close();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
