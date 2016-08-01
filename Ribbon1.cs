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
            foreach(Template tmpl in doc.Application.Templates)
            {
                if(tmpl.Name.ToLower().Contains("built-in building blocks"))
                {
                    var  Draft = "DRAFT 1";
                    try
                    {
                        BuildingBlock wm = tmpl.BuildingBlockEntries.Item(Draft);
                        for (int i = 1; i < doc.Sections.Count; i++)
                        {
                            foreach (WdHeaderFooterIndex hfi in Enum.GetValues(typeof(WdHeaderFooterIndex)))
                            {
                                if (doc.Sections[i].Headers[hfi].Exists)
                                {
                                    var rg = doc.Sections[i].Headers[hfi].Range;
                                    rg.Collapse(WdCollapseDirection.wdCollapseStart); 
                                    wm.Insert(rg,RichText:true);
                                }
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        Util.Help.guidanceNote("Failed to add watermark to document");
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        continue;
                    }
                }
            }
            //export as PDF
            System.Windows.Forms.SaveFileDialog sd = new System.Windows.Forms.SaveFileDialog();
            sd.FileName = sd.InitialDirectory + doc.contract.Contract_Name + "_" + doc.contract.Contract_Number;
            if (sd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                object missing = Type.Missing;
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
            //delete bookmarks in headers across document
            for (int i = 1; i < doc.Sections.Count; i++)
            {
                foreach (WdHeaderFooterIndex hfi in Enum.GetValues(typeof(WdHeaderFooterIndex)))
                {
                    if (doc.Sections[i].Headers[hfi].Exists)
                    {
                        try
                        {
                            var rg = doc.Sections[i].Headers[hfi].Range;
                            rg.Select();
                            //Globals.ThisDocument.Application.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageHeader;
                            foreach(Shape sp in rg.ShapeRange)
                            {
                                if (sp.AlternativeText == "DRAFT")
                                {
                                    sp.Delete();
                                    //Globals.ThisDocument.Application.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument;
                                }
                            }
                            //doc.Sections[i].Headers[hfi].Range.Select();
                            //Globals.ThisDocument.Application.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageHeader;
                            //foreach (Shape sp in doc.Sections[i].Headers[hfi].Shapes)
                            //{
                            //    if (sp.AlternativeText == "DRAFT")
                            //    {
                            //        sp.Delete();
                            //        Globals.ThisDocument.Application.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument;
                            //    }
                            //}
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                            continue;
                        }
                    }
                }
            }
            if (Globals.ThisDocument.ActiveWindow.Panes.Count > 1)
            {
                Globals.ThisDocument.ActiveWindow.Panes[2].Close();
            }
            Globals.ThisDocument.Application.ActiveWindow.View.Type = WdViewType.wdPrintView;
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
                                string CellNumber = tb.Cell(i, 1).Range.Text.Replace("\r\a", "");
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
            if (Globals.ThisDocument.Bookmarks.Exists("bmAdditionaServicesNum"))
            {
                string ASNum = Globals.ThisDocument.Bookmarks["bmAdditionaServicesNum"].Range.ListFormat.ListString;
                int iASNum;
                if(int.TryParse(ASNum,out iASNum))
                {
                    if (Globals.ThisDocument.Bookmarks.Exists("bmAdditionalServiceScheduleTable"))
                    {
                        if (Globals.ThisDocument.Bookmarks["bmAdditionalServiceScheduleTable"].Range.Tables.Count == 1)
                        {
                            Table tb = Globals.ThisDocument.Bookmarks["bmAdditionalServiceScheduleTable"].Range.Tables[1];
                            for(int i = 1; i <= tb.Rows.Count; i++)
                            {
                                string CellNumber = tb.Cell(i, 1).Range.Text.Replace("\r\a", "");
                                int intCell;
                                if (int.TryParse(CellNumber.Replace(".", ""),out intCell))
                                {
                                    CellNumber = iASNum.ToString() + CellNumber.Substring(CellNumber.IndexOf('.'));
                                    tb.Cell(i, 1).Range.Text = CellNumber;
                                }
                            }
                        }
                    }
                }
            }
            //update all fields
            Globals.ThisDocument.Fields.Update();
            foreach(TableOfContents toc in Globals.ThisDocument.TablesOfContents)
            {
                toc.Update();
            }
            Globals.ThisDocument.Application.ScreenUpdating = true;
            Util.Help.guidanceNote("All fields updated and page number adjusted.");
        }
    }
}
