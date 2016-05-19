using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    partial class ContractDetails : UserControl
    {

        Contract contract = Globals.ThisDocument.contract;
        bool ignoreChange = false;

        public ContractDetails()
        {
            InitializeComponent();

            //display build date
            System.Reflection.Assembly asbly = System.Reflection.Assembly.GetCallingAssembly();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(asbly.Location);
            DateTime lastModified = fileInfo.LastWriteTime;
            lblBuiltDate.Text = "Built: " + lastModified.ToShortDateString() + ", " + lastModified.ToShortTimeString();

            //Load any data
            ignoreChange = true;            
            //Address combobox
            Address_1.DataSource = new BindingSource(Constants.Location.data, null);
            Address_1.DisplayMember = "Key";
            Address_1.ValueMember = "Value";
            Address_1.SelectedIndex = -1;
           
            //Region combobox
            //Region.DataSource = new BindingSource(Constants.Location.data, null);
            //Region.DisplayMember = "Key";
            //Region.ValueMember = "Value";
            //Region.SelectedIndex = -1;

            //Tender box
            TenderBox.DataSource = new BindingSource(Constants.Location.data, null);
            TenderBox.DisplayMember = "Key";
            TenderBox.ValueMember = "Value";
            TenderBox.SelectedIndex = -1;

            //Address 2 combobox
            Address_2.DataSource = new BindingSource(Constants.Location.data, null);
            Address_2.DisplayMember = "Key";
            Address_2.ValueMember = "Value";
            Address_2.SelectedIndex = -1;
            ignoreChange = false;

            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
        }
        public string ContractName { get { return Contract_Name.Text; } set { Contract_Name.Text = value; } }        
        private void Contract_Name_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            contract.Contract_Name = ((TextBox)sender).Text;
        }

        private void Contract_Number_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            contract.Contract_Number = ((TextBox)sender).Text;
        }

        private void help1_Click(object sender, EventArgs me)
        {
            Util.Help.guidanceNote("The full physical address will show in the document when this selection is made.");
        }

        private void Address_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null && !ignoreChange)
            {
                KeyValuePair<String, Util.Address> selectedEntry = (KeyValuePair<String, Util.Address>)((ComboBox)sender).SelectedItem;
                contract.Address_1 = selectedEntry.Key;
                contract.Company_Name_1 = selectedEntry.Key;
                contract.Level_1 = selectedEntry.Value.building;
                contract.Street_1 = selectedEntry.Value.streetAddress;
                contract.Box_1 = selectedEntry.Value.boxNumber;
                contract.City_1 = selectedEntry.Value.city;
                contract.Telephone_1 = selectedEntry.Value.telephone;
                contract.Fax_1 = selectedEntry.Value.fax;

                Company_Name_1.Text = selectedEntry.Key;
                Level_1.Text = selectedEntry.Value.building;
                Street_1.Text = selectedEntry.Value.streetAddress;
                Box_1.Text = selectedEntry.Value.boxNumber;
                City_1.Text = selectedEntry.Value.city;
                Telephone_1.Text = selectedEntry.Value.telephone;
                Fax_1.Text = selectedEntry.Value.fax;
                Globals.ThisDocument.rtcAddress1.Range.Select();
            }
        }

        private void geo_Changed(object sender, EventArgs e)
        {
            bool YesChkd = geoYes.Checked;
            bool PSChkd = provisionalSum.Checked;
            contract.geoYes = YesChkd;
            contract.geoNo = !YesChkd;
            contract.provisionalSum = PSChkd;
            contract.scheduledItems = !PSChkd;
            gbGeo.Enabled = YesChkd;
            var GeoRg = Globals.ThisDocument.rtcGeotechnicalSection.Range;
            var PSRg = Globals.ThisDocument.rtcGeotechProvisionalSum.Range;
            var SRg = Globals.ThisDocument.rtcGeotechScheduledItems.Range;
            Util.ContentControls.RangeHideShow(ref GeoRg, YesChkd);
            Util.ContentControls.RangeHideShow(ref PSRg, (YesChkd && PSChkd));
            Util.ContentControls.RangeHideShow(ref SRg, (YesChkd && !PSChkd));
            Globals.ThisDocument.rtcGeoTS372.Range.Font.Hidden = YesChkd ? 0 : 1;
            //GeoRg.SetRange(GeoRg.Start - 1, GeoRg.End + 2);
            //PSRg.SetRange(PSRg.Start - 1, PSRg.End + 2);
            //SRg.SetRange(SRg.Start - 1, SRg.End + 2);
            //GeoRg.Font.Hidden = YesChkd ? 0 : 1;
            //PSRg.Font.Hidden = (YesChkd && PSChkd) ? 0 : 1;
            //SRg.Font.Hidden = (YesChkd && !PSChkd) ? 0 : 1;
            GeoRg.Select();
        }

        private void help2_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Alternative tenders are not normally used as it can create considerable work in evaluating tenders and can be used to manipulate the tender process as opposed to adding value.  Innovated ideas can still be discussed with the preferred tenderer at a later date.");
        }

        private void Nominated_Person_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            contract.Nominated_Person = ((TextBox)sender).Text;
            object here = Globals.ThisDocument.SelectContentControlsByTag(((TextBox)sender).Name)[1].Range;
            Globals.ThisDocument.Application.Selection.GoTo(Microsoft.Office.Interop.Word.WdGoToItem.wdGoToObject, Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToFirst, 1, ref here);
            Globals.ThisDocument.rtcNominatedPerson.Range.Select();
        }

        private void Nominated_Email_TextChanged(object sender, EventArgs e)
        {
            contract.Nominated_Email = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void PM_Name_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            contract.PM_Name = ((TextBox)sender).Text;
        }

        private void PM_Title_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            contract.PM_Title = ((TextBox)sender).Text;
        }

        private void Company_Name_1_TextChanged(object sender, EventArgs e)
        {
            contract.Company_Name_1 = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void Level_1_TextChanged(object sender, EventArgs e)
        {
            contract.Level_1 = ((TextBox)sender).Text;
            Util.ContentControls.setText("Address_1", Level_1.Text + " " + Street_1.Text);
        }

        private void Street_1_TextChanged(object sender, EventArgs e)
        {
            contract.Street_1 = ((TextBox)sender).Text;
            Util.ContentControls.setText("Address_1", Level_1.Text + " " + Street_1.Text);
        }

        private void Box_1_TextChanged(object sender, EventArgs e)
        {
            contract.Box_1 = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void City_1_TextChanged(object sender, EventArgs e)
        {
            contract.City_1 = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void Telephone_1_TextChanged(object sender, EventArgs e)
        {
            contract.Telephone_1 = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void Fax_1_TextChanged(object sender, EventArgs e)
        {
            contract.Fax_1 = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null && !ignoreChange)
            {
                KeyValuePair<String, Util.Address> selectedEntry = (KeyValuePair<String, Util.Address>)((ComboBox)sender).SelectedItem;
                contract.Region = selectedEntry.Key;
            }
        }

        //private void provisionalSum_CheckedChanged(object sender, EventArgs e)
        //{
        //    contract.provisionalSum = ((RadioButton)sender).Checked;
        //    contract.scheduledItems = !((RadioButton)sender).Checked;
        //    var rg = Globals.ThisDocument.rtcGeotechProvisionalSum.Range;
        //    rg.SetRange(rg.Start - 1, rg.End + 2);
        //    rg.Font.Hidden = ((RadioButton)sender).Checked ? 0 : 1;
        //}

        //private void scheduledItems_CheckedChanged(object sender, EventArgs e)
        //{
        //    contract.provisionalSum = !((RadioButton)sender).Checked;
        //    contract.scheduledItems = ((RadioButton)sender).Checked;
        //    var rg = Globals.ThisDocument.rtcGeotechScheduledItems.Range;
        //    rg.SetRange(rg.Start - 1, rg.End + 2);
        //    rg.Font.Hidden = ((RadioButton)sender).Checked ? 0 : 1;
        //}

        private void SiteInspection_Changed(object sender, EventArgs e)
        {
            bool SiteYesChkd = clientSiteYes.Checked;
            contract.clientSiteNo = !SiteYesChkd;
            contract.clientSiteYes = SiteYesChkd;
            Globals.ThisDocument.rtcSiteInspection.LockContents = false;
            var SiteRg = Globals.ThisDocument.rtcSiteInspection.Range;
            object SiteStyle = SiteYesChkd ? Globals.ThisDocument.rtcLevel2Style.Range.get_Style() : "Normal";
            SiteRg.Collapse();
            SiteRg.set_Style(ref SiteStyle);
            SiteRg = Globals.ThisDocument.rtcSiteInspection.Range;
            SiteRg.SetRange(SiteRg.Start - 1, SiteRg.End + 2);
            SiteRg.Font.Hidden = SiteYesChkd ? 0 : 1;
            if (SiteYesChkd) { SiteRg.Select(); }
            Globals.ThisDocument.rtcSiteInspection.LockContents = true;
        }

        private void altTender_Changed(object sender, EventArgs e)
        {
            bool blYes = altTenderYes.Checked;
            contract.altTenderYes = blYes;
            contract.altTenderNo = !blYes;
            Globals.ThisDocument.rtcAlternativeTenderNo.LockContents = false;
            Globals.ThisDocument.rtcAlternativeTenderYes.LockContents = false;
            var altYesRg = Globals.ThisDocument.rtcAlternativeTenderYes.Range;
            var altNoRg = Globals.ThisDocument.rtcAlternativeTenderNo.Range;
            var stl = blYes ? "Normal" : altYesRg.Paragraphs.First.get_Style();
            altNoRg.set_Style(ref stl);
            altYesRg.SetRange(altYesRg.Start - 1, altYesRg.End + 2);
            altNoRg.SetRange(altNoRg.Start - 1, altNoRg.End + 2);
            altNoRg.Font.Hidden = blYes ? 1 : 0;
            altYesRg.Font.Hidden = blYes ? 0 : 1;
            if (blYes) { altYesRg.Select(); }
            Globals.ThisDocument.rtcAlternativeTenderNo.LockContents = true;
            Globals.ThisDocument.rtcAlternativeTenderYes.LockContents = true;
        }

        private void TenderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null && !ignoreChange)
            {
                KeyValuePair<String, Util.Address> selectedEntry = (KeyValuePair<String, Util.Address>)((ComboBox)sender).SelectedItem;
                contract.TenderBox = selectedEntry.Key;
                Util.ContentControls.setText(((ComboBox)sender).Name, selectedEntry.Value.building + ", " + selectedEntry.Value.streetAddress + ", " + selectedEntry.Value.city);
                Globals.ThisDocument.rtcTenderBox.Range.Select();
            }
        }

        private void Nominated_Phone_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, (((TextBox)sender).Text));
            contract.Nominated_Phone = ((TextBox)sender).Text;
        }

        private void Address_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null && !ignoreChange)
            {
                KeyValuePair<string, Util.Address> selectedEntry = (KeyValuePair<string, Util.Address>)Address_2.SelectedItem;
                contract.Address_2 = selectedEntry.Key;
                contract.Company_Name_2 = selectedEntry.Key;
                contract.Level_2 = selectedEntry.Value.building;
                contract.Street_2 = selectedEntry.Value.streetAddress;
                contract.Box_1 = selectedEntry.Value.boxNumber;
                contract.City_2 = selectedEntry.Value.city;
                contract.Telephone_2 = selectedEntry.Value.telephone;
                contract.Fax_2 = selectedEntry.Value.fax;

                Company_Name_2.Text = selectedEntry.Key;
                Level_2.Text = selectedEntry.Value.building;
                Street_2.Text = selectedEntry.Value.streetAddress;
                Box_2.Text = selectedEntry.Value.boxNumber;
                City_2.Text = selectedEntry.Value.city;
                
                Util.ContentControls.setText("NZTA_Or_Company", "NZTA " + selectedEntry.Key);
                Util.ContentControls.setText("Address_2", selectedEntry.Value.building + " " + selectedEntry.Value.streetAddress);
                Util.ContentControls.setText("Box_2", selectedEntry.Value.boxNumber);
                Util.ContentControls.setText("City_2", selectedEntry.Value.city);
            }
        }

        private void Company_Name_2_TextChanged(object sender, EventArgs e)
        {
            contract.Company_Name_2 = ((TextBox)sender).Text;
            Util.ContentControls.setText("NZTA_Or_Company", Company_Name_2.Text);
        }

        private void Level_2_TextChanged(object sender, EventArgs e)
        {
            contract.Level_2 = ((TextBox)sender).Text;
            Util.ContentControls.setText("Address_2", Level_2.Text + " " + Street_2.Text);
        }

        private void Street_2_TextChanged(object sender, EventArgs e)
        {
            contract.Street_2 = ((TextBox)sender).Text;
            Util.ContentControls.setText("Address_2", Level_2.Text + " " + Street_2.Text);
        }

        private void Box_2_TextChanged(object sender, EventArgs e)
        {
            contract.Box_2 = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void City_2_TextChanged(object sender, EventArgs e)
        {
            contract.City_2 = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }        

        private void Nominated_Email_Leave(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsEmail(((TextBox)sender).Text))
            {
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
                contract.Nominated_Email = ((TextBox)sender).Text;
            }
            else
                Util.Help.guidanceNote("Invalid Email address");
        }

        private void ContractDetails_Load(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void MadeDate_ValueChanged(object sender, EventArgs e)
        {
            contract.MadeDate = ((DateTimePicker)sender).Value.ToString("O");
            if (MadeDate.Value != null && !ignoreChange)
            {
                Util.ContentControls.setText("Date_Day", MadeDate.Value.Day.ToString());
                Util.ContentControls.setText("Date_Month", MadeDate.Value.ToString("MMMM"));
                Util.ContentControls.setText("Date_Year", MadeDate.Value.Year.ToString());
                Globals.ThisDocument.rtcContractDate.Range.Select();
            }
            
        }

        private void Consultant_Name_TextChanged(object sender, EventArgs e)
        {
            contract.Consultant_Name = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void Consultant_Address_TextChanged(object sender, EventArgs e)
        {
            contract.Consultant_Address = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void Set_No_TextChanged(object sender, EventArgs e)
        {
            contract.Set_No = ((TextBox)sender).Text; ;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void CloseDate_ValueChanged(object sender, EventArgs e)
        {
            contract.CloseDate = CloseDate.Value.ToString("O");
            Util.ContentControls.setText("CloseDate", CloseDate.Value.ToString(GlobalVar.DateFormat));
            Globals.ThisDocument.rtcCloseDate.Range.Select();
        }

        private void Email_1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Util.ContentControls.IsEmail(Email_1.Text))
            {
                MessageBox.Show("wrong email address");
                Email_1.Focus();
            }
            else
            {
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
                contract.Email_1 = ((TextBox)sender).Text;             
            }
        }


        //private void StatementOfInterestAbilityClose_Chk_CheckedChanged(object sender, EventArgs e)
        //{
        //    bool chkd = StatementOfInterestAbilityClose_Chk.Checked;
        //    contract.StatementOfInterestAbilityClose_Chk = chkd;
        //    var style = chkd ? Globals.ThisDocument.rtcLevel3Style.Range.get_Style() : "Normal";
        //    var rg = Globals.ThisDocument.rtcStatementOfInterestAbilityClose.Range;
        //    rg.set_Style(ref style);
        //    rg.SetRange(rg.Start - 1, rg.End + 2);
        //    rg.Font.Hidden = chkd ? 0 : 1;
        //    rg = Globals.ThisDocument.rtcStatementOfInterestAbilityCloseTitle.Range;
        //    rg.SetRange(rg.Start - 1, rg.End + 2);
        //    rg.Font.Hidden = chkd ? 0 : 1;
        //}

        private void numDays_ValueChanged(object sender, EventArgs e)
        {
            contract.numDays = numDays.Value;
            Util.ContentControls.setText(numDays.Name, numDays.Value.ToString() + " (" + Util.ContentControls.NumberToWords((int)numDays.Value) + ")");
            Globals.ThisDocument.rtcEnquiryDays.Range.Select();
        }

        private void numHours_ValueChanged(object sender, EventArgs e)
        {
            contract.numHours = numHours.Value;
            Util.ContentControls.setText(numHours.Name, numHours.Value.ToString() + " (" + Util.ContentControls.NumberToWords((int)numHours.Value) + ")");
            Globals.ThisDocument.rtcEnquiryHours.Range.Select();
        }
    }
}
