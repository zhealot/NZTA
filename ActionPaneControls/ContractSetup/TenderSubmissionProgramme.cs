﻿using System;
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
            gbElecForm.Enabled = false;
            ignoreChange = false;
            NZTA_Contract_Generator.Globals.ThisDocument.rtcPreLettingClause.Range.Font.Hidden = 1;
            NZTA_Contract_Generator.Globals.ThisDocument.rtcPresentationOfTenderClause.Range.Font.Hidden = 1;
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void elecYes_CheckedChanged(object sender, EventArgs e)
        {
            contract.elecYes = ((RadioButton)sender).Checked;
            contract.elecNo = !((RadioButton)sender).Checked;
            gbElecForm.Enabled = ((RadioButton)sender).Checked;
            var rg = Globals.ThisDocument.rtcElectronicInformation.Range;
            rg.Paragraphs.First.Range.set_Style("NZTA Tendering: Level 2");
            rg.SetRange(rg.Start - 1, rg.End + 2);
            rg.Font.Hidden = (elecYes.Checked ? 0 : 1);
            if (anotherMeansYes.Checked)
            {
                anotherMeansYes_CheckedChanged(anotherMeansYes, null);
            }
            else
            {
                anotherMeansNo_CheckedChanged(anotherMeansNo, null);
            }
            NZTA_Contract_Generator.Globals.ThisDocument.DocumentFormatForm.Select();
        }

        private void elecNo_CheckedChanged(object sender, EventArgs e)
        {
            contract.elecNo = ((RadioButton)sender).Checked;
            contract.elecYes = !((RadioButton)sender).Checked;
            gbElecForm.Enabled = !((RadioButton)sender).Checked;
            var rg = Globals.ThisDocument.rtcElectronicInformation.Range;
            rg.Paragraphs.First.Range.set_Style("NZTA Body Text");
            rg.SetRange(rg.Start - 1, rg.End + 2);
            rg.Font.Hidden = (elecNo.Checked ? 1 : 0);
        }

        private void anotherMeansNo_CheckedChanged(object sender, EventArgs e)
        {
            contract.anotherMeansNo = anotherMeansNo.Checked;
            otherDetails.Enabled = !anotherMeansNo.Checked;
            Util.ContentControls.setText("E-Copy", " and accompanied by an electronic copy on email");
        }

        private void anotherMeansYes_CheckedChanged(object sender, EventArgs e)
        {
            contract.anotherMeansYes = anotherMeansYes.Checked;
            contract.anotherMeansNo = anotherMeansNo.Checked;
            otherDetails.Enabled = anotherMeansYes.Checked;
            otherDetails.Focus();
        }
        
        private void otherDetails_Leave(object sender, EventArgs e)
        {
            if ( anotherMeansYes.Checked && string.IsNullOrEmpty(otherDetails.Text))
            {
                Util.Help.guidanceNote("Please enter content.");
                return;
            }
            else
            {
                contract.otherDetails = ((TextBox)sender).Text;
                Util.ContentControls.setText("E-Copy", " and accompanied by an electronic copy on " + contract.otherDetails);
            }            
        }


        private void Evaluation_Start_ValueChanged(object sender, EventArgs e)
        {
            contract.Evaluation_Start = ((DateTimePicker)sender).Value.ToString("O");
            Util.ContentControls.setText("Evaluation_Period", "From " + contract.Evaluation_Start + " to " + contract.Evaluation_End);
        }

        private void Evaluation_End_ValueChanged(object sender, EventArgs e)
        {
            if (Evaluation_End.Value < Evaluation_Start.Value)
            {
                Util.Help.guidanceNote("End date should not be earlier than start date");
                return;
            }
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
            Util.ContentControls.setText(((DateTimePicker)sender).Name, ((DateTimePicker)sender).Value.ToString("dd-MMMM-yyyy"));
        }

        private void Presentations_Changed(object sender, EventArgs e)
        {
            bool PreYes = PresentationsRequired_Yes.Checked;
            contract.PresentationsRequired_No = !PreYes;
            contract.PresentationsRequired_Yes = PreYes;
            var PreRg = Globals.ThisDocument.rtcPresentationOfTenderClause.Range;
            object PreStyle = PreYes ? Globals.ThisDocument.rtcLevel2Style.Range.get_Style() : "Normal";
            PreRg.SetRange(PreRg.Start - 1, PreRg.End + 2);
            PreRg.Paragraphs[1].set_Style(ref PreStyle);
            PreRg.Font.Hidden = PreYes ? 0 : 1;
            if (PreYes) { PreRg.Select(); }
        }

        private void PrelettingMetting_Changed(object sender, EventArgs e)
        {
            bool YesChkd = PrelettingMeetings_Yes.Checked;
            contract.PrelettingMeetings_Yes = YesChkd;
            contract.PrelettingMeetings_No = !YesChkd;
            gbPrelettingDate.Enabled = YesChkd;
            var YesRg = Globals.ThisDocument.rtcPreLettingClause.Range;
            object style = YesChkd ? Globals.ThisDocument.rtcLevel2Style.Range.get_Style() : "Normal";
            YesRg.SetRange(YesRg.Start - 1, YesRg.End + 2);
            YesRg.Paragraphs[1].set_Style(ref style);
            YesRg.Font.Hidden = YesChkd ? 0 : 1;
            if (YesChkd) { YesRg.Select(); }
        }
        private void PrelettingMeetings_No_CheckedChanged(object sender, EventArgs e)
        {
            contract.PrelettingMeetings_No = ((RadioButton)sender).Checked;
            contract.PrelettingMeetings_Yes = !((RadioButton)sender).Checked;
            PrelettingEndDate.Enabled = !((RadioButton)sender).Checked;
            PrelettingFromDate.Enabled = !((RadioButton)sender).Checked;
            NZTA_Contract_Generator.Globals.ThisDocument.rtcPreLettingClause.Range.Font.Hidden = ((RadioButton)sender).Checked ? 1 : 0;
            Util.ContentControls.setText("Preletting_Period", "Not required");
        }
      
        private void PrelettingMeetings_Yes_CheckedChanged(object sender, EventArgs e)
        {
            contract.PrelettingMeetings_Yes = ((RadioButton)sender).Checked;
            contract.PrelettingMeetings_No = !((RadioButton)sender).Checked;
            PrelettingFromDate.Enabled = ((RadioButton)sender).Checked;
            PrelettingEndDate.Enabled = ((RadioButton)sender).Checked;
            NZTA_Contract_Generator.Globals.ThisDocument.rtcPreLettingClause.Range.Font.Hidden = ((RadioButton)sender).Checked ? 0 : 1;
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
            }
        }

        private void Presentation_Company_TextChanged(object sender, EventArgs e)
        {
            contract.Presentation_Company = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void Presentation_Level_TextChanged(object sender, EventArgs e)
        {
            contract.Presentation_Building = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void Presentation_Street_TextChanged(object sender, EventArgs e)
        {
            contract.Presentation_Street = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
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