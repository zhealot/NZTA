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
            bool BridgeChkd = BridgesOther.Checked;
            bool HighwayChkd = StateHighway.Checked;
            // hide/show clause in StandardSpecifications
            bool chkd = BridgesOther.Checked || StateHighway.Checked ? true : false;
            var rg = Globals.ThisDocument.rtcStandardSpecificationsClause.Range;
            Util.ContentControls.RangeHideShow(ref rg, BridgeChkd || HighwayChkd);
            Util.ContentControls.setText("Standard_Specifications", chkd ? "and Standard Specifications" : "");
            //hide/show clauses in Page 16
            rg = Globals.ThisDocument.rtcClauseBridge.Range;
            Util.ContentControls.RangeHideShow(ref rg, BridgeChkd);
            rg = Globals.ThisDocument.rtcClauseHighway.Range;
            Util.ContentControls.RangeHideShow(ref rg, HighwayChkd);

            //hide/show row in contract pricing & payment tables
            var bm8Bridges = Globals.ThisDocument.bm8BridegInPricingTable;
            var bm9Highways = Globals.ThisDocument.bm9HighwayInPricingTable;
            var bm10Geo = Globals.ThisDocument.bm10GeoInPricingTable;
            try
            {
                for (int i = bm8Bridges.Rows[1].Index; i < bm9Highways.Rows[1].Index; i++)
                {
                    Globals.ThisDocument.bm8BridegInPricingTable.Tables[1].Rows[i].Range.Font.Hidden = BridgeChkd ? 0 : 1;
                }
                for (int i = bm9Highways.Rows[1].Index; i < bm10Geo.Rows[1].Index; i++)
                {
                    Globals.ThisDocument.bm9HighwayInPricingTable.Tables[1].Rows[i].Range.Font.Hidden = HighwayChkd ? 0 : 1;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
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
    }
}
