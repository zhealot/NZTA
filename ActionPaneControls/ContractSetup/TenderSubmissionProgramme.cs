using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    partial class TenderSubmissionProgramme : UserControl
    {

        Contract contract = Globals.ThisDocument.contract;
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
            Presentation_Address.SelectedIndex = -1;
            gbElecForm.Enabled = false;
            ignoreChange = false;
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void elec_Changed(object sender, EventArgs e)
        {
            bool YesChkd = elecYes.Checked;
            contract.elecNo = !YesChkd;
            contract.elecYes = YesChkd;
            gbElecForm.Enabled = YesChkd;

            Globals.ThisDocument.rtcElectronicInformation.LockContents = false;
            var Rg = Globals.ThisDocument.rtcElectronicInformation.Range;
            object style = YesChkd ? Globals.ThisDocument.rtcLevel2Style.Range.get_Style() : "Normal";
            Rg.Collapse();
            Rg.set_Style(ref style);
            Rg = Globals.ThisDocument.rtcElectronicInformation.Range;
            Rg.SetRange(Rg.Start - 1, Rg.End + 2);
            Rg.Font.Hidden = YesChkd ? 0 : 1;
            if (YesChkd) Rg.Select();
            Globals.ThisDocument.rtcElectronicInformation.LockContents = true;
        }

        private void anotherMeans_Changed(object sender, EventArgs e)
        {
            bool YesChkd = anotherMeansYes.Checked;
            contract.anotherMeansYes = YesChkd;
            contract.anotherMeansNo = !YesChkd;
            contract.otherDetails = otherDetails.Text;
            if (sender is RadioButton )
            {
                if (((RadioButton)sender).Name == "anotherMeansNo")
                {
                    otherDetails.Text = "";
                }
                else if(((RadioButton)sender).Name== "anotherMeansYes" && YesChkd)
                {
                    otherDetails.Focus();
                }
            }
            //if (sender is TextBox && YesChkd)
            //{
            //    if (string.IsNullOrEmpty(otherDetails.Text))
            //    {
            //        Util.Help.guidanceNote("Please enter content for other electronic copies.");
            //    }
            //    else
            //    {
            //        Util.ContentControls.setText("E-Copy", " and " + contract.otherDetails);
            //        contract.otherDetails = otherDetails.Text;
            //        Globals.ThisDocument.rtcECopy.Range.Select();
            //    }
            //}
        }

        private void Evaluation_Date_Changed(object sender, EventArgs e)
        {
            if (Evaluation_Start.Value > Evaluation_End.Value || Evaluation_Start.Value <  DateTime.Today )
            {
                Evaluation_Start.Value = Evaluation_End.Value;
                Util.Help.guidanceNote("Start date should not be later than end date or earlier than today.");
                Globals.ThisDocument.rtcEvaluationPeriod.Range.Select();
            }
            contract.Evaluation_End = sender == Evaluation_End ? Evaluation_End.Value.ToString("O") : contract.Evaluation_End;
            contract.Evaluation_Start = sender == Evaluation_Start ? Evaluation_Start.Value.ToString("O") : contract.Evaluation_Start;
            Util.ContentControls.setText("Evaluation_Period", "From " + Evaluation_Start.Value.ToString(GlobalVar.DateFormat) + " to " + Evaluation_End.Value.ToString(GlobalVar.DateFormat));
        }

        private void Evaluation_Other_TextChanged(object sender, EventArgs e)
        {
            contract.Evaluation_Other = ((TextBox)sender).Text;
            Util.ContentControls.setText("Evaluation_Period", Evaluation_Other.Text);
        }

        private void Preletting_Date_Changed(object sender, EventArgs e)
        {
            if (PrelettingFromDate.Value > PrelettingEndDate.Value || PrelettingFromDate.Value < DateTime.Today)
            {
                PrelettingFromDate.Value = PrelettingEndDate.Value;
                Util.Help.guidanceNote("Start date should not be later than end date or earlier than today.");
                Globals.ThisDocument.rtcPrelettingPeriod.Range.Select();
            }
            contract.PrelettingFromDate = sender == PrelettingFromDate ? PrelettingFromDate.Value.ToString("O") : contract.PrelettingFromDate;
            contract.PrelettingEndDate = sender == PrelettingEndDate ? PrelettingEndDate.Value.ToString("O") : contract.PrelettingEndDate;
            Util.ContentControls.setText("Preletting_Period", "From " + PrelettingFromDate.Value.ToString(GlobalVar.DateFormat) + " to " + PrelettingEndDate.Value.ToString(GlobalVar.DateFormat));
        }

        private void PrelettingOther_TextChanged(object sender, EventArgs e)
        {
            contract.PrelettingOther = ((TextBox)sender).Text;
            Util.ContentControls.setText("Preletting_Period", PrelettingOther.Text);
        }

        private void TargetDate_ValueChanged(object sender, EventArgs e)
        {
            contract.TargetDate = ((DateTimePicker)sender).Value.ToString("O");
            Util.ContentControls.setText(((DateTimePicker)sender).Name, ((DateTimePicker)sender).Value.ToString(GlobalVar.DateFormat));
            Globals.ThisDocument.rtcTargetDate.Range.Select();
        }

        private void Presentations_Changed(object sender, EventArgs e)
        {
            bool PreYes = PresentationsRequired_Yes.Checked;
            contract.PresentationsRequired_No = !PreYes;
            contract.PresentationsRequired_Yes = PreYes;
            Globals.ThisDocument.rtcPresentationOfTenderClause.LockContents = false;
            var PreRg = Globals.ThisDocument.rtcPresentationOfTenderClause.Range;
            object PreStyle = PreYes ? Globals.ThisDocument.rtcLevel2Style.Range.get_Style() : "Normal";
            PreRg.Collapse();
            PreRg.set_Style(ref PreStyle);
            PreRg = Globals.ThisDocument.rtcPresentationOfTenderClause.Range;
            PreRg.SetRange(PreRg.Start - 1, PreRg.End + 2);
            PreRg.Font.Hidden = PreYes ? 0 : 1;
            if (PreYes) { PreRg.Select(); }
            Globals.ThisDocument.rtcPresentationOfTenderClause.LockContents = true;
        }

        private void InterviewCity_TextChanged(object sender, EventArgs e)
        {
            contract.InterviewCity = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            Globals.ThisDocument.rtcInterviewCity.Range.Select();
        }
        private void InterviewNotice_ValueChanged(object sender, EventArgs e)
        {
            contract.InterviewNotice = ((NumericUpDown)sender).Value;
            Util.ContentControls.setText(((NumericUpDown)sender).Name, Util.ContentControls.DecimalToWords(((NumericUpDown)sender).Value) + " week" + (((NumericUpDown)sender).Value > 1 ? "s'" : "'s"));
            Globals.ThisDocument.rtcInterviewNotice.Range.Select();
        }
        private void PrelettingMetting_Changed(object sender, EventArgs e)
        {
            bool YesChkd = PrelettingMeetings_Yes.Checked;
            contract.PrelettingMeetings_Yes = YesChkd;
            contract.PrelettingMeetings_No = !YesChkd;
            gbPrelettingDate.Enabled = YesChkd;
            Globals.ThisDocument.rtcPreLettingClause.LockContents = false;
            var YesRg = Globals.ThisDocument.rtcPreLettingClause.Range;
            object style = YesChkd ? Globals.ThisDocument.rtcLevel2Style.Range.get_Style() : "Normal";
            YesRg.Collapse();
            YesRg.set_Style(ref style);
            YesRg = Globals.ThisDocument.rtcPreLettingClause.Range;
            YesRg.SetRange(YesRg.Start - 1, YesRg.End + 2);
            YesRg.Font.Hidden = YesChkd ? 0 : 1;
            if (YesChkd) { YesRg.Select(); }
            Globals.ThisDocument.rtcPreLettingClause.LockContents = true;
        }
        private void PrelettingMeetings_No_CheckedChanged(object sender, EventArgs e)
        {
            contract.PrelettingMeetings_No = ((RadioButton)sender).Checked;
            contract.PrelettingMeetings_Yes = !((RadioButton)sender).Checked;
            PrelettingEndDate.Enabled = !((RadioButton)sender).Checked;
            PrelettingFromDate.Enabled = !((RadioButton)sender).Checked;
            Globals.ThisDocument.rtcPreLettingClause.Range.Font.Hidden = ((RadioButton)sender).Checked ? 1 : 0;
            Util.ContentControls.setText("Preletting_Period", "Not required");
        }
      
        private void PrelettingMeetings_Yes_CheckedChanged(object sender, EventArgs e)
        {
            contract.PrelettingMeetings_Yes = ((RadioButton)sender).Checked;
            contract.PrelettingMeetings_No = !((RadioButton)sender).Checked;
            PrelettingFromDate.Enabled = ((RadioButton)sender).Checked;
            PrelettingEndDate.Enabled = ((RadioButton)sender).Checked;
            Globals.ThisDocument.rtcPreLettingClause.Range.Font.Hidden = ((RadioButton)sender).Checked ? 0 : 1;
        }

        private void Presentation_Address_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null && !ignoreChange)
            {
                KeyValuePair<String, Util.Address> selectedEntry = (KeyValuePair<String, Util.Address>)((ComboBox)sender).SelectedItem;
                contract.Presentation_Address = selectedEntry.Key;
                contract.Presentation_Company = selectedEntry.Key;
                contract.Presentation_Level = selectedEntry.Value.building;
                contract.Presentation_Street = selectedEntry.Value.streetAddress;
                contract.Presentation_Box = selectedEntry.Value.boxNumber;
                contract.Presentation_City = selectedEntry.Value.city;
                Presentation_Company.Text = selectedEntry.Key;
                Presentation_Level.Text = selectedEntry.Value.building;
                Presentation_Street.Text = selectedEntry.Value.streetAddress;
                Presentation_Box.Text = selectedEntry.Value.boxNumber;
                Presentation_City.Text = selectedEntry.Value.city;
                Util.ContentControls.setText("Presentation_Company", "Transport Agency’s office");
            }
        }

        private void Presentation_Company_TextChanged(object sender, EventArgs e)
        {
            contract.Presentation_Company = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            Globals.ThisDocument.rtcAgencyOrCompany.Range.Select();
        }

        private void Presentation_Level_TextChanged(object sender, EventArgs e)
        {
            contract.Presentation_Building = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            Globals.ThisDocument.rtcPresentationLevel.Range.Select();
        }

        private void Presentation_Street_TextChanged(object sender, EventArgs e)
        {
            contract.Presentation_Street = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            Globals.ThisDocument.rtcPresentationStreet.Range.Select();
        }

        private void Presentation_Box_TextChanged(object sender, EventArgs e)
        {
            contract.Presentation_Box = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void Presentation_City_TextChanged(object sender, EventArgs e)
        {
            contract.Presentation_City = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            Globals.ThisDocument.rtcPresentationCity.Range.Select();
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

        private void otherDetails_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(otherDetails.Text) && anotherMeansYes.Checked)
            {
                //MessageBox.Show("please");
                //if (otherDetails.Focused) return;
                otherDetails.Focus();
                e.Cancel = true;
            }
            else {
                contract.otherDetails = otherDetails.Text;
            }
        }
    }
}