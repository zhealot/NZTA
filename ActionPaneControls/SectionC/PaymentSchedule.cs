using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.SectionC
{
    public partial class PaymentSchedule : UserControl
    {
        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;        
        public PaymentSchedule()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
            UnitRate_chk_CheckedChanged(null, null);
            HourlyRate_chk_CheckedChanged(null, null);
            CostFluctuations_Check_CheckedChanged(null,null);
        }

        private void help3_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Cost fluctuations will be paid where contract period is more than 12 months");
        }

        private void CostFluctuations_Check_CheckedChanged(object sender, EventArgs e)
        {
            bool blChkd = CostFluctuations_Check.Checked;
            contract.CostFluctuations_Check = blChkd;
            CostIndex.Enabled = blChkd;
            lblCostIndex.Enabled = blChkd;
            var rgNo = Globals.ThisDocument.rtcCostFluctuationsNo.Range;
            var rgYes = Globals.ThisDocument.rtcCostFluctuationsYes.Range;
            object style = blChkd ? "Normal" : Globals.ThisDocument.rtcLevel3Style.Range.get_Style();
            rgNo.Collapse();
            rgNo.set_Style(ref style);
            rgNo = Globals.ThisDocument.rtcCostFluctuationsNo.Range;
            rgNo.SetRange(rgNo.Start - 1, rgNo.End + 2);
            rgNo.Font.Hidden = blChkd ? 1 : 0;
            rgYes.SetRange(rgYes.Start - 1, rgYes.End + 2);
            rgYes.Font.Hidden = blChkd ? 0 : 1;
            if (blChkd)
            { 
                rgYes.Select();
            }
            else
            {
                rgNo.Select();
            }
        }

        private void CostIndex_ValueChanged(object sender, EventArgs e)
        {
            contract.CostIndex = CostIndex.Value;
            Util.ContentControls.setText("CostIndex1", CostIndex.Value.ToString());
            Util.ContentControls.setText("CostIndex2", (1 - CostIndex.Value).ToString());
        }

        private void UnitRate_chk_CheckedChanged(object sender, EventArgs e)
        {
            bool UnitRateChkd = UnitRate_chk.Checked;
            contract.UnitRate_chk = UnitRate_chk.Checked;
            var rg = Globals.ThisDocument.rtcUnitRateItems.Range;
            object style = UnitRateChkd ? Globals.ThisDocument.rtcLevel2Style.Range.get_Style() : GlobalVar.StyleNormal;
            rg.Collapse();
            rg.set_Style(ref style);
            rg = Globals.ThisDocument.rtcUnitRateItems.Range;
            Util.ContentControls.RangeHideShow(ref rg, UnitRateChkd);
            rg.Select();
        }

        private void HourlyRate_chk_CheckedChanged(object sender, EventArgs e)
        {
            contract.HourlyRate_chk = HourlyRate_chk.Checked;
            bool HourlyRateChkd = HourlyRate_chk.Checked;
            var rg = Globals.ThisDocument.rtcHourlyRateItems.Range;
            object style = HourlyRateChkd ? Globals.ThisDocument.rtcLevel2Style.Range.get_Style() : GlobalVar.StyleNormal;
            rg.Collapse();
            rg.set_Style(ref style);
            rg = Globals.ThisDocument.rtcHourlyRateItems.Range;
            Util.ContentControls.RangeHideShow(ref rg, HourlyRateChkd);
            rg.Select();
            rg = Globals.ThisDocument.rtcHourlyRateItem2.Range;
            rg.Collapse();
            rg.set_Style(ref style);
            rg = Globals.ThisDocument.rtcHourlyRateItem2.Range;
            Util.ContentControls.RangeHideShow(ref rg, HourlyRateChkd);
        }
    }
}
