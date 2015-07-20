namespace NZTA_Contract_Generator.ActionPaneControls.SectionC
{
    partial class ContractPricing
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
            this.label12 = new System.Windows.Forms.Label();
            this.CP_Total = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbMissing = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(106)))));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contract Pricing";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(67, 569);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(185, 29);
            this.label12.TabIndex = 0;
            this.label12.Text = "TOTAL TENDERED SUM/TARGET PRICE (excluding GST)";
            // 
            // CP_Total
            // 
            this.CP_Total.Enabled = false;
            this.CP_Total.Location = new System.Drawing.Point(248, 576);
            this.CP_Total.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CP_Total.Name = "CP_Total";
            this.CP_Total.Size = new System.Drawing.Size(120, 20);
            this.CP_Total.TabIndex = 2;
            this.CP_Total.TextChanged += new System.EventHandler(this.CP_Total_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Contract Pricing Schedule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbMissing
            // 
            this.lbMissing.FormattingEnabled = true;
            this.lbMissing.Location = new System.Drawing.Point(8, 114);
            this.lbMissing.Name = "lbMissing";
            this.lbMissing.Size = new System.Drawing.Size(279, 355);
            this.lbMissing.TabIndex = 4;
            // 
            // ContractPricing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbMissing);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CP_Total);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ContractPricing";
            this.Size = new System.Drawing.Size(380, 601);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox CP_Total;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lbMissing;
    }
}
