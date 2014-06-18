using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNotes
{
    public partial class FormSetPassword : Form
    {
        bool _passwordCorrect=false;
        public FormSetPassword(bool a)
        {
            InitializeComponent();
            if (a)
            { this.label3.Text = ""; }
            else
            {
                this.label3.Text = "The passwords did not match,please try again";
            }
        }

        public string assword
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public bool passwordCorrect
        {
            get { return _passwordCorrect; }
            set { _passwordCorrect = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals(this.textBox2.Text))
            {
                _passwordCorrect = true;
            }
            else
            {
                _passwordCorrect = false;
            }
        }

        

        
    }
}
