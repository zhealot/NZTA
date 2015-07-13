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
        }

        private void CostIndex_TextChanged(object sender, EventArgs e)
        {
            Decimal d;
            if (Decimal.TryParse(((TextBox)sender).Text, out d))
            {
                contract.CostIndex = d.ToString("0.00");
                Util.ContentControls.setText("CostIndex1", contract.CostIndex);
                Util.ContentControls.setText("CostIndex2", (1 - d).ToString("0.00"));
            }
            else
            {
                Util.Help.guidanceNote("Please enter 1 digit decimal");
            }            
        }

        private void ConsultantsProjectQualityPlan_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.ConsultantsProjectQualityPlan = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }  
        }

        private void BaselineProgrramme_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.BaselineProgrramme = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }  
        }

        private void HealthSafetyManagementPlan_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.HealthSafetyManagementPlan = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }  
        }

        private void CommunityEngagementPlan_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.CommunityEngagementPlan = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }
        }

        private void ActivityRisk_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.ActivityRisk = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }
        }
        
        private void ProgrammeBusinessCase_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.ProgrammeBusinessCase = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }
        }

        private void TransportTrafficModel_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.ProgrammeBusinessCase = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }
        }

        private void IndicativeBusinessCase_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.ProgrammeBusinessCase = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }
        }

        private void TransportTrafficModel2_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.TransportTrafficModel2 = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }
        }

        private void DetailedBusinessCase_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.DetailedBusinessCase = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }
        }

        private void AssessmentReport_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.AssessmentReport = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }
        }

        private void GeotechnicalInterpretiveReport_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.GeotechnicalInterpretiveReport = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }
        }

        private void General_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.General = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }
        }

        private void AssetOwnersManual_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.AssetOwnersManual = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }
        }

        private void PropertyRequirements_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsPercentage(((TextBox)sender).Text))
            {
                contract.PropertyRequirements = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else
            {
                Util.Help.guidanceNote("Please enter a number for percentage");
            }
        }
    }
}
