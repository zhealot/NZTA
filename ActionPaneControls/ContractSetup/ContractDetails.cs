using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    partial class ContractDetails : UserControl
    {

        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;
        bool ignoreChange = false;

        public ContractDetails()
        {
            InitializeComponent();

            //Load any data

            ignoreChange = true;
            
            //Address combobox
            Address_1.DataSource = new BindingSource(Constants.Location.data, null);
            Address_1.DisplayMember = "Key";
            Address_1.ValueMember = "Value";
            Address_1.SelectedIndex = -1;
           

            //Region combobox
            Region.DataSource = new BindingSource(Constants.Location.data, null);
            Region.DisplayMember = "Key";
            Region.ValueMember = "Key";
            Region.SelectedIndex = -1;

            //Tender box
            TenderBox.DataSource = new BindingSource(Constants.Location.data, null);
            TenderBox.DisplayMember = "Key";
            TenderBox.ValueMember = "Key";
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
                KeyValuePair<String, String> selectedEntry = (KeyValuePair<String, String>)((ComboBox)sender).SelectedItem;
                contract.Address_1 = selectedEntry.Key;
            }
        }

        private void geoNo_CheckedChanged(object sender, EventArgs e)
        {
            scheduledItems.Enabled = false;
            provisionalSum.Enabled = false;
            schedLabel.Enabled = false;
            contract.geoNo = true;
            contract.geoYes = false;
        }

        private void geoYes_CheckedChanged(object sender, EventArgs e)
        {
            scheduledItems.Enabled = true;
            provisionalSum.Enabled = true;
            schedLabel.Enabled = true;
            contract.geoNo = false;
            contract.geoYes = true;
        }

        private void help2_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Alternative tenders are not normally used as it can create considerable work in evaluating tenders and can be used to manipulate the tender process as opposed to adding value.  Innovated ideas can still be discussed with the preferred tenderer at a later date.");
        }

        private void Nominated_Person_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            contract.Nominated_Person = ((TextBox)sender).Text;
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
        }

        private void Level_1_TextChanged(object sender, EventArgs e)
        {
            contract.Level_1 = ((TextBox)sender).Text;
        }

        private void Street_1_TextChanged(object sender, EventArgs e)
        {
            contract.Street_1 = ((TextBox)sender).Text;
        }

        private void Box_1_TextChanged(object sender, EventArgs e)
        {
            contract.Box_1 = ((TextBox)sender).Text;
        }

        private void City_1_TextChanged(object sender, EventArgs e)
        {
            contract.City_1 = ((TextBox)sender).Text;
        }

        private void Telephone_1_TextChanged(object sender, EventArgs e)
        {
            contract.Telephone_1 = ((TextBox)sender).Text;
        }

        private void Fax_1_TextChanged(object sender, EventArgs e)
        {
            contract.Fax_1 = ((TextBox)sender).Text;
        }

        private void Email_1_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            contract.Email_1 = ((TextBox)sender).Text;
        }

        private void Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null && !ignoreChange)
            {
                KeyValuePair<String, String> selectedEntry = (KeyValuePair<String, String>)((ComboBox)sender).SelectedItem;
                contract.Region = selectedEntry.Key;
            }
        }

        private void provisionalSum_CheckedChanged(object sender, EventArgs e)
        {
            contract.provisionalSum = true;
            contract.scheduledItems = false;
        }

        private void scheduledItems_CheckedChanged(object sender, EventArgs e)
        {
            contract.provisionalSum = false;
            contract.scheduledItems = true;
        }

        private void clientSiteNo_CheckedChanged(object sender, EventArgs e)
        {
            contract.clientSiteNo = true;
            contract.clientSiteYes = false;
        }

        private void altTenderNo_CheckedChanged(object sender, EventArgs e)
        {
            contract.altTenderNo = true;
            contract.altTenderYes = false;
            NZTA_Contract_Generator.Globals.ThisDocument.AlternativeTenders.Text = NZTA_Contract_Generator.Constants.Text.GetText(((RadioButton)sender).Name);
        }

        private void altTenderYes_CheckedChanged(object sender, EventArgs e)
        {
            contract.altTenderYes = true;
            contract.altTenderNo = false;
            NZTA_Contract_Generator.Globals.ThisDocument.AlternativeTenders.Text = NZTA_Contract_Generator.Constants.Text.GetText(((RadioButton)sender).Name);
        }

        private void TenderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null && !ignoreChange)
            {
                KeyValuePair<String, String> selectedEntry = (KeyValuePair<String, String>)((ComboBox)sender).SelectedItem;
                contract.TenderBox = selectedEntry.Key;
            }
        }

        private void Nominated_Phone_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, (((TextBox)sender).Text));
            contract.Nominated_Person = ((TextBox)sender).Text;
        }

        private void Address_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null && !ignoreChange)
            {
                //KeyValuePair<String, string> selectedEntry = (KeyValuePair<String, String>)((ComboBox)sender).SelectedItem;
                KeyValuePair<string, Util.Address> selectedEntry = (KeyValuePair<string, NZTA_Contract_Generator.Util.Address>)Address_2.SelectedItem;
                contract.Address_2 = selectedEntry.Key;
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

        private void numDays_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            contract.numDays = ((TextBox)sender).Text;
        }

        private void numHours_TextChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
            contract.numHours = ((TextBox)sender).Text;
        }

        private void elecYes_CheckedChanged(object sender, EventArgs e)
        {
            contract.elecYes = true;
            contract.elecNo = false;
            label37.Enabled = true;
            label36.Enabled = true;
            anotherMeansNo.Enabled = true;
            anotherMeansYes.Enabled = true;
            otherDetails.Enabled = true;
        }

        private void elecNo_CheckedChanged(object sender, EventArgs e)
        {
            contract.elecNo = true;
            contract.elecYes = false;
            label37.Enabled = false;
            label36.Enabled = false;
            anotherMeansNo.Enabled = false;
            anotherMeansYes.Enabled = false;
            otherDetails.Enabled = false;
            Util.ContentControls.setText("E-Copy", ".");
        }

        private void anotherMeansNo_CheckedChanged(object sender, EventArgs e)
        {
            contract.anotherMeansNo = true;
            contract.anotherMeansYes = false;
            Util.ContentControls.setText("E-Copy", " and Email.");
        }

        private void anotherMeansYes_CheckedChanged(object sender, EventArgs e)
        {
            contract.anotherMeansYes = true;
            contract.anotherMeansNo = false;
            Util.ContentControls.setText("E-Copy", " and " + contract.otherDetails);
        }

        private void otherDetails_TextChanged(object sender, EventArgs e)
        {
            contract.otherDetails = ((TextBox)sender).Text;
            Util.ContentControls.setText("E-Copy", "accompanied by an electronic copy on " + contract.otherDetails + ".");
        }

        private void isPersonDifferentNo_CheckedChanged(object sender, EventArgs e)
        {
            Different_Name.Enabled = false;
            Different_Email.Enabled = false;
            contract.isPersonDifferentNo = true;
            contract.isPersonDifferentYes = false;
        }

        private void isPersonDifferentYes_CheckedChanged(object sender, EventArgs e)
        {
            Different_Name.Enabled = true;
            Different_Email.Enabled = true;
            contract.isPersonDifferentYes = true;
            contract.isPersonDifferentNo = false;
        }

        private void Different_Name_TextChanged(object sender, EventArgs e)
        {
            contract.Different_Name = ((TextBox)sender).Text;
        }

        private void Different_Email_Leave(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsEmail(((TextBox)sender).Text))
            {
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
                contract.Different_Email = ((TextBox)sender).Text;
            }
            else
                MessageBox.Show("Invalid Email address");
            
        }

        private void Nominated_Email_Leave(object sender, EventArgs e)
        {
            if (Util.ContentControls.IsEmail(((TextBox)sender).Text))
            {
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
                contract.Nominated_Email = ((TextBox)sender).Text;
            }
            else
                MessageBox.Show("Invalid Email address");
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
                Util.ContentControls.setText("Date_Month", MadeDate.Value.Month.ToString());
                Util.ContentControls.setText("Date_Year", MadeDate.Value.Year.ToString());
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
    }
}
