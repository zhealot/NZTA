using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace NZTA_Contract_Generator.ActionPaneControls
{
    partial class NavTreeAPC : UserControl
    {
        public NavTreeAPC()
        {
            InitializeComponent();
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                Type toCreate = Type.GetType("NZTA_Contract_Generator.ActionPaneControls."+e.Node.Name, true);
                Globals.ThisDocument.ActionsPane.Controls.Remove(Globals.ThisDocument.apc);
                Globals.ThisDocument.apc = (Control)Activator.CreateInstance(toCreate);
                Globals.ThisDocument.ActionsPane.Controls.Add(Globals.ThisDocument.apc);
            }
            catch (System.TypeLoadException ex)
            { 
                Globals.ThisDocument.ActionsPane.Controls.Remove(Globals.ThisDocument.apc);
                Console.WriteLine(ex.Message);
            }
            //select the bookmark by node tag, test for commit 10:13
            if (e.Node.Tag != null && Globals.ThisDocument.Bookmarks.Exists(e.Node.Tag.ToString()))
            {
                //NZTA_Contract_Generator.Globals.ThisDocument.Bookmarks[e.Node.Tag].Select();
                object  bm =Globals.ThisDocument.Bookmarks[e.Node.Tag];
                Globals.ThisDocument.Application.Selection.GoTo(Microsoft.Office.Interop.Word.WdGoToItem.wdGoToBookmark,Name:ref bm);                
            }
        }
    }
}
