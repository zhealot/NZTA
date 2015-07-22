using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    partial class InteractiveTenderProcess : UserControl
    {

        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;
        public InteractiveTenderProcess()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void Interactive_Yes_CheckedChanged(object sender, EventArgs e)
        {
            Meeting_Box.Visible = true;
            contract.Interactive_Yes = true;
            contract.Interactive_No = false;
            if (Interactive_Yes.Checked && NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables.Count == 0)
            {
                //for (int i = 1; i <= NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables.Count; i++)
                //{
                //    NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[i].Delete();
                //}
                var rg = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range;
                var tbl = rg.Tables.Add(rg, 6, 2);
                tbl.Borders.Enable = 1;
            }
            Combined_Check_CheckedChanged(Combined_Check, null);
            Individual1_Check_CheckedChanged(Individual1_Check, null);
            Individual2_Check_CheckedChanged(Individual2_Check, null);
            Individual3_Check_CheckedChanged(Individual3_Check, null);
            Individual4_Check_CheckedChanged(Individual4_Check, null);
            Individual5_Check_CheckedChanged(Individual5_Check, null);
        }

        private void Interactive_No_CheckedChanged(object sender, EventArgs e)
        {
            Meeting_Box.Visible = false;
            contract.Interactive_No = true;
            contract.Interactive_Yes = false;
            for (int i = 1; i <= NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables.Count; i++)
            {
                NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[i].Delete();
            }
        }

        private void help1_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Interactive meetings allow the Agency to work alongside the tenderers in order that they may fully understand the tender document and the scope of the contract.  Interactives are normally undertaken for larger PS contract.  If you opt for Interactives, then you would normally have a combined meeting as a minimum, with individual interactive potentially in addition.");
        }

        private void Combined_Date_ValueChanged(object sender, EventArgs e)
        {
            contract.Combined_Date = Combined_Date.Value.ToString("O");
            Util.ContentControls.setText(Combined_Date.Name, Combined_Date.Value.ToString("dd/MMM/yyyy"));
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[1];
            tbl.Rows[1].Cells[1].Range.Text = Combined_Date.Value.ToString("dd/MMM/yyyy") + " (DD/MMM/YYYY)" + Environment.NewLine + Combined_Time.Value.ToString("HH/mm") + "(HH/mm)";
        }

        private void Individual1_Date_ValueChanged(object sender, EventArgs e)
        {
            contract.Individual1_Date = Individual1_Date.Value.ToString("O");
            Util.ContentControls.setText(Individual1_Date.Name, Individual1_Date.Value.ToString("dd/MMM/yyyy"));
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[1];
            tbl.Rows[2].Cells[1].Range.Text = Individual1_Date.Value.ToString("dd/MMM/yyyy") + " (DD/MM/YYYY)";
        }

        private void Combined_Time_ValueChanged(object sender, EventArgs e)
        {
            contract.Combined_Time = Combined_Time.Value.ToString("O");
            Util.ContentControls.setText(Combined_Time.Name, Combined_Time.Value.ToString("HH/mm"));
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[1];
            tbl.Rows[1].Cells[1].Range.Text = Combined_Date.Value.ToString("dd/MMM/yyyy") + " (DD/MMM/YYYY)" + Environment.NewLine + Combined_Time.Value.ToString("HH/mm") + "(HH/mm)";
        }

        private void Individual2_Date_ValueChanged(object sender, EventArgs e)
        {
            contract.Individual2_Date = Individual2_Date.Value.ToString("O");
            Util.ContentControls.setText(Individual2_Date.Name, Individual2_Date.Value.ToString("dd/MMM/yyyy"));
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[1];
            tbl.Rows[3].Cells[1].Range.Text = Individual2_Date.Value.ToString("dd/MMM/yyyy") + " (DD/MM/YYYY)";
        }

        private void Individual3_Date_ValueChanged(object sender, EventArgs e)
        {
            contract.Individual3_Date = Individual3_Date.Value.ToString("O");
            Util.ContentControls.setText(Individual3_Date.Name, Individual3_Date.Value.ToString("dd/MMM/yyyy"));
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[1];
            tbl.Rows[4].Cells[1].Range.Text = Individual3_Date.Value.ToString("dd/MMM/yyyy") + " (DD/MM/YYYY)";
        }

        private void Individual4_Date_ValueChanged(object sender, EventArgs e)
        {
            contract.Individual4_Date = Individual4_Date.Value.ToString("O");
            Util.ContentControls.setText(Individual4_Date.Name, Individual4_Date.Value.ToString("dd/MMM/yyyy"));
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[1];
            tbl.Rows[5].Cells[1].Range.Text = Individual4_Date.Value.ToString("dd/MMM/yyyy") + " (DD/MM/YYYY)";
        }

        private void Individual5_Date_ValueChanged(object sender, EventArgs e)
        {
            contract.Individual5_Date = Individual5_Date.Value.ToString("O");
            Util.ContentControls.setText(Individual5_Date.Name, Individual5_Date.Value.ToString("dd/MMM/yyyy"));
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[1];
            tbl.Rows[6].Cells[1].Range.Text = Individual5_Date.Value.ToString("dd/MMM/yyyy") + " (DD/MM/YYYY)";
        }

        private void Combined_Check_CheckedChanged(object sender, EventArgs e)
        {
            contract.Combined_Check = ((CheckBox)sender).Checked;
            Combined_Date.Enabled = ((CheckBox)sender).Checked;
            Combined_Time.Enabled = ((CheckBox)sender).Checked;
            Combined_Place.Enabled = ((CheckBox)sender).Checked;
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[1];                       
            if (((CheckBox)sender).Checked)
            {                
                tbl.Rows[1].Cells[2].Range.Text = "Combined Meeting";
                Combined_Date_ValueChanged(Combined_Date, null);
                Combined_Time_ValueChanged(Combined_Time, null);
            }
            else
            {
                tbl.Rows[1].Cells[1].Range.Text = null;
                tbl.Rows[1].Cells[2].Range.Text = null;
            }            
        }

        private void Individual1_Check_CheckedChanged(object sender, EventArgs e)
        {
            contract.Individual1_Check = ((CheckBox)sender).Checked;
            Individual1_Date.Enabled = ((CheckBox)sender).Checked;

            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[1];
            if (((CheckBox)sender).Checked)
            {                
                tbl.Rows[2].Cells[2].Range.Text = "Individual Meetings I";
                Individual1_Date_ValueChanged(Individual1_Date, null);
            }
            else
            {
                tbl.Rows[2].Cells[1].Range.Text = null;
                tbl.Rows[2].Cells[2].Range.Text = null;
            }            
        }

        private void Individual2_Check_CheckedChanged(object sender, EventArgs e)
        {
            contract.Individual2_Check = ((CheckBox)sender).Checked;
            Individual2_Date.Enabled = ((CheckBox)sender).Checked;
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[1];
            if (((CheckBox)sender).Checked)
            {
                tbl.Rows[3].Cells[2].Range.Text = "Individual Meetings II";
                Individual2_Date_ValueChanged(Individual2_Date, null);
            }
            else
            {
                tbl.Rows[3].Cells[1].Range.Text = null;
                tbl.Rows[3].Cells[2].Range.Text = null;
            }   
        }

        private void Individual3_Check_CheckedChanged(object sender, EventArgs e)
        {
            contract.Individual3_Check = ((CheckBox)sender).Checked;
            Individual3_Date.Enabled = ((CheckBox)sender).Checked;
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[1];
            if (((CheckBox)sender).Checked)
            {
                tbl.Rows[4].Cells[2].Range.Text = "Individual Meetings III";
                Individual3_Date_ValueChanged(Individual3_Date, null);
            }
            else
            {
                tbl.Rows[4].Cells[1].Range.Text = null;
                tbl.Rows[4].Cells[2].Range.Text = null;
            }   
        }

        private void Individual4_Check_CheckedChanged(object sender, EventArgs e)
        {
            contract.Individual4_Check = ((CheckBox)sender).Checked;
            Individual4_Date.Enabled = ((CheckBox)sender).Checked;
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[1];
            if (((CheckBox)sender).Checked)
            {
                tbl.Rows[5].Cells[2].Range.Text = "Individual Meetings IV";
                Individual4_Date_ValueChanged(Individual4_Date, null);
            }
            else
            {
                tbl.Rows[5].Cells[1].Range.Text = null;
                tbl.Rows[5].Cells[2].Range.Text = null;
            }   
        }

        private void Individual5_Check_CheckedChanged(object sender, EventArgs e)
        {
            contract.Individual5_Check = ((CheckBox)sender).Checked;
            Individual5_Date.Enabled = ((CheckBox)sender).Checked;
            var tbl = NZTA_Contract_Generator.Globals.ThisDocument.MeetingSchedule.Range.Tables[1];
            if (((CheckBox)sender).Checked)
            {
                tbl.Rows[6].Cells[2].Range.Text = "Individual Meetings V";
                Individual5_Date_ValueChanged(Individual5_Date, null);
            }
            else
            {
                tbl.Rows[6].Cells[1].Range.Text = null;
                tbl.Rows[6].Cells[2].Range.Text = null;
            }   
        }

        private void Individual_Place_TextChanged(object sender, EventArgs e)
        {
            contract.Individual_Place = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void Combined_Place_TextChanged(object sender, EventArgs e)
        {
            contract.Combined_Place = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void Meeting_Box_Enter(object sender, EventArgs e)
        {
            
        }


 
    }
}
