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
        }

        private void cbMeth1_CheckedChanged(object sender, EventArgs e)
        {
            var rg = NZTA_Contract_Generator.Globals.ThisDocument;
            

        }

        private void GuidanceNote_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void RelevantExperience_ValueChanged(object sender, EventArgs e)
        {
            contract.RelevantExperience = ((NumericUpDown)sender).Value.ToString();
            Util.ContentControls.setText(((NumericUpDown)sender).Name, ((NumericUpDown)sender).Value.ToString());
        }

        private void TrackRecord_ValueChanged(object sender, EventArgs e)
        {
            contract.TrackRecord = ((NumericUpDown)sender).Value.ToString();
            Util.ContentControls.setText(((NumericUpDown)sender).Name, ((NumericUpDown)sender).Value.ToString());
        }

        private void ExperienceVSRecord_ValueChanged(object sender, EventArgs e)
        {
            contract.ExperienceVSRecord = ((NumericUpDown)sender).Value.ToString();
            Util.ContentControls.setText(((NumericUpDown)sender).Name, ((NumericUpDown)sender).Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object RgStart = NZTA_Contract_Generator.Globals.ThisDocument.MethStart.Start;
            object RgEnd = NZTA_Contract_Generator.Globals.ThisDocument.Tender_Evaluation_Procedure.Start;
            var rg = NZTA_Contract_Generator.Globals.ThisDocument.Range(ref RgStart, ref RgEnd);
            lbMeths.Items.Clear();
            rg.Find.ClearFormatting();
            object stl = "NZTA Tendering: Level 4 (Numbering)";
            rg.Find.set_Style(ref stl);
            rg.Find.Execute();
            //var stl = rg.get_Style().NameLocal;
            while (rg.Find.Found && rg.Start < (int)RgEnd && rg.End >= (int)RgStart)
            {
                if (!string.IsNullOrEmpty(rg.Text) && rg.Text.Contains(":") && !rg.Text.Contains("[Other]"))
                {                    
                    lbMeths.Items.Add(rg.Text.Substring(0,rg.Text.IndexOf(":")));
                }                
                rg.Find.Execute();
            }
            NZTA_Contract_Generator.Globals.ThisDocument.MethStart.Select();
        }

        private void TransferToFormC_Click(object sender, EventArgs e)
        {
            decimal[] pst;
            try
            {
                pst = tbPercent.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Select(decimal.Parse).ToArray();                
            }
            catch (Exception ex)
            {
                Util.Help.guidanceNote("invalid input for percentage");
                return;
            }
            if (pst.Count() != lbMeths.Items.Count)
            {
                Util.Help.guidanceNote("Each Methodology needs one percentage number");
                return;
            }
            if (pst.Sum() != 100)
            {
                Util.Help.guidanceNote("Percentage must add up to 100");
                return;
            }

            var MethStart = NZTA_Contract_Generator.Globals.ThisDocument.FormC_MethStart;
            var MethEnd = NZTA_Contract_Generator.Globals.ThisDocument.FormC_MethEnd;
            var MethAbove = NZTA_Contract_Generator.Globals.ThisDocument.MethAbove;
            //NZTA_Contract_Generator.Globals.ThisDocument.Application.UndoRecord.EndCustomRecord();
            //var PaginationOption = NZTA_Contract_Generator.Globals.ThisDocument.Application.Options.Pagination;
            //NZTA_Contract_Generator.Globals.ThisDocument.Application.Options.Pagination = false;
            //MethStart.Tables[1].AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitFixed);
            //var ViewType = NZTA_Contract_Generator.Globals.ThisDocument.Application.ActiveWindow.View.Type;
            //NZTA_Contract_Generator.Globals.ThisDocument.Application.ScreenUpdating = false;
            //NZTA_Contract_Generator.Globals.ThisDocument.Application.Visible = false;

            while (MethEnd.Range.Rows[1].Index - MethAbove.Range.Rows[1].Index > 2)
            {
                MethStart.Range.Tables[1].Rows[MethAbove.Range.Rows[1].Index + 1].Delete();
            }
            MethStart.Range.Rows[1].Range.Delete();
            object bf = MethStart.Rows[1];            
            
            for (int i = 0; i < lbMeths.Items.Count; i++)
            {
                var rw = MethAbove.Rows.Add(ref bf);
                rw.Cells[1].Range.Text = lbMeths.Items[i].ToString();
                rw.Cells[2].Range.Text = pst[i].ToString();
            }
            MethStart.Select();
            //NZTA_Contract_Generator.Globals.ThisDocument.Application.ScreenUpdating = true;
            //NZTA_Contract_Generator.Globals.ThisDocument.Application.Options.Pagination = PaginationOption;
            //NZTA_Contract_Generator.Globals.ThisDocument.Application.ActiveWindow.View.Type = ViewType;
            //MethStart.Tables[1].AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent);
            //NZTA_Contract_Generator.Globals.ThisDocument.Application.Visible = true;
        }

        private void lbMeths_SizeChanged(object sender, EventArgs e)
        {
            //tbPercent.Height = lbMeths.Height;
        }
    }
}
