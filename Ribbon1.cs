using System;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;

namespace NZTA_Contract_Generator
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void ToggleNaviTree_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisDocument.Application.CommandBars["Task Pane"].Visible = ((RibbonToggleButton)sender).Checked;
        }

        private void ExportWordButton_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Globals.ThisDocument.Save();
                Globals.ThisDocument.RemoveCustomization();
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
            Range rg = doc.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
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
                    Globals.ThisDocument.ExportAsFixedFormat(outputFileName: sd.FileName, exportFormat: WdExportFormat.wdExportFormatPDF,
                                                            openAfterExport: true, optimizeFor: WdExportOptimizeFor.wdExportOptimizeForPrint,
                                                            range: WdExportRange.wdExportAllDocument, from: 0, to: 0, item: WdExportItem.wdExportDocumentContent,
                                                            includeDocProps: true, keepIRM: true, createBookmarks: WdExportCreateBookmarks.wdExportCreateNoBookmarks,
                                                            docStructureTags: true, bitmapMissingFonts: true, useISO19005_1: false, fixedFormatExtClassPtr: ref missing);
                }
                catch
                {
                    Util.Help.guidanceNote("Sorry, failed to export PDF");
                }
            }

            //delete inserted watermark
            foreach( Shape sp in doc.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Shapes)
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
            sd.FileName = sd.InitialDirectory + Globals.ThisDocument.contract.Contract_Name + "_" + Globals.ThisDocument.contract.Contract_Number;
            if (sd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                object missing = System.Type.Missing;
                try
                {
                    Globals.ThisDocument.ExportAsFixedFormat(outputFileName: sd.FileName, exportFormat: WdExportFormat.wdExportFormatPDF,
                                                    openAfterExport: true, optimizeFor: WdExportOptimizeFor.wdExportOptimizeForPrint,
                                                    range: WdExportRange.wdExportAllDocument, from: 0, to: 0, item: WdExportItem.wdExportDocumentContent,
                                                    includeDocProps: true, keepIRM: true, createBookmarks: WdExportCreateBookmarks.wdExportCreateNoBookmarks,
                                                    docStructureTags: true, bitmapMissingFonts: true, useISO19005_1: false, fixedFormatExtClassPtr: ref missing);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void btnRemoveGuidance_Click(object sender, RibbonControlEventArgs e)
        //remove guidance notes, which have hightlight color as format
        {
            Globals.ThisDocument.Application.ScreenUpdating = false;

            var rg = Globals.ThisDocument.Paragraphs.First.Range;
            rg.Find.ClearFormatting();
            rg.Find.Forward = true;
            rg.Find.Highlight = 1;
            rg.Find.Text = "";
            rg.Find.Replacement.Text = "";
            rg.Find.Wrap = WdFindWrap.wdFindContinue;
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
                    //in case rg is not deleted successfully 
                    //rg.SetRange(rg.Start + 1, rg.Start + 1);
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("####" + ex.Message);
                }
                rg.Find.Execute();
            }
            Util.Help.guidanceNote("Guidance notes removed.");
            Globals.ThisDocument.Application.ScreenUpdating = true;
        }

        private void Finalize_Click(object sender, RibbonControlEventArgs e)
        //update all page ref fields code; make sure key page is on odd page & has a blank page afterwards
        {
            Globals.ThisDocument.Application.ScreenUpdating = false;
            //adjust numbering for Geo testing schedule 
            if(Globals.ThisDocument.contract.geoYes && Globals.ThisDocument.contract.scheduledItems)
            {
                if (Globals.ThisDocument.Bookmarks.Exists("bm10GeoInPricingTable"))
                {
                    string GeoNum = Globals.ThisDocument.Bookmarks["bm10GeoInPricingTable"].Range.ListFormat.ListString;
                    int iGeoNum;
                    if (int.TryParse(GeoNum, out iGeoNum))
                    {
                        if (Globals.ThisDocument.rtcGeotechScheduledItems.Range.Tables.Count == 1)
                        {
                            Table tb = Globals.ThisDocument.rtcGeotechScheduledItems.Range.Tables[1];
                            for (int i = 1; i <= tb.Rows.Count; i++)
                            {
                                string CellNumber = tb.Cell(i, 1).Range.Text;
                                CellNumber = CellNumber.Replace("\r\a", "");
                                int intCell;
                                if (int.TryParse(CellNumber.Replace(".", ""), out intCell))
                                {
                                    CellNumber = iGeoNum.ToString() + CellNumber.Substring(CellNumber.IndexOf('.'));
                                    tb.Cell(i, 1).Range.Text = CellNumber;
                                }
                            }
                            
                        }

                    }
                }

            }
            //adjust numbering for Additional service schedule


            //update all fields
            foreach (Field fld in Globals.ThisDocument.Fields)
            {
                if (fld.Type == WdFieldType.wdFieldPageRef)
                    fld.Update();
            }

            Globals.ThisDocument.Application.ScreenUpdating = true;
        }
    }
}
