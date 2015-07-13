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
                if (!string.IsNullOrEmpty(rg.Text) && rg.Text.Contains(":"))
                {                    
                    lbMeths.Items.Add(rg.Text.Substring(0,rg.Text.IndexOf(":")));
                }                
                rg.Find.Execute();
            }
            NZTA_Contract_Generator.Globals.ThisDocument.MethStart.Select();
        }
    }
}
