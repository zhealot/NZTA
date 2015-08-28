using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.SupplierSelectionMethod
{
    public partial class NonPriceAttributes : UserControl
    {
        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;        
        public NonPriceAttributes()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
            TrackRecord.Enabled = contract.cbTrackRecord;
        }

        private void RelevantExperience_ValueChanged(object sender, EventArgs e)
        {
            contract.RelevantExperience = ((NumericUpDown)sender).Value;
            Util.ContentControls.setText(((NumericUpDown)sender).Name, Util.ContentControls.DecimalToWords(((NumericUpDown)sender).Value));
        }

        private void TrackRecord_ValueChanged(object sender, EventArgs e)
        {
            contract.TrackRecord = ((NumericUpDown)sender).Value;
            Util.ContentControls.setText(((NumericUpDown)sender).Name, Util.ContentControls.DecimalToWords(((NumericUpDown)sender).Value));
        }

        private void ExperienceVSRecord_ValueChanged(object sender, EventArgs e)
        {
            contract.ExperienceVSRecord = ((NumericUpDown)sender).Value;
            Util.ContentControls.setText(((NumericUpDown)sender).Name, Util.ContentControls.DecimalToWords(((NumericUpDown)sender).Value));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object RgStart = NZTA_Contract_Generator.Globals.ThisDocument.MethStart.Start;
            object RgEnd = NZTA_Contract_Generator.Globals.ThisDocument.Tender_Evaluation_Procedure.Start;
            var rg = NZTA_Contract_Generator.Globals.ThisDocument.Range(ref RgStart, ref RgEnd);
            lbMeths.Items.Clear();
            rg.Find.ClearFormatting();
            object stl = Globals.ThisDocument.MethStart.Range.get_Style(); //"NZTA Tendering: Level 4 (Numbering)";
            rg.Find.set_Style(ref stl);
            rg.Find.Execute();
            //retrieve clauses from 2.3 Methodology and list them in ACP Listbox
            while (rg.Find.Found && rg.Start <= (int)RgEnd && rg.End >= (int)RgStart)
            {
                if (!string.IsNullOrEmpty(rg.Text) && rg.Text.Contains(":") && !rg.Text.Contains("Other:"))
                {                    
                    lbMeths.Items.Add(rg.Text.Substring(0,rg.Text.IndexOf(":")));
                }                
                rg.Find.Execute();
            }
            //retireve weighting data from 5 Form C and list them in ACP Textbox
            //tbPercent.Clear();
            var tb =NZTA_Contract_Generator.Globals.ThisDocument.MethAbove.Tables[1];
            for (int i = NZTA_Contract_Generator.Globals.ThisDocument.MethAbove.Rows[1].Index + 1; 
                i <= NZTA_Contract_Generator.Globals.ThisDocument.FormC_MethStart.Rows[1].Index; i++)
            {
                if (tb.Rows[i].Cells.Count >= 2)
                {
                    tbPercent.Text += tb.Rows[i].Cells[2].Range.Text.Replace("%", "").Replace("\r\a", "") + Environment.NewLine;
                }
            }
            tbPercent.Text = tbPercent.Text.TrimEnd(Environment.NewLine.ToCharArray());
            NZTA_Contract_Generator.Globals.ThisDocument.MethStart.Select();
        }

        private void TransferToFormC_Click(object sender, EventArgs e)
        {

            decimal[] pctg = new decimal[lbMeths.Items.Count];
            //no weightings if Supplier Selection Methody is Lowest Price Conforming 
            if (contract.rbLPC == false)
            {
                try
                {
                    //tbPercent.Text.TrimEnd(Environment.NewLine.ToCharArray());
                    pctg = tbPercent.Text.TrimEnd(Environment.NewLine.ToCharArray()).Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Select(decimal.Parse).ToArray();
                }
                catch (Exception ex)
                {
                    Util.Help.guidanceNote("invalid input for percentage");
                    Console.Write(ex.Message);
                    return;
                }
                if (pctg.Count() != lbMeths.Items.Count)
                {
                    Util.Help.guidanceNote("Each Methodology needs one percentage number");
                    return;
                }
                if (pctg.Sum() != 100)
                {
                    Util.Help.guidanceNote("Percentage must add up to 100");
                    return;
                }    
            }
            
            var FormC_MethStart = NZTA_Contract_Generator.Globals.ThisDocument.FormC_MethStart;
            var FormC_MethEnd = NZTA_Contract_Generator.Globals.ThisDocument.FormC_MethEnd;
            var MethAbove = NZTA_Contract_Generator.Globals.ThisDocument.MethAbove;
            
            var PaginationOption = NZTA_Contract_Generator.Globals.ThisDocument.Application.Options.Pagination;
            NZTA_Contract_Generator.Globals.ThisDocument.Application.Options.Pagination = false;
            NZTA_Contract_Generator.Globals.ThisDocument.Application.ScreenUpdating = false;

            while (FormC_MethEnd.Range.Rows[1].Index - MethAbove.Range.Rows[1].Index > 2)
            {
                FormC_MethStart.Range.Tables[1].Rows[MethAbove.Range.Rows[1].Index + 1].Delete();
            }
            FormC_MethStart.Range.Rows[1].Range.Delete();
            object bf = FormC_MethStart.Rows[1];            
            
            for (int i = 0; i < lbMeths.Items.Count; i++)
            {
                var rw = MethAbove.Rows.Add(ref bf);
                rw.Cells[1].Range.Text = lbMeths.Items[i].ToString();
                rw.Cells[2].Range.Text = (contract.rbLPC == true) ? "N/A" : pctg[i].ToString() + "%";
            }
            FormC_MethStart.Select();
            NZTA_Contract_Generator.Globals.ThisDocument.Application.ScreenUpdating = true;
            NZTA_Contract_Generator.Globals.ThisDocument.Application.Options.Pagination = PaginationOption;
        }

        private void lbMeths_SelectedIndexChanged(object sender, EventArgs e)
        {
            //place cursor to corresponding weighting line 
            if (tbPercent.Lines.Count() >= lbMeths.SelectedIndex + 1 && lbMeths.SelectedIndex > 0)
            {
                tbPercent.Select(tbPercent.GetFirstCharIndexFromLine(lbMeths.SelectedIndex), 0);
                tbPercent.Focus();
                tbPercent.ScrollToCaret();
            }            
        }
    }
}
