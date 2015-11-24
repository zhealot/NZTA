namespace NZTA_Contract_Generator.ActionPaneControls.SectionC
{
    partial class PaymentSchedule
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
            this.UnitRate_chk = new System.Windows.Forms.CheckBox();
            this.HourlyRate_chk = new System.Windows.Forms.CheckBox();
            this.CostIndex = new System.Windows.Forms.NumericUpDown();
            this.lblCostIndex = new System.Windows.Forms.Label();
            this.help3 = new System.Windows.Forms.Button();
            this.CostFluctuations_Check = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.CostIndex)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Payment Schedule";
            // 
            // UnitRate_chk
            // 
            this.UnitRate_chk.AutoSize = true;
            this.UnitRate_chk.Location = new System.Drawing.Point(8, 60);
            this.UnitRate_chk.Name = "UnitRate_chk";
            this.UnitRate_chk.Size = new System.Drawing.Size(99, 17);
            this.UnitRate_chk.TabIndex = 0;
            this.UnitRate_chk.Text = "Unit Rate Items";
            this.UnitRate_chk.UseVisualStyleBackColor = true;
            this.UnitRate_chk.CheckedChanged += new System.EventHandler(this.UnitRate_chk_CheckedChanged);
            // 
            // HourlyRate_chk
            // 
            this.HourlyRate_chk.AutoSize = true;
            this.HourlyRate_chk.Location = new System.Drawing.Point(8, 98);
            this.HourlyRate_chk.Name = "HourlyRate_chk";
            this.HourlyRate_chk.Size = new System.Drawing.Size(110, 17);
            this.HourlyRate_chk.TabIndex = 1;
            this.HourlyRate_chk.Text = "Hourly Rate Items";
            this.HourlyRate_chk.UseVisualStyleBackColor = true;
            this.HourlyRate_chk.CheckedChanged += new System.EventHandler(this.HourlyRate_chk_CheckedChanged);
            // 
            // CostIndex
            // 
            this.CostIndex.DecimalPlaces = 2;
            this.CostIndex.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.CostIndex.Location = new System.Drawing.Point(88, 156);
            this.CostIndex.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CostIndex.Name = "CostIndex";
            this.CostIndex.Size = new System.Drawing.Size(79, 20);
            this.CostIndex.TabIndex = 3;
            this.CostIndex.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.CostIndex.ValueChanged += new System.EventHandler(this.CostIndex_ValueChanged);
            // 
            // lblCostIndex
            // 
            this.lblCostIndex.AutoSize = true;
            this.lblCostIndex.Location = new System.Drawing.Point(31, 158);
            this.lblCostIndex.Name = "lblCostIndex";
            this.lblCostIndex.Size = new System.Drawing.Size(39, 13);
            this.lblCostIndex.TabIndex = 104;
            this.lblCostIndex.Text = "Index: ";
            // 
            // help3
            // 
            this.help3.Location = new System.Drawing.Point(144, 127);
            this.help3.Name = "help3";
            this.help3.Size = new System.Drawing.Size(23, 23);
            this.help3.TabIndex = 103;
            this.help3.Text = "?";
            this.help3.UseVisualStyleBackColor = true;
            this.help3.Click += new System.EventHandler(this.help3_Click);
            // 
            // CostFluctuations_Check
            // 
            this.CostFluctuations_Check.AutoSize = true;
            this.CostFluctuations_Check.Location = new System.Drawing.Point(8, 131);
            this.CostFluctuations_Check.Name = "CostFluctuations_Check";
            this.CostFluctuations_Check.Size = new System.Drawing.Size(128, 17);
            this.CostFluctuations_Check.TabIndex = 2;
            this.CostFluctuations_Check.Text = "Pay Cost Fluctuations";
            this.CostFluctuations_Check.UseVisualStyleBackColor = true;
            this.CostFluctuations_Check.CheckedChanged += new System.EventHandler(this.CostFluctuations_Check_CheckedChanged);
            // 
            // PaymentSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.CostIndex);
            this.Controls.Add(this.lblCostIndex);
            this.Controls.Add(this.help3);
            this.Controls.Add(this.CostFluctuations_Check);
            this.Controls.Add(this.HourlyRate_chk);
            this.Controls.Add(this.UnitRate_chk);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "PaymentSchedule";
            this.Size = new System.Drawing.Size(317, 196);
            ((System.ComponentModel.ISupportInitialize)(this.CostIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox UnitRate_chk;
        private System.Windows.Forms.CheckBox HourlyRate_chk;
        private System.Windows.Forms.NumericUpDown CostIndex;
        private System.Windows.Forms.Label lblCostIndex;
        private System.Windows.Forms.Button help3;
        private System.Windows.Forms.CheckBox CostFluctuations_Check;
    }
}
