using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZTA_Contract_Generator
{
    public class Contract
    {

        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
        }

        //Contructor use to set defaults
        public Contract()
        {
            //Contract Details
            geoNo = true;
            numDays = "eight";
            numHours = "48";

            //Interactive Tender Process
            Interactive_No = true;
        }

        //Start of Contract Details

        public String Contract_Name { get; set; }
        public String Contract_Number { get; set; }
        
        public string Consultant_Name { get; set; }
        public string Consultant_Address { get; set; }
        public string Set_No{ get; set; }
        public string MadeDate{ get; set; }


        public String PM_Name { get; set; }
        public String PM_Title { get; set; }

        public String Address_1 { get; set; }
        public String Company_Name_1 { get; set; }
        public String Level_1 { get; set; }
        public String Street_1 { get; set; }
        public String Box_1 { get; set; }
        public String City_1 { get; set; }
        public String Telephone_1 { get; set; }
        public String Fax_1 { get; set; }
        public String Email_1 { get; set; }

        public String Region { get; set; }

        public Boolean geoYes { get; set; }
        public Boolean geoNo { get; set; }
        public Boolean provisionalSum { get; set; }
        public Boolean scheduledItems { get; set; }

        public Boolean clientSiteYes { get; set; }
        public Boolean clientSiteNo { get; set; }

        public Boolean altTenderYes { get; set; }
        public Boolean altTenderNo { get; set; }

        public String TenderBox { get; set; }

        public String Nominated_Person { get; set; }
        public String Nominated_Phone { get; set; }
        public String Nominated_Email { get; set; }

        public String Address_2 { get; set; }
        public String Company_Name_2 { get; set; }
        public String Level_2 { get; set; }
        public String Street_2 { get; set; }
        public String Box_2 { get; set; }
        public String City_2 { get; set; }

        public String numDays { get; set; }
        public String numHours { get; set; }

        public Boolean elecYes { get; set; }
        public Boolean elecNo { get; set; }
        public Boolean anotherMeansYes { get; set; }
        public Boolean anotherMeansNo { get; set; }
        public String otherDetails { get; set; }
        public Boolean isPersonDifferentYes { get; set; }
        public Boolean isPersonDifferentNo { get; set; }
        public String Different_Name { get; set; }
        public String Different_Email { get; set; }

        // End of Contract Details

        //Start of Interactive tender Process

        public Boolean Interactive_No { get; set; }
        public Boolean Interactive_Yes { get; set; }

        public Boolean Combined_Check { get; set; }
        public String Combined_Date { get; set; }
        public String Combined_Time { get; set; }
        public String Combined_Place { get; set; }

        public Boolean Individual1_Check { get; set; }
        public String Individual1_Date { get; set; }

        public Boolean Individual2_Check { get; set; }
        public String Individual2_Date { get; set; }

        public Boolean Individual3_Check { get; set; }
        public String Individual3_Date { get; set; }

        public Boolean Individual4_Check { get; set; }
        public String Individual4_Date { get; set; }

        public Boolean Individual5_Check { get; set; }
        public String Individual5_Date { get; set; }

        public String Individual_Place { get; set; }

        //End of Interactive tender process

        //Start of pricing options

        public Boolean BaseEstimate_Check { get; set; }
        public String BaseEstimate_Amount { get; set; }
        public String ProvisionalSumAmount { get; set; }
        public Boolean BrooksLaw_Check { get; set; }
        public Boolean RatesOnly_Check  { get; set; }
        public Boolean TargetPrice_Check { get; set; }
        public String TargetPriceAmount { get; set; }
        public String TargetPriceAmountInWords { get; set; }

        //End of pricing options

        //Start of tender submission programme

        public String CloseDate { get; set; }
        public Boolean PresentationsRequired_Yes { get; set; }
        public Boolean PresentationsRequired_No { get; set; }

        public String Presentation_Address { get; set; }
        public String Presentation_Company { get; set; }
        public String Presentation_Building { get; set; }
        public String Presentation_Level { get; set; }
        public String Presentation_Street { get; set; }
        public String Presentation_Box { get; set; }
        public String Presentation_City { get; set; }

        public String Evaluation_Start { get; set; }
        public String Evaluation_End { get; set; }
        public String Evaluation_Other { get; set; }

        public Boolean PrelettingMeetings_Yes { get; set; }
        public Boolean PrelettingMeetings_No { get; set; }
        public String PrelettingFromDate { get; set; }
        public String PrelettingEndDate { get; set; }
        public String PrelettingOther { get; set; }

        public String TargetDate { get; set; }

        //End of tender submission programme

    }
}
