using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    partial class LiabilityandInsurance : UserControl
    {
        Contract contract = Globals.ThisDocument.contract;
        public LiabilityandInsurance()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void PublicLiabilityInsurance_TextChanged(object sender, EventArgs e)
        {
            var value = PublicLiabilityInsurance.Text;
            if (string.IsNullOrEmpty(value) || rbApprovedDefault.Checked)
            {
                Util.ContentControls.setText(PublicLiabilityInsurance.Name, "The minimum amount of Public Liability Insurance required will be $5,000,000.00.");
                contract.PublicLiabilityInsurance = value;
            }
            else
            {
                if (Util.ContentControls.IsAmount(PublicLiabilityInsurance.Text))
                {
                    contract.PublicLiabilityInsurance = (PublicLiabilityInsurance.Text);
                    Util.ContentControls.setText(PublicLiabilityInsurance.Name, "The amount of Public Liability Insurance required will be $ " + value);
                }
                else
                {
                    Util.Help.guidanceNote("Please enter a number");
                }
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

        private void InsuranceLevel_CheckedChanged(object sender, EventArgs e)
        {
            bool blDefaultChkd = rbApprovedDefault.Checked;
            pnGroup1.Enabled = !blDefaultChkd;
            contract.rbApprovedDefault = blDefaultChkd;
            contract.rbOtherLevels = !blDefaultChkd;
            Globals.ThisDocument.rtcLimitationDefault.LockContents = false;
            Globals.ThisDocument.rtcLimitationOther.LockContents = false;
            var rgDefault = Globals.ThisDocument.rtcLimitationDefault.Range;
            var rgOther = Globals.ThisDocument.rtcLimitationOther.Range;
            var DefaultStyle = blDefaultChkd ? Globals.ThisDocument.rtcDurationOfLiability.Range.Paragraphs[1].get_Style() : "Normal";
            var OtherStyle = !blDefaultChkd ? Globals.ThisDocument.rtcDurationOfLiability.Range.Paragraphs[1].get_Style() : "Normal";
            rgDefault.set_Style(ref DefaultStyle);
            rgOther.set_Style(ref OtherStyle);
            rgDefault.SetRange(rgDefault.Start - 1, rgDefault.End + 2);
            rgOther.SetRange(rgOther.Start - 1, rgOther.End + 2);
            rgDefault.Font.Hidden = blDefaultChkd ? 0 : 1;
            rgOther.Font.Hidden = blDefaultChkd ? 1 : 0;
            if (!blDefaultChkd)
            {
                MaximumLiability.Focus();
            }
            Globals.ThisDocument.rtcLimitationDefault.LockContents = true;
            Globals.ThisDocument.rtcLimitationOther.LockContents = true;
            PublicLiabilityInsurance_TextChanged(null, null);
        }

        private void help2_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Guidance Note:  other amount to be approved by the Risk/Insurance Sub VAC as per Appendix XXIII for Professional Services, of the Contract Procedures Manual (SM021), for Consultancy Services with fees estimated in excess of $1,000,000.00 per annum, or a total estimated fee for the period of the Contract in excess of $5,000,000, or contracts that are considered high risk, e.g. tunnels and bridges, other service providers in close proximity (gas pipelines, railway), new technology.>>");
        }
    }
}
