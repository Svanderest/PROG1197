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

namespace SecretAdmirer
{
    public partial class FormRead : Form
    {
        public FormRead()
        {
            InitializeComponent();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            //Prompt user to select file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName.Length > 0)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                using(StreamReader sr = new StreamReader(fs))
                {
                    while(!sr.EndOfStream)
                        lstContent.Items.Add(sr.ReadLine());                    
                }
            }
            //Display file in list box
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                try
                {
                    foreach (string str in lstContent.Items)
                    {
                        sw.WriteLine(str);
                    }
                }
                catch
                {
                    MessageBox.Show("File write failed");
                }
            }
        }
    }
}
