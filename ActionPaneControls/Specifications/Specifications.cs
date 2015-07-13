using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.Specifications
{
    public partial class Specifications : UserControl
    {
        public Specifications()
        {
            Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;
            InitializeComponent();
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }

        //### exclusive with another check box
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MultipleProjects_No_CheckedChanged(object sender, EventArgs e)
        {
            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            label7.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;   
        }

        private void MultipleProjects_Yes_CheckedChanged(object sender, EventArgs e)
        {
            label3.Enabled = true;
            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            label7.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;      
        }
    }
}
