using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    partial class TenderEvaluationProcedure : UserControl
    {
        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;                
        public TenderEvaluationProcedure()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void TeamLeader_Change(object sender, EventArgs e)
        {
            try
            {
                var tb = Globals.ThisDocument.bmTenderEvaluationTeam.Tables[1];
                if (!Util.ContentControls.RowsInTable(ref tb, 6)) 
                { 
                    throw new Exception();
                }
                tb.Rows[2].Range.Text = ETL_Name.Text + ", " + ETL_Company.Text + ", " + ETL_Position.Text + ". (Leader)";
                tb.Range.Select();
            }
            catch (Exception ex)
            {
                Util.Help.guidanceNote("Failed: " + ex.Message);
            }
        }

        private void Text_Change(object sender, EventArgs e)
        {
            try
            {
                var tb = Globals.ThisDocument.bmTenderEvaluationTeam.Tables[1];
                if (!Util.ContentControls.RowsInTable(ref tb, 6)) { throw new Exception(); }
                int n;
                if (int.TryParse(((TextBox)sender).Name.Substring(2, 1), out n))
                {
                    string txt = ((TextBox)this.Controls.Find("ET" + n.ToString() + "_Name", true)[0]).Text;
                    txt += ", " + ((TextBox)this.Controls.Find("ET" + n.ToString() + "_Position", true)[0]).Text;
                    txt += ", " + ((TextBox)this.Controls.Find("ET" + n.ToString() + "_Company", true)[0]).Text+".";
                    tb.Rows[n + 1].Cells[1].Range.Text = txt;
                    tb.Range.Select();
                }
            }
            catch (Exception ex) { Util.Help.guidanceNote("Failed: " + ex.Message); }
        }

        private void Checkbox_Changed(object sender, EventArgs e)
        {
            try
            {
                var tb = Globals.ThisDocument.bmTenderEvaluationTeam.Tables[1];
                if (!Util.ContentControls.RowsInTable(ref tb, 6)) { throw new Exception(); }
                int n;
                if (int.TryParse(((CheckBox)sender).Name.Substring(3, 1), out n))
                {
                    ((GroupBox)this.Controls.Find("gbTET" + n.ToString(), true)[0]).Enabled = ((CheckBox)sender).Checked;
                    Globals.ThisDocument.bmTenderEvaluationTeam.Tables[1].Rows[n + 1].Range.Font.Hidden = ((CheckBox)sender).Checked ? 0 : 1;
                    tb.Range.Select();
                }
            }
            catch (Exception ex) { Util.Help.guidanceNote("Failed: " + ex.Message); }
        }


        private void Audit_Period_ValueChanged(object sender, EventArgs e)
        {
            if (AuditPeriod.Value > 2)
            {
                Util.Help.guidanceNote("Audit period must not be greater than 2 weeks.");
                AuditPeriod.Value = 2;
            }
            else
            {
                contract.AuditPeriod = ((NumericUpDown)sender).Value;
                Util.ContentControls.setText(((NumericUpDown)sender).Name, Util.ContentControls.DecimalToWords(((NumericUpDown)sender).Value) + " week" + (((NumericUpDown)sender).Value > 1 ? "s" : ""));
                Globals.ThisDocument.rtcAuditPeriod.Range.Select();
            }
        }

        private void help1_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("At least one TET member must be qualified for tenders >$200,000, but this does not have to be the TET Leader");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Guidance note: must not be greater than 2 weeks");
        }
    }
}
