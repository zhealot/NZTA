using System;
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
            Util.SavedState.setControlsToState(contract, Controls);
        }

        private void Interactive_CheckedChanged(object sender, EventArgs e)
        {
            bool blChkd = Interactive_Yes.Checked;
            Meeting_Box.Enabled = blChkd;
            Meeting_Box.Visible = blChkd;
            contract.Interactive_Yes = blChkd;
            contract.Interactive_No = !blChkd;
            var rg = Globals.ThisDocument.rtcInteractiveTenderProcess.Range;
            object style = blChkd ? Globals.ThisDocument.rtcLevel2Style.Range.get_Style() : "Normal";
            //apply rg.Paragraphs.First.set_Style() affects above line, so instead of seting style to paragraph, collapse range to first paragraph and set it style
            //rg.Paragraphs.First.set_Style(ref style); 
            rg.Collapse();
            rg.set_Style(ref style);
            rg = Globals.ThisDocument.rtcInteractiveTenderProcess.Range;
            rg.SetRange(rg.Start - 1, rg.End + 2);
            rg.Font.Hidden = blChkd ? 0 : 1;
            if (blChkd) { rg.Select(); }
        }

        private void CommercialInConfidence_Check_CheckedChanged(object sender, EventArgs e)
        {
            bool Chkd = CommercialInConfidence_Check.Checked;
            contract.CommercialInConfidence_Check = Chkd; 
            var CCIRg = Globals.ThisDocument.rtcCommercialInConfidence.Range;
            object style = Chkd ? Globals.ThisDocument.rtcLevel2Style.Range.get_Style() : "Normal";
            CCIRg.Collapse();
            CCIRg.set_Style(ref style);
            CCIRg = Globals.ThisDocument.rtcCommercialInConfidence.Range;
            //CCIRg.Paragraphs.First.set_Style(ref style);
            CCIRg.SetRange(CCIRg.Start - 1, CCIRg.End + 2);
            CCIRg.Font.Hidden = Chkd ? 0 : 1;
            if (Chkd) { CCIRg.Select(); }
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
                tb.Rows[rw].Cells[1].Range.Text = Combined_Date.Value.ToString("dd-MMMM-yyyy")+ Environment.NewLine + Combined_Time.Value.ToShortTimeString();
                tb.Rows[rw].Cells[2].Range.Text = "Combined Meeting";
                rw++;
            }
            foreach (KeyValuePair<CheckBox, DateTime> kv in iMeetingItem.OrderBy(i => i.Value))
            {
                if (kv.Key.Checked)
                {
                    tb.Rows[rw].Cells[1].Range.Text = kv.Value.ToString("dd-MMMM-yyyy");
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

    }
}
