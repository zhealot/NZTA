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
    public partial class NonPriceAttributes : UserControl
    {
        public NonPriceAttributes()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            GuidanceNote.Enabled = true;
            Util.ContentControls.setText(((TextBox)GuidanceNote).Name, ((TextBox)GuidanceNote).Text);
        }

        private void GuidanceNote_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }
    }
}
