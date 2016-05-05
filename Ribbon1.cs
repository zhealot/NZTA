﻿using System;
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
                    rg.SetRange(rg.Start + 1, rg.Start + 1);
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("####" + ex.Message);
                }
                rg.Find.Execute();
            }

            Globals.ThisDocument.Application.ScreenUpdating = true;
        }

        private void Finalize_Click(object sender, RibbonControlEventArgs e)
        //update all page ref fields code; make sure key page is on odd page & has a blank page afterwards
        {
            //Globals.ThisDocument.Application.ScreenUpdating = false;
            //List<Microsoft.Office.Tools.Word.RichTextContentControl> lsRTC = new List<Microsoft.Office.Tools.Word.RichTextContentControl>();
            //lsRTC.Add(Globals.ThisDocument.RTC_SectionA);
            //lsRTC.Add(Globals.ThisDocument.RTC_SectionB);
            //lsRTC.Add(Globals.ThisDocument.RTC_SectionC);
            //lsRTC.Add(Globals.ThisDocument.RTC_SectionD);
            //lsRTC.Add(Globals.ThisDocument.RTC_SectionE);

            //foreach (var rtc in lsRTC)
            //{
            //    var rg = rtc.Range;
            //    if (rg.Information[WdInformation.wdActiveEndPageNumber] % 2 == 0)
            //    {
            //        bool blLockContent = rtc.LockContents;
            //        bool blLockCC = rtc.LockContentControl;
            //        rtc.LockContentControl = false;
            //        rtc.LockContents = false;
            //        rg.SetRange(rg.Start - 1, rg.Start - 1);
            //        rg.InsertBefore(" "); //### unable to insert page break from rg.Start-1, so insert a blank before CC then insert page break from there
            //        rg = rtc.Range;
            //        rg.SetRange(rg.Start - 1, rg.Start - 1);
            //        rg.InsertBreak(WdBreakType.wdPageBreak);
            //        rg.InsertBreak(WdBreakType.wdPageBreak);
            //    }
            //}

            //foreach (Field fld in Globals.ThisDocument.Fields)
            //{
            //    if (fld.Type == WdFieldType.wdFieldPageRef)
            //        fld.Update();                    
            //}

            //Globals.ThisDocument.Application.ScreenUpdating=true;
        }
    }
}
