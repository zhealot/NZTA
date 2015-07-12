using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.SectionC
{
    public partial class ContractPricing : UserControl
    {
        public ContractPricing()
        {
            InitializeComponent();
        }

        private void CP_Total_TextChanged(object sender, EventArgs e)
        {
            
        }
        public string CP_Total_Text { get { return CP_Total.Text; } set { CP_Total.Text = value; } }
    }
}
