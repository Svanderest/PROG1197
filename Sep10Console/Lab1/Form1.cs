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
        int[,] Population = new uint[13, 48];

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
            uint provinceID;
            uint regionID;
            if(!uint.TryParse(txtRegion.Text, out regionID) || !uint.TryParse(txtProvince.Text, out provinceID) || provinceID > 12 || regionID > 47)            
                MessageBox.Show("Please enter a province ID between 0 and 12 and a region ID between 0 and 47");            
            else if(!uint.TryParse(txtPopulation.Text,out Population[provinceID,regionID]))
                MessageBox.Show("Please enter a numberic population value greater than 0");
            else
                MessageBox.Show("Success");
        }
    }
}
