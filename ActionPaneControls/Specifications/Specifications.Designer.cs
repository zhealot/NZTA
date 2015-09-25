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
            this.BridgesOther = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Project1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MultipleProjects_Yes = new System.Windows.Forms.RadioButton();
            this.MultipleProjects_No = new System.Windows.Forms.RadioButton();
            this.StateHighway = new System.Windows.Forms.CheckBox();
            this.OtherSpecification = new System.Windows.Forms.CheckBox();
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
            this.label2.Size = new System.Drawing.Size(215, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select which Specifications are included in your Tender/Contract document.\r\n";
            // 
            // BridgesOther
            // 
            this.BridgesOther.Location = new System.Drawing.Point(5, 87);
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
            this.groupBox1.Location = new System.Drawing.Point(5, 191);
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
            // StateHighway
            // 
            this.StateHighway.Location = new System.Drawing.Point(5, 116);
            this.StateHighway.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.StateHighway.Name = "StateHighway";
            this.StateHighway.Size = new System.Drawing.Size(212, 22);
            this.StateHighway.TabIndex = 7;
            this.StateHighway.Text = "State Highway Traffic Monitoring";
            this.StateHighway.UseVisualStyleBackColor = true;
            this.StateHighway.CheckedChanged += new System.EventHandler(this.BridgesOther_CheckedChanged);
            // 
            // OtherSpecification
            // 
            this.OtherSpecification.Location = new System.Drawing.Point(5, 144);
            this.OtherSpecification.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.OtherSpecification.Name = "OtherSpecification";
            this.OtherSpecification.Size = new System.Drawing.Size(212, 22);
            this.OtherSpecification.TabIndex = 7;
            this.OtherSpecification.Text = "Other";
            this.OtherSpecification.UseVisualStyleBackColor = true;
            this.OtherSpecification.CheckedChanged += new System.EventHandler(this.OtherSpecification_Changed);
            // 
            // Specifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OtherSpecification);
            this.Controls.Add(this.StateHighway);
            this.Controls.Add(this.BridgesOther);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Specifications";
            this.Size = new System.Drawing.Size(241, 363);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox BridgesOther;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Project1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton MultipleProjects_Yes;
        private System.Windows.Forms.RadioButton MultipleProjects_No;
        private System.Windows.Forms.CheckBox StateHighway;
        private System.Windows.Forms.CheckBox OtherSpecification;
    }
}
