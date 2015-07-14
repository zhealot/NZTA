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
using NZTA_Contract_Generator.ActionPaneControls.SectionC;

namespace NZTA_Contract_Generator
{
    public partial class ThisDocument
    {

        public Control apc;
        public Contract contract;

        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {

            //See if we have saved state
            contract = Util.XML.loadFromXML();
            if (contract == null)
            {
                contract = new Contract();
            }

            //Add save handler
            this.BeforeSave += new Microsoft.Office.Tools.Word.SaveEventHandler(ThisDocument_BeforeSave);
            
            //Add NavTree
            this.ActionsPane.Controls.Add(new ActionPaneControls.NavTreeAPC());

            //Add edit form
            apc = new ActionPaneControls.ContractSetup.ContractDetails();
            this.ActionsPane.Controls.Add(apc);

            //We want nav tree then edit form
            this.ActionsPane.StackOrder = Microsoft.Office.Tools.StackStyle.FromLeft;            
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
            this.richTextContentControl1.Entering += new Microsoft.Office.Tools.Word.ContentControlEnteringEventHandler(this.richTextContentControl1_Entering);
            this.rtcSupplierSelectoionMethodName.Entering += new Microsoft.Office.Tools.Word.ContentControlEnteringEventHandler(this.rtcSupplierSelectoionMethodName_Entering);
            this.Startup += new System.EventHandler(this.ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(this.ThisDocument_Shutdown);

        }

        #endregion


        private void richTextContentControl43_Entering(object sender, ContentControlEnteringEventArgs e)
        {

        }

        private void richTextContentControl47_Entering(object sender, ContentControlEnteringEventArgs e)
        {

        }

        private void rtcSupplierSelectoionMethodName_Entering(object sender, ContentControlEnteringEventArgs e)
        {

        }

        private void richTextContentControl1_Entering(object sender, ContentControlEnteringEventArgs e)
        {

        }
    }
}
