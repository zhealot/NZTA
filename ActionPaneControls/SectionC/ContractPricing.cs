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

        private void CP_Total_TextChanged(object sender, EventArgs e)
        {
            
        }
        public string CP_Total_Text { get { return CP_Total.Text; } set { CP_Total.Text = value; } }

        private void button1_Click(object sender, EventArgs e)
        {
            lbMissing.Items.Clear();
            foreach (Microsoft.Office.Interop.Word.Row rw in NZTA_Contract_Generator.Globals.ThisDocument.bmContractPricingSchedule.Tables[1].Rows)
            {             
                //text like: 1.2.3
                if (Regex.IsMatch(rw.Cells[1].Range.Text.Replace("\r\a", ""), @"^(\d+.)*\d+$"))
                {
                    var rg = NZTA_Contract_Generator.Globals.ThisDocument.bmContractPaymentSchedule.Tables[1].Range;
                    bool found = false;
                    rg.Find.ClearFormatting();
                    rg.Find.MatchCase = false;
                    rg.Find.MatchWholeWord = true;
                    rg.Find.Text = rw.Cells[1].Range.Text.Replace("\r\a", "");
                    rg.Find.Execute();
                    while (rg.Find.Found && rg.InRange(NZTA_Contract_Generator.Globals.ThisDocument.bmContractPaymentSchedule.Tables[1].Range)) 
                    {
                        if (rg.Cells[1].Range.Text == rw.Cells[1].Range.Text)
                        {
                            found = true;
                            break;
                        }
                        else rg.Find.Execute();
                    }
                    if (!found && !rw.Cells[2].Range.Text.Contains("[Other]"))
                    {
                        lbMissing.Items.Add(rw.Cells[1].Range.Text + " " + rw.Cells[2].Range.Text);
                    }
                }
            }
        }
    }
}
