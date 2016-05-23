using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Office.Tools.Word;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
//using NZTA_Contract_Generator.ActionPaneControls.SectionC;

namespace NZTA_Contract_Generator
{
    public partial class ThisDocument
    {
        public Control apc;
        public Contract contract;

        
        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            //turn off Paragraph Marks
            if (Globals.ThisDocument.ActiveWindow.ActivePane.View.ShowAll )
            {
                Globals.ThisDocument.ActiveWindow.ActivePane.View.ShowAll = false;
            }

            //See if we have saved state
            contract = Util.XML.loadFromXML();
            if (contract == null)
            {
                contract = new Contract();
            }

            //Add save handler
            this.BeforeSave += new Microsoft.Office.Tools.Word.SaveEventHandler(ThisDocument_BeforeSave);

            //Add new document event handler
            this.New += ThisDocument_New;
            this.Open += ThisDocument_Open;
            //Add NavTree
            this.ActionsPane.Controls.Add(new ActionPaneControls.NavTreeAPC());

            //Add edit form
            apc = new ActionPaneControls.ContractSetup.ContractDetails();
            this.ActionsPane.Controls.Add(apc);
            this.Application.TaskPanes[Word.WdTaskPanes.wdTaskPaneDocumentActions].Visible = false;
            //We want nav tree then edit form
            this.ActionsPane.StackOrder = Microsoft.Office.Tools.StackStyle.FromLeft;
            //show task pane
            this.Application.CommandBars["Task Pane"].Visible = true;
            //update fields
            this.Fields.Update();
            //show Custom Ribbon
            //Globals.Ribbons.Ribbon1.tab1.RibbonUI.ActivateTab("CGTAB");
        }

        private void ThisDocument_Open()
        {
            Globals.ThisDocument.richTextContentControl1.Range.Select();
        }

        private void ThisDocument_New()
        {
            //select first page when creating new document
            Globals.ThisDocument.richTextContentControl1.Range.Select();
        }

        void ThisDocument_BeforeSave(object sender, Microsoft.Office.Tools.Word.SaveEventArgs e)
        {
            //Store state in XML
            Util.XML.saveToXML(contract);
        }

        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
           
        }


        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.bmPaymentSchedule.SelectionChange += new Microsoft.Office.Tools.Word.SelectionEventHandler(this.bmPaymentSchedule_SelectionChange);
            this.Startup += new System.EventHandler(this.ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(this.ThisDocument_Shutdown);

        }

        #endregion

        private void rtcGeoTestingSum_Exiting(object sender, ContentControlExitingEventArgs e)
        {
            Globals.ThisDocument.rtcCPS_GeoTestingSum.Range.Text = rtcGeoTestingSum.Range.Text;
        }

        private void rtcAdditionalServicesSchedule_Sum_Exiting(object sender, ContentControlExitingEventArgs e)
        {
            Globals.ThisDocument.rtcCPS_ASS_Sum.Range.Text = Globals.ThisDocument.rtcAdditionalServicesSchedule_Sum.Range.Text;
        }

        private void bmPaymentSchedule_SelectionChange(object sender, SelectionEventArgs e)
        {

        }
    }
    public static class GlobalVar
    {
        //Date string format
        public const string DateFormat = "dd MMMM yyyy";
        /// <summary>
        /// style name for Normal 
        /// </summary>
        public const string StyleNormal = "Normal";
    }
}
