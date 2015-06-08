using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.Util
{
    static class SavedState
    {

        public static void setControlsToState(Contract con, Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is GroupBox)
                {
                    setControlsToState(con, c.Controls);
                }
                else if (c is TextBox && con[c.Name] != null)
                {
                    c.Text = (String)con[c.Name];
                }
                else if (c is ComboBox && con[c.Name] != null)
                {
                    try
                    {
                        ((ComboBox)c).SelectedValue = Constants.Location.data[((String)con[c.Name])];
                    }
                    catch (KeyNotFoundException) { }
                }
                else if (c is RadioButton && con[c.Name] != null)
                {
                    ((RadioButton)c).Checked = (bool)con[c.Name];
                }
                else if (c is DateTimePicker && con[c.Name] != null)
                {
                    ((DateTimePicker)c).Value = DateTime.ParseExact((String)con[c.Name], "O", CultureInfo.InvariantCulture);
                }
                else if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = (Boolean)con[c.Name];
                }
            }
        }
    }
}
