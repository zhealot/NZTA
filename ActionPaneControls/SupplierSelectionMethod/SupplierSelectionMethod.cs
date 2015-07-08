using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZTA_Contract_Generator.ActionPaneControls.SupplierSelectionMethod
{
    public partial class SupplierSelectionMethod : UserControl
    {
        Contract contract = NZTA_Contract_Generator.Globals.ThisDocument.contract;
        public SupplierSelectionMethod()
        {
            InitializeComponent();
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
            tbTR.Enabled = cbTrackRecord.Checked;
            pnM.Enabled = false; pnRE.Enabled = false; pnRS.Enabled = false; pnTR.Enabled = false;
        }

        private void rbPQM_CheckedChanged(object sender, EventArgs e)
        {
            contract.rbPQM = rbPQM.Checked;
        }

        private void cbTrackRecord_CheckedChanged(object sender, EventArgs e)
        {
            tbTR.Enabled = cbTrackRecord.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Decimal RE, TR, RS, M, P;
            var Docu = NZTA_Contract_Generator.Globals.ThisDocument;
            //Lowest Price Conforming
            if (rbLPC.Checked)
            {
                Docu.rtcSupplierSelectoionMethodName.Text = "Lowest Price Conforming";
                Docu.rtcSupplierSelectionMethodStart.Text="Tenders will be evaluated in accordance with this document and the “Lowest Price Conforming” method of the Transport Agency’s Contract Procedures Manual (SM021)."+
                                                            Environment.NewLine+"The following selected non-price attributes will be assessed for tender conformance:";
                Docu.rtcRelevantExperience.Text = (rbRE_P.Checked == true) ? "Pass" : "Fail";
                Docu.rtcTrackRecord.Text = (rbTR_P.Checked == true) ? "Pass" : "Fail";
                Docu.rtcRelevantSkills.Text = (rbRS_P.Checked == true) ? "Pass" : "Fail";
                Docu.rtcMethodology.Text = (rbM_P.Checked == true) ? "Pass" : "Fail";
                Docu.rtcPrice.Text = "N/A";
                Docu.rtcSupplierSelectionMethodEnd.Text = "A tender receiving a fail score for any non-price attribute will be rejected.";
                //set text for 5. Tender Evaluation Forms
                Util.ContentControls.setText("RelevantExperienceWeighting", "N/A for LPC");
                Util.ContentControls.setText("TrackRecordWeighting", "N/A for LPC");
                Util.ContentControls.setText("RelevantSkillsWeighting", "N/A for LPC");
                Util.ContentControls.setText("MethodologyWeighting", "N/A for LPC");
            }
            else
            {
                //PQM Simple
                if (rbPQM.Checked)
                {
                    if (Decimal.TryParse(tbRE.Text, out RE) && Decimal.TryParse(((cbTrackRecord.Checked == true) ? tbTR.Text : "0"), out TR) && Decimal.TryParse(tbRS.Text, out RS) && Decimal.TryParse(tbM.Text, out M) && Decimal.TryParse(tbP.Text, out P))
                    {
                        if (RE + TR + RS + M + P == 100)
                        {
                            if (RE >= 10 && (cbTrackRecord.Checked == true ? TR >= 10 : true) && RS >= 10 && M >= 10 && P >= 10)
                            {
                                if (P >= 20 && P <= 30)
                                {
                                    Docu.rtcSupplierSelectoionMethodName.Text = "PQM Simple";
                                    Docu.rtcSupplierSelectionMethodStart.Text = "Tenders will be evaluated in accordance with this document and the “PQM Simple Method”, of the Transport Agency’s Contract Procedures Manual (SM021)." +
                                                                                Environment.NewLine + "Weightings will be given to each of the attributes as follows:";
                                    Docu.rtcRelevantExperience.Text = RE.ToString() + "%";                                    
                                    Docu.rtcTrackRecord.Text = (cbTrackRecord.Checked == true) ? TR.ToString() + "%" : "N/A";                                    
                                    Docu.rtcRelevantSkills.Text = RS.ToString() + "%";                                    
                                    Docu.rtcMethodology.Text = M.ToString() + "%";                                    
                                    Docu.rtcPrice.Text = P.ToString() + "%";
                                    Docu.rtcSupplierSelectionMethodEnd.Text = "A tender receiving a score of 35% or less for any non-price attribute will fail on that attribute and that tender will be rejected.";
                                }
                                else
                                {
                                    tbP.Focus();
                                    Util.Help.guidanceNote("Price must not be less than 20% and must not exceed 30%");
                                }
                            }
                            else
                            {
                                Util.Help.guidanceNote("No value less then 10");
                            }
                        }
                        else
                        {
                            Util.Help.guidanceNote("The total must add up to 100%");
                        }
                    }
                    else
                    {
                        Util.Help.guidanceNote("Please enter number");
                    }
                }
                //PQM Simple + Price Deviation Adjustment (PDA)
                if (rbPQMPDA.Checked)
                {
                    if (Decimal.TryParse(tbRE.Text, out RE) && Decimal.TryParse(((cbTrackRecord.Checked == true) ? tbTR.Text : "0"), out TR) && Decimal.TryParse(tbRS.Text, out RS) && Decimal.TryParse(tbM.Text, out M) && Decimal.TryParse(tbP.Text, out P))
                    {
                        if (RE + TR + RS + M + P == 100)
                        {
                            if (RE >= 10 && (cbTrackRecord.Checked == true ? TR >= 10 : true) && RS >= 10 && M >= 10 && P >= 10)
                            {
                                if (P >= 20 && P <= 30)
                                {
                                    Docu.rtcSupplierSelectoionMethodName.Text = "PQM Simple + Price Deviation Adjustment (PDA)";
                                    Docu.rtcSupplierSelectionMethodStart.Text = "In addition to the PQM Simple evaluation method of the NZTA Contract Procedures Manual (SM021), the submitted tender price will have a Price Deviation Adjustment added.  This adjustment is calculated after all submitted price envelopes have been opened." +
                                                                                Environment.NewLine + "If the tendered price is more than 90% of the median tender price, (when only two tenders are received the Base Estimate is included in the median price calculation), no adjustment will be made." +
                                                                                Environment.NewLine + "If the tender price is less than 90% of the median tender price, the Price Deviation Adjustment is calculated by multiplying the difference between the tendered price and 90% of the median tender price by 1.5 to give a positive adjustment figure, which is then added to the submitted tendered price. E.g.  If 90% of the median tender price is $100,000.00 and a submitted tender price is $80,000.00 the PDA = ($100,000.00 - $80,000.00) x 1.5 = $30,000.00." +
                                                                                Environment.NewLine + "Weightings will be given to each of the attributes as follows:";
                                    Docu.rtcRelevantExperience.Text = RE.ToString() + "%";
                                    Docu.rtcTrackRecord.Text = (cbTrackRecord.Checked == true) ? TR.ToString() + "%" : "N/A";
                                    Docu.rtcRelevantSkills.Text = RS.ToString() + "%";
                                    Docu.rtcMethodology.Text = M.ToString() + "%";
                                    Docu.rtcPrice.Text = P.ToString() + "%";
                                    Docu.rtcSupplierSelectionMethodEnd.Text = "A tender receiving a score of 35% or less for any non-price attribute will fail on that attribute and that tender will be rejected.";
                                }
                                else
                                {
                                    tbP.Focus();
                                    Util.Help.guidanceNote("Price must not be less than 20% and must not exceed 30%");
                                }
                            }
                            else
                            {
                                Util.Help.guidanceNote("No value less then 10");
                            }
                        }
                        else
                        {
                            Util.Help.guidanceNote("The total must add up to 100%");
                        }
                    }
                    else
                    {
                        Util.Help.guidanceNote("Please enter number");
                    }
                }
                //Target Price
                if (rbTP.Checked)
                {
                    if (Decimal.TryParse(tbRE.Text, out RE) && Decimal.TryParse(((cbTrackRecord.Checked == true) ? tbTR.Text : "0"), out TR) && Decimal.TryParse(tbRS.Text, out RS) && Decimal.TryParse(tbM.Text, out M))
                    {
                        if (RE + TR + RS + M == 100)
                        {
                            if (RE >= 10 && (cbTrackRecord.Checked == true ? TR >= 10 : true) && RS >= 10 && M >= 10)
                            {
                                Docu.rtcSupplierSelectoionMethodName.Text = "Target Price";
                                Docu.rtcSupplierSelectionMethodStart.Text = "Tenders will be evaluated in accordance with this document and the “Target Price Method”, of the Transport Agency’s Contract Procedures Manual (SM021)." +
                                                                            Environment.NewLine + "Weightings will be given to each of the non-price attributes as follows:";
                                Docu.rtcRelevantExperience.Text = RE.ToString() + "%";
                                Docu.rtcTrackRecord.Text = (cbTrackRecord.Checked == true) ? TR.ToString() + "%" : "N/A";
                                Docu.rtcRelevantSkills.Text = RS.ToString() + "%";
                                Docu.rtcMethodology.Text = M.ToString() + "%";
                                Docu.rtcPrice.Text = "N/A";
                                Docu.rtcSupplierSelectionMethodEnd.Text = "A tender receiving a score of 35% or less for any non-price attribute will fail on that attribute and that tender will be rejected.";
                            }
                            else
                            {
                                Util.Help.guidanceNote("No value less then 10");
                            }
                        }
                        else
                        {
                            Util.Help.guidanceNote("The total must add up to 100%");
                        }
                    }
                    else
                    {
                        Util.Help.guidanceNote("Please enter number");
                    }
                }
                //Brook's Law Option
                if (rbBLO.Checked)
                {
                    if (Decimal.TryParse(tbRE.Text, out RE) && Decimal.TryParse(((cbTrackRecord.Checked == true) ? tbTR.Text : "0"), out TR) && Decimal.TryParse(tbRS.Text, out RS) && Decimal.TryParse(tbM.Text, out M))
                    {
                        if (RE + TR + RS + M == 100)
                        {
                            if (RE >= 10 && (cbTrackRecord.Checked == true ? TR >= 10 : true) && RS >= 10 && M >= 10)
                            {
                                Docu.rtcSupplierSelectoionMethodName.Text = "Brook's Law Option";
                                Docu.rtcSupplierSelectionMethodStart.Text = "1.1.12	Tenders will be evaluated in accordance with this document and the “Brook’s Law Method” of Transport Agency’s Contract Procedures Manual (SM021)." +
                                                                            Environment.NewLine + "Weightings will be given to each of the non-price attributes as follows:";
                                Docu.rtcRelevantExperience.Text = RE.ToString() + "%";
                                Docu.rtcTrackRecord.Text = (cbTrackRecord.Checked == true) ? TR.ToString() + "%" : "N/A";
                                Docu.rtcRelevantSkills.Text = RS.ToString() + "%";
                                Docu.rtcMethodology.Text = M.ToString() + "%";
                                Docu.rtcPrice.Text = "N/A";
                                Docu.rtcSupplierSelectionMethodEnd.Text = "A tender receiving a score of 35% or less for any non-price attribute will fail on that attribute and that tender will be rejected.";
                            }
                            else
                            {
                                Util.Help.guidanceNote("No value less then 10");
                            }
                        }
                        else
                        {
                            Util.Help.guidanceNote("The total must add up to 100%");
                        }
                    }
                    else
                    {
                        Util.Help.guidanceNote("Please enter number");
                    }
                }
                //set text for 5. Tender Evaluation Forms
                Util.ContentControls.setText("RelevantExperienceWeighting", Docu.rtcRelevantExperience.Text);
                Util.ContentControls.setText("TrackRecordWeighting", Docu.rtcTrackRecord.Text);
                Util.ContentControls.setText("RelevantSkillsWeighting", Docu.rtcRelevantSkills.Text);
                Util.ContentControls.setText("MethodologyWeighting", Docu.rtcMethodology.Text);
            }            
        }

        private void rbLPC_CheckedChanged(object sender, EventArgs e)
        {
            contract.rbLPC = rbLPC.Checked;
            pnM.Enabled = rbLPC.Checked; pnRE.Enabled = rbLPC.Checked; pnRS.Enabled = rbLPC.Checked; pnTR.Enabled = rbLPC.Checked;
            contract.rbM_F = rbM_F.Checked; contract.rbM_P = rbM_P.Checked; 
            contract.rbRE_F = rbRE_F.Checked; contract.rbRE_P = rbRE_P.Checked;
            contract.rbRS_F = rbRS_F.Checked; contract.rbRS_P = rbRS_P.Checked;
            contract.rbTR_F = rbTR_F.Checked; contract.rbTR_P = rbTR_P.Checked;
            lblM.Enabled = !rbLPC.Checked;
            lblP.Enabled = !rbLPC.Checked;
            lblRE.Enabled = !rbLPC.Checked;
            lblRS.Enabled = !rbLPC.Checked;
            cbTrackRecord.Enabled = !rbLPC.Checked;
            tbM.Enabled = !rbLPC.Checked;
            tbP.Enabled = !rbLPC.Checked;
            tbRE.Enabled = !rbLPC.Checked;
            tbRS.Enabled = !rbLPC.Checked;
            tbTR.Enabled = !rbLPC.Checked;
        }

        private void rbPQMPDA_CheckedChanged(object sender, EventArgs e)
        {
            contract.rbPQMPDA = rbPQMPDA.Checked;
        }

        private void rbTP_CheckedChanged(object sender, EventArgs e)
        {
            contract.rbTP = rbTP.Checked;
            lblP.Enabled = !rbTP.Checked;
            tbP.Enabled = !rbTP.Checked;
        }

        private void rbBLO_CheckedChanged(object sender, EventArgs e)
        {
            contract.rbBLO = !rbBLO.Checked;
            lblP.Enabled = !rbBLO.Checked;
            tbP.Enabled = !rbBLO.Checked;
        }              
    }
}