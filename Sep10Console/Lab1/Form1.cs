using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class FrmMain : Form
    {
        int[,] Population = new int[13, 48];

        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            int provinceID;
            int regionID;
            if(!int.TryParse(txtRegion.Text, out regionID) || !int.TryParse(txtProvince.Text, out provinceID))
            {

            }
        }
    }
}
