﻿using System;
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
                NZTA_Contract_Generator.Globals.ThisDocument.ActionsPane.Controls.Remove(NZTA_Contract_Generator.Globals.ThisDocument.apc);
                NZTA_Contract_Generator.Globals.ThisDocument.apc = (Control)Activator.CreateInstance(toCreate);
                NZTA_Contract_Generator.Globals.ThisDocument.ActionsPane.Controls.Add(NZTA_Contract_Generator.Globals.ThisDocument.apc);
            }
            catch (System.TypeLoadException ex)
            { 
                NZTA_Contract_Generator.Globals.ThisDocument.ActionsPane.Controls.Remove(NZTA_Contract_Generator.Globals.ThisDocument.apc);
                Console.WriteLine(ex.Message);
            }
            //select the bookmark by node tag, test for commit 10:13
            if (e.Node.Tag != null && NZTA_Contract_Generator.Globals.ThisDocument.Bookmarks.Exists(e.Node.Tag.ToString()))
            {
                //NZTA_Contract_Generator.Globals.ThisDocument.Bookmarks[e.Node.Tag].Select();
                object  bm =NZTA_Contract_Generator.Globals.ThisDocument.Bookmarks[e.Node.Tag];
                NZTA_Contract_Generator.Globals.ThisDocument.Application.Selection.GoTo(Microsoft.Office.Interop.Word.WdGoToItem.wdGoToBookmark,Name:ref bm);                
            }
        }
    }
}
