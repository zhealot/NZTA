namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    [System.ComponentModel.ToolboxItemAttribute(false)]
    partial class TenderEvaluationProcedure
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
            this.ETL_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ETL_Position = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ETL_Company = new System.Windows.Forms.TextBox();
            this.ET2_Company = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ET2_Position = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ET2_Name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ET3_Company = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ET3_Position = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ET3_Name = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.help1 = new System.Windows.Forms.Button();
            this.ET4_Company = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ET4_Position = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ET4_Name = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.AuditPeriod = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.TET2_Chk = new System.Windows.Forms.CheckBox();
            this.gbTET2 = new System.Windows.Forms.GroupBox();
            this.gbTET3 = new System.Windows.Forms.GroupBox();
            this.TET3_Chk = new System.Windows.Forms.CheckBox();
            this.gbTET4 = new System.Windows.Forms.GroupBox();
            this.TET4_Chk = new System.Windows.Forms.CheckBox();
            this.gbTET1 = new System.Windows.Forms.GroupBox();
            this.gbTET5 = new System.Windows.Forms.GroupBox();
            this.ET5_Company = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ET5_Position = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ET5_Name = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TET5_Chk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.AuditPeriod)).BeginInit();
            this.gbTET2.SuspendLayout();
            this.gbTET3.SuspendLayout();
            this.gbTET4.SuspendLayout();
            this.gbTET1.SuspendLayout();
            this.gbTET5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(106)))));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 59);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tender Evaluation Procedure";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name of Evaluation Team Leader:";
            // 
            // ETL_Name
            // 
            this.ETL_Name.Location = new System.Drawing.Point(9, 41);
            this.ETL_Name.Name = "ETL_Name";
            this.ETL_Name.Size = new System.Drawing.Size(212, 20);
            this.ETL_Name.TabIndex = 0;
            this.ETL_Name.TextChanged += new System.EventHandler(this.TeamLeader_Change);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Position 1:";
            // 
            // ETL_Position
            // 
            this.ETL_Position.Location = new System.Drawing.Point(81, 65);
            this.ETL_Position.Name = "ETL_Position";
            this.ETL_Position.Size = new System.Drawing.Size(140, 20);
            this.ETL_Position.TabIndex = 1;
            this.ETL_Position.TextChanged += new System.EventHandler(this.TeamLeader_Change);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Company 1:";
            // 
            // ETL_Company
            // 
            this.ETL_Company.Location = new System.Drawing.Point(81, 89);
            this.ETL_Company.Name = "ETL_Company";
            this.ETL_Company.Size = new System.Drawing.Size(140, 20);
            this.ETL_Company.TabIndex = 2;
            this.ETL_Company.TextChanged += new System.EventHandler(this.TeamLeader_Change);
            // 
            // ET2_Company
            // 
            this.ET2_Company.Location = new System.Drawing.Point(78, 75);
            this.ET2_Company.Name = "ET2_Company";
            this.ET2_Company.Size = new System.Drawing.Size(140, 20);
            this.ET2_Company.TabIndex = 5;
            this.ET2_Company.TextChanged += new System.EventHandler(this.Text_Change);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Company 2:";
            // 
            // ET2_Position
            // 
            this.ET2_Position.Location = new System.Drawing.Point(78, 51);
            this.ET2_Position.Name = "ET2_Position";
            this.ET2_Position.Size = new System.Drawing.Size(140, 20);
            this.ET2_Position.TabIndex = 4;
            this.ET2_Position.TextChanged += new System.EventHandler(this.Text_Change);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Position 2:";
            // 
            // ET2_Name
            // 
            this.ET2_Name.Location = new System.Drawing.Point(78, 27);
            this.ET2_Name.Name = "ET2_Name";
            this.ET2_Name.Size = new System.Drawing.Size(140, 20);
            this.ET2_Name.TabIndex = 3;
            this.ET2_Name.TextChanged += new System.EventHandler(this.Text_Change);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Name 2:";
            // 
            // ET3_Company
            // 
            this.ET3_Company.Location = new System.Drawing.Point(81, 72);
            this.ET3_Company.Name = "ET3_Company";
            this.ET3_Company.Size = new System.Drawing.Size(140, 20);
            this.ET3_Company.TabIndex = 8;
            this.ET3_Company.TextChanged += new System.EventHandler(this.Text_Change);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Company 3:";
            // 
            // ET3_Position
            // 
            this.ET3_Position.Location = new System.Drawing.Point(81, 48);
            this.ET3_Position.Name = "ET3_Position";
            this.ET3_Position.Size = new System.Drawing.Size(140, 20);
            this.ET3_Position.TabIndex = 7;
            this.ET3_Position.TextChanged += new System.EventHandler(this.Text_Change);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Position 3:";
            // 
            // ET3_Name
            // 
            this.ET3_Name.Location = new System.Drawing.Point(81, 24);
            this.ET3_Name.Name = "ET3_Name";
            this.ET3_Name.Size = new System.Drawing.Size(140, 20);
            this.ET3_Name.TabIndex = 6;
            this.ET3_Name.TextChanged += new System.EventHandler(this.Text_Change);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Name 3:";
            // 
            // help1
            // 
            this.help1.Location = new System.Drawing.Point(198, 12);
            this.help1.Name = "help1";
            this.help1.Size = new System.Drawing.Size(23, 23);
            this.help1.TabIndex = 23;
            this.help1.Text = "?";
            this.help1.UseVisualStyleBackColor = true;
            this.help1.Click += new System.EventHandler(this.help1_Click);
            // 
            // ET4_Company
            // 
            this.ET4_Company.Location = new System.Drawing.Point(81, 75);
            this.ET4_Company.Name = "ET4_Company";
            this.ET4_Company.Size = new System.Drawing.Size(140, 20);
            this.ET4_Company.TabIndex = 11;
            this.ET4_Company.TextChanged += new System.EventHandler(this.Text_Change);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Company 4:";
            // 
            // ET4_Position
            // 
            this.ET4_Position.Location = new System.Drawing.Point(81, 51);
            this.ET4_Position.Name = "ET4_Position";
            this.ET4_Position.Size = new System.Drawing.Size(140, 20);
            this.ET4_Position.TabIndex = 10;
            this.ET4_Position.TextChanged += new System.EventHandler(this.Text_Change);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Position 4:";
            // 
            // ET4_Name
            // 
            this.ET4_Name.Location = new System.Drawing.Point(81, 27);
            this.ET4_Name.Name = "ET4_Name";
            this.ET4_Name.Size = new System.Drawing.Size(140, 20);
            this.ET4_Name.TabIndex = 9;
            this.ET4_Name.TextChanged += new System.EventHandler(this.Text_Change);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Name 4:";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(6, 78);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 36);
            this.label18.TabIndex = 46;
            this.label18.Text = "COI Notification to Probity Auditor (weeks)";
            // 
            // AuditPeriod
            // 
            this.AuditPeriod.Location = new System.Drawing.Point(144, 78);
            this.AuditPeriod.Name = "AuditPeriod";
            this.AuditPeriod.Size = new System.Drawing.Size(61, 20);
            this.AuditPeriod.TabIndex = 12;
            this.AuditPeriod.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.AuditPeriod.ValueChanged += new System.EventHandler(this.Audit_Period_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(215, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // TET2_Chk
            // 
            this.TET2_Chk.Location = new System.Drawing.Point(170, 253);
            this.TET2_Chk.Name = "TET2_Chk";
            this.TET2_Chk.Size = new System.Drawing.Size(65, 16);
            this.TET2_Chk.TabIndex = 47;
            this.TET2_Chk.Text = "Include";
            this.TET2_Chk.UseVisualStyleBackColor = true;
            this.TET2_Chk.CheckedChanged += new System.EventHandler(this.Checkbox_Changed);
            // 
            // gbTET2
            // 
            this.gbTET2.Controls.Add(this.ET2_Company);
            this.gbTET2.Controls.Add(this.label5);
            this.gbTET2.Controls.Add(this.ET2_Position);
            this.gbTET2.Controls.Add(this.label6);
            this.gbTET2.Controls.Add(this.ET2_Name);
            this.gbTET2.Controls.Add(this.label7);
            this.gbTET2.Location = new System.Drawing.Point(9, 264);
            this.gbTET2.Name = "gbTET2";
            this.gbTET2.Size = new System.Drawing.Size(232, 104);
            this.gbTET2.TabIndex = 48;
            this.gbTET2.TabStop = false;
            this.gbTET2.Text = "Team 2";
            // 
            // gbTET3
            // 
            this.gbTET3.Controls.Add(this.ET3_Company);
            this.gbTET3.Controls.Add(this.label8);
            this.gbTET3.Controls.Add(this.ET3_Position);
            this.gbTET3.Controls.Add(this.label9);
            this.gbTET3.Controls.Add(this.ET3_Name);
            this.gbTET3.Controls.Add(this.label10);
            this.gbTET3.Location = new System.Drawing.Point(9, 383);
            this.gbTET3.Name = "gbTET3";
            this.gbTET3.Size = new System.Drawing.Size(232, 101);
            this.gbTET3.TabIndex = 49;
            this.gbTET3.TabStop = false;
            this.gbTET3.Text = "Team 3";
            // 
            // TET3_Chk
            // 
            this.TET3_Chk.Location = new System.Drawing.Point(170, 372);
            this.TET3_Chk.Name = "TET3_Chk";
            this.TET3_Chk.Size = new System.Drawing.Size(65, 16);
            this.TET3_Chk.TabIndex = 47;
            this.TET3_Chk.Text = "Include";
            this.TET3_Chk.UseVisualStyleBackColor = true;
            this.TET3_Chk.CheckedChanged += new System.EventHandler(this.Checkbox_Changed);
            // 
            // gbTET4
            // 
            this.gbTET4.Controls.Add(this.ET4_Company);
            this.gbTET4.Controls.Add(this.label11);
            this.gbTET4.Controls.Add(this.ET4_Position);
            this.gbTET4.Controls.Add(this.label12);
            this.gbTET4.Controls.Add(this.ET4_Name);
            this.gbTET4.Controls.Add(this.label13);
            this.gbTET4.Location = new System.Drawing.Point(9, 501);
            this.gbTET4.Name = "gbTET4";
            this.gbTET4.Size = new System.Drawing.Size(232, 101);
            this.gbTET4.TabIndex = 51;
            this.gbTET4.TabStop = false;
            this.gbTET4.Text = "Team 4";
            // 
            // TET4_Chk
            // 
            this.TET4_Chk.Location = new System.Drawing.Point(170, 490);
            this.TET4_Chk.Name = "TET4_Chk";
            this.TET4_Chk.Size = new System.Drawing.Size(65, 16);
            this.TET4_Chk.TabIndex = 47;
            this.TET4_Chk.Text = "Include";
            this.TET4_Chk.UseVisualStyleBackColor = true;
            this.TET4_Chk.CheckedChanged += new System.EventHandler(this.Checkbox_Changed);
            // 
            // gbTET1
            // 
            this.gbTET1.Controls.Add(this.ETL_Company);
            this.gbTET1.Controls.Add(this.label4);
            this.gbTET1.Controls.Add(this.ETL_Position);
            this.gbTET1.Controls.Add(this.label3);
            this.gbTET1.Controls.Add(this.ETL_Name);
            this.gbTET1.Controls.Add(this.label2);
            this.gbTET1.Controls.Add(this.help1);
            this.gbTET1.Location = new System.Drawing.Point(6, 128);
            this.gbTET1.Name = "gbTET1";
            this.gbTET1.Size = new System.Drawing.Size(232, 115);
            this.gbTET1.TabIndex = 52;
            this.gbTET1.TabStop = false;
            this.gbTET1.Text = "Team 1";
            // 
            // gbTET5
            // 
            this.gbTET5.Controls.Add(this.ET5_Company);
            this.gbTET5.Controls.Add(this.label14);
            this.gbTET5.Controls.Add(this.ET5_Position);
            this.gbTET5.Controls.Add(this.label15);
            this.gbTET5.Controls.Add(this.ET5_Name);
            this.gbTET5.Controls.Add(this.label16);
            this.gbTET5.Location = new System.Drawing.Point(9, 618);
            this.gbTET5.Name = "gbTET5";
            this.gbTET5.Size = new System.Drawing.Size(232, 101);
            this.gbTET5.TabIndex = 51;
            this.gbTET5.TabStop = false;
            this.gbTET5.Text = "Team 5";
            // 
            // ET5_Company
            // 
            this.ET5_Company.Location = new System.Drawing.Point(81, 75);
            this.ET5_Company.Name = "ET5_Company";
            this.ET5_Company.Size = new System.Drawing.Size(140, 20);
            this.ET5_Company.TabIndex = 11;
            this.ET5_Company.TextChanged += new System.EventHandler(this.Text_Change);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Company 5:";
            // 
            // ET5_Position
            // 
            this.ET5_Position.Location = new System.Drawing.Point(81, 51);
            this.ET5_Position.Name = "ET5_Position";
            this.ET5_Position.Size = new System.Drawing.Size(140, 20);
            this.ET5_Position.TabIndex = 10;
            this.ET5_Position.TextChanged += new System.EventHandler(this.Text_Change);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Position 5:";
            // 
            // ET5_Name
            // 
            this.ET5_Name.Location = new System.Drawing.Point(81, 27);
            this.ET5_Name.Name = "ET5_Name";
            this.ET5_Name.Size = new System.Drawing.Size(140, 20);
            this.ET5_Name.TabIndex = 9;
            this.ET5_Name.TextChanged += new System.EventHandler(this.Text_Change);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Name 5:";
            // 
            // TET5_Chk
            // 
            this.TET5_Chk.Location = new System.Drawing.Point(170, 608);
            this.TET5_Chk.Name = "TET5_Chk";
            this.TET5_Chk.Size = new System.Drawing.Size(65, 16);
            this.TET5_Chk.TabIndex = 47;
            this.TET5_Chk.Text = "Include";
            this.TET5_Chk.UseVisualStyleBackColor = true;
            this.TET5_Chk.CheckedChanged += new System.EventHandler(this.Checkbox_Changed);
            // 
            // TenderEvaluationProcedure
            // 
            this.Controls.Add(this.TET2_Chk);
            this.Controls.Add(this.TET3_Chk);
            this.Controls.Add(this.TET4_Chk);
            this.Controls.Add(this.TET5_Chk);
            this.Controls.Add(this.gbTET1);
            this.Controls.Add(this.gbTET5);
            this.Controls.Add(this.gbTET4);
            this.Controls.Add(this.gbTET3);
            this.Controls.Add(this.gbTET2);
            this.Controls.Add(this.AuditPeriod);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "TenderEvaluationProcedure";
            this.Size = new System.Drawing.Size(255, 733);
            ((System.ComponentModel.ISupportInitialize)(this.AuditPeriod)).EndInit();
            this.gbTET2.ResumeLayout(false);
            this.gbTET2.PerformLayout();
            this.gbTET3.ResumeLayout(false);
            this.gbTET3.PerformLayout();
            this.gbTET4.ResumeLayout(false);
            this.gbTET4.PerformLayout();
            this.gbTET1.ResumeLayout(false);
            this.gbTET1.PerformLayout();
            this.gbTET5.ResumeLayout(false);
            this.gbTET5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ETL_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ETL_Position;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ETL_Company;
        private System.Windows.Forms.TextBox ET2_Company;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ET2_Position;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ET2_Name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ET3_Company;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ET3_Position;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ET3_Name;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button help1;
        private System.Windows.Forms.TextBox ET4_Company;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ET4_Position;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox ET4_Name;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown AuditPeriod;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox TET2_Chk;
        private System.Windows.Forms.GroupBox gbTET2;
        private System.Windows.Forms.GroupBox gbTET3;
        private System.Windows.Forms.CheckBox TET3_Chk;
        private System.Windows.Forms.GroupBox gbTET4;
        private System.Windows.Forms.CheckBox TET4_Chk;
        private System.Windows.Forms.GroupBox gbTET1;
        private System.Windows.Forms.GroupBox gbTET5;
        private System.Windows.Forms.CheckBox TET5_Chk;
        private System.Windows.Forms.TextBox ET5_Company;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox ET5_Position;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox ET5_Name;
        private System.Windows.Forms.Label label16;
    }
}
