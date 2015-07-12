using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.SupplierSelectionMethod
{
    public partial class NonPriceAttributes : UserControl
    {
        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;        
        public NonPriceAttributes()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            //###Util.SavedState.setControlsToState(contract, Controls);
        }

        private void cbMeth1_CheckedChanged(object sender, EventArgs e)
        {
            var rg = NZTA_Contract_Generator.Globals.ThisDocument;
            

        }

        private void GuidanceNote_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void RelevantExperience_ValueChanged(object sender, EventArgs e)
        {
            contract.RelevantExperience = ((NumericUpDown)sender).Value.ToString();
            Util.ContentControls.setText(((NumericUpDown)sender).Name, ((NumericUpDown)sender).Value.ToString());
        }

        private void TrackRecord_ValueChanged(object sender, EventArgs e)
        {
            contract.TrackRecord = ((NumericUpDown)sender).Value.ToString();
            Util.ContentControls.setText(((NumericUpDown)sender).Name, ((NumericUpDown)sender).Value.ToString());
        }

        private void ExperienceVSRecord_ValueChanged(object sender, EventArgs e)
        {
            contract.ExperienceVSRecord = ((NumericUpDown)sender).Value.ToString();
            Util.ContentControls.setText(((NumericUpDown)sender).Name, ((NumericUpDown)sender).Value.ToString());
        }
    }
}
