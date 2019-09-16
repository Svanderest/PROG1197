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

namespace Lab1
{
    public partial class FrmMain : Form
    {
        uint[,] Population = new uint[13, 48];

        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            this.Clear();
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
            this.Clear();
        }
        
        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.ResetData();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(!Population.Cast<uint>().Any(u => u == 0) || MessageBox.Show("There are regions without recorded population values. Are you sure you want to save?","Unset Values", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveFileDialog sfg = new SaveFileDialog();
                sfg.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                sfg.DefaultExt = ".txt";
                sfg.AddExtension = true;                
                if(sfg.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(sfg.FileName, FileMode.Create);
                    using(StreamWriter sw = new StreamWriter(fs))
                    {
                        for(int i = 0; i<13; i++)
                        {
                            sw.WriteLine(string.Format("Regions for province {0}", i));
                            for (int j = 0; j < 48; j++)
                                sw.WriteLine(string.Format("    Population for Region {0}: {1}", new object[] { j, Population[i, j] }));
                        }
                    }
                }
            }
            ResetData();
        }

        private void Clear()
        {
            Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
        }
        

        private void ResetData()
        {
            Population = new uint[13, 48];
        }
    }
}
