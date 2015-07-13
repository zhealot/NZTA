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
        bool ignoreChange = false;
        public TenderFormat()
        {
            InitializeComponent();

            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
            
        }

        private void CopyOfEnvelope_ValueChanged(object sender, EventArgs e)
        {
            Util.ContentControls.setText("CopyOfEnvelope", Util.ContentControls.DecimalToWords(CopyOfEnvelope.Value));
        }

        private void CoverLetter_Page_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.Validator(((TextBox)sender).Text, typeof(int)))
            {
                contract.CoverLetter_Page = ((TextBox)sender).Text;
                Util.ContentControls.setText(((TextBox)sender).Name, ((TextBox)sender).Text);
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
            if (Util.ContentControls.Validator(Index_Page.Text, typeof(int)))
            {
                contract.Index_Page = Index_Page.Text;
                Util.ContentControls.setText("Index_Page", Index_Page.Text + ((Index_A3_Check.Checked == true) ? " x A3 " : "")+((Index_Double_Check.Checked == true) ? " x Double sided" : ""));
            }
            else
            {
                Index_Page.Focus();
                Util.Help.guidanceNote("Please enter a number");
            }                
        }

        private void Project_Page_TextChanged(object sender, EventArgs e)
        {
            if (Project_Check.Checked)
            {
                if (Util.ContentControls.Validator(Project_Page.Text, typeof(int)))
                {
                    contract.Project_Page = Project_Page.Text;
                    Util.ContentControls.setText("Project_Page", Project_Page.Text +
                        ((Project_A3_Check.Checked == true) ? " x A3" : ""));
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
        }

        private void NonPrice_Page_TextChanged(object sender, EventArgs e)
        {
            if (Util.ContentControls.Validator(NonPrice_Page.Text, typeof(int)))
            {
                contract.NonPrice_Page = NonPrice_Page.Text;
                Util.ContentControls.setText("NonPrice_Page", NonPrice_Page.Text + (NonPrice_A3_Check.Checked == true ? " x A3 " : "") + (NonPrice_Double_Check.Checked == true ? " x Double " : ""));
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
            if (Outline_Check.Checked)
            {                
                if (Util.ContentControls.Validator(Outline_Page.Text, typeof(int)))
                {
                    contract.Outline_Page = Outline_Page.Text;
                    Util.ContentControls.setText("Outline_Page",
                                                Outline_Page.Text +
                                                ((Outline_A3_Check.Checked == true) ? " x A3 " : "") +
                                                ((Outline_Double_Check.Checked == true) ? " x Double " : ""));
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

        }

        private void CV_Page_TextChanged(object sender, EventArgs e)
        {
            if (CV_Check.Checked)
            {
                if (Util.ContentControls.Validator(CV_Page.Text, typeof(int)))
                {
                    contract.CV_Page = CV_Page.Text;
                    Util.ContentControls.setText("CV_Page", CV_Page.Text +
                        ((CV_A3_Check.Checked == true) ? " x A3 " : ""));
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
        }
    }
}