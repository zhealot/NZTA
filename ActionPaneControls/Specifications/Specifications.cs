using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.Specifications
{
    public partial class Specifications : UserControl
    {
        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;
        public Specifications()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void ContractManagemnet_CheckedChanged(object sender, EventArgs e)
        {
            contract.ContractManagemnet = ((CheckBox)sender).Checked;
        }

        private void InvestigationReporting_CheckedChanged(object sender, EventArgs e)
        {
            contract.InvestigationReporting = ((CheckBox)sender).Checked;
        }

        private void DesignProject_CheckedChanged(object sender, EventArgs e)
        {
            contract.DesignProject = ((CheckBox)sender).Checked;
        }

        private void DesignConstruct_CheckedChanged(object sender, EventArgs e)
        {
            contract.DesignConstruct = ((CheckBox)sender).Checked;
        }

        private void MSQA_CheckedChanged(object sender, EventArgs e)
        {
            contract.MSQA = ((CheckBox)sender).Checked;
        }

        private void NetworkMangement_CheckedChanged(object sender, EventArgs e)
        {
            contract.NetworkMangement = ((CheckBox)sender).Checked;
        }

        private void HybridContract_CheckedChanged(object sender, EventArgs e)
        {
            contract.HybridContract = ((CheckBox)sender).Checked;
        }

        private void BridgesOther_CheckedChanged(object sender, EventArgs e)
        {
            contract.BridgesOther = ((CheckBox)sender).Checked;
        }

        private void MultipleProjects_No_CheckedChanged(object sender, EventArgs e)
        {
            contract.MultipleProjects_No = ((RadioButton)sender).Checked;
        }

        private void MultipleProjects_Yes_CheckedChanged(object sender, EventArgs e)
        {
            contract.MultipleProjects_Yes = ((RadioButton)sender).Checked;
        }

        private void Project1_TextChanged(object sender, EventArgs e)
        {
            contract.Project1 = ((TextBox)sender).Text;
        }
    }
}
