using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
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

            if (contract.rbLPC == false)
            {
                tbWeighting.Enabled = false;
            }
            //retrieve entries from section 5 Tender Evaluation Forms, Form B
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.bmPersonalAbove.Tables[1];
            lbPersonnel.Items.Clear();
            for (int i = NZTA_Contract_Generator.Globals.ThisDocument.bmPersonalStart.Rows[1].Index; 
                     i < NZTA_Contract_Generator.Globals.ThisDocument.bmPersonalEnd.Rows[1].Index; i++)
            {
                lbPersonnel.Items.Add(tbl.Rows[i].Cells[1].Range.Text.Replace("\r\a", ""));
            }
        }

        private void btnPS_Click(object sender, EventArgs e)
        {

        }

        private void btnASS_Click(object sender, EventArgs e)
        {
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.bmASSStart.Tables[1];
            tbl.Range.Find.ClearFormatting();            
            tbl.Range.Find.MatchWholeWord = true;
            tbl.Range.Find.MatchCase = false;
            foreach (var ls in lbPersonnel.Items)
            {
                tbl.Range.Find.Execute(ls.ToString());
                if (!tbl.Range.Find.Found)
                {
                    
                }
            }
        }
    }
}
