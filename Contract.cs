﻿using System;
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
        
        public String Consultant_Name { get; set; }
        public String Consultant_Address { get; set; }
        public String Set_No{ get; set; }
        public String MadeDate{ get; set; }


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
        public String Telephone_2 { get; set; }
        public String Fax_2 { get; set; }
        public String Email_2 { get; set; }

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

        //Start of Tender Format programme
        public String CopyOfEnvelope { get; set; }
        public String CoverLetter_Page { get; set; }
        public String Index_Page { get; set; }
        public String NonPrice_Page { get; set; }
        public String Personnel_Page { get; set; }
        public String Outline_Page { get; set; }
        public String Project_Page { get; set; }
        public String CV_Page { get; set; }
        public String TimeResource_Page { get; set; }
        public String Docu1_Page { get; set; }
        public String Docu1 { get; set; }        

        public Boolean TimeResource_Check { get; set; }
        public Boolean Outline_Check { get; set; }
        public Boolean Project_Check { get; set; }
        public Boolean CV_Check { get; set; }
        public Boolean Index_A3_Check { get; set; }
        public Boolean Index_Double_Check { get; set; }
        public Boolean NonPrice_A3_Check { get; set; }
        public Boolean NonPrice_Double_Check { get; set; }
        public Boolean Outline_A3_Check { get; set; }
        public Boolean Outline_Double_Check { get; set; }
        public Boolean Project_A3_Check { get; set; }
        public Boolean CV_A3_Check { get; set; }
        public Boolean TimeResource_A3_Check { get; set; }
        public Boolean Docu1_Check { get; set; }
        public Boolean Docu1_A3_Check { get; set; }
        public Boolean Docu1_Double_Check { get; set; }        
        //End of Tender Format programme

        //Start of Non Price Attributes
        public String RelevantExperience { get; set; }
        public String TrackRecord { get; set; }
        public String ExperienceVSRecord { get; set; }
        public String GuidanceNote { get; set; }
        public String tbShow { get; set; }
        public Boolean cbMeth1 { get; set; }
        public String tbPercent { get; set; }

        //End of Non Price Attributes

        //Start of Supplier Selection Methods
        public Boolean rbPQM { get; set; }
        public Boolean rbPQMPDA { get; set; }
        public Boolean rbLPC { get; set; }
        public Boolean rbTP { get; set; }
        public Boolean rbBLO { get; set; }

        public Boolean rbRE_P { get; set; }
        public Boolean rbRE_F { get; set; }
        public Boolean rbTR_P { get; set; }
        public Boolean rbTR_F { get; set; }
        public Boolean rbRS_P { get; set; }
        public Boolean rbRS_F { get; set; }
        public Boolean rbM_P { get; set; }
        public Boolean rbM_F{ get; set; }
        public Boolean cbTrackRecord { get; set; }

        public String tbRE { get; set; }
        public String tbTR { get; set; }
        public String tbRS { get; set; }
        public String tbM { get; set; }
        public String tbP { get; set; }
        //End of Supplier Selection Methods

        //Start of Tender Evaluation Procedure
        public String EvaluationTeamLeader { get; set; }
        public String ETL_Position { get; set; }
        public String ETL_Company { get; set; }
        public String ET2_Name { get; set; }
        public String ET2_Position { get; set; }
        public String ET2_Company { get; set; }
        public String ET3_Name { get; set; }
        public String ET3_Position { get; set; }
        public String ET3_Company { get; set; }
        public String ET4_Name { get; set; }
        public String ET4_Position { get; set; }
        public String ET4_Company { get; set; }
        public String ET5_Name { get; set; }
        public String ET5_Position { get; set; }
        public String ET5_Company { get; set; }
        public String Audit_Period { get; set; }
        public String InterviewCity { get; set; }
        public String InterviewNotice { get; set; }
        //End of Tender Evaluation Procedure

        //Start of Payment Schedule
        public String CostIndex { get; set; }
        public String ConsultantsProjectQualityPlan { get; set; }
        public String BaselineProgrramme { get; set; }
        public String HealthSafetyManagementPlan { get; set; }
        public String CommunityEngagementPlan { get; set; }
        public String ActivityRisk { get; set; }
        public String ProgrammeBusinessCase { get; set; }
        public String TransportTrafficModel { get; set; }
        public String IndicativeBusinessCase { get; set; }
        public String TransportTrafficModel2 { get; set; }
        public String DetailedBusinessCase { get; set; }
        public String AssessmentReport { get; set; }
        public String GeotechnicalInterpretiveReport { get; set; }
        public String General { get; set; }
        public String AssetOwnersManual { get; set; }
        public String PropertyRequirements { get; set; }
        //End of Payment Schedule

        //Start of PublicLiabilityInsurance
        public String PublicLiabilityInsurance { get; set; }
        public String MaximumLiability { get; set; }
        public String DurationOfLiability { get; set; }
        public Boolean rbNotRequired { get; set; }
        public Boolean rbApprovedDefault { get; set; }
        public Boolean rbOtherLevels { get; set; }
        //End of PublicLiabilityInsurance

        //Start of Personnel
        public String tbWeighting { get; set; }
        //End of Personnel

        //Start of Contract Pricing
        public String CP_Total { get; set; }

        //End of Contract Pricing
    }
}
