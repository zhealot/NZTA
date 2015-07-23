using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace NZTA_Contract_Generator.ActionPaneControls.SectionC
{
    public partial class AdditionalServicesSchedule : UserControl
    {
        //Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;
        public AdditionalServicesSchedule()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            //Util.SavedState.setControlsToState(contract, Controls);
        }

        private void ASS_TLPD_Qty_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
