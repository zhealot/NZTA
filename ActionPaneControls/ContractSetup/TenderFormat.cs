using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    public partial class TenderFormat : UserControl
    {
        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;
        public TenderFormat()
        {
            InitializeComponent();

            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);            
        }

        private void CopyOfEnvelope_ValueChanged(object sender, EventArgs e)
        {
            contract.CopyOfEnvelope = ((NumericUpDown)sender).Value;
            Util.ContentControls.setText(((NumericUpDown)sender).Name, Util.ContentControls.DecimalToWords(CopyOfEnvelope.Value));
            Globals.ThisDocument.rtcCopyOfEnvelope.Range.Select();
        }

        private void CoverLetter_Page_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.Validator(((TextBox)sender).Text, typeof(int)))
            {
                contract.CoverLetter_Page = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
                Globals.ThisDocument.rtcCoverLetterPage.Range.Select();
            }
            else
            {
                CoverLetter_Page.Focus();
                Util.Help.guidanceNote("Please enter a number");
            }                
        }

        private void Personnel_Page_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.Validator(((TextBox)sender).Text, typeof(int)))
            {
                contract.Personnel_Page = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
                Globals.ThisDocument.rtcPersonnelPage.Range.Select();
            }
            else
            {
                Personnel_Page.Focus();
                Util.Help.guidanceNote("Please enter a number");
            }                
        }

        private void TimeResource_Check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Outline_Check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Project_Check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Index_Page_TextChanged(object sender, EventArgs e)
        {
            contract.Index_A3_Check = (sender == Index_A3_Check) ? Index_A3_Check.Checked : contract.Index_A3_Check;
            contract.Index_Double_Check = (sender == Index_Double_Check) ? Index_Double_Check.Checked : contract.Index_Double_Check;
            if (Util.ContentControls.Validator(Index_Page.Text, typeof(int)))
            {
                contract.Index_Page = Index_Page.Text;                
                Util.ContentControls.setText("Index_Page", Index_Page.Text + ((Index_A3_Check.Checked == true) ? " x A3 " : "")+((Index_Double_Check.Checked == true) ? " x Double sided" : ""));
                Globals.ThisDocument.rtcIndexPage.Range.Select();
            }
            else
            {
                Index_Page.Focus();
                Util.Help.guidanceNote("Please enter a number");
            }                
        }

        private void Project_Page_TextChanged(object sender, EventArgs e)
        {
            contract.Project_Check = (sender == Project_Check) ? Project_Check.Checked : contract.Project_Check;
            contract.Project_A3_Check = (sender == Project_A3_Check) ? Project_A3_Check.Checked : contract.Project_A3_Check;
            if (Project_Check.Checked)
            {
                if (Util.ContentControls.Validator(Project_Page.Text, typeof(int)))
                {
                    contract.Project_Page = Project_Page.Text;
                    Util.ContentControls.setText("Project_Page", Project_Page.Text +
                        ((Project_A3_Check.Checked == true) ? " x A3" : ""));
                    Globals.ThisDocument.rtcProjectPage.Range.Select();
                }
                else
                {
                    Project_Page.Focus();
                    Util.Help.guidanceNote("Please enter a number");
                }
            }
            else
            {
                Util.ContentControls.setText("Project_Page", "");
            }
            Globals.ThisDocument.bmProjectRow.Rows[1].Range.Font.Hidden = Project_Check.Checked ? 0 : 1;
        }

        private void NonPrice_Page_TextChanged(object sender, EventArgs e)
        {
            contract.NonPrice_A3_Check = (sender == NonPrice_A3_Check) ? NonPrice_A3_Check.Checked : contract.NonPrice_A3_Check;
            contract.NonPrice_Double_Check = (sender == NonPrice_Double_Check) ? NonPrice_Double_Check.Checked : contract.NonPrice_Double_Check;
            if (Util.ContentControls.Validator(NonPrice_Page.Text, typeof(int)))
            {
                contract.NonPrice_Page = NonPrice_Page.Text;
                Util.ContentControls.setText("NonPrice_Page", NonPrice_Page.Text + (NonPrice_A3_Check.Checked == true ? " x A3 " : "") + (NonPrice_Double_Check.Checked == true ? " x Double sided" : ""));
                Globals.ThisDocument.rtcNonPricePage.Range.Select();
            }
            else
            {
                NonPrice_Page.Focus();
                Util.Help.guidanceNote("Please enter a number");
            }                
        }

        private void Personnel_Check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("(bar chart) detailing for all personnel, hours proposed to be expended and work focus on a personnel summary information by resource type is acceptable. The total proposed hours is to be shown for each of the key personnel or resource(Ref. clause 2.2 Relevant Skills)");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < RowsCount.Value; i++)
            {
                NZTA_Contract_Generator.Globals.ThisDocument.TenderFormatAppend.Range.Tables[1].Rows.Add();
            }            
            NZTA_Contract_Generator.Globals.ThisDocument.TenderFormatAppend.Range.Select();
        }

        private void Outline_Page_TextChanged(object sender, EventArgs e)
        {
            contract.Outline_Check = (sender == Outline_Check) ? Outline_Check.Checked : contract.Outline_Check;
            contract.Outline_A3_Check = (sender == Outline_A3_Check) ? Outline_A3_Check.Checked : contract.Outline_A3_Check;
            contract.Outline_Double_Check = (sender == Outline_Double_Check) ? Outline_Double_Check.Checked : contract.Outline_Double_Check;
            if (Outline_Check.Checked)
            {                
                if (Util.ContentControls.Validator(Outline_Page.Text, typeof(int)))
                {
                    contract.Outline_Page = Outline_Page.Text;
                    Util.ContentControls.setText("Outline_Page",
                                                Outline_Page.Text +
                                                ((Outline_A3_Check.Checked == true) ? " x A3 " : "") +
                                                ((Outline_Double_Check.Checked == true) ? " x Double sided" : ""));
                    Globals.ThisDocument.rtcOutlinePage.Range.Select();
                }
                else 
                {
                    Outline_Page.Focus();
                    Util.Help.guidanceNote("Please enter a number"); 
                }
            }
            else
            {
                Util.ContentControls.setText("Outline_Page", "");
            }
            Globals.ThisDocument.bmOutlineRow.Rows[1].Range.Font.Hidden = Outline_Check.Checked ? 0 : 1;
        }

        private void CV_Page_TextChanged(object sender, EventArgs e)
        {
            contract.CV_Check = (sender == CV_Check) ? CV_Check.Checked : contract.CV_Check;
            contract.CV_A3_Check = (sender == CV_A3_Check) ? CV_A3_Check.Checked : contract.CV_A3_Check;
            contract.CV_Double_Check = (sender == CV_Double_Check) ? CV_Double_Check.Checked : contract.CV_Double_Check;
            if (CV_Check.Checked)
            {
                if (Util.ContentControls.Validator(CV_Page.Text, typeof(int)))
                {
                    contract.CV_Page = CV_Page.Text;
                    Util.ContentControls.setText("CV_Page", 
                        CV_Page.Text +
                        ((CV_A3_Check.Checked == true) ? " x A3 " : "") +
                        ((CV_Double_Check.Checked == true) ? " x Double sided" : ""));
                    Globals.ThisDocument.rtcCVPage.Range.Select();
                }
                else
                {
                    CV_Page.Focus();
                    Util.Help.guidanceNote("Please enter a number");
                }
            }
            else
            {
                Util.ContentControls.setText("CV_Page", "");
            }
            Globals.ThisDocument.bmCVRow.Rows[1].Range.Font.Hidden = CV_Check.Checked ? 0 : 1;
        }

        private void TimeResource_Page_TextChanged(object sender, EventArgs e)
        {
            contract.TimeResource_Check = (sender == TimeResource_Check) ? TimeResource_Check.Checked : contract.TimeResource_Check;
            contract.TimeResource_A3_Check = (sender == TimeResource_A3_Check) ? TimeResource_A3_Check.Checked : contract.TimeResource_A3_Check;
            if (TimeResource_Check.Checked)
            {
                if (Util.ContentControls.Validator(TimeResource_Page.Text, typeof(int)))
                {
                    contract.TimeResource_Page = TimeResource_Page.Text;
                    Util.ContentControls.setText("TimeResource", TimeResource_Page.Text + ((TimeResource_A3_Check.Checked == true) ? " x A3" : ""));
                    Globals.ThisDocument.rtcTimeResource.Range.Select();
                }
                else
                {
                    TimeResource_Page.Focus();
                    Util.Help.guidanceNote("Please enter a number");
                }
            }
            else
            {
                Util.ContentControls.setText("TimeResource", "");
            }
            Globals.ThisDocument.bmTimeResourceRow.Rows[1].Range.Font.Hidden = TimeResource_Check.Checked ? 0 : 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //set font color to black to normal paragraph
            Microsoft.Office.Interop.Word.Style stl;
            foreach (Microsoft.Office.Interop.Word.Paragraph pg in Globals.ThisDocument.Paragraphs)
            {

                stl = pg.get_Style();
            }
        }
    }
}