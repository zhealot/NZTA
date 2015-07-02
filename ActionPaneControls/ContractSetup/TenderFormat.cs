using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    public partial class TenderFormat : UserControl
    {
        public TenderFormat()
        {
            InitializeComponent();
        }

        private void CopyOfEnvelope_ValueChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText("CopyOfEnvelope", Util.ContentControls.DecimalToWords(CopyOfEnvelope.Value));
        }
    }
}