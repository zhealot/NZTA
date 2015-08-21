namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    [System.ComponentModel.ToolboxItemAttribute(false)]
    partial class PricingOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PricingOptions));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BaseEstimate_Amount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ProvisionalSumAmount = new System.Windows.Forms.TextBox();
            this.BrooksLaw_Check = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TargetPriceAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TargetPriceAmountInWords = new System.Windows.Forms.TextBox();
            this.gbBaseEstimate = new System.Windows.Forms.GroupBox();
            this.gbTargetPrice = new System.Windows.Forms.GroupBox();
            this.BaseEstimate_Check = new System.Windows.Forms.RadioButton();
            this.TargetPrice_Check = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbBaseEstimate.SuspendLayout();
            this.gbTargetPrice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(106)))));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pricing Options";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 101);
            this.label2.TabIndex = 4;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Base Estimate Amount   $ ";
            // 
            // BaseEstimate_Amount
            // 
            this.BaseEstimate_Amount.Location = new System.Drawing.Point(140, 14);
            this.BaseEstimate_Amount.Name = "BaseEstimate_Amount";
            this.BaseEstimate_Amount.Size = new System.Drawing.Size(122, 20);
            this.BaseEstimate_Amount.TabIndex = 7;
            this.BaseEstimate_Amount.TextChanged += new System.EventHandler(this.BaseEstimate_Amount_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 31);
            this.label4.TabIndex = 8;
            this.label4.Text = "Includes fixed amounts of Provisional sum              $";
            // 
            // ProvisionalSumAmount
            // 
            this.ProvisionalSumAmount.Location = new System.Drawing.Point(140, 54);
            this.ProvisionalSumAmount.Name = "ProvisionalSumAmount";
            this.ProvisionalSumAmount.Size = new System.Drawing.Size(122, 20);
            this.ProvisionalSumAmount.TabIndex = 9;
            this.ProvisionalSumAmount.TextChanged += new System.EventHandler(this.ProvisionalSumAmount_TextChanged);
            // 
            // BrooksLaw_Check
            // 
            this.BrooksLaw_Check.AutoSize = true;
            this.BrooksLaw_Check.Location = new System.Drawing.Point(0, 86);
            this.BrooksLaw_Check.Name = "BrooksLaw_Check";
            this.BrooksLaw_Check.Size = new System.Drawing.Size(84, 17);
            this.BrooksLaw_Check.TabIndex = 10;
            this.BrooksLaw_Check.Text = "Brook\'s Law";
            this.BrooksLaw_Check.UseVisualStyleBackColor = true;
            this.BrooksLaw_Check.CheckedChanged += new System.EventHandler(this.BrooksLaw_Check_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Target Price Amount     $";
            // 
            // TargetPriceAmount
            // 
            this.TargetPriceAmount.Location = new System.Drawing.Point(140, 13);
            this.TargetPriceAmount.Name = "TargetPriceAmount";
            this.TargetPriceAmount.Size = new System.Drawing.Size(122, 20);
            this.TargetPriceAmount.TabIndex = 14;
            this.TargetPriceAmount.TextChanged += new System.EventHandler(this.TargetPriceAmount_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Target Price Amount in words";
            // 
            // TargetPriceAmountInWords
            // 
            this.TargetPriceAmountInWords.Location = new System.Drawing.Point(3, 78);
            this.TargetPriceAmountInWords.Name = "TargetPriceAmountInWords";
            this.TargetPriceAmountInWords.Size = new System.Drawing.Size(259, 20);
            this.TargetPriceAmountInWords.TabIndex = 16;
            this.TargetPriceAmountInWords.TextChanged += new System.EventHandler(this.TargetPriceAmountInWords_TextChanged);
            // 
            // gbBaseEstimate
            // 
            this.gbBaseEstimate.Controls.Add(this.BrooksLaw_Check);
            this.gbBaseEstimate.Controls.Add(this.label3);
            this.gbBaseEstimate.Controls.Add(this.BaseEstimate_Amount);
            this.gbBaseEstimate.Controls.Add(this.label4);
            this.gbBaseEstimate.Controls.Add(this.ProvisionalSumAmount);
            this.gbBaseEstimate.Location = new System.Drawing.Point(2, 212);
            this.gbBaseEstimate.Name = "gbBaseEstimate";
            this.gbBaseEstimate.Size = new System.Drawing.Size(274, 113);
            this.gbBaseEstimate.TabIndex = 17;
            this.gbBaseEstimate.TabStop = false;
            // 
            // gbTargetPrice
            // 
            this.gbTargetPrice.Controls.Add(this.label5);
            this.gbTargetPrice.Controls.Add(this.TargetPriceAmount);
            this.gbTargetPrice.Controls.Add(this.label6);
            this.gbTargetPrice.Controls.Add(this.TargetPriceAmountInWords);
            this.gbTargetPrice.Location = new System.Drawing.Point(3, 331);
            this.gbTargetPrice.Name = "gbTargetPrice";
            this.gbTargetPrice.Size = new System.Drawing.Size(273, 104);
            this.gbTargetPrice.TabIndex = 18;
            this.gbTargetPrice.TabStop = false;
            // 
            // BaseEstimate_Check
            // 
            this.BaseEstimate_Check.AutoSize = true;
            this.BaseEstimate_Check.Location = new System.Drawing.Point(6, 26);
            this.BaseEstimate_Check.Name = "BaseEstimate_Check";
            this.BaseEstimate_Check.Size = new System.Drawing.Size(92, 17);
            this.BaseEstimate_Check.TabIndex = 19;
            this.BaseEstimate_Check.TabStop = true;
            this.BaseEstimate_Check.Text = "Base Estimate";
            this.BaseEstimate_Check.UseVisualStyleBackColor = true;
            this.BaseEstimate_Check.CheckedChanged += new System.EventHandler(this.PricingOption_Changed);
            // 
            // TargetPrice_Check
            // 
            this.TargetPrice_Check.AutoSize = true;
            this.TargetPrice_Check.Location = new System.Drawing.Point(140, 26);
            this.TargetPrice_Check.Name = "TargetPrice_Check";
            this.TargetPrice_Check.Size = new System.Drawing.Size(83, 17);
            this.TargetPrice_Check.TabIndex = 19;
            this.TargetPrice_Check.TabStop = true;
            this.TargetPrice_Check.Text = "Target Price";
            this.TargetPrice_Check.UseVisualStyleBackColor = true;
            this.TargetPrice_Check.CheckedChanged += new System.EventHandler(this.PricingOption_Changed);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TargetPrice_Check);
            this.groupBox1.Controls.Add(this.BaseEstimate_Check);
            this.groupBox1.Location = new System.Drawing.Point(3, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 49);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pricing Option";
            // 
            // PricingOptions
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbTargetPrice);
            this.Controls.Add(this.gbBaseEstimate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PricingOptions";
            this.Size = new System.Drawing.Size(280, 462);
            this.gbBaseEstimate.ResumeLayout(false);
            this.gbBaseEstimate.PerformLayout();
            this.gbTargetPrice.ResumeLayout(false);
            this.gbTargetPrice.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BaseEstimate_Amount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ProvisionalSumAmount;
        private System.Windows.Forms.CheckBox BrooksLaw_Check;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TargetPriceAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TargetPriceAmountInWords;
        private System.Windows.Forms.GroupBox gbBaseEstimate;
        private System.Windows.Forms.GroupBox gbTargetPrice;
        private System.Windows.Forms.RadioButton BaseEstimate_Check;
        private System.Windows.Forms.RadioButton TargetPrice_Check;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
