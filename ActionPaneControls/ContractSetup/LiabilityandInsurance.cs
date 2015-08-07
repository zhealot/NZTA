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

        private void rbNotRequired_CheckedChanged(object sender, EventArgs e)
        {
            contract.rbNotRequired = ((RadioButton)sender).Checked;
        }

        private void rbApprovedDefault_CheckedChanged(object sender, EventArgs e)
        {
            contract.rbApprovedDefault = ((RadioButton)sender).Checked;
        }

        private void rbOtherLevels_CheckedChanged(object sender, EventArgs e)
        {
            contract.rbOtherLevels = ((RadioButton)sender).Checked;
        }

        private void help2_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Guidance Note:  other amount to be approved by the Risk/Insurance Sub VAC as per Appendix XXIII for Professional Services, of the Contract Procedures Manual (SM021), for Consultancy Services with fees estimated in excess of $1,000,000.00 per annum, or a total estimated fee for the period of the Contract in excess of $5,000,000, or contracts that are considered high risk, e.g. tunnels and bridges, other service providers in close proximity (gas pipelines, railway), new technology.>>");
        }
    }
}
