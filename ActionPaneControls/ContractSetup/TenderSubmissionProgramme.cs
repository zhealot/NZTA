using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    partial class TenderSubmissionProgramme : UserControl
    {

        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;
        bool ignoreChange = false;

        public TenderSubmissionProgramme()
        {
            InitializeComponent();
            //Load any data
            ignoreChange = true;
            //Address combobox
            Presentation_Address.DataSource = new BindingSource(Constants.Location.data, null);
            Presentation_Address.DisplayMember = "Key";
            Presentation_Address.ValueMember = "Value";
            ignoreChange = false;
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void CloseDate_ValueChanged(object sender, EventArgs e)
        {
            contract.CloseDate = CloseDate.Value.Day.ToString("dd/MM/yyyy");
            Util.ContentControls.setText("CloseDate", contract.CloseDate);
        }

        private void Evaluation_Start_ValueChanged(object sender, EventArgs e)
        {
            contract.Evaluation_Start = ((DateTimePicker)sender).Value.ToString("O");
            Util.ContentControls.setText("Evaluation_Period", "From " + contract.Evaluation_Start + " to " + contract.Evaluation_End);
        }

        private void Evaluation_End_ValueChanged(object sender, EventArgs e)
        {
            contract.Evaluation_End = ((DateTimePicker)sender).Value.ToString("O");
            Util.ContentControls.setText("Evaluation_Period", "From " + contract.Evaluation_Start + " to " + contract.Evaluation_End);
        }

        private void PrelettingFromDate_ValueChanged(object sender, EventArgs e)
        {
            contract.PrelettingFromDate = ((DateTimePicker)sender).Value.ToString("O");
            Util.ContentControls.setText("Preletting_Period", "From " + contract.PrelettingFromDate + " to " + contract.PrelettingEndDate);
        }

        private void PrelettingEndDate_ValueChanged(object sender, EventArgs e)
        {
            contract.PrelettingEndDate = ((DateTimePicker)sender).Value.ToString("O");
            Util.ContentControls.setText("Preletting_Period", "From " + contract.PrelettingFromDate + " to " + contract.PrelettingEndDate);
        }

        //### in format: "from xx to xx"?
        private void Preletting_Period(object sender, EventArgs e)
        {
            Util.ContentControls.setText("Preletting_Period", "from " + contract.PrelettingFromDate + Environment.NewLine + " to " + contract.PrelettingEndDate);
        }

        private void TargetDate_ValueChanged(object sender, EventArgs e)
        {
            contract.TargetDate = ((DateTimePicker)sender).Value.ToString("O");
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void PresentationsRequired_No_CheckedChanged(object sender, EventArgs e)
        {
            contract.PrelettingMeetings_No = true;
            contract.PrelettingMeetings_Yes = false;
        }

        private void PresentationsRequired_Yes_CheckedChanged(object sender, EventArgs e)
        {
            contract.PrelettingMeetings_Yes = true;
            contract.PrelettingMeetings_No = false;
        }

        private void PrelettingMeetings_No_CheckedChanged(object sender, EventArgs e)
        {
            contract.PrelettingMeetings_No = true;
            contract.PrelettingMeetings_Yes = false;
            PrelettingEndDate.Enabled = false;
            PrelettingFromDate.Enabled = false;
            Util.ContentControls.setText("Preletting_Period", "Not required");
        }
      
        private void PrelettingMeetings_Yes_CheckedChanged(object sender, EventArgs e)
        {
            contract.PrelettingMeetings_Yes = true;
            contract.PrelettingMeetings_No = false;
            PrelettingFromDate.Enabled = true;
            PrelettingEndDate.Enabled = true;
        }

        private void Presentation_Address_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null && !ignoreChange)
            {
                KeyValuePair<String, String> selectedEntry = (KeyValuePair<String, String>)((ComboBox)sender).SelectedItem;
                contract.Presentation_Address = selectedEntry.Key;
            }
        }

        private void Presentation_Company_TextChanged(object sender, EventArgs e)
        {
            contract.Presentation_Company = ((TextBox)sender).Text;
        }

        private void Presentation_Level_TextChanged(object sender, EventArgs e)
        {
            contract.Presentation_Building = ((TextBox)sender).Text;
        }

        private void Presentation_Street_TextChanged(object sender, EventArgs e)
        {
            contract.Presentation_Street = ((TextBox)sender).Text;
        }

        private void Presentation_Box_TextChanged(object sender, EventArgs e)
        {
            contract.Presentation_Box = ((TextBox)sender).Text;
        }

        private void Presentation_City_TextChanged(object sender, EventArgs e)
        {
            contract.Presentation_City = ((TextBox)sender).Text;
        }

        private void Evaluation_Other_TextChanged(object sender, EventArgs e)
        {
            contract.Evaluation_Other = ((TextBox)sender).Text;
            Util.ContentControls.setText("Preletting_Period", Evaluation_Other.Text);
        }

        private void PrelettingOther_TextChanged(object sender, EventArgs e)
        {
            contract.PrelettingOther = ((TextBox)sender).Text;
            Util.ContentControls.setText("Preletting_Period", PrelettingOther.Text);
        }

        private void help1_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Allows for tenderers to present their tenders and ask questions.  Tenderers are not allowed to present any new information other than that covered within their tender submission.");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("If no fixed dates, then state “4 weeks from close of tender");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("It is recommended you select yes to enable you to negotiate contract erms and rates, especially if you have select a Quality/Brook's Law tender");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Typically 4-5 weeks after close of tender");
        }
    }
}
