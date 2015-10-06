namespace NZTA_Contract_Generator.ActionPaneControls.Personnel
{
    [System.ComponentModel.ToolboxItemAttribute(false)]
    //[System.ComponentModel.ToolboxItem(false)]
    partial class Personnel
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
            this.lbPersonnel = new System.Windows.Forms.ListBox();
            this.tbWeighting = new System.Windows.Forms.TextBox();
            this.btnPS = new System.Windows.Forms.Button();
            this.btnASS = new System.Windows.Forms.Button();
            this.btnGetPersonnel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(106)))));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Personnel";
            // 
            // lbPersonnel
            // 
            this.lbPersonnel.FormattingEnabled = true;
            this.lbPersonnel.Location = new System.Drawing.Point(3, 61);
            this.lbPersonnel.Name = "lbPersonnel";
            this.lbPersonnel.Size = new System.Drawing.Size(250, 498);
            this.lbPersonnel.TabIndex = 0;
            this.lbPersonnel.SelectedIndexChanged += new System.EventHandler(this.lbPersonnel_SelectedIndexChanged);
            // 
            // tbWeighting
            // 
            this.tbWeighting.Location = new System.Drawing.Point(270, 61);
            this.tbWeighting.Multiline = true;
            this.tbWeighting.Name = "tbWeighting";
            this.tbWeighting.Size = new System.Drawing.Size(64, 498);
            this.tbWeighting.TabIndex = 1;
            this.tbWeighting.TextChanged += new System.EventHandler(this.tbWeighting_TextChanged);
            // 
            // btnPS
            // 
            this.btnPS.Location = new System.Drawing.Point(116, 577);
            this.btnPS.Name = "btnPS";
            this.btnPS.Size = new System.Drawing.Size(91, 36);
            this.btnPS.TabIndex = 3;
            this.btnPS.Text = "Personal Schedule";
            this.btnPS.UseVisualStyleBackColor = true;
            this.btnPS.Click += new System.EventHandler(this.btnPS_Click);
            // 
            // btnASS
            // 
            this.btnASS.Location = new System.Drawing.Point(213, 577);
            this.btnASS.Name = "btnASS";
            this.btnASS.Size = new System.Drawing.Size(106, 36);
            this.btnASS.TabIndex = 4;
            this.btnASS.Text = "Additional Services Schedule";
            this.btnASS.UseVisualStyleBackColor = true;
            this.btnASS.Click += new System.EventHandler(this.btnASS_Click);
            // 
            // btnGetPersonnel
            // 
            this.btnGetPersonnel.Location = new System.Drawing.Point(8, 577);
            this.btnGetPersonnel.Name = "btnGetPersonnel";
            this.btnGetPersonnel.Size = new System.Drawing.Size(91, 36);
            this.btnGetPersonnel.TabIndex = 2;
            this.btnGetPersonnel.Text = "Read Form B";
            this.btnGetPersonnel.UseVisualStyleBackColor = true;
            this.btnGetPersonnel.Click += new System.EventHandler(this.btnGetPersonnel_Click);
            // 
            // Personnel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnASS);
            this.Controls.Add(this.btnGetPersonnel);
            this.Controls.Add(this.btnPS);
            this.Controls.Add(this.tbWeighting);
            this.Controls.Add(this.lbPersonnel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Personnel";
            this.Size = new System.Drawing.Size(345, 624);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbPersonnel;
        private System.Windows.Forms.TextBox tbWeighting;
        private System.Windows.Forms.Button btnPS;
        private System.Windows.Forms.Button btnASS;
        private System.Windows.Forms.Button btnGetPersonnel;
    }
}
