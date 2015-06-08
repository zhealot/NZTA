using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Word; 

namespace NZTA_Contract_Generator.Util
{
    static class ContentControls
    {

        public static void setText(String tag, String text)
        {
            ThisDocument doc = NZTA_Contract_Generator.Globals.ThisDocument;
            Microsoft.Office.Interop.Word.ContentControls ccs = doc.SelectContentControlsByTag(tag);
            foreach (ContentControl cc in ccs)
            {
                cc.Range.Text = text;
            }  
        }

        public static bool IsEmail(string em)
        {
            try
            {
                var foo = new System.Net.Mail.MailAddress(em);
                return foo.Address == em;
            }
            catch
            {
                return false;
            }
        }
    }

}
