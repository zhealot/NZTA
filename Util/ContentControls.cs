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

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static string DecimalToWords(decimal number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + DecimalToWords(Math.Abs(number));

            string words = "";

            int intPortion = (int)number;
            decimal fraction = (number - intPortion) * 100;
            int decPortion = (int)fraction;

            words = NumberToWords(intPortion);
            if (decPortion > 0)
            {
                words += " and ";
                words += NumberToWords(decPortion);
            }
            return words;
        }

        public static string StringToCurrency(string amt)
        {
            decimal d;
            if (Decimal.TryParse(amt, out d))
            {
                return d.ToString("C2");
            }
            else
            {
                return null;
            }
        }

        public static bool Validator(string s, Type t)
        {
            if (s == "" || s == null) { return false; }
            if (t.Name == "Int32" || t.Name=="Int16")
            {
                int i;
                if (int.TryParse(s, out i)) { return true; }
            }
            if (t.Name=="Decimal")
            {
                decimal d;
                if (decimal.TryParse(s, out d)) { return true; }
            }            
            return false;
        }

    }

}
