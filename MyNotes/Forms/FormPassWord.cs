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
    public partial class fmPasswordIn : Form
    {
        public fmPasswordIn()
        {
            InitializeComponent();
        }

        public string assword
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

       
                        
     }
}
