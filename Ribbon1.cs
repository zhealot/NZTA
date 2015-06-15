using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using COM = System.Runtime.InteropServices.ComTypes;

namespace NZTA_Contract_Generator
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            //Globals.ThisDocument.ActionsPane.Visible = ((RibbonToggleButton)sender).Checked;
        }

        private void toggleButton1_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisDocument.Application.CommandBars["Task Pane"].Visible = ((RibbonToggleButton)sender).Checked;
        }

        private void ExportWordButton_Click(object sender, RibbonControlEventArgs e)
        {
            //Microsoft.Office.Interop.Word.Dialog dlg = NZTA_Contract_Generator.Globals.ThisDocument.Application.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFileSaveAs];
            //object ODlg = (object)dlg;
            //object[] oArgs = new object[1];
            //oArgs[0] = (object)@"test.doc";
            //ODlg.GetType().InvokeMember("Name", System.Reflection.BindingFlags.SetProperty, null, ODlg, oArgs);
            //dlg.Show();

            //System.Windows.Forms.SaveFileDialog sd = new System.Windows.Forms.SaveFileDialog();
            //sd.FileName = sd.InitialDirectory + NZTA_Contract_Generator.Globals.ThisDocument.contract.Contract_Name + "_" + NZTA_Contract_Generator.Globals.ThisDocument.contract.Contract_Number;
            //sd.DefaultExt = ".dotx";
            //if (sd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    object Filename = sd.FileName;
            //    object Fileformat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocumentDefault;
            //    object LockComment = false;
            //    object password = System.Type.Missing;
            //    object addToRecentFile = true;
            //    object writePassword = System.Type.Missing;
            //    object readOnlyRecommended = true; //Word suggests read only when this copy is open
            //    object embedTrueTypeFonts = false;
            //    object saveNativePictureFormat = true;
            //    object saveFormsData = true;
            //    object saveAsAOCELetter = false;
            //    object encoding = Microsoft.Office.Core.MsoEncoding.msoEncodingUSASCII;
            //    object InsertLineBreaks = false;
            //    object AllowSubstitutions = false;
            //    object LineEnding = Microsoft.Office.Interop.Word.WdLineEndingType.wdCRLF;
            //    object AddBiDiMarks = false;
            //    object compatibilityMode = Microsoft.Office.Interop.Word.WdCompatibilityMode.wdCurrent;
            //    //NZTA_Contract_Generator.Globals.ThisDocument.SaveAs2(ref Filename, ref Fileformat, ref LockComment, ref password, ref addToRecentFile, ref writePassword,
            //    //                                                    ref readOnlyRecommended, ref embedTrueTypeFonts, ref saveNativePictureFormat, ref saveFormsData,
            //    //                                                    ref saveAsAOCELetter, ref encoding, ref InsertLineBreaks, ref AllowSubstitutions, ref LineEnding,
            //    //                                                    ref AddBiDiMarks, ref compatibilityMode);
            //    NZTA_Contract_Generator.Globals.ThisDocument.Base.Saved = true;
            //}
            try
            {
                NZTA_Contract_Generator.Globals.ThisDocument.Save();
                NZTA_Contract_Generator.Globals.ThisDocument.RemoveCustomization();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ExportDraftButton_Click(object sender, RibbonControlEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog sd = new System.Windows.Forms.SaveFileDialog();
            sd.FileName = sd.InitialDirectory + NZTA_Contract_Generator.Globals.ThisDocument.contract.Contract_Name + "_" + NZTA_Contract_Generator.Globals.ThisDocument.contract.Contract_Number;
            if (sd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                object missing = System.Type.Missing;
                try
                {
                    NZTA_Contract_Generator.Globals.ThisDocument.ExportAsFixedFormat(sd.FileName, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF,
                                                                                true, Microsoft.Office.Interop.Word.WdExportOptimizeFor.wdExportOptimizeForPrint,
                                                                                Microsoft.Office.Interop.Word.WdExportRange.wdExportAllDocument, 0, 0, Microsoft.Office.Interop.Word.WdExportItem.wdExportDocumentContent,
                                                                                true, true, Microsoft.Office.Interop.Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks, true,
                                                                                true, false, ref missing);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
