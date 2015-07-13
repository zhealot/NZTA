using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    partial class LiabilityandInsurance : UserControl
    {
        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;
        public LiabilityandInsurance()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void PublicLiabilityInsurance_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsAmount(((TextBox)sender).Text))
            {
                contract.PublicLiabilityInsurance = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number");
            }
        }

        private void MaximumLiability_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsAmount(((TextBox)sender).Text))
            {
                contract.MaximumLiability = ((TextBox)sender).Text;                
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number");
            }
        }

        private void DurationOfLiability_TextChanged(object sender, EventArgs e)
        {
            contract.DurationOfLiability = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }
    }
}
