﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using System.Linq;

namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    partial class InteractiveTenderProcess : UserControl
    {
        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;        
        public InteractiveTenderProcess()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            CommercialInConfidence_Check.Checked = false;
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void Interactive_Yes_CheckedChanged(object sender, EventArgs e)
        {
            Meeting_Box.Enabled = Interactive_Yes.Checked;
            Meeting_Box.Visible = Interactive_Yes.Checked;
            CommercialInConfidence_Check.Checked = Interactive_Yes.Checked;
            contract.Interactive_Yes = Interactive_Yes.Checked;
            contract.Interactive_No = Interactive_No.Checked;
            NZTA_Contract_Generator.Globals.ThisDocument.rtcInteractiveTenderProcess.Range.Font.Hidden = Interactive_Yes.Checked ? 0 : 1;
            NZTA_Contract_Generator.Globals.ThisDocument.rtcCommercialInConfidence.Range.Font.Hidden = Interactive_Yes.Checked ? 0 : 1;
        }

        private void Interactive_No_CheckedChanged(object sender, EventArgs e)
        {
            Meeting_Box.Enabled = !Interactive_No.Checked;
            Meeting_Box.Visible = !Interactive_No.Checked;
            CommercialInConfidence_Check.Checked = !Interactive_No.Checked;
            contract.Interactive_Yes = Interactive_Yes.Checked;
            contract.Interactive_No = Interactive_No.Checked;
            NZTA_Contract_Generator.Globals.ThisDocument.rtcInteractiveTenderProcess.Range.Font.Hidden = Interactive_No.Checked ? 1 : 0;
            NZTA_Contract_Generator.Globals.ThisDocument.rtcCommercialInConfidence.Range.Font.Hidden = Interactive_No.Checked ? 1 : 0;
        }

        private void AnyItemChanged(object sender, EventArgs e)
        //handles any 1 of 6 meeting events changes, date/time/checked, populate Meeting talbe
        {
            NZTA_Contract_Generator.Globals.ThisDocument.Application.ScreenUpdating = false;
            Dictionary<CheckBox, DateTime> iMeetingItem = new Dictionary<CheckBox, DateTime>();
            //put Individual meetings data into a list then sort it 
            iMeetingItem.Clear();
            foreach (Control c in this.Meeting_Box.Controls)
            {
                if (c is CheckBox)
                {
                    if (((CheckBox)c).Name.Contains("Combined"))
                    {
                        contract[c.Name] = ((CheckBox)c).Checked;
                    }
                    if (((CheckBox)c).Checked && ((CheckBox)c).Name.Contains("Individual"))
                    {
                        contract[c.Name] = ((CheckBox)c).Checked;   
                        try
                        {
                            iMeetingItem.Add((CheckBox)c, ((DateTimePicker)this.Meeting_Box.Controls.Find("Individual" + ((CheckBox)c).Name.Substring(10, 1) + "_Date", false)[0]).Value);
                        }
                        catch (ArgumentException x)    //
                        {
                            System.Diagnostics.Debug.WriteLine(x.Message);
                        }    
                    }                    
                }
                if (c is DateTimePicker)
                {
                    contract[c.Name] = ((DateTimePicker)c).Value.ToString("O");
                }
            }

            iMeetingItem.OrderBy(i => i.Value);
            
            //fill in meeting table if Combined meeting exists
            var tb = NZTA_Contract_Generator.Globals.ThisDocument.rtcInteractiveTenderProcess.Range.Tables[1];
            tb.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitFixed);

            for (int i = tb.Rows.Count; i > 1; i--)
            {
                tb.Rows[i].Delete();
            }
            while (tb.Rows.Count < iMeetingItem.Count + (Combined_Check.Checked == true ? 1 : 0))
            {
                tb.Rows.Add();
            }
            int rw = 1;
            if (Combined_Check.Checked)
            {
                tb.Rows[rw].Cells[1].Range.Text = Combined_Date.Value.ToShortDateString() + Environment.NewLine + Combined_Time.Value.ToShortTimeString();
                tb.Rows[rw].Cells[2].Range.Text = "Combined Meeting";
                rw++;
            }
            foreach (KeyValuePair<CheckBox, DateTime> kv in iMeetingItem.OrderBy(i => i.Value))
            {
                if (kv.Key.Checked)
                {
                    tb.Rows[rw].Cells[1].Range.Text = kv.Value.ToShortDateString();
                    tb.Rows[rw].Cells[2].Range.Text = kv.Key.Name.Substring(0, 10) + " Meeting " + Util.ContentControls.IntegerToRoman((rw - (Combined_Check.Checked ? 1 : 0)));
                }
                rw++;
            }
            NZTA_Contract_Generator.Globals.ThisDocument.Application.ScreenUpdating = true;
        }

        private void help1_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Interactive meetings allow the Agency to work alongside the tenderers in order that they may fully understand the tender document and the scope of the contract.  Interactives are normally undertaken for larger PS contract.  If you opt for Interactives, then you would normally have a combined meeting as a minimum, with individual interactive potentially in addition.");
        }
        
        private void Individual_Place_TextChanged(object sender, EventArgs e)
        {
            contract.Individual_Place = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void Combined_Place_TextChanged(object sender, EventArgs e)
        {
            contract.Combined_Place = ((TextBox)sender).Text;
            Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
        }

        private void CommercialInConfidence_Check_CheckedChanged(object sender, EventArgs e)
        {
            contract.CommercialInConfidence_Check = CommercialInConfidence_Check.Checked;
            NZTA_Contract_Generator.Globals.ThisDocument.rtcCommercialInConfidence.Range.Font.Hidden = (CommercialInConfidence_Check.Checked ? 0 : 1);           
        }
    }
}
