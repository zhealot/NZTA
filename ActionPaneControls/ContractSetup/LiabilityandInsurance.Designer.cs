namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    [System.ComponentModel.ToolboxItemAttribute(false)]
    partial class LiabilityandInsurance
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.MaximumLiability = new System.Windows.Forms.TextBox();
            this.DurationOfLiability = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PublicLiabilityInsurance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(106)))));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Liability and Insurance";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Do Insurance Levels require approval by the Risk/Insurance Sub VAC?";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(6, 91);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(225, 41);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "No. Risk/Insurance Sub VAC approval is not required";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(6, 138);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(225, 41);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "YES. Levels have been approved at default levels";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(6, 185);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(225, 41);
            this.radioButton3.TabIndex = 6;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "YES. Other levels have been approved";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 33);
            this.label3.TabIndex = 7;
            this.label3.Text = "The maximum amount payable for Limitation of Liability shall be:";
            // 
            // MaximumLiability
            // 
            this.MaximumLiability.Location = new System.Drawing.Point(6, 270);
            this.MaximumLiability.Name = "MaximumLiability";
            this.MaximumLiability.Size = new System.Drawing.Size(225, 20);
            this.MaximumLiability.TabIndex = 8;
            this.MaximumLiability.TextChanged += new System.EventHandler(this.MaximumLiability_TextChanged);
            // 
            // DurationOfLiability
            // 
            this.DurationOfLiability.Location = new System.Drawing.Point(6, 328);
            this.DurationOfLiability.Name = "DurationOfLiability";
            this.DurationOfLiability.Size = new System.Drawing.Size(225, 20);
            this.DurationOfLiability.TabIndex = 10;
            this.DurationOfLiability.TextChanged += new System.EventHandler(this.DurationOfLiability_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "The Duration of the Liability period shall be:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 63);
            this.label5.TabIndex = 11;
            this.label5.Text = "Guidance Note: As per approval e.g. 6 years from the date on which the Servies we" +
    "re completed OR 6 years from the issue of Defects Liability Certificate";
            // 
            // PublicLiabilityInsurance
            // 
            this.PublicLiabilityInsurance.Location = new System.Drawing.Point(6, 440);
            this.PublicLiabilityInsurance.Name = "PublicLiabilityInsurance";
            this.PublicLiabilityInsurance.Size = new System.Drawing.Size(225, 20);
            this.PublicLiabilityInsurance.TabIndex = 12;
            this.PublicLiabilityInsurance.TextChanged += new System.EventHandler(this.PublicLiabilityInsurance_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 418);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "The amount of Public Liability Insurance will be: ";
            // 
            // LiabilityandInsurance
            // 
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PublicLiabilityInsurance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DurationOfLiability);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MaximumLiability);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LiabilityandInsurance";
            this.Size = new System.Drawing.Size(280, 650);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MaximumLiability;
        private System.Windows.Forms.TextBox DurationOfLiability;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PublicLiabilityInsurance;
        private System.Windows.Forms.Label label6;
    }
}
