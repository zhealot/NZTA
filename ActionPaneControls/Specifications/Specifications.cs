using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.Specifications
{
    public partial class Specifications : UserControl
    {
        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;
        public Specifications()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void BridgesOther_CheckedChanged(object sender, EventArgs e)
        {
            contract.BridgesOther = BridgesOther.Checked;
            contract.StateHighway = StateHighway.Checked;
            object start = NZTA_Contract_Generator.Globals.ThisDocument.bmStandardSpecificationClause.Range.Start;
            var rg = NZTA_Contract_Generator.Globals.ThisDocument.Range(ref start, ref start);
            rg.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdParagraph, 2);
            if (BridgesOther.Checked || StateHighway.Checked)
            {
                Util.ContentControls.setText("Standard_Specifications", " and Standard Specifications");
                if (!rg.Text.Contains("Standard Specifications"))
                {
                    rg.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart);
                    rg.InsertParagraph();
                    rg.InsertAfter("Standard Specifications will only be attached to the signing sets.  To view copies of the Standard Specifications during the tender period, refer to the Highways Information Portal (");
                    rg.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                    rg.Hyperlinks.Add(rg, "http://hip.nzta.govt.nz/technical-information", TextToDisplay: "http://hip.nzta.govt.nz/technical-information");
                    rg.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdParagraph, 1);
                    rg.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, -1);
                    rg.InsertAfter(").");
                }
            }
            else
            {
                if (rg.Text.Contains("Standard Specifications"))
                {
                    rg.Delete();
                }
                Util.ContentControls.setText("Standard_Specifications", "");
            }
        }

        private void MultipleProjects_No_CheckedChanged(object sender, EventArgs e)
        {
            contract.MultipleProjects_No = ((RadioButton)sender).Checked;
        }

        private void MultipleProjects_Yes_CheckedChanged(object sender, EventArgs e)
        {
            contract.MultipleProjects_Yes = ((RadioButton)sender).Checked;
        }

        private void Project1_TextChanged(object sender, EventArgs e)
        {
            contract.Project1 = ((TextBox)sender).Text;
        }
    }
}
