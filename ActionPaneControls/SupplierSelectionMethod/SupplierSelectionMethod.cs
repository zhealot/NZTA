using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.SupplierSelectionMethod
{
    public partial class SupplierSelectionMethod : UserControl
    {
        public SupplierSelectionMethod()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            label3.Enabled = ((CheckBox)sender).Checked;
            textBox1.Enabled = ((CheckBox)sender).Checked;
            label4.Enabled = ((CheckBox)sender).Checked;
            Track_check.Enabled = ((CheckBox)sender).Checked;
            textBox2.Enabled = ((CheckBox)sender).Checked;
            label5.Enabled = ((CheckBox)sender).Checked;
            textBox3.Enabled = ((CheckBox)sender).Checked;
            label7.Enabled = ((CheckBox)sender).Checked;
            label8.Enabled = ((CheckBox)sender).Checked;
            textBox4.Enabled = ((CheckBox)sender).Checked;
            label9.Enabled = ((CheckBox)sender).Checked;
            label10.Enabled = ((CheckBox)sender).Checked;
            textBox5.Enabled = ((CheckBox)sender).Checked;
            label11.Enabled = ((CheckBox)sender).Checked;
        }
    }
}
