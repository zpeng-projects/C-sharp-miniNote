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
    public partial class fmMiniMe : Form

    {
        public bool aCloseForm = false;
        public delegate void readbackfromMiniNote(string a);

        public readbackfromMiniNote readbackfunc;
        private string tempText = "";

        //string textA;
        public fmMiniMe()
        {
            InitializeComponent();
            rtMiniMe.KeyDown += new KeyEventHandler(fmMiniMe_KeyUp);
            //textA = a;

         }

        private void fmMiniMe_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            
        }

        private void fmMiniMe_DoubleClick(object sender, EventArgs e)
        {
            if (formBorderStyle == false)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                formBorderStyle = true;

                tempText = this.rtMiniMe.Text;
                this.rtMiniMe.Text = "";

            }
            else
            {
                FormBorderStyle = FormBorderStyle.None;
                formBorderStyle = false;
                this.rtMiniMe.Text = tempText;
            }
        }

        private bool formBorderStyle = false;

        private void fmMiniMe_KeyUp(object sender, KeyEventArgs e)
        {
            //e.SuppressKeyPress = true;
            // Determine whether the key entered is the F1 key. Display help if it is.
            if (e.KeyCode == Keys.Left & Control.ModifierKeys == Keys.Shift)
            {
                e.SuppressKeyPress = true;
                Point f=new Point();
                f = this.Location;
                f.Offset(-20, 0);
                this.Location=f;
                this.Update();
                //e.SuppressKeyPress = false;
            }
            if (e.KeyCode == Keys.Right & Control.ModifierKeys == Keys.Shift)
            {
                e.SuppressKeyPress = true;
                Point f = new Point();
                f = this.Location;
                f.Offset(20, 0);
                this.Location = f;
                this.Update();
                //e.SuppressKeyPress = false;
            }
            if (e.KeyCode == Keys.Up & Control.ModifierKeys == Keys.Shift)
            {
                e.SuppressKeyPress = true;
                Point f = new Point();
                f = this.Location;
                f.Offset(0, -20);
                this.Location = f;
                this.Update();
                //e.SuppressKeyPress = false;
            }
            if (e.KeyCode == Keys.Down & Control.ModifierKeys == Keys.Shift)
            {
                e.SuppressKeyPress = true;
                Point f = new Point();
                f = this.Location;
                f.Offset(0, 20);
                this.Location = f;
                this.Update();
                //e.SuppressKeyPress = false;
            }
            if (e.KeyCode == Keys.Down & Control.ModifierKeys == Keys.Alt)
            {
                e.SuppressKeyPress = true;
                this.Height -= 20;
                this.Update();
                //e.SuppressKeyPress = false;
            }

            if (e.KeyCode == Keys.Up & Control.ModifierKeys == Keys.Alt)
            {
                e.SuppressKeyPress = true;
                this.Height += 20;
                this.Update();
                //e.SuppressKeyPress = false;
            }
            if (e.KeyCode == Keys.Right & Control.ModifierKeys == Keys.Alt)
            {
                e.SuppressKeyPress = true;
                this.Width += 20;
                this.Update();
                //e.SuppressKeyPress = false;
            }

            if (e.KeyCode == Keys.Left  & Control.ModifierKeys == Keys.Alt)
            {
                e.SuppressKeyPress = true;
                this.Width -= 20;
                this.Update();
                //e.SuppressKeyPress = false;
            }

            if (e.KeyCode == Keys.Up & Control.ModifierKeys == Keys.Control)
            {
                e.SuppressKeyPress = true;
                float nn = this.rtMiniMe.ZoomFactor;
                nn += 1;

                if (nn >= 6) nn = 6;

                this.rtMiniMe.ZoomFactor = nn;
                //e.SuppressKeyPress = false;
                //this.Update();
            }
            if (e.KeyCode == Keys.Down & Control.ModifierKeys == Keys.Control)
            {
                e.SuppressKeyPress = true;
                float nn=this.rtMiniMe.ZoomFactor;
                nn -= 1;

                if (nn<=1) nn=1;

                this.rtMiniMe.ZoomFactor = nn;
             }

            if (e.KeyCode == Keys.Escape)
            {
                    e.SuppressKeyPress = true;
                    this.DialogResult = DialogResult.OK;
                    this.aCloseForm = true;
                    this.Visible = false;
                    //textA = this.rtMiniMe.Text;
                    readbackfunc(this.rtMiniMe.Text);               
            }

          }


        public string MiniInput
        {
            get { return rtMiniMe.Text; }
            set { rtMiniMe.Text = value; }
        }

        private void rtMiniMe_TextChanged(object sender, EventArgs e)
        {

        }

            
        }
                         
    }

