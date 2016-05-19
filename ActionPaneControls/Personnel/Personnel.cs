using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.Personnel
{
    public partial class Personnel : UserControl
    {
        Contract contract = Globals.ThisDocument.contract;
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
            Globals.ThisDocument.bmPersonalStart.Select();
            //retrieve entries from section 5 Tender Evaluation Forms, Form B
            var tbl = Globals.ThisDocument.bmPersonalAbove.Tables[1];
            lbPersonnel.Items.Clear();
            tbWeighting.Clear();
            List<decimal> pctg = new List<decimal>();
            decimal tmp;
            for (int i = Globals.ThisDocument.bmPersonalStart.Rows[1].Index;
                     i < Globals.ThisDocument.bmPersonalEnd.Rows[1].Index; i++)
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
            tbl.Select();
        }

        private void btnPS_Click(object sender, EventArgs e)
        {
            //check whether rows exist in PS not in Form B
            Globals.ThisDocument.Application.ScreenUpdating = false;
            try
            {
                var tb = Globals.ThisDocument.bmKeyPersonnel.Tables[1];
                Microsoft.Office.Interop.Word.Range rgFormB;
                for (int j = 1; j <= Globals.ThisDocument.bmKeyPersonnel.Tables[1].Rows.Count; j++)
                {
                    rgFormB = Globals.ThisDocument.bmPersonalStart.Tables[1].Range;
                    rgFormB.Find.ClearFormatting();
                    rgFormB.Find.MatchWholeWord = true;
                    rgFormB.Find.MatchCase = false;
                    rgFormB.Find.Forward = true;
                    rgFormB.Find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindStop;
                    if (tb.Rows[j].Cells[1].Range.Text.Replace("\r\a", "").Trim() == "") continue;
                    rgFormB.Find.Text = tb.Rows[j].Cells[2].Range.Text.Replace("\r\a", "").Trim();
                    rgFormB.Find.Execute();
                    if (!rgFormB.Find.Found || rgFormB.Cells[1].ColumnIndex != 1 
                        || rgFormB.Start > Globals.ThisDocument.bmPersonalEnd.Range.End
                        || rgFormB.End < Globals.ThisDocument.bmPersonalStart.Start)
                    {
                        if (MessageBox.Show("There're some entries that not existed in Form B, and this operation will delete them, continue?", "Continue Transfer",
                            MessageBoxButtons.YesNo) ==DialogResult.No) return;
                        else break;
                    }
                }
            }
            catch (Exception ex) { Util.Help.guidanceNote("Operation not succeed: " + ex.Message); }
            
            try
            {
                //skip first rows that belong to Consultants Staff table
                int FirstRows = 2; 
                //delete every row in Key Personnel table and copy from Form B
                var tb = Globals.ThisDocument.bmKeyPersonnel.Tables[1];
                object n = lbPersonnel.Items.Count - FirstRows - tb.Rows.Count;
                //ASS has fewer rows than Form B
                if ((int)n >= 0)
                {
                    tb.Rows.Last.Select();
                    Globals.ThisDocument.Application.Selection.InsertRowsBelow(ref n);
                    Globals.ThisDocument.Application.Selection.Collapse();
                }
                //ASS has more rows than Form B
                else
                {
                    do { tb.Rows.Last.Delete(); }
                    while (tb.Rows.Count > lbPersonnel.Items.Count - FirstRows);
                }
                //copy items to Key Personnel table skip first x rows, which belong to Consultant's Staff
                for (int i = FirstRows; i < lbPersonnel.Items.Count; i++)
                {
                    tb.Rows[i - FirstRows + 1].Range.Delete();
                    tb.Rows[i - FirstRows + 1].Cells[1].Range.Text = lbPersonnel.Items[i].ToString();
                }
                tb.Range.Font.Bold = 0;
                tb.Rows[1].Select();
            }
            catch(Exception ex)
            {
                Util.Help.guidanceNote("Operation not succeed" + ex.Message);
            }
            Globals.ThisDocument.Application.ScreenUpdating = true;
            Globals.ThisDocument.bmKeyPersonnel.Tables[1].Select();
        }

        private void btnASS_Click(object sender, EventArgs e)
        {
            //check whether some rows in ASS not existed in Form B
            Globals.ThisDocument.Application.ScreenUpdating = false;
            var tb = Globals.ThisDocument.bmASSEnd.Tables[1];
            try
            {
                Microsoft.Office.Interop.Word.Range rgFormB;
                for (int j = 2; j < Globals.ThisDocument.bmASSEnd.Rows[1].Index; j++)
                {
                    rgFormB = Globals.ThisDocument.bmPersonalStart.Tables[1].Range;
                    rgFormB.Find.ClearFormatting();
                    rgFormB.Find.MatchWholeWord = true;
                    rgFormB.Find.MatchCase = false;
                    rgFormB.Find.Forward = true;
                    rgFormB.Find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindStop;
                    if (tb.Rows[j].Cells[2].Range.Text.Replace("\r\a", "").Trim() == "") continue;
                    rgFormB.Find.Text = tb.Rows[j].Cells[2].Range.Text.Replace("\r\a", "").Trim();
                    rgFormB.Find.Execute();
                    if (!rgFormB.Find.Found || rgFormB.Cells[1].ColumnIndex != 1 
                        || rgFormB.Start > Globals.ThisDocument.bmPersonalEnd.Range.End
                        || rgFormB.End < Globals.ThisDocument.bmPersonalStart.Start)
                    {
                        if (MessageBox.Show("There're some entries that not existed in Form B, and this operation will delete them, continue?", "Continue Transfer",
                            MessageBoxButtons.YesNo) ==DialogResult.No) return;
                        else break;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Help.guidanceNote("Operation not succeed: " + ex.Message);
            }

            try
            {
                //delete every row in ASS and copy from Form B
                object n = lbPersonnel.Items.Count - (Globals.ThisDocument.bmASSEnd.Rows[1].Index - 2);
                //ASS has fewer rows than Form B
                if ((int)n >= 0)
                {
                    tb.Rows[Globals.ThisDocument.bmASSEnd.Rows[1].Index - 1].Select();
                    Globals.ThisDocument.Application.Selection.InsertRowsBelow(ref n);
                    Globals.ThisDocument.Application.Selection.Collapse();
                }
                //ASS has more rows than Form B
                else
                {
                    do
                    {
                        tb.Rows[Globals.ThisDocument.bmASSEnd.Rows[1].Index - 1].Delete();
                    }
                    while (Globals.ThisDocument.bmASSEnd.Rows[1].Index - 2 > lbPersonnel.Items.Count);
                }
                //copy items to ASS
                int i = 2;
                foreach (var item in lbPersonnel.Items)
                {
                    tb.Rows[i].Range.Delete();
                    tb.Rows[i].Cells[1].Range.Text = (i - 1).ToString();
                    tb.Rows[i].Cells[2].Range.Text = item.ToString();
                    i++;
                }
                tb.Rows[1].Select();
            }
            catch(Exception ex)
            {
                Util.Help.guidanceNote("Operation not succeed" + ex.Message);
            }
            Globals.ThisDocument.Application.ScreenUpdating = true;
            Globals.ThisDocument.bmASSEnd.Tables[1].Select();
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
    }
}
