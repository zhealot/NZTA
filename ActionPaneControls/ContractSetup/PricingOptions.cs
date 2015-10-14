using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    partial class PricingOptions : UserControl
    {

        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;

        public PricingOptions()
        {
            InitializeComponent();

            //Load saved state. Defaults set in state...
            gbTargetPrice.Enabled = false;
            gbBaseEstimate.Enabled = false;
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void PricingOption_Changed(object sender, EventArgs e)
        {
            bool BaseChkd = BaseEstimate_Check.Checked;
            contract.BaseEstimate_Check = BaseChkd;
            contract.TargetPrice_Check = !BaseChkd;
            gbBaseEstimate.Enabled = BaseChkd;
            gbTargetPrice.Enabled = !BaseChkd;

            //Base Estimate clause Title 
            object style = BaseChkd ? Globals.ThisDocument.rtcLevel3Style.Range.get_Style() : GlobalVar.StyleNormal;
            var rg = Globals.ThisDocument.rtcPricing_BaseEstimateTitle.Range;
            rg.set_Style(ref style);
            Util.ContentControls.RangeHideShow(ref rg, BaseChkd);

            //Base Estimate Tender Form
            rg = Globals.ThisDocument.rtcBaseEstimateTenderForm.Range;
            Util.ContentControls.RangeHideShow(ref rg, BaseChkd);

            //Base Estimate clause Body 
            rg = Globals.ThisDocument.rtcPricing_BaseEstimateBody.Range;
            Util.ContentControls.RangeHideShow(ref rg, BaseChkd);

            //Boork's Law clause 
            rg = Globals.ThisDocument.rtcPricing_BrooksLaw.Range;
            style = BaseChkd && BrooksLaw_Check.Checked ? Globals.ThisDocument.rtcLevel3Style.Range.get_Style() : GlobalVar.StyleNormal;
            rg.set_Style(ref style);
            Util.ContentControls.RangeHideShow(ref rg, BrooksLaw_Check.Checked && BaseChkd);

            //Target Price clause 
            rg = Globals.ThisDocument.rtcPricing_TargetPrice.Range;
            style = !BaseChkd ? Globals.ThisDocument.rtcLevel3Style.Range.get_Style() : GlobalVar.StyleNormal;
            rg.set_Style(ref style);
            Util.ContentControls.RangeHideShow(ref rg, !BaseChkd);

            //Target Price Tender Form
            rg = Globals.ThisDocument.rtcTargetPriceTenderForm.Range;
            rg.SetRange(rg.Start - 1, rg.End + 2);
            rg.Font.Hidden = BaseChkd ? 1 : 0;
        }


        private void BrooksLaw_Check_CheckedChanged(object sender, EventArgs e)
        {
            bool BLChkd = BrooksLaw_Check.Checked; 
            contract.BrooksLaw_Check = BLChkd;
            var BLRg = Globals.ThisDocument.rtcPricing_BrooksLaw.Range;
            object BLStyle = BLChkd ? Globals.ThisDocument.rtcLevel3Style.Range.get_Style() : "Normal";
            BLRg.SetRange(BLRg.Start - 1, BLRg.End + 2);
            BLRg.Paragraphs[1].set_Style(ref BLStyle);
            BLRg.Font.Hidden = (BLChkd && BaseEstimate_Check.Checked) ? 0 : 1;
        }

        private void BaseEstimate_Amount_TextChanged(object sender, EventArgs e)
        {
            contract.BaseEstimate_Amount = ((TextBox)sender).Text;
            if (Util.ContentControls.StringToCurrency(((TextBox)sender).Text) != null)
            {
                Util.ContentControls.setText(((TextBox)sender).Name, Util.ContentControls.StringToCurrency(((TextBox)sender).Text));
            }
            else
                Util.Help.guidanceNote("Please enter a number");
        }

        private void ProvisionalSumAmount_TextChanged(object sender, EventArgs e)
        {
            contract.ProvisionalSumAmount = ((TextBox)sender).Text;
            if (Util.ContentControls.StringToCurrency(((TextBox)sender).Text) != null)
            {
                Util.ContentControls.setText(((TextBox)sender).Name, Util.ContentControls.StringToCurrency(((TextBox)sender).Text));
            }
            else
                Util.Help.guidanceNote("Please enter a number");
        }

        private void TargetPriceAmount_TextChanged(object sender, EventArgs e)
        {
            contract.TargetPriceAmount = ((TextBox)sender).Text;            
            if (Util.ContentControls.StringToCurrency(((TextBox)sender).Text) != null)
            {
                Util.ContentControls.setText(((TextBox)sender).Name, Util.ContentControls.StringToCurrency(((TextBox)sender).Text));
                decimal amnt;
                if (Decimal.TryParse(((TextBox)sender).Text,out amnt))
                {
                    TargetPriceAmountInWords.Text = Util.ContentControls.DecimalToWords(amnt);
                }
                else
                    Util.Help.guidanceNote("Please enter a number");
            }
            else
                Util.Help.guidanceNote("Please enter a number");
        }

        private void TargetPriceAmountInWords_TextChanged(object sender, EventArgs e)
        {            
            contract.TargetPriceAmountInWords = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
