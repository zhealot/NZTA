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
        ThisDocument doc = NZTA_Contract_Generator.Globals.ThisDocument;
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
            bool chkd = BridgesOther.Checked || StateHighway.Checked ? true : false;
            var rg = Globals.ThisDocument.rtcStandardSpecificationsClause.Range;
            rg.SetRange(rg.Start - 1, rg.End + 2);
            rg.Font.Hidden = chkd ? 0 : 1;
            Util.ContentControls.setText("Standard_Specifications", chkd ? "and Standard Specifications" : "");
            chkd = BridgesOther.Checked;
            rg = Globals.ThisDocument.rtcClauseBridge.Range;
            rg.SetRange(rg.Start - 1, rg.End + 2);
            rg.Font.Hidden = chkd ? 0 : 1;
            chkd = StateHighway.Checked;
            rg = Globals.ThisDocument.rtcClauseHighway.Range;
            rg.SetRange(rg.Start - 1, rg.End + 2);
            rg.Font.Hidden = chkd ? 0 : 1;
        }

        private void OtherSpecification_Changed(object sender, EventArgs e)
        {
            contract.OtherSpecification = OtherSpecification.Checked;
            var rg = Globals.ThisDocument.rtcClauseOther.Range;
            rg.SetRange(rg.Start - 1, rg.End + 2);
            rg.Font.Hidden = OtherSpecification.Checked ? 0 : 1;
            if (OtherSpecification.Checked)
            {
                rg.Select();
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

        private void button1_Click(object sender, EventArgs e)
        {
            var tb = Globals.ThisDocument.bmBridegInPricingTable.Tables[1];
            int hiden = tb.Rows[Globals.ThisDocument.bmBridegInPricingTable.Rows[1].Index].Range.Font.Hidden;
            tb.Rows[Globals.ThisDocument.bmBridegInPricingTable.Rows[1].Index].Range.Font.Hidden = hiden == -1 ? 0 : 1;
        }
    }
}
