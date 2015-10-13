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
            var PaginationOption = NZTA_Contract_Generator.Globals.ThisDocument.Application.Options.Pagination;
            NZTA_Contract_Generator.Globals.ThisDocument.Application.Options.Pagination = false;
            NZTA_Contract_Generator.Globals.ThisDocument.Application.ScreenUpdating = false;
            
            lbMissing.Items.Clear();
            Microsoft.Office.Interop.Word.Range rg;
            foreach (Microsoft.Office.Interop.Word.Row rw in NZTA_Contract_Generator.Globals.ThisDocument.bmContractPricingSchedule.Tables[1].Rows)
            {
                //ignore hidden rows
                if (rw.Range.Font.Hidden != 0) continue;
                //look for text like: 1.2.3 in numbering
                var PricingNumText = rw.Cells[1].Range.ListFormat.ListString == "" ? rw.Cells[1].Range.Text.Replace("\r\a", "") : rw.Cells[1].Range.ListFormat.ListString;
                PricingNumText.Trim();
                if (Regex.IsMatch(PricingNumText, @"^(\d+.)*\d+$"))
                {                    
                    rg = NZTA_Contract_Generator.Globals.ThisDocument.bmContractPaymentSchedule.Tables[1].Range;
                    bool found = false;
                    rg.Find.ClearFormatting();
                    rg.Find.MatchCase = false;
                    rg.Find.MatchWholeWord = true;
                    rg.Find.Forward = true;
                    rg.Find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
                    rg.Find.Text = rw.Cells[2].Range.Text.Replace("\r\a", "").Trim(); //rw.Cells[1].Range.ListFormat.ListString;
                    rg.Find.Execute();
                    var LastPosition = rg.Start;
                    while (rg.Find.Found && rg.InRange(NZTA_Contract_Generator.Globals.ThisDocument.bmContractPaymentSchedule.Tables[1].Range) && rg.Start >= LastPosition) 
                    {
                        LastPosition = rg.End;
                        if (rg.Rows[1].Cells[2].Range.Text.Replace("\r\a", "").Trim() == rw.Cells[2].Range.Text.Replace("\r\a", "").Trim())
                        {
                            var PaymentNumText = rg.Rows[1].Cells[1].Range.ListFormat.ListString == "" ? rg.Rows[1].Cells[1].Range.Text.Replace("\r\a", "") : rg.Rows[1].Cells[1].Range.ListFormat.ListString;
                            PaymentNumText.Trim();
                            if (PaymentNumText == PricingNumText)
                            {
                                found = true;
                                break;
                            }
                        }
                        //else
                        //{
                            rg.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                            rg.Find.Execute();
                        //}
                    }
                    if (!found && !rw.Cells[2].Range.Text.Contains("[Other]"))
                    {
                        lbMissing.Items.Add(PricingNumText + " " + rw.Cells[2].Range.Text.Replace("\r\a",""));
                    }
                }
            }
            NZTA_Contract_Generator.Globals.ThisDocument.bmContractPaymentSchedule.Select();
            NZTA_Contract_Generator.Globals.ThisDocument.Application.ScreenUpdating = true;
            NZTA_Contract_Generator.Globals.ThisDocument.Application.Options.Pagination = PaginationOption;
        }
    }
}
