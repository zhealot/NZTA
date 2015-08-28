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

            BaseEstimate_Check.Checked = BaseChkd;
            contract.BaseEstimate_Check = BaseChkd;
            contract.TargetPrice_Check = !BaseChkd;
            gbBaseEstimate.Enabled = BaseChkd;
            gbTargetPrice.Enabled = !BaseChkd;

            var BaseRg = Globals.ThisDocument.rtcPricing_BaseEstimate.Range;
            var TargetRg = Globals.ThisDocument.rtcPricing_TargetPrice.Range;
            var BLRg = Globals.ThisDocument.rtcPricing_BrooksLaw.Range;
            var UnitRateRg = Globals.ThisDocument.rtcUnitRateItems.Range;
            var HourlyRateRg = Globals.ThisDocument.rtcHourlyRateItems.Range;
            
            object BaseStyle = BaseChkd ? Globals.ThisDocument.rtcLevel3Style.Range.get_Style() : "Normal";
            object TargetStyle = !BaseChkd ? Globals.ThisDocument.rtcLevel3Style.Range.get_Style() : "Normal";
            object BLStyle = BrooksLaw_Check.Checked ? Globals.ThisDocument.rtcLevel3Style.Range.get_Style() : "Normal";
            object RateStyle = BaseChkd ? Globals.ThisDocument.rtcLevel2Style.Range.get_Style() : "Normal";

            BaseRg.Collapse();
            BaseRg.set_Style(ref BaseStyle);
            TargetRg.Collapse();
            TargetRg.set_Style(ref TargetStyle);
            BLRg.Collapse();
            BLRg.set_Style(ref BLStyle);
            HourlyRateRg.Collapse();
            HourlyRateRg.set_Style(ref RateStyle);
            UnitRateRg.Collapse();
            UnitRateRg.set_Style(ref RateStyle);

            BaseRg = Globals.ThisDocument.rtcPricing_BaseEstimate.Range;
            TargetRg = Globals.ThisDocument.rtcPricing_TargetPrice.Range;
            BLRg = Globals.ThisDocument.rtcPricing_BrooksLaw.Range;
            UnitRateRg = Globals.ThisDocument.rtcUnitRateItems.Range;
            HourlyRateRg = Globals.ThisDocument.rtcHourlyRateItems.Range;
            BaseRg.SetRange(BaseRg.Start - 1, BaseRg.End + 2);
            TargetRg.SetRange(TargetRg.Start - 1, TargetRg.End + 2);
            BLRg.SetRange(BLRg.Start - 1, BLRg.End + 2);
            UnitRateRg.SetRange(UnitRateRg.Start - 1, UnitRateRg.End + 2);
            HourlyRateRg.SetRange(HourlyRateRg.Start - 1, HourlyRateRg.End + 2);

            BaseRg.Font.Hidden = BaseChkd ? 0 : 1;
            TargetRg.Font.Hidden = BaseChkd ? 1 : 0;
            BLRg.Font.Hidden = BrooksLaw_Check.Checked && BaseEstimate_Check.Checked ? 0 : 1;
            UnitRateRg.Font.Hidden = BaseChkd ? 0 : 1;
            HourlyRateRg.Font.Hidden = BaseChkd ? 0 : 1;

            var rg = Globals.ThisDocument.rtcTargetPriceTenderForm.Range;
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
