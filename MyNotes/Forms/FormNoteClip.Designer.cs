namespace MyNotes
{
    partial class fmMiniMe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtMiniMe = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtMiniMe
            // 
            this.rtMiniMe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rtMiniMe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtMiniMe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtMiniMe.Location = new System.Drawing.Point(0, 0);
            this.rtMiniMe.Margin = new System.Windows.Forms.Padding(4);
            this.rtMiniMe.Name = "rtMiniMe";
            this.rtMiniMe.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtMiniMe.Size = new System.Drawing.Size(284, 213);
            this.rtMiniMe.TabIndex = 0;
            this.rtMiniMe.Text = "";
            this.rtMiniMe.TextChanged += new System.EventHandler(this.rtMiniMe_TextChanged);
            this.rtMiniMe.DoubleClick += new System.EventHandler(this.fmMiniMe_DoubleClick);
            // 
            // fmMiniMe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(284, 213);
            this.Controls.Add(this.rtMiniMe);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fmMiniMe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quick Note";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.fmMiniMe_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtMiniMe;
    }
}