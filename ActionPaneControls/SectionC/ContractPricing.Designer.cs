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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(106)))));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contract Pricing";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(89, 657);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(247, 33);
            this.label12.TabIndex = 0;
            this.label12.Text = "TOTAL TENDERED SUM/TARGET PRICE (excluding GST)";
            // 
            // CP_Total
            // 
            this.CP_Total.Enabled = false;
            this.CP_Total.Location = new System.Drawing.Point(331, 665);
            this.CP_Total.Name = "CP_Total";
            this.CP_Total.Size = new System.Drawing.Size(159, 25);
            this.CP_Total.TabIndex = 2;
            this.CP_Total.TextChanged += new System.EventHandler(this.CP_Total_TextChanged);
            // 
            // ContractPricing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CP_Total);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Name = "ContractPricing";
            this.Size = new System.Drawing.Size(507, 693);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox CP_Total;
    }
}
