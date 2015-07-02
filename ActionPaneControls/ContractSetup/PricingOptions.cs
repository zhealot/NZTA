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
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void BaseEstimate_Check_CheckedChanged(object sender, EventArgs e)
        {
            contract.BaseEstimate_Check = ((CheckBox)sender).Checked;
        }

        private void BrooksLaw_Check_CheckedChanged(object sender, EventArgs e)
        {
            contract.BrooksLaw_Check = ((CheckBox)sender).Checked;
        }

        private void RatesOnly_Check_CheckedChanged(object sender, EventArgs e)
        {
            contract.RatesOnly_Check = ((CheckBox)sender).Checked;
        }

        private void TargetPrice_Check_CheckedChanged(object sender, EventArgs e)
        {
            contract.TargetPrice_Check = ((CheckBox)sender).Checked;
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
