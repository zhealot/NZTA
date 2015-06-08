using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.Util
{
    static class Help
    {

        public static void guidanceNote(String text)
        {
            MessageBox.Show(text, "Guidance Note", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

    }
}
