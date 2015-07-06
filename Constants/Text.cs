using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZTA_Contract_Generator.Constants
{
    static class Text
    {
        public static Dictionary<string, string> ParagraphText = new Dictionary<string, string>
        {
            {"altTenderNo","As the contract scope has been clearly defined in Section D of this document, no \"Alternative\" Tenders are to be submitted by Tenderers.  If any such \"Alternative Tenders\" are submitted, they will be rejected by the TET and not considered at all."},
            {"altTenderYes", "Alternative Tenders will be considered for this contract.  However Alternative Tenders shall be deemed non-conforming tenders and excluded from further consideration with respect to: "
                            +Environment.NewLine+ "Tenderers submitting an Alternative Tender are required to also submit a non-alternative tender.  Each tender submitted over and above the non-alternative tender will be viewed as an alternative tender."
                            +Environment.NewLine+ "The Alternative Tender is to include sufficient information to allow the TET to evaluate it.  This should include a statement explaining the general nature of the Alternative Tender and detail in what respect it varies the requirements of the tender document.  If there is insufficient information to fully assess the Alternative, the TET will either exclude it from further consideration or assign a value that accounts for the risk to NZTA in accepting the Alternative Tender."
                            +Environment.NewLine+ "A separate Tender Form and Schedule of Prices shall be completed for each Alternative Tender.  Only Alternative Tenders confirmed in writing by the Client prior to the close of tenders will be considered."}
        };

        public static string GetText(string s)
        {
            if (ParagraphText.ContainsKey(s))
            {
                return ParagraphText[s];
            }
            else return null;
        }
    }
}
