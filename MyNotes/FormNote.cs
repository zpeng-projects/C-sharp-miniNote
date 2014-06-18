using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Globalization;
using System.Xml.XPath;
using System.IO;
using System.Security.Cryptography;

namespace MyNotes
{
    public partial class FormNote : Form
    {
        private XmlDocument _doc;
        private XmlNode _node;
        private CultureInfo _ci;
        private DateTime _dT;
        string _xmlFileName = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)+ "\\note.jn";
        private string _fileVersion = @"Beta_1.1";
        private int secondDm = 247;
        private String passwordOn = "P";
        private string _password="ABCD";
         
        public FormNote()
        {
            InitializeComponent();
            _ci = CultureInfo.InvariantCulture;
            _dT = new DateTime();
            _dT = this.monthCalendar1.TodayDate;
            _doc = new XmlDocument();
            
            string blankXml = "<Jninputs>" +
                          "<input>" +
                          "<inputDate>" + _dT.ToString("yyyy-MM-dd", _ci) +
                          "</inputDate>" +
                          "<lastUpdateDate>" + _dT.ToString("yyyy-MM-dd", _ci) +
                          "</lastUpdateDate>" +
                          "<simage></simage>" +
                          "<content></content>" +
                          "</input>" +
                          "</Jninputs>";
            _doc.LoadXml(blankXml);
             _node=_doc.DocumentElement;
             this.tbFileName1.Text = _xmlFileName;
        }
   
       

        private void FormNote_Load(object sender, EventArgs e)
        {
            _dT = this.monthCalendar1.TodayDate;
            string SelectString = "Jninputs/input[inputDate='" + _dT.ToString("yyyy-MM-dd", _ci) + "']";
            XmlNodeList nodeLst1 = this._doc.SelectNodes(SelectString);
            this.rtJn.Text = "";
            foreach (XmlNode node in nodeLst1)
            {
                this.rtJn.Text = node.LastChild.InnerXml ;
            }
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            string newContent = this.rtJn.Text;
            String oldContent ="";
            this.rtJn.Text = "";

            string SelectString = "Jninputs/input[inputDate='" + _dT.ToString("yyyy-MM-dd", _ci) + "']";
            XmlNodeList nodeLst0 = _doc.SelectNodes(SelectString);
            if (nodeLst0[0] != null) oldContent =nodeLst0[0].LastChild.InnerXml;
            if (newContent!=oldContent)
            {
                if (nodeLst0[0] != null) _node.RemoveChild(nodeLst0[0]);
                    XmlElement newinput = _doc.CreateElement("input");
                    XmlElement newinputDate = _doc.CreateElement("inputDate");
                    XmlElement newlastUpdate = _doc.CreateElement("lastUpdateDate");
                    XmlElement newimage = _doc.CreateElement("simage");
                    XmlElement newcontent = _doc.CreateElement("content");                    
                    XmlText inDate = _doc.CreateTextNode(_dT.ToString("yyyy-MM-dd", _ci));
                    XmlText outDate = _doc.CreateTextNode(DateTime.Today.ToString("yyyy-MM-dd", _ci));
                    XmlText inImage = _doc.CreateTextNode(" ");
                    XmlText inText = _doc.CreateTextNode(newContent);
                    newinput.AppendChild(newinputDate);
                    newinput.AppendChild(newlastUpdate);
                    newinput.AppendChild(newimage);
                    newinput.AppendChild(newcontent);
                    newinputDate.AppendChild(inDate);
                    newlastUpdate.AppendChild(outDate);
                    newimage.AppendChild(inImage);
                    newcontent.AppendChild(inText);
                    
                    _node.InsertAfter(newinput, _node.FirstChild);
                    this.monthCalendar1.AddBoldedDate(_dT);
                    this.monthCalendar1.UpdateBoldedDates();
            }
            
            DateTime DayCurrentSelect = this.monthCalendar1.SelectionRange.Start;
            SelectString = "Jninputs/input[inputDate='" + DayCurrentSelect.ToString("yyyy-MM-dd", _ci) + "']";
            XmlNodeList nodeLst1 = _doc.SelectNodes(SelectString);
            //iterate through the XmlNodeList
            foreach (XmlNode node in nodeLst1)
            {
                this.rtJn.Text = node.LastChild.InnerXml;
            }

            _dT = DayCurrentSelect;
             _node = _doc.DocumentElement;    
            
        }

        private void update_DateChanged()
        {
            string newContent = this.rtJn.Text;
            String oldContent = "";
            //this.rtJn.Text = "";

            string SelectString = "Jninputs/input[inputDate='" + _dT.ToString("yyyy-MM-dd", _ci) + "']";
            XmlNodeList nodeLst0 = _doc.SelectNodes(SelectString);
            if (nodeLst0[0] != null) oldContent = nodeLst0[0].LastChild.InnerXml;
            if (newContent != oldContent)
            {
                if (nodeLst0[0] != null) _node.RemoveChild(nodeLst0[0]);
                XmlElement newinput = _doc.CreateElement("input");
                XmlElement newinputDate = _doc.CreateElement("inputDate");
                XmlElement newlastUpdate = _doc.CreateElement("lastUpdateDate");
                XmlElement newimage = _doc.CreateElement("simage");
                XmlElement newcontent = _doc.CreateElement("content");
                XmlText inDate = _doc.CreateTextNode(_dT.ToString("yyyy-MM-dd", _ci));
                XmlText outDate = _doc.CreateTextNode(DateTime.Today.ToString("yyyy-MM-dd", _ci));
                XmlText inImage = _doc.CreateTextNode(" ");
                XmlText inText = _doc.CreateTextNode(newContent);
                newinput.AppendChild(newinputDate);
                newinput.AppendChild(newlastUpdate);
                newinput.AppendChild(newimage);
                newinput.AppendChild(newcontent);
                newinputDate.AppendChild(inDate);
                newlastUpdate.AppendChild(outDate);
                newimage.AppendChild(inImage);
                newcontent.AppendChild(inText);

                _node.InsertAfter(newinput, _node.FirstChild);
                this.monthCalendar1.AddBoldedDate(_dT);
                this.monthCalendar1.UpdateBoldedDates();
            }

            DateTime DayCurrentSelect = this.monthCalendar1.SelectionRange.Start;
            SelectString = "Jninputs/input[inputDate='" + DayCurrentSelect.ToString("yyyy-MM-dd", _ci) + "']";
            XmlNodeList nodeLst1 = _doc.SelectNodes(SelectString);
            //iterate through the XmlNodeList
            foreach (XmlNode node in nodeLst1)
            {
                this.rtJn.Text = node.LastChild.InnerXml;
            }

            _dT = DayCurrentSelect;
            _node = _doc.DocumentElement;

        }


        private string  checkForPassword(string sPasswd)
        {
            string pswordReadIn = "";
            fmPasswordIn PasswordForm = new fmPasswordIn();
            DialogResult dialogResult = PasswordForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                pswordReadIn = PasswordForm.assword;
            }

            string atemp=Password2HashCode(pswordReadIn);            
            if (atemp == sPasswd)
            {
                return pswordReadIn;
            }
            else
            {
                return "-1";
            }
        }

        private string Password2HashCode(string sPasswd)
        {
            HashAlgorithm hashAlg = new SHA1Managed();
            byte[] pwordData = Encoding.Default.GetBytes(sPasswd);
            byte[] hash = hashAlg.ComputeHash(pwordData);
            string atemp = BitConverter.ToString(hash);
            return atemp;
        }
       private void openToolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                _xmlFileName = openFileDialog1.FileName;
                tbFileName1.Text = _xmlFileName;
                using (StreamReader binReader =
             new StreamReader(File.Open(_xmlFileName, FileMode.Open)))
                {
                    string dataString = binReader.ReadToEnd();
                    {
                        int n = dataString.Length;
                        int inco = n / secondDm;// (Convert.ToInt32(Math.Round(Convert.ToDouble(n) / Convert.ToDouble(secondDm))));
                        StringBuilder sb = new StringBuilder(dataString, n);
                        shuffleString(sb, inco, false);
                        if (sb.ToString(2, 1) == "P")
                        {
                            string[] Sttemp = sb.ToString(0, 128).Split('$');
                            bool passwordright = false;
                            for (int i = 0; i < 3; i++)
                            {
                                string atemp = checkForPassword(Sttemp[4]);
                                if (atemp != "-1")
                                {
                                    passwordright = true;
                                    _password = atemp;
                                    break;
                                }
                            }
                            if (passwordright)
                            {
                                string[] Stringtemp = sb.ToString(0, 128).Split('$');
                                int xmlLeng = Convert.ToInt32(Stringtemp[2]);
                                _fileVersion = Stringtemp[3];
                                sb.Remove(0, Stringtemp[0].Length + Stringtemp[1].Length + Stringtemp[4].Length + Stringtemp[2].Length + Stringtemp[3].Length + 5);
                                _doc.LoadXml(sb.ToString(0, xmlLeng));
                                _node = _doc.DocumentElement;
                                this.tslStatus.Text = "Success";
                                passwordOn = "P";
                                this.rbPassword.Checked = true;
                            }
                            else
                            {
                                this.tslStatus.Text = "Failed to load the file";
                            }
                        }
                        else
                        {
                            string[] Stringtemp = sb.ToString(0, 128).Split('$');
                            int xmlLeng = Convert.ToInt32(Stringtemp[2]);
                            _fileVersion = Stringtemp[3];
                            sb.Remove(0, Stringtemp[0].Length + Stringtemp[1].Length + Stringtemp[4].Length + Stringtemp[2].Length + Stringtemp[3].Length + 5);
                            _doc.LoadXml(sb.ToString(0, xmlLeng));
                            _node = _doc.DocumentElement;
                            this.tslStatus.Text = "Success";
                            passwordOn = "N";
                            this.rbPassword.Checked = false;
                        }
                    }

                }
                string SelectString = "Jninputs/input/inputDate";
                XmlNodeList nodeLst0 = this._doc.SelectNodes(SelectString);
                foreach (XmlNode node in nodeLst0)
                {
                    string[] a = node.InnerXml.Split('-');
                    DateTime adt = new DateTime(Convert.ToInt16(a[0]), Convert.ToInt16(a[1]), Convert.ToInt16(a[2]));

                    this.monthCalendar1.AddBoldedDate(adt);
                }
                this.monthCalendar1.UpdateBoldedDates();

                SelectString = "Jninputs/input[inputDate='" + _dT.ToString("yyyy-MM-dd", _ci) + "']";
                XmlNodeList nodeLst1 = this._doc.SelectNodes(SelectString);
                //iterate through the XmlNodeList
                this.rtJn.Text = "";
                foreach (XmlNode node in nodeLst1)
                {
                    this.rtJn.Text = node.LastChild.InnerXml;
                }
            
            }
         }

       private void shuffleString(StringBuilder tSB, int bas, bool A_encode)
       {
           
           int len=tSB.Length;
           String sh = tSB.ToString();
           tSB.Clear();
           int j = 0;
           int k = 0;
           int incu = 3;
           char s;
           for (int i = 0; i < len; i++)
           {
               
               if (A_encode)
               {
                   int t = sh[j] + incu;
                   if (t > 255)
                   {
                       t = t - 256;
                   }
                   s = Convert.ToChar(t);
               }
               else
               {
                   int t = sh[j] - incu;
                   if (t <0)
                   {
                       t = t + 256;
                   }
                   s = Convert.ToChar(t);
               }
               tSB.Append(s);
               j = j + bas;
               if (j >= len)
               {
                   k = k + 1;
                   j = k;
               }

           }
           

           
       }

       private string RandomString(int size)
       {
           StringBuilder builder = new StringBuilder();
           Random random = new Random();
           char ch;
           for (int i = 0; i < size; i++)
           {
               ch = Convert.ToChar(Convert.ToInt32(Math.Floor(255 * random.NextDouble()) ));
               builder.Append(ch);
           }
           
           return builder.ToString();
       }

        private void saveToolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                _xmlFileName = saveFileDialog1.FileName;
                tbFileName1.Text = _xmlFileName;
                SaveFile(_xmlFileName);
            }
         }

        private void SaveFile(string filename)
        {
            using (StreamWriter binWriter =
            new StreamWriter(File.Open(filename, FileMode.Create)))
            {
                string aSt;
                string _passwordHashCode;
                if (this.rbPassword.Checked)
                {
                    passwordOn = "P";
                }
                else
                {
                    passwordOn = "N";
                }

                _passwordHashCode = Password2HashCode(_password);

                int n = _fileVersion.Length + _doc.InnerXml.Length +_passwordHashCode.Length + 6 + Convert.ToString(_doc.InnerXml.Length).Length;
               
                if (n < secondDm * 10) 
                {
                    aSt = "A$" + passwordOn + "$" + Convert.ToString(_doc.InnerXml.Length) + '$' + _fileVersion + '$' + _passwordHashCode +'$' + _doc.InnerXml + RandomString(secondDm * 10 - n-1);
                }
                else
                {
                    string g= RandomString(Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(n) /Convert.ToDecimal(secondDm))) * secondDm - n-1);
                    aSt = "A$" + passwordOn + "$" + Convert.ToString(_doc.InnerXml.Length) + '$' + _fileVersion + '$' + _passwordHashCode + '$' + _doc.InnerXml + g;

                }

                StringBuilder xmlString = new StringBuilder(aSt,aSt.Length);

                shuffleString(xmlString, secondDm, true);
                                                              
                binWriter.Write(xmlString.ToString());
                
            }
        }

        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                _xmlFileName = saveFileDialog1.FileName;
                tbFileName1.Text = _xmlFileName;
            }
        }

        private void tsbMiniMe1_Click(object sender, EventArgs e)
        {
            //this.TopMost = true;
            this.Hide();
            //string ab=this.rtJn.Text;
            fmMiniMe fmMini = new fmMiniMe();
            fmMini.MiniInput = this.rtJn.Text;
            fmMini.readbackfunc=new fmMiniMe.readbackfromMiniNote(this.readbackfromMiniNote);
            //fmMiniMe.readbackfromMiniNote+= (updateMinimedata);

            fmMini.Show();            
        }

        private void readbackfromMiniNote(string a)
        {
            this.rtJn.Text = a;
            this.Show();
        }

        

        private void toolStripComboBox1__TextChanged(object sender, EventArgs e)
        {
            _xmlFileName = tbFileName1.Text;
        }

        private void FormNote_Close(object sender, EventArgs e)
        {
            //this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool a = true;

            for (; ;)
            {
                string atemp = SetPassWord(a);
                if (atemp != "-1")
                {
                    _password = atemp;
                    break;
                }
                else
                {
                    a = false;
                }
            }
        }
        private string SetPassWord(bool a)
        {
            FormSetPassword SetPassword = new FormSetPassword(a);
            bool b=true;
            DialogResult dialogResult = SetPassword.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                b = SetPassword.passwordCorrect;
            }
            if (b)
            {
                return SetPassword.assword;
            }
            else
            {
                return "-1";
            }

        }

        private void rbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPassword.Checked)
            {
                rbPassword.Checked = false;
                _password = "ABCD";
            }
            else
            {
                rbPassword.Checked=true;
                bool a = true;

                for (; ; )
                {
                    string atemp = SetPassWord(a);
                    if (atemp != "-1")
                    {
                        _password = atemp;
                        break;
                    }
                    else
                    {
                        a = false;
                    }
                }
            }
        }

        private void rtJn_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            update_DateChanged();
            _xmlFileName = tbFileName1.Text;
            SaveFile(_xmlFileName);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFile(tbFileName1.Text);
            this.rtJn.Text="";
            string _xmlFileName = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\note.jn";
            tbFileName1.Text = _xmlFileName;
            _ci = CultureInfo.InvariantCulture;
            _dT = new DateTime();
            _dT = this.monthCalendar1.TodayDate;
            _doc = new XmlDocument();

           passwordOn = "N";
           rbPassword.Checked = false;

            string blankXml = "<Jninputs>" +
                          "<input>" +
                          "<inputDate>" + _dT.ToString("yyyy-MM-dd", _ci) +
                          "</inputDate>" +
                          "<lastUpdateDate>" + _dT.ToString("yyyy-MM-dd", _ci) +
                          "</lastUpdateDate>" +
                          "<simage></simage>" +
                          "<content></content>" +
                          "</input>" +
                          "</Jninputs>";
            _doc.LoadXml(blankXml);
            _node = _doc.DocumentElement;
            this.monthCalendar1.RemoveAllBoldedDates();
            this.monthCalendar1.UpdateBoldedDates();
           
        }

        private void tsbKey1_Click(object sender, EventArgs e)
        {
            bool a = true;

            for (; ; )
            {
                string atemp = SetPassWord(a);
                if (atemp != "-1")
                {
                    _password = atemp;
                    break;
                }
                else
                {
                    a = false;
                }
            }
        }

    }
}
