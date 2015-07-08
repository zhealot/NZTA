using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    partial class TenderEvaluationProcedure : UserControl
    {
        public TenderEvaluationProcedure()
        {
            InitializeComponent();
        }

        private void EvaluationTeamLeader_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ETL_Position_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ETL_Company_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET2_Name_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET2_Position_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET2_Company_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET3_Name_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET3_Position_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET3_Company_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET4_Name_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET4_Position_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET4_Company_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET5_Name_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET5_Position_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void ET5_Company_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void InterView_City_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void InterView_Notice_ValueChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }
    }
}
