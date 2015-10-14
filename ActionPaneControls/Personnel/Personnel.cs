using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.Personnel
{
    public partial class Personnel : UserControl
    {
        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;
        public Personnel()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
            //no Weighting for Lowest Price Conforming
            if (contract.rbLPC)
            {
                tbWeighting.Enabled = false;
            }            
        }

        private void btnGetPersonnel_Click(object sender, EventArgs e)
        {
            NZTA_Contract_Generator.Globals.ThisDocument.bmPersonalStart.Select();
            //retrieve entries from section 5 Tender Evaluation Forms, Form B
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.bmPersonalAbove.Tables[1];
            lbPersonnel.Items.Clear();
            tbWeighting.Clear();
            List<decimal> pctg = new List<decimal>();
            decimal tmp;
            for (int i = NZTA_Contract_Generator.Globals.ThisDocument.bmPersonalStart.Rows[1].Index;
                     i < NZTA_Contract_Generator.Globals.ThisDocument.bmPersonalEnd.Rows[1].Index; i++)
            {
                lbPersonnel.Items.Add(tbl.Rows[i].Cells[1].Range.Text.Replace("\r\a", ""));
                if (tbl.Rows[i].Cells.Count > 1)
                {
                    var str = tbl.Rows[i].Cells[2].Range.Text.Replace("\r\a", "").Replace("%", "").Trim();
                    tbWeighting.Text += str + Environment.NewLine;
                    if (decimal.TryParse(str, out tmp))
                    {
                        pctg.Add(tmp);
                    }
                }
            }
            tbWeighting.Text = tbWeighting.Text.TrimEnd(Environment.NewLine.ToArray());
            //no weightings for Lowest Price Conforming
            if (!contract.rbLPC)
            {
                if (pctg.Count != lbPersonnel.Items.Count)
                {
                    Util.Help.guidanceNote(lbPersonnel.Items.Count + " Personal items" + Environment.NewLine +
                                           pctg.Count + " Weighings");
                }
                if (pctg.Sum() != 100)
                {
                    Util.Help.guidanceNote("Weightings must add to 100");
                }
            }
        }

        //### make PS exactly the same as Fomr B
        private void btnPS_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var ls in lbPersonnel.Items)
            {
                object txt = ls.ToString();
                var rg = NZTA_Contract_Generator.Globals.ThisDocument.bmPSEnd.Tables[1].Range;
                var rgConsultant = NZTA_Contract_Generator.Globals.ThisDocument.bmPS_Consultant.Tables[1].Range;
                rg.Find.ClearFormatting();
                rg.Find.MatchCase = false;
                rg.Find.MatchWholeWord = true;
                rgConsultant.Find.ClearFormatting();
                rgConsultant.Find.MatchCase = false;
                rgConsultant.Find.MatchWholeWord = true;
                if (!rg.Find.Execute(ref txt) && !rgConsultant.Find.Execute(ref txt ))
                {
                    NZTA_Contract_Generator.Globals.ThisDocument.bmPSEnd.Rows[1].Range.Copy();
                    NZTA_Contract_Generator.Globals.ThisDocument.bmPSEnd.Range.PasteAppendTable();
                    NZTA_Contract_Generator.Globals.ThisDocument.bmPSEnd.Tables[1].Rows[NZTA_Contract_Generator.Globals.ThisDocument.bmPSEnd.Rows[1].Index + 1].Range.Delete();
                    NZTA_Contract_Generator.Globals.ThisDocument.bmPSEnd.Tables[1].Rows[NZTA_Contract_Generator.Globals.ThisDocument.bmPSEnd.Rows[1].Index + 1].Cells[1].Range.Text = txt.ToString();
                    i++;
                }
            }
            Util.Help.guidanceNote(i.ToString() + " rows were added to Personal Schedule");
            NZTA_Contract_Generator.Globals.ThisDocument.bmPSEnd.Select();
        }

        private void btnASS_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var ls in lbPersonnel.Items)
            {
                object txt = ls.ToString();
                var rg = NZTA_Contract_Generator.Globals.ThisDocument.bmASSEnd.Tables[1].Range;
                rg.Find.ClearFormatting();
                rg.Find.MatchWholeWord = true;
                rg.Find.MatchCase = false;
                if (!rg.Find.Execute(ref txt))
                {
                    //NZTA_Contract_Generator.Globals.ThisDocument.bmASSEnd.Rows.Add().Cells[2].Range.Text = txt.ToString();
                    //NZTA_Contract_Generator.Globals.ThisDocument.bmASSEnd.Select();
                    NZTA_Contract_Generator.Globals.ThisDocument.bmASSEnd.Rows[1].Range.Copy();
                    NZTA_Contract_Generator.Globals.ThisDocument.bmASSEnd.Range.PasteAppendTable();
                    NZTA_Contract_Generator.Globals.ThisDocument.bmASSEnd.Tables[1].Rows[NZTA_Contract_Generator.Globals.ThisDocument.bmASSEnd.Rows[1].Index + 1].Range.Delete();
                    NZTA_Contract_Generator.Globals.ThisDocument.bmASSEnd.Tables[1].Rows[NZTA_Contract_Generator.Globals.ThisDocument.bmASSEnd.Rows[1].Index + 1].Cells[2].Range.Text = txt.ToString();
                    i++;
                }                
            }
            Util.Help.guidanceNote(i.ToString() + " rows were added to Additional Service Schedule");
            NZTA_Contract_Generator.Globals.ThisDocument.bmASSEnd.Select();
        }

        private void lbPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbWeighting.Lines.Count() >= lbPersonnel.Items.Count + 1 && lbPersonnel.SelectedIndex > 0)
            {
                tbWeighting.Select(tbWeighting.GetFirstCharIndexFromLine(lbPersonnel.SelectedIndex), 0);
                tbWeighting.Focus();
                tbWeighting.ScrollToCaret();
            }
        }

        private void tbWeighting_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
