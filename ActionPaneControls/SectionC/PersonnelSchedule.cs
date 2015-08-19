using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.SectionC
{
    public partial class PersonnelSchedule : UserControl
    {
        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;
        public PersonnelSchedule()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void TeamLeaderProjectDirector_TextChanged(object sender, EventArgs e)
        {

        }

        private void TeamLeaderProjectDirectorPhone_TextChanged(object sender, EventArgs e)
        {
            //### Personal Schedule talbe (page 62)
        }
    }
}
