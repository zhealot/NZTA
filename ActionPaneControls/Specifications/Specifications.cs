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

namespace NZTA_Contract_Generator.ActionPaneControls.Specifications
{
    public partial class Specifications : UserControl
    {
        Contract contract = Globals.ThisDocument.contract;
        ThisDocument doc = Globals.ThisDocument;
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
            //hide/show clauses in Contract Agreement Form 4.1
            rg = Globals.ThisDocument.rtcClauseBridge.Range;
            Util.ContentControls.RangeHideShow(ref rg, BridgeChkd);
            rg = Globals.ThisDocument.rtcClauseHighway.Range;
            Util.ContentControls.RangeHideShow(ref rg, HighwayChkd);

            //hide/show row in contract pricing & payment tables
            var bm8Bridges = Globals.ThisDocument.bm8BridegInPricingTable;
            var bm9Highways = Globals.ThisDocument.bm9HighwayInPricingTable;
            var bm10Geo = Globals.ThisDocument.bm10GeoInPricingTable;
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                bm8Bridges.Rows[1].Cells[1].Range.SetListLevel(BridgeChkd ? (short)1 : (short)2);
                bm9Highways.Rows[1].Cells[1].Range.SetListLevel(HighwayChkd ? (short)1 : (short)2);
                for (int i = bm8Bridges.Rows[1].Index; i < bm9Highways.Rows[1].Index; i++)
                {
                    bm8Bridges.Tables[1].Rows[i].Range.Font.Hidden = BridgeChkd ? 0 : 1;
                }
                for (int i = bm9Highways.Rows[1].Index; i < bm10Geo.Rows[1].Index; i++)
                {
                    bm9Highways.Tables[1].Rows[i].Range.Font.Hidden = HighwayChkd ? 0 : 1;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }


            bm8Bridges = Globals.ThisDocument.bm8BridegInPaymentTable;
            bm9Highways = Globals.ThisDocument.bm9HighwayInPaymentTable;
            bm10Geo = Globals.ThisDocument.bm10GeoInPaymentTable;
            try
            {
                bm8Bridges.Rows[1].Cells[1].Range.SetListLevel(BridgeChkd ? (short)1 : (short)2);
                bm9Highways.Rows[1].Cells[1].Range.SetListLevel(HighwayChkd ? (short)1 : (short)2);
                for (int i = bm8Bridges.Rows[1].Index; i < bm9Highways.Rows[1].Index; i++)
                {
                    bm8Bridges.Tables[1].Rows[i].Range.Font.Hidden = BridgeChkd ? 0 : 1;
                }
                for (int i = bm9Highways.Rows[1].Index; i < bm10Geo.Rows[1].Index; i++)
                {
                    bm9Highways.Tables[1].Rows[i].Range.Font.Hidden = HighwayChkd ? 0 : 1;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            //update subtaol and total number
            int sub = 9;
            sub = BridgeChkd ? sub : sub - 1;
            sub = HighwayChkd ? sub : sub - 1;
            Globals.ThisDocument.rtcSubTotal9.Range.Text = sub++.ToString();
            Globals.ThisDocument.rtcSubTotal10.Range.Text = sub++.ToString();
            Globals.ThisDocument.rtcSubTotal11.Range.Text = sub.ToString();
            Globals.ThisDocument.rtcSubTotal11_2.Range.Text = sub++.ToString();
            Globals.ThisDocument.rtcSubTotal12.Range.Text = sub.ToString();
            Globals.ThisDocument.rtcTotal.Range.Text = sub.ToString();
            Globals.ThisDocument.rtcSectionG.Range.Font.Hidden = (OtherSpecification.Checked || BridgesOther.Checked || StateHighway.Checked) ? 0 : 1;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            Globals.ThisDocument.rtcSectionG.Range.Select();
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
            Globals.ThisDocument.rtcSectionG.Range.Font.Hidden = (OtherSpecification.Checked || BridgesOther.Checked || StateHighway.Checked) ? 0 : 1;
        }

        //private void MultipleProjects_No_CheckedChanged(object sender, EventArgs e)
        //{
        //    contract.MultipleProjects_No = ((RadioButton)sender).Checked;
        //}

        //private void MultipleProjects_Yes_CheckedChanged(object sender, EventArgs e)
        //{
        //    contract.MultipleProjects_Yes = ((RadioButton)sender).Checked;
        //}

        //private void Project1_TextChanged(object sender, EventArgs e)
        //{
        //    contract.Project1 = ((TextBox)sender).Text;
        //}
    }
}
