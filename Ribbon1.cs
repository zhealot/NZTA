using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

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
            object what = Microsoft.Office.Interop.Word.WdGoToItem.wdGoToHeading;
            object which = Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToAbsolute;

            
            
            NZTA_Contract_Generator.Globals.ThisDocument.Content.Select();
            object findtext = "The NZ Transport Agency’s Expectations";
            object missing = System.Type.Missing;
            object style;
            if (NZTA_Contract_Generator.Globals.ThisDocument.Application.Selection.Find.Execute(ref findtext))
            {
                Console.WriteLine("found it!");
                style = NZTA_Contract_Generator.Globals.ThisDocument.Application.Selection.Paragraphs.OutlineLevel;
                //style = NZTA_Contract_Generator.Globals.ThisDocument.Application.Selection.Find.ParagraphFormat;

            }
            NZTA_Contract_Generator.Globals.ThisDocument.Application.Selection.Select();

        }

    }
}
