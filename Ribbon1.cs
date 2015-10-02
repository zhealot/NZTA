using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using COM = System.Runtime.InteropServices.ComTypes;
using Microsoft.Office.Interop.Word;

namespace NZTA_Contract_Generator
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void toggleButton1_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisDocument.Application.CommandBars["Task Pane"].Visible = ((RibbonToggleButton)sender).Checked;
        }

        private void ExportWordButton_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NZTA_Contract_Generator.Globals.ThisDocument.Save();
                NZTA_Contract_Generator.Globals.ThisDocument.RemoveCustomization();
                Globals.ThisDocument.Application.CommandBars["Task Pane"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ExportDraftButton_Click(object sender, RibbonControlEventArgs e)
        {
            //add water mark from Buildingblocks
            var doc = Globals.ThisDocument;
            doc.Application.ScreenUpdating = false;
            doc.Application.Templates.LoadBuildingBlocks();
            //after calling LoadBuildingBlocks(), Blocks.dotx will be 1st in Templates
            var tmpl = doc.Application.Templates[1];   
            Microsoft.Office.Interop.Word.Range rg = doc.Sections[1].Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            object Draft = "DRAFT 1";
            try
            {
               tmpl.BuildingBlockEntries.Item(ref Draft).Insert(rg, true);
            }
            catch(Exception ex)
            {
                Util.Help.guidanceNote("Failed to add watermark to document");
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            //export as PDF
            System.Windows.Forms.SaveFileDialog sd = new System.Windows.Forms.SaveFileDialog();
            sd.FileName = sd.InitialDirectory + doc.contract.Contract_Name + "_" + doc.contract.Contract_Number;
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
                catch
                {
                    Util.Help.guidanceNote("Sorry, failed to export PDF");
                }
            }

            //delete inserted watermark
            foreach( Microsoft.Office.Interop.Word.Shape sp in doc.Sections[1].Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Shapes)
            {
                if (sp.AlternativeText == "DRAFT")
                {
                    sp.Delete();
                }
            }
            doc.Application.ScreenUpdating = true;
        }

        private void ExportFinalButton_Click(object sender, RibbonControlEventArgs e)
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

        private void button1_Click(object sender, RibbonControlEventArgs e)
        //remove guidance notes, which have hightlight color as format
        {
            Globals.ThisDocument.Application.ScreenUpdating = false;

            var rg = Globals.ThisDocument.Paragraphs.First.Range;
            rg.Find.ClearFormatting();
            rg.Find.Forward = true;
            rg.Find.Highlight = 1;
            rg.Find.Text = "";
            rg.Find.Replacement.Text = "";
            rg.Find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
            rg.Find.Format = true;
            rg.Find.MatchCase = false;
            rg.Find.MatchWholeWord = false;
            rg.Find.MatchByte = false;
            rg.Find.MatchWildcards = false;
            rg.Find.MatchSoundsLike = false;
            rg.Find.MatchAllWordForms = false;
            rg.Find.Execute();

            int first = 0;
            if (rg.Find.Found) { first = rg.Start; }
            while (rg.Find.Found && rg.Start >= first)
            {
                first = rg.Start;
                try
                {
                    rg.Delete();
                    rg.SetRange(rg.Start + 1, rg.Start + 1);
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("####" + ex.Message);
                }
                int info=rg.Information[Microsoft.Office.Interop.Word.WdInformation.wdActiveEndPageNumber];
                System.Diagnostics.Debug.WriteLine(info.ToString());
                rg.Find.Execute();
            }
            Globals.ThisDocument.Application.ScreenUpdating = true;
        }
    }
}
