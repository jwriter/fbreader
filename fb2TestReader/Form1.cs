using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using FB2Library;

namespace fb2TestReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private bool LoadFB2File(string fileName)
        {
            try
            {
                Stream s = File.OpenRead(fileName);
                ReadFB2FileStream(s);
                s.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        FB2File file;
        private void ReadFB2FileStream(Stream s)
        {
            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.None,
                ProhibitDtd = false
            };
            XDocument fb2Document = null;
            using (XmlReader reader = XmlReader.Create(s, settings))
            {
                fb2Document = XDocument.Load(reader, LoadOptions.PreserveWhitespace);
                reader.Close();
            }
            file = new FB2File();
            try
            {
                file.Load(fb2Document, false);
                Text = file.MainBody.Title.ToString();
                var sc = file.MainBody.Sections;
                var str = "";
                foreach (var sectionItem in sc)
                {
                    str += Environment.NewLine + sectionItem.Title + Environment.NewLine;

                    foreach (var textItem in sectionItem.Content)
                    {
                        str += Environment.NewLine + textItem.ToString() + Environment.NewLine;
                    }
                }
                tbox.Text = str;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error loading file : {0}", ex.Message));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFB2File("1.fb2");
        }
    }
}
