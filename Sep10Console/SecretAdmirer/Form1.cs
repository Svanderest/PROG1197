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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            var res = sfd.ShowDialog();
            FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
            using(StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(string.Format("Dear {0}", txtName.Text));
                sw.WriteLine(string.Format("I think you are the cutest {0} in the world", cmbGender.Text));
                sw.WriteLine("Love, Your Secret Admirer");
            }
        }
    }
}
