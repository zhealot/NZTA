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
            if (AuditPeriod.Value > 2)
            {
                Util.Help.guidanceNote("Audit period must not be greater than 2 weeks.");
                AuditPeriod.Value = 2;
            }
            else
            {
                contract.AuditPeriod = ((NumericUpDown)sender).Value;
                Util.ContentControls.setText(((NumericUpDown)sender).Name, Util.ContentControls.DecimalToWords(((NumericUpDown)sender).Value) + " week" + (((NumericUpDown)sender).Value > 1 ? "s" : ""));
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void help1_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("At least one TET member must be qualified for tenders >$200,000, but this does not have to be the TET Leader");
        }
    }
}
