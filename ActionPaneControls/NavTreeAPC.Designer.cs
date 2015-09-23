namespace NZTA_Contract_Generator.ActionPaneControls
{
    [System.ComponentModel.ToolboxItemAttribute(false)]
    partial class NavTreeAPC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Contract Details");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Interactive Tender Process");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Pricing Options");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Tender Submission Programme");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Tender Format");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Tender Evaluation Procedure");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Liability and Insurance");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Contract Setup", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Supplier Selection Method");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Non-Price Attibutes");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Supplier Selection Method", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Specifications");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Personnel");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Personnel", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Contract Pricing");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Section C", new System.Windows.Forms.TreeNode[] {
            treeNode15});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "ContractSetup.ContractDetails";
            treeNode1.Tag = "Contract_Details";
            treeNode1.Text = "Contract Details";
            treeNode2.Name = "ContractSetup.InteractiveTenderProcess";
            treeNode2.Tag = "Interactive_Tender_Process";
            treeNode2.Text = "Interactive Tender Process";
            treeNode3.Name = "ContractSetup.PricingOptions";
            treeNode3.Tag = "Pricing_Options";
            treeNode3.Text = "Pricing Options";
            treeNode4.Name = "ContractSetup.TenderSubmissionProgramme";
            treeNode4.Tag = "Tender_Submission_Programme";
            treeNode4.Text = "Tender Submission Programme";
            treeNode5.Name = "ContractSetup.TenderFormat";
            treeNode5.Tag = "Tender_Format";
            treeNode5.Text = "Tender Format";
            treeNode6.Name = "ContractSetup.TenderEvaluationProcedure";
            treeNode6.Tag = "Tender_Evaluation_Procedure";
            treeNode6.Text = "Tender Evaluation Procedure";
            treeNode7.Name = "ContractSetup.LiabilityandInsurance";
            treeNode7.Tag = "Liability_Insurance";
            treeNode7.Text = "Liability and Insurance";
            treeNode8.Name = "Node0";
            treeNode8.Tag = "Contract_Details";
            treeNode8.Text = "Contract Setup";
            treeNode9.Name = "SupplierSelectionMethod.SupplierSelectionMethod";
            treeNode9.Tag = "Supplier_Selection_Method";
            treeNode9.Text = "Supplier Selection Method";
            treeNode10.Name = "SupplierSelectionMethod.NonPriceAttributes";
            treeNode10.Tag = "Non_Price_Attributes";
            treeNode10.Text = "Non-Price Attibutes";
            treeNode11.Name = "SupplierSelectionMethod.SupplierSelectionMethod";
            treeNode11.Text = "Supplier Selection Method";
            treeNode12.Name = "Specifications.Specifications";
            treeNode12.Tag = "bmRFTDocuments";
            treeNode12.Text = "Specifications";
            treeNode13.Name = "Personnel.Personnel";
            treeNode13.Tag = "Personnel";
            treeNode13.Text = "Personnel";
            treeNode14.Name = "Personnel.Personnel";
            treeNode14.Text = "Personnel";
            treeNode15.Name = "SectionC.ContractPricing";
            treeNode15.Tag = "Contract_Pricing";
            treeNode15.Text = "Contract Pricing";
            treeNode16.Name = "SectionC";
            treeNode16.Text = "Section C";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode11,
            treeNode12,
            treeNode14,
            treeNode16});
            this.treeView1.Size = new System.Drawing.Size(268, 650);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // NavTreeAPC
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.treeView1);
            this.Name = "NavTreeAPC";
            this.Size = new System.Drawing.Size(271, 653);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
    }
}
