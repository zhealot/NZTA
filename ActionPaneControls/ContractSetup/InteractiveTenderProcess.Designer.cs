namespace NZTA_Contract_Generator.ActionPaneControls.ContractSetup
{
    [System.ComponentModel.ToolboxItemAttribute(false)]
    partial class InteractiveTenderProcess
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
            this.Interactive_Yes = new System.Windows.Forms.RadioButton();
            this.Interactive_No = new System.Windows.Forms.RadioButton();
            this.Meeting_Box = new System.Windows.Forms.GroupBox();
            this.Individual_Place = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Individual5_Check = new System.Windows.Forms.CheckBox();
            this.Individual5_Date = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.Individual4_Check = new System.Windows.Forms.CheckBox();
            this.Individual4_Date = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.Individual3_Check = new System.Windows.Forms.CheckBox();
            this.Individual3_Date = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.Individual2_Check = new System.Windows.Forms.CheckBox();
            this.Individual2_Date = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.Individual1_Check = new System.Windows.Forms.CheckBox();
            this.Individual1_Date = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.Combined_Place = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Combined_Time = new System.Windows.Forms.DateTimePicker();
            this.Combined_Check = new System.Windows.Forms.CheckBox();
            this.Combined_Date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.help1 = new System.Windows.Forms.Button();
            this.Meeting_Box.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(106)))));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Interactive Tender Process";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Will you have an Interactive Tender Process?";
            // 
            // Interactive_Yes
            // 
            this.Interactive_Yes.AutoSize = true;
            this.Interactive_Yes.Location = new System.Drawing.Point(9, 81);
            this.Interactive_Yes.Name = "Interactive_Yes";
            this.Interactive_Yes.Size = new System.Drawing.Size(52, 19);
            this.Interactive_Yes.TabIndex = 4;
            this.Interactive_Yes.TabStop = true;
            this.Interactive_Yes.Text = "Yes";
            this.Interactive_Yes.UseVisualStyleBackColor = true;
            this.Interactive_Yes.CheckedChanged += new System.EventHandler(this.Interactive_Yes_CheckedChanged);
            // 
            // Interactive_No
            // 
            this.Interactive_No.AutoSize = true;
            this.Interactive_No.Location = new System.Drawing.Point(135, 81);
            this.Interactive_No.Name = "Interactive_No";
            this.Interactive_No.Size = new System.Drawing.Size(44, 19);
            this.Interactive_No.TabIndex = 5;
            this.Interactive_No.TabStop = true;
            this.Interactive_No.Text = "No";
            this.Interactive_No.UseVisualStyleBackColor = true;
            this.Interactive_No.CheckedChanged += new System.EventHandler(this.Interactive_No_CheckedChanged);
            // 
            // Meeting_Box
            // 
            this.Meeting_Box.Controls.Add(this.Individual_Place);
            this.Meeting_Box.Controls.Add(this.label10);
            this.Meeting_Box.Controls.Add(this.Individual5_Check);
            this.Meeting_Box.Controls.Add(this.Individual5_Date);
            this.Meeting_Box.Controls.Add(this.label9);
            this.Meeting_Box.Controls.Add(this.Individual4_Check);
            this.Meeting_Box.Controls.Add(this.Individual4_Date);
            this.Meeting_Box.Controls.Add(this.label8);
            this.Meeting_Box.Controls.Add(this.Individual3_Check);
            this.Meeting_Box.Controls.Add(this.Individual3_Date);
            this.Meeting_Box.Controls.Add(this.label7);
            this.Meeting_Box.Controls.Add(this.Individual2_Check);
            this.Meeting_Box.Controls.Add(this.Individual2_Date);
            this.Meeting_Box.Controls.Add(this.label6);
            this.Meeting_Box.Controls.Add(this.Individual1_Check);
            this.Meeting_Box.Controls.Add(this.Individual1_Date);
            this.Meeting_Box.Controls.Add(this.label5);
            this.Meeting_Box.Controls.Add(this.Combined_Place);
            this.Meeting_Box.Controls.Add(this.label4);
            this.Meeting_Box.Controls.Add(this.Combined_Time);
            this.Meeting_Box.Controls.Add(this.Combined_Check);
            this.Meeting_Box.Controls.Add(this.Combined_Date);
            this.Meeting_Box.Controls.Add(this.label3);
            this.Meeting_Box.Location = new System.Drawing.Point(9, 106);
            this.Meeting_Box.Name = "Meeting_Box";
            this.Meeting_Box.Size = new System.Drawing.Size(307, 531);
            this.Meeting_Box.TabIndex = 6;
            this.Meeting_Box.TabStop = false;
            this.Meeting_Box.Visible = false;
            // 
            // Individual_Place
            // 
            this.Individual_Place.Location = new System.Drawing.Point(9, 352);
            this.Individual_Place.Name = "Individual_Place";
            this.Individual_Place.Size = new System.Drawing.Size(245, 25);
            this.Individual_Place.TabIndex = 23;
            this.Individual_Place.TextChanged += new System.EventHandler(this.Individual_Place_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 336);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(207, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Individual Meeting place:";
            // 
            // Individual5_Check
            // 
            this.Individual5_Check.AutoSize = true;
            this.Individual5_Check.Location = new System.Drawing.Point(23, 316);
            this.Individual5_Check.Name = "Individual5_Check";
            this.Individual5_Check.Size = new System.Drawing.Size(18, 17);
            this.Individual5_Check.TabIndex = 21;
            this.Individual5_Check.UseVisualStyleBackColor = true;
            this.Individual5_Check.CheckedChanged += new System.EventHandler(this.Individual5_Check_CheckedChanged);
            // 
            // Individual5_Date
            // 
            this.Individual5_Date.CustomFormat = "";
            this.Individual5_Date.Location = new System.Drawing.Point(54, 313);
            this.Individual5_Date.Name = "Individual5_Date";
            this.Individual5_Date.Size = new System.Drawing.Size(200, 25);
            this.Individual5_Date.TabIndex = 20;
            this.Individual5_Date.ValueChanged += new System.EventHandler(this.Individual5_Date_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(287, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Optional Individual Meeting V date:";
            // 
            // Individual4_Check
            // 
            this.Individual4_Check.AutoSize = true;
            this.Individual4_Check.Location = new System.Drawing.Point(23, 277);
            this.Individual4_Check.Name = "Individual4_Check";
            this.Individual4_Check.Size = new System.Drawing.Size(18, 17);
            this.Individual4_Check.TabIndex = 18;
            this.Individual4_Check.UseVisualStyleBackColor = true;
            this.Individual4_Check.CheckedChanged += new System.EventHandler(this.Individual4_Check_CheckedChanged);
            // 
            // Individual4_Date
            // 
            this.Individual4_Date.CustomFormat = "";
            this.Individual4_Date.Location = new System.Drawing.Point(54, 274);
            this.Individual4_Date.Name = "Individual4_Date";
            this.Individual4_Date.Size = new System.Drawing.Size(200, 25);
            this.Individual4_Date.TabIndex = 17;
            this.Individual4_Date.ValueChanged += new System.EventHandler(this.Individual4_Date_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(295, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Optional Individual Meeting IV date:";
            // 
            // Individual3_Check
            // 
            this.Individual3_Check.AutoSize = true;
            this.Individual3_Check.Location = new System.Drawing.Point(23, 236);
            this.Individual3_Check.Name = "Individual3_Check";
            this.Individual3_Check.Size = new System.Drawing.Size(18, 17);
            this.Individual3_Check.TabIndex = 15;
            this.Individual3_Check.UseVisualStyleBackColor = true;
            this.Individual3_Check.CheckedChanged += new System.EventHandler(this.Individual3_Check_CheckedChanged);
            // 
            // Individual3_Date
            // 
            this.Individual3_Date.CustomFormat = "";
            this.Individual3_Date.Location = new System.Drawing.Point(54, 233);
            this.Individual3_Date.Name = "Individual3_Date";
            this.Individual3_Date.Size = new System.Drawing.Size(200, 25);
            this.Individual3_Date.TabIndex = 14;
            this.Individual3_Date.ValueChanged += new System.EventHandler(this.Individual3_Date_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(303, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Optional Individual Meeting III date:";
            // 
            // Individual2_Check
            // 
            this.Individual2_Check.AutoSize = true;
            this.Individual2_Check.Location = new System.Drawing.Point(23, 197);
            this.Individual2_Check.Name = "Individual2_Check";
            this.Individual2_Check.Size = new System.Drawing.Size(18, 17);
            this.Individual2_Check.TabIndex = 12;
            this.Individual2_Check.UseVisualStyleBackColor = true;
            this.Individual2_Check.CheckedChanged += new System.EventHandler(this.Individual2_Check_CheckedChanged);
            // 
            // Individual2_Date
            // 
            this.Individual2_Date.CustomFormat = "";
            this.Individual2_Date.Location = new System.Drawing.Point(54, 194);
            this.Individual2_Date.Name = "Individual2_Date";
            this.Individual2_Date.Size = new System.Drawing.Size(200, 25);
            this.Individual2_Date.TabIndex = 11;
            this.Individual2_Date.ValueChanged += new System.EventHandler(this.Individual2_Date_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Individual Meeting II date:";
            // 
            // Individual1_Check
            // 
            this.Individual1_Check.AutoSize = true;
            this.Individual1_Check.Location = new System.Drawing.Point(23, 158);
            this.Individual1_Check.Name = "Individual1_Check";
            this.Individual1_Check.Size = new System.Drawing.Size(18, 17);
            this.Individual1_Check.TabIndex = 9;
            this.Individual1_Check.UseVisualStyleBackColor = true;
            this.Individual1_Check.CheckedChanged += new System.EventHandler(this.Individual1_Check_CheckedChanged);
            // 
            // Individual1_Date
            // 
            this.Individual1_Date.CustomFormat = "";
            this.Individual1_Date.Location = new System.Drawing.Point(54, 155);
            this.Individual1_Date.Name = "Individual1_Date";
            this.Individual1_Date.Size = new System.Drawing.Size(200, 25);
            this.Individual1_Date.TabIndex = 8;
            this.Individual1_Date.ValueChanged += new System.EventHandler(this.Individual1_Date_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Individual Meeting I date:";
            // 
            // Combined_Place
            // 
            this.Combined_Place.Location = new System.Drawing.Point(9, 116);
            this.Combined_Place.Name = "Combined_Place";
            this.Combined_Place.Size = new System.Drawing.Size(245, 25);
            this.Combined_Place.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Combined Meeting place:";
            // 
            // Combined_Time
            // 
            this.Combined_Time.CustomFormat = "h:mm tt";
            this.Combined_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Combined_Time.Location = new System.Drawing.Point(54, 77);
            this.Combined_Time.Name = "Combined_Time";
            this.Combined_Time.ShowUpDown = true;
            this.Combined_Time.Size = new System.Drawing.Size(92, 25);
            this.Combined_Time.TabIndex = 4;
            this.Combined_Time.ValueChanged += new System.EventHandler(this.Combined_Time_ValueChanged);
            // 
            // Combined_Check
            // 
            this.Combined_Check.AutoSize = true;
            this.Combined_Check.Location = new System.Drawing.Point(23, 53);
            this.Combined_Check.Name = "Combined_Check";
            this.Combined_Check.Size = new System.Drawing.Size(18, 17);
            this.Combined_Check.TabIndex = 3;
            this.Combined_Check.UseVisualStyleBackColor = true;
            this.Combined_Check.CheckedChanged += new System.EventHandler(this.Combined_Check_CheckedChanged);
            // 
            // Combined_Date
            // 
            this.Combined_Date.CustomFormat = "";
            this.Combined_Date.Location = new System.Drawing.Point(54, 50);
            this.Combined_Date.Name = "Combined_Date";
            this.Combined_Date.Size = new System.Drawing.Size(200, 25);
            this.Combined_Date.TabIndex = 2;
            this.Combined_Date.ValueChanged += new System.EventHandler(this.Combined_Date_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Combined Meeting date and time:";
            // 
            // help1
            // 
            this.help1.Location = new System.Drawing.Point(253, 77);
            this.help1.Name = "help1";
            this.help1.Size = new System.Drawing.Size(60, 23);
            this.help1.TabIndex = 13;
            this.help1.Text = "?";
            this.help1.UseVisualStyleBackColor = true;
            this.help1.Click += new System.EventHandler(this.help1_Click);
            // 
            // InteractiveTenderProcess
            // 
            this.Controls.Add(this.help1);
            this.Controls.Add(this.Meeting_Box);
            this.Controls.Add(this.Interactive_No);
            this.Controls.Add(this.Interactive_Yes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InteractiveTenderProcess";
            this.Size = new System.Drawing.Size(316, 650);
            this.Meeting_Box.ResumeLayout(false);
            this.Meeting_Box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton Interactive_Yes;
        private System.Windows.Forms.RadioButton Interactive_No;
        private System.Windows.Forms.GroupBox Meeting_Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker Combined_Date;
        private System.Windows.Forms.CheckBox Combined_Check;
        private System.Windows.Forms.Button help1;
        private System.Windows.Forms.DateTimePicker Combined_Time;
        private System.Windows.Forms.TextBox Individual_Place;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox Individual5_Check;
        private System.Windows.Forms.DateTimePicker Individual5_Date;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox Individual4_Check;
        private System.Windows.Forms.DateTimePicker Individual4_Date;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox Individual3_Check;
        private System.Windows.Forms.DateTimePicker Individual3_Date;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox Individual2_Check;
        private System.Windows.Forms.DateTimePicker Individual2_Date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox Individual1_Check;
        private System.Windows.Forms.DateTimePicker Individual1_Date;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Combined_Place;
        private System.Windows.Forms.Label label4;
    }
}
