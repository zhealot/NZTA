using System;

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
                cc.Range.Text = text.Replace("\r\n", " ");
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

        public static bool BoldRange(ThisDocument dc, Range rg, string txt, string before)
        {
            if (string.IsNullOrEmpty(txt)) return false;            
            rg.Text = txt;
            object oStart = rg.Start;
            object oEnd = rg.Start + (txt.IndexOf(before) != -1 ? txt.IndexOf(before) : 0);
            var tmp = dc.Range(ref oStart, ref oEnd);
            tmp.Bold = 1;
            return true;
        }

        public static bool IsPercentage(string s)
        {
            Decimal d;
            if (Decimal.TryParse(s, out d) && d >= 0 && d <= 100)
            {
                return true;
            }
            else return false;
        }

        public static bool IsAmount(string s)
        {
            Decimal d;
            if (Decimal.TryParse(s, out d))
            {
                return true;
            }
            else return false;
        }

        public static string IntegerToRoman(int i)
        {
            switch (i)
            {
                case 1: return "I";
                case 2: return "II";
                case 3: return "III";
                case 4: return "IV";
                case 5: return "V";
                case 6: return "VI";
                case 7: return "VII";
                case 8: return "VIII";
                case 9: return "VIIII";
                case 10: return "X";
                default: return i.ToString();
            }
        }
    }


}
