namespace NZTA_Contract_Generator
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.CGTAB = this.Factory.CreateRibbonTab();
            this.DisplayOptionsGroup = this.Factory.CreateRibbonGroup();
            this.ExportGroup = this.Factory.CreateRibbonGroup();
            this.toggleButton1 = this.Factory.CreateRibbonToggleButton();
            this.ExportWordButton = this.Factory.CreateRibbonButton();
            this.ExportDraftButton = this.Factory.CreateRibbonButton();
            this.ExportFinalButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.CGTAB.SuspendLayout();
            this.DisplayOptionsGroup.SuspendLayout();
            this.ExportGroup.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            this.tab1.Visible = false;
            // 
            // group1
            // 
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // CGTAB
            // 
            this.CGTAB.Groups.Add(this.DisplayOptionsGroup);
            this.CGTAB.Groups.Add(this.ExportGroup);
            this.CGTAB.Label = "Contract Generator";
            this.CGTAB.Name = "CGTAB";
            // 
            // DisplayOptionsGroup
            // 
            this.DisplayOptionsGroup.Items.Add(this.toggleButton1);
            this.DisplayOptionsGroup.Label = "Display Options";
            this.DisplayOptionsGroup.Name = "DisplayOptionsGroup";
            // 
            // ExportGroup
            // 
            this.ExportGroup.Items.Add(this.ExportWordButton);
            this.ExportGroup.Items.Add(this.ExportDraftButton);
            this.ExportGroup.Items.Add(this.ExportFinalButton);
            this.ExportGroup.Label = "Export";
            this.ExportGroup.Name = "ExportGroup";
            // 
            // toggleButton1
            // 
            this.toggleButton1.Checked = true;
            this.toggleButton1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleButton1.Image = global::NZTA_Contract_Generator.Properties.Resources.Control_Panel;
            this.toggleButton1.Label = "Toggle Navigation Tree";
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.ShowImage = true;
            this.toggleButton1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButton1_Click);
            // 
            // ExportWordButton
            // 
            this.ExportWordButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ExportWordButton.Image = global::NZTA_Contract_Generator.Properties.Resources.Word;
            this.ExportWordButton.Label = "Word";
            this.ExportWordButton.Name = "ExportWordButton";
            this.ExportWordButton.ShowImage = true;
            this.ExportWordButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ExportWordButton_Click);
            // 
            // ExportDraftButton
            // 
            this.ExportDraftButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ExportDraftButton.Image = global::NZTA_Contract_Generator.Properties.Resources.Draft_PDF;
            this.ExportDraftButton.Label = "Draft PDF";
            this.ExportDraftButton.Name = "ExportDraftButton";
            this.ExportDraftButton.ShowImage = true;
            this.ExportDraftButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ExportDraftButton_Click);
            // 
            // ExportFinalButton
            // 
            this.ExportFinalButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ExportFinalButton.Image = global::NZTA_Contract_Generator.Properties.Resources.Final_PDF;
            this.ExportFinalButton.Label = "Final PDF";
            this.ExportFinalButton.Name = "ExportFinalButton";
            this.ExportFinalButton.ShowImage = true;
            this.ExportFinalButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ExportFinalButton_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.CGTAB);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.CGTAB.ResumeLayout(false);
            this.CGTAB.PerformLayout();
            this.DisplayOptionsGroup.ResumeLayout(false);
            this.DisplayOptionsGroup.PerformLayout();
            this.ExportGroup.ResumeLayout(false);
            this.ExportGroup.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        private Microsoft.Office.Tools.Ribbon.RibbonTab CGTAB;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup DisplayOptionsGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup ExportGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ExportWordButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ExportFinalButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ExportDraftButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton1;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
