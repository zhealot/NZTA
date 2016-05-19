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
        Contract contract = Globals.ThisDocument.contract;
        public SupplierSelectionMethod()
        {
            InitializeComponent();
            tbTR.Enabled = cbTrackRecord.Checked;
            pnM.Enabled = false; pnRE.Enabled = false; pnRS.Enabled = false; pnTR.Enabled = false;
            //Load saved state. Defaults set in state...
            Util.SavedState.setControlsToState(contract, Controls);
            if (contract.BrooksLaw_Check)
            {
                rbBLO.Checked = true;
                gbMethods.Enabled = false;
            }
            if (contract.TargetPrice_Check)
            {
                rbTP.Checked = true;
                gbMethods.Enabled = false;
            }
            if (contract.BaseEstimate_Check)
            {
                rbTP.Enabled = false;
                rbBLO.Enabled = false;
            }
            //### show/hide clauses base on cbTrackRecord status, there should be a better way to achieve this
            cbTrackRecord_CheckedChanged(null, null);
            Globals.ThisDocument.Supplier_Selection_Method.Select();
        }

        private void rbPQM_CheckedChanged(object sender, EventArgs e)
        {
            contract.rbPQM = rbPQM.Checked;
        }

        private void cbTrackRecord_CheckedChanged(object sender, EventArgs e)
        {
            contract.cbTrackRecord = cbTrackRecord.Checked;
            tbTR.Enabled = cbTrackRecord.Checked;
            Globals.ThisDocument.rtcTrackRecordClause1.LockContents = false;
            Globals.ThisDocument.rtcTrackRecordClause2.LockContents = false;
            Globals.ThisDocument.rtcTrackRecordClause3.LockContents = false;
            var TRC1Rg = Globals.ThisDocument.rtcTrackRecordClause1.Range;
            var TRC2Rg = Globals.ThisDocument.rtcTrackRecordClause2.Range;
            var TRC3Rg = Globals.ThisDocument.rtcTrackRecordClause3.Range;
            object style = cbTrackRecord.Checked ? Globals.ThisDocument.rtcLevel3Style.Range.get_Style() : "Normal";
            TRC3Rg.set_Style(ref style);
            TRC1Rg.SetRange(TRC1Rg.Start - 1, TRC1Rg.End + 2);
            TRC2Rg.SetRange(TRC2Rg.Start - 1, TRC2Rg.End + 2);
            TRC3Rg.SetRange(TRC3Rg.Start - 1, TRC3Rg.End + 2);
            TRC1Rg.Font.Hidden = cbTrackRecord.Checked ? 0 : 1;
            TRC2Rg.Font.Hidden = cbTrackRecord.Checked ? 0 : 1;
            TRC3Rg.Font.Hidden = cbTrackRecord.Checked ? 0 : 1;
            Util.ContentControls.setText("TrackRecordClause4", cbTrackRecord.Checked ? "and Track Record" : "");
            Util.ContentControls.setText("TrackRecordFill", cbTrackRecord.Checked ? " and Track Record" : "");
            Globals.ThisDocument.rtcTrackRecordClause1.LockContents = true;
            Globals.ThisDocument.rtcTrackRecordClause2.LockContents = true;
            Globals.ThisDocument.rtcTrackRecordClause3.LockContents = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!rbBLO.Checked && !rbLPC.Checked && !rbTP.Checked && !rbPQM.Checked && !rbPQMPDA.Checked)
            {
                Util.Help.guidanceNote("Please select a Supplier Selection Method");
                return;
            }
            Decimal RE, TR, RS, M, P;
            var Docu = Globals.ThisDocument;
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
            //PQM, PQM+PDA, TP and BLO
            else
            {
                if (Decimal.TryParse(tbRE.Text, out RE) && Decimal.TryParse(((cbTrackRecord.Checked == true) ? tbTR.Text : "0"), out TR) && Decimal.TryParse(tbRS.Text, out RS) && Decimal.TryParse(tbM.Text, out M) && Decimal.TryParse(tbP.Text, out P))
                {
                    if(RE + TR + RS + M + (((rbTP.Checked) || (rbBLO.Checked) ) ? 0 : P) == 100)  //if (RE + TR + RS + M + P == 100)
                    {
                        //if (RE >= 10 && (cbTrackRecord.Checked == true ? TR >= 10 : true) && RS >= 10 && M >= 10)
                        //{
                            if (rbPQM.Checked || rbPQMPDA.Checked) //PQM and PQM+PDA
                            {
                                if (P >= 20 && P <= 30) //check price
                                {
                                    Docu.rtcPrice.Text = P.ToString() + "%";
                                    if (rbPQM.Checked)
                                    {
                                        Docu.rtcSupplierSelectoionMethodName.Text = "PQM Simple";
                                        Docu.rtcSupplierSelectionMethodStart.Text = "Tenders will be evaluated in accordance with this document and the “PQM Simple Method”, of the Transport Agency’s Contract Procedures Manual (SM021)." +
                                                                                    Environment.NewLine + "Weightings will be given to each of the attributes as follows:";
                                        Docu.rtcSupplierSelectionMethodEnd.Text = "A tender receiving a score of 35% or less for any non-price attribute will fail on that attribute and that tender will be rejected.";
                                    }
                                    if (rbPQMPDA.Checked)
                                    {
                                        Docu.rtcSupplierSelectoionMethodName.Text = "PQM Simple + Price Deviation Adjustment (PDA)";
                                        Docu.rtcSupplierSelectionMethodStart.Text = "In addition to the PQM Simple evaluation method of the NZTA Contract Procedures Manual (SM021), the submitted tender price will have a Price Deviation Adjustment added.  This adjustment is calculated after all submitted price envelopes have been opened." +
                                                                                    Environment.NewLine + "If the tendered price is more than 90% of the median tender price, (when only two tenders are received the Base Estimate is included in the median price calculation), no adjustment will be made." +
                                                                                    Environment.NewLine + "If the tender price is less than 90% of the median tender price, the Price Deviation Adjustment is calculated by multiplying the difference between the tendered price and 90% of the median tender price by 1.5 to give a positive adjustment figure, which is then added to the submitted tendered price. E.g.  If 90% of the median tender price is $100,000.00 and a submitted tender price is $80,000.00 the PDA = ($100,000.00 - $80,000.00) x 1.5 = $30,000.00." +
                                                                                    Environment.NewLine + "Weightings will be given to each of the attributes as follows:";
                                        Docu.rtcSupplierSelectionMethodEnd.Text = "A tender receiving a score of 35% or less for any non-price attribute will fail on that attribute and that tender will be rejected.";
                                    }
                                }
                                //for PQM and PQM+PDA, check Price 
                                else 
                                {
                                    tbP.Focus();
                                    Util.Help.guidanceNote("Price must not be less than 20% and must not exceed 30% without specific approval");
                                    return;
                                }
                            }                            
                            //Target Price
                            if (rbTP.Checked)   
                            {
                                Docu.rtcSupplierSelectoionMethodName.Text = "Target Price";
                                Docu.rtcSupplierSelectionMethodStart.Text = "Tenders will be evaluated in accordance with this document and the “Target Price Method”, of the Transport Agency’s Contract Procedures Manual (SM021)." +
                                                                            Environment.NewLine + "Weightings will be given to each of the non-price attributes as follows:";
                                Docu.rtcSupplierSelectionMethodEnd.Text = "A tender receiving a score of 35% or less for any non-price attribute will fail on that attribute and that tender will be rejected.";
                                Docu.rtcPrice.Text = "N/A";
                            }
                            //Brook's Law Opton
                            if (rbBLO.Checked)  
                            {
                                Docu.rtcSupplierSelectoionMethodName.Text = "Brook's Law Option";
                                Docu.rtcSupplierSelectionMethodStart.Text = "Tenders will be evaluated in accordance with this document and the “Brook’s Law Method” of Transport Agency’s Contract Procedures Manual (SM021)." +
                                                                            Environment.NewLine + "Weightings will be given to each of the non-price attributes as follows:";
                                Docu.rtcSupplierSelectionMethodEnd.Text = "A tender receiving a score of 35% or less for any non-price attribute will fail on that attribute and that tender will be rejected.";
                                Docu.rtcPrice.Text = "N/A";
                            }
                            //update Supplier Selection Method session
                            Docu.rtcRelevantExperience.Text = RE.ToString() + "%";
                            Docu.rtcTrackRecord.Text = (cbTrackRecord.Checked == true) ? TR.ToString() + "%" : "N/A";
                            Docu.rtcRelevantSkills.Text = RS.ToString() + "%";
                            Docu.rtcMethodology.Text = M.ToString() + "%";                            
                            //write back
                            contract.tbM = M.ToString();
                            contract.tbP = P.ToString();
                            contract.tbRE = RE.ToString();
                            contract.tbRS = RS.ToString();
                            contract.tbTR = TR.ToString();
                            //set text for "5. Tender Evaluation Forms"
                            Util.ContentControls.setText("RelevantExperienceWeighting", Docu.rtcRelevantExperience.Text);
                            Util.ContentControls.setText("TrackRecordWeighting", Docu.rtcTrackRecord.Text);
                            Util.ContentControls.setText("RelevantSkillsWeighting", Docu.rtcRelevantSkills.Text);
                            Util.ContentControls.setText("MethodologyWeighting", Docu.rtcMethodology.Text);
                            Globals.ThisDocument.rtcSupplierSelectoionMethodName.Range.Select();
                        }
                        //weighting <10%
                        //else
                        //{
                        //    Util.Help.guidanceNote("Weighting applied must not less then 10%");
                        //    return;
                        //}
                    //}
                    //add up not 100%
                    else
                    {
                        Util.Help.guidanceNote("The total must add up to 100%");
                        return;
                    }
                }
                //input not number
                else 
                {
                    Util.Help.guidanceNote("Please enter number");
                    return;
                }
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
            contract.rbBLO = rbBLO.Checked;
            lblP.Enabled = !rbBLO.Checked;
            tbP.Enabled = !rbBLO.Checked;
        }

        private void helpPQM_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Where a NPA is used, the weighting applied must not be less than 10%, and Price must not be less than 20% and must not exceed 30% without specific approval.  If Price weighting exceeds 30% then approval from the Manager of Project Services at National Office must be obtained. The total must add up to 100%.");
        }

        private void helpPQMPDA_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote(": Where a NPA is used, the weighting applied must not be less than 10%, and Price must not be less than 20% and must not exceed 30% without specific approval.  If Price weighting exceeds 30% then approval from the Manager Project Services at National Office must be obtained. The total must add up to 100%.");
        }

        private void helpLPC_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Mandatory NPAs must be chosen and scored on a Pass/Fail basis with relevant Pass/Fail marking forms, unless you have applied rules from guidance note 3 under 3.2 above.");
        }

        private void helpTP_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Mandatory NPAs must be chosen (each NPA must not be less than 10%), and total must add up to 100% with relevant marking forms) unless you have applied rules from guidance note 3 under 3.2 above.");
        }

        private void helpBL_Click(object sender, EventArgs e)
        {
            Util.Help.guidanceNote("Mandatory NPAs must be chosen (each NPA must not be less than 10%), and total must add up to 100% with relevant marking forms.");
        }              


    }
}