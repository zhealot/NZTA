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
            //###Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void EvaluationTeamLeader_TextChanged(object sender, EventArgs e)
        {
            contract.EvaluationTeamLeader = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ETL_Position_TextChanged(object sender, EventArgs e)
        {
            contract.ETL_Position = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ETL_Company_TextChanged(object sender, EventArgs e)
        {
            contract.ETL_Company = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET2_Name_TextChanged(object sender, EventArgs e)
        {
            contract.ET2_Name = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET2_Position_TextChanged(object sender, EventArgs e)
        {
            contract.ET2_Position = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET2_Company_TextChanged(object sender, EventArgs e)
        {
            contract.ET2_Company = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET3_Name_TextChanged(object sender, EventArgs e)
        {
            contract.ET3_Name = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET3_Position_TextChanged(object sender, EventArgs e)
        {
            contract.ET3_Position = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET3_Company_TextChanged(object sender, EventArgs e)
        {
            contract.ET3_Company = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET4_Name_TextChanged(object sender, EventArgs e)
        {
            contract.ET4_Name = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET4_Position_TextChanged(object sender, EventArgs e)
        {
            contract.ET4_Position = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET4_Company_TextChanged(object sender, EventArgs e)
        {
            contract.ET4_Company = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET5_Name_TextChanged(object sender, EventArgs e)
        {
            contract.ET5_Name = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET5_Position_TextChanged(object sender, EventArgs e)
        {
            contract.ET5_Position = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET5_Company_TextChanged(object sender, EventArgs e)
        {
            contract.ET5_Company = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void Audit_Period_ValueChanged(object sender, EventArgs e)
        {
            contract.AuditPeriod = ((NumericUpDown)sender).Value;
            Util.ContentControls.setText(((NumericUpDown)sender).Name, ((NumericUpDown)sender).Value.ToString());
        }

        private void InterviewCity_TextChanged(object sender, EventArgs e)
        {
            contract.InterviewCity = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }
        private void InterviewNotice_ValueChanged(object sender, EventArgs e)
        {
            contract.InterviewNotice = ((NumericUpDown)sender).Value;
            Util.ContentControls.setText(((NumericUpDown)sender).Name, ((NumericUpDown)sender).Value.ToString());
        }
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void help1_Click(object sender, EventArgs e)
        {

        }
    }
}
