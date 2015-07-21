using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace NZTA_Contract_Generator.ActionPaneControls.SectionC
{
    public partial class ContractPricing : UserControl
    {
        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;
        public ContractPricing()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NZTA_Contract_Generator.Globals.ThisDocument.Application.ScreenUpdating = false;
            lbMissing.Items.Clear();
            Microsoft.Office.Interop.Word.Range rg;
            foreach (Microsoft.Office.Interop.Word.Row rw in NZTA_Contract_Generator.Globals.ThisDocument.bmContractPricingSchedule.Tables[1].Rows)
            {             
                //text like: 1.2.3
                if (Regex.IsMatch(rw.Cells[1].Range.Text.Replace("\r\a", ""), @"^(\d+.)*\d+$"))
                {
                    rg = NZTA_Contract_Generator.Globals.ThisDocument.bmContractPaymentSchedule.Tables[1].Range;
                    bool found = false;
                    rg.Find.ClearFormatting();
                    rg.Find.MatchCase = false;
                    rg.Find.MatchWholeWord = true;
                    rg.Find.Text = rw.Cells[1].Range.Text.Replace("\r\a", "");
                    rg.Find.Execute(); 
                    while (rg.Find.Found && rg.InRange(NZTA_Contract_Generator.Globals.ThisDocument.bmContractPaymentSchedule.Tables[1].Range)) 
                    {
                        if(rg.Rows[1].Cells[1].Range.Text == rw.Cells[1].Range.Text)
                         {                             
                             if (rg.Rows[1].Cells[2].Range.Text == rw.Cells[2].Range.Text)
                             {
                                 found = true;
                             }
                             break;
                        }
                        else rg.Find.Execute();
                    }
                    if (!found && !rw.Cells[2].Range.Text.Contains("[Other]"))
                    {
                        lbMissing.Items.Add(rw.Cells[1].Range.Text.Replace("\r\a","") + " " + rw.Cells[2].Range.Text.Replace("\r\a",""));
                    }
                }
            }
            NZTA_Contract_Generator.Globals.ThisDocument.bmContractPaymentSchedule.Select();
            NZTA_Contract_Generator.Globals.ThisDocument.Application.ScreenUpdating = true;
        }
    }
}
