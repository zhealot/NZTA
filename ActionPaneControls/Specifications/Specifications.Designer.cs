namespace NZTA_Contract_Generator.ActionPaneControls.Specifications
{
    partial class Specifications
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ContractManagemnet = new System.Windows.Forms.CheckBox();
            this.InvestigationReporting = new System.Windows.Forms.CheckBox();
            this.DesignProject = new System.Windows.Forms.CheckBox();
            this.DesignConstruct = new System.Windows.Forms.CheckBox();
            this.MSQA = new System.Windows.Forms.CheckBox();
            this.NetworkMangement = new System.Windows.Forms.CheckBox();
            this.HybridContract = new System.Windows.Forms.CheckBox();
            this.BridgesOther = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Project1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MultipleProjects_Yes = new System.Windows.Forms.RadioButton();
            this.MultipleProjects_No = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(106)))));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Specifications";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 73);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select which Specifications are included in your Tender/Contract document.\r\nStruc" +
    "ture the Pricing Schedules for easy completion.";
            // 
            // ContractManagemnet
            // 
            this.ContractManagemnet.Location = new System.Drawing.Point(17, 110);
            this.ContractManagemnet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ContractManagemnet.Name = "ContractManagemnet";
            this.ContractManagemnet.Size = new System.Drawing.Size(206, 75);
            this.ContractManagemnet.TabIndex = 7;
            this.ContractManagemnet.Text = "Contract Management (not required if \'Network Management\' or \'Hybrid Contract Spe" +
    "cification\' have been chosen.)";
            this.ContractManagemnet.UseVisualStyleBackColor = true;
            this.ContractManagemnet.CheckedChanged += new System.EventHandler(this.ContractManagemnet_CheckedChanged);
            // 
            // InvestigationReporting
            // 
            this.InvestigationReporting.Location = new System.Drawing.Point(17, 190);
            this.InvestigationReporting.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.InvestigationReporting.Name = "InvestigationReporting";
            this.InvestigationReporting.Size = new System.Drawing.Size(194, 24);
            this.InvestigationReporting.TabIndex = 7;
            this.InvestigationReporting.Text = "Investigation && Reporting";
            this.InvestigationReporting.UseVisualStyleBackColor = true;
            this.InvestigationReporting.CheckedChanged += new System.EventHandler(this.InvestigationReporting_CheckedChanged);
            // 
            // DesignProject
            // 
            this.DesignProject.Location = new System.Drawing.Point(17, 220);
            this.DesignProject.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DesignProject.Name = "DesignProject";
            this.DesignProject.Size = new System.Drawing.Size(206, 50);
            this.DesignProject.TabIndex = 7;
            this.DesignProject.Text = "Design && Project Documentation (do not include if selecting Design && Construct " +
    "Contracts.)";
            this.DesignProject.UseVisualStyleBackColor = true;
            this.DesignProject.CheckedChanged += new System.EventHandler(this.DesignProject_CheckedChanged);
            // 
            // DesignConstruct
            // 
            this.DesignConstruct.Location = new System.Drawing.Point(17, 275);
            this.DesignConstruct.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DesignConstruct.Name = "DesignConstruct";
            this.DesignConstruct.Size = new System.Drawing.Size(206, 63);
            this.DesignConstruct.TabIndex = 7;
            this.DesignConstruct.Text = "Design && Construct Contracts - Specimen Design && Project Documentation (do not " +
    "include if selecting Design && Project Document.)";
            this.DesignConstruct.UseVisualStyleBackColor = true;
            this.DesignConstruct.CheckedChanged += new System.EventHandler(this.DesignConstruct_CheckedChanged);
            // 
            // MSQA
            // 
            this.MSQA.Location = new System.Drawing.Point(17, 344);
            this.MSQA.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MSQA.Name = "MSQA";
            this.MSQA.Size = new System.Drawing.Size(194, 36);
            this.MSQA.TabIndex = 7;
            this.MSQA.Text = "Management, Suveillance && Quality Assurance";
            this.MSQA.UseVisualStyleBackColor = true;
            this.MSQA.CheckedChanged += new System.EventHandler(this.MSQA_CheckedChanged);
            // 
            // NetworkMangement
            // 
            this.NetworkMangement.Location = new System.Drawing.Point(17, 385);
            this.NetworkMangement.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.NetworkMangement.Name = "NetworkMangement";
            this.NetworkMangement.Size = new System.Drawing.Size(194, 23);
            this.NetworkMangement.TabIndex = 7;
            this.NetworkMangement.Text = "Network Mangement";
            this.NetworkMangement.UseVisualStyleBackColor = true;
            this.NetworkMangement.CheckedChanged += new System.EventHandler(this.NetworkMangement_CheckedChanged);
            // 
            // HybridContract
            // 
            this.HybridContract.Location = new System.Drawing.Point(17, 413);
            this.HybridContract.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.HybridContract.Name = "HybridContract";
            this.HybridContract.Size = new System.Drawing.Size(194, 23);
            this.HybridContract.TabIndex = 7;
            this.HybridContract.Text = "Hybrid Contract Management";
            this.HybridContract.UseVisualStyleBackColor = true;
            this.HybridContract.CheckedChanged += new System.EventHandler(this.HybridContract_CheckedChanged);
            // 
            // BridgesOther
            // 
            this.BridgesOther.Location = new System.Drawing.Point(17, 442);
            this.BridgesOther.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BridgesOther.Name = "BridgesOther";
            this.BridgesOther.Size = new System.Drawing.Size(194, 23);
            this.BridgesOther.TabIndex = 7;
            this.BridgesOther.Text = "Bridges && Other Structures";
            this.BridgesOther.UseVisualStyleBackColor = true;
            this.BridgesOther.CheckedChanged += new System.EventHandler(this.BridgesOther_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Project1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.MultipleProjects_Yes);
            this.groupBox1.Controls.Add(this.MultipleProjects_No);
            this.groupBox1.Location = new System.Drawing.Point(5, 483);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(215, 169);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2. Do you have multiple projects or regions for this Contract?";
            // 
            // Project1
            // 
            this.Project1.Location = new System.Drawing.Point(84, 128);
            this.Project1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Project1.Name = "Project1";
            this.Project1.Size = new System.Drawing.Size(128, 20);
            this.Project1.TabIndex = 2;
            this.Project1.TextChanged += new System.EventHandler(this.Project1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Project Name";
            // 
            // MultipleProjects_Yes
            // 
            this.MultipleProjects_Yes.Location = new System.Drawing.Point(4, 70);
            this.MultipleProjects_Yes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MultipleProjects_Yes.Name = "MultipleProjects_Yes";
            this.MultipleProjects_Yes.Size = new System.Drawing.Size(206, 58);
            this.MultipleProjects_Yes.TabIndex = 0;
            this.MultipleProjects_Yes.TabStop = true;
            this.MultipleProjects_Yes.Text = "Yes, select to enable the option to price items for individual projects and name " +
    "the projects below:";
            this.MultipleProjects_Yes.UseVisualStyleBackColor = true;
            this.MultipleProjects_Yes.CheckedChanged += new System.EventHandler(this.MultipleProjects_Yes_CheckedChanged);
            // 
            // MultipleProjects_No
            // 
            this.MultipleProjects_No.AutoSize = true;
            this.MultipleProjects_No.Location = new System.Drawing.Point(4, 49);
            this.MultipleProjects_No.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MultipleProjects_No.Name = "MultipleProjects_No";
            this.MultipleProjects_No.Size = new System.Drawing.Size(168, 17);
            this.MultipleProjects_No.TabIndex = 0;
            this.MultipleProjects_No.TabStop = true;
            this.MultipleProjects_No.Text = "No, select to price as one item";
            this.MultipleProjects_No.UseVisualStyleBackColor = true;
            this.MultipleProjects_No.CheckedChanged += new System.EventHandler(this.MultipleProjects_No_CheckedChanged);
            // 
            // Specifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DesignConstruct);
            this.Controls.Add(this.DesignProject);
            this.Controls.Add(this.BridgesOther);
            this.Controls.Add(this.HybridContract);
            this.Controls.Add(this.NetworkMangement);
            this.Controls.Add(this.MSQA);
            this.Controls.Add(this.InvestigationReporting);
            this.Controls.Add(this.ContractManagemnet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Specifications";
            this.Size = new System.Drawing.Size(241, 775);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ContractManagemnet;
        private System.Windows.Forms.CheckBox InvestigationReporting;
        private System.Windows.Forms.CheckBox DesignProject;
        private System.Windows.Forms.CheckBox DesignConstruct;
        private System.Windows.Forms.CheckBox MSQA;
        private System.Windows.Forms.CheckBox NetworkMangement;
        private System.Windows.Forms.CheckBox HybridContract;
        private System.Windows.Forms.CheckBox BridgesOther;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Project1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton MultipleProjects_Yes;
        private System.Windows.Forms.RadioButton MultipleProjects_No;
    }
}
