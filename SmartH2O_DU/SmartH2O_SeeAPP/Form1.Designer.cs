namespace SmartH2O_SeeAPP
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLogsBetweenDates = new System.Windows.Forms.Button();
            this.dateTimePickerLogsStartingDate = new System.Windows.Forms.DateTimePicker();
            this.labelStartingDate = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.labelEndingDate = new System.Windows.Forms.Label();
            this.dataGridViewAlarms = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Element = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLogs = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAlarms = new System.Windows.Forms.TabPage();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.labelElements = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.groupBoxLogsWeekly = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBoxLogsDaily = new System.Windows.Forms.GroupBox();
            this.buttonLogsDaily = new System.Windows.Forms.Button();
            this.dateTimePickerLogsDaily = new System.Windows.Forms.DateTimePicker();
            this.comboBoxLogs = new System.Windows.Forms.ComboBox();
            this.groupBoxLogsBetweenDates = new System.Windows.Forms.GroupBox();
            this.labelLogsStartingDate = new System.Windows.Forms.Label();
            this.labelLogsEndingDate = new System.Windows.Forms.Label();
            this.dateTimePickerLogsEndingDate = new System.Windows.Forms.DateTimePicker();
            this.Statistics = new System.Windows.Forms.TabPage();
            this.labelLogsWeekly = new System.Windows.Forms.Label();
            this.labelLogsDaily = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlarms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabAlarms.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.groupBoxLogsWeekly.SuspendLayout();
            this.groupBoxLogsDaily.SuspendLayout();
            this.groupBoxLogsBetweenDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogsBetweenDates
            // 
            this.buttonLogsBetweenDates.Location = new System.Drawing.Point(671, 16);
            this.buttonLogsBetweenDates.Name = "buttonLogsBetweenDates";
            this.buttonLogsBetweenDates.Size = new System.Drawing.Size(75, 23);
            this.buttonLogsBetweenDates.TabIndex = 0;
            this.buttonLogsBetweenDates.Text = "Print";
            this.buttonLogsBetweenDates.UseVisualStyleBackColor = true;
            this.buttonLogsBetweenDates.Click += new System.EventHandler(this.buttonLogsBetweenDates_Click);
            // 
            // dateTimePickerLogsStartingDate
            // 
            this.dateTimePickerLogsStartingDate.Location = new System.Drawing.Point(101, 15);
            this.dateTimePickerLogsStartingDate.Name = "dateTimePickerLogsStartingDate";
            this.dateTimePickerLogsStartingDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerLogsStartingDate.TabIndex = 2;
            this.dateTimePickerLogsStartingDate.Value = new System.DateTime(2016, 12, 15, 20, 29, 0, 0);
            // 
            // labelStartingDate
            // 
            this.labelStartingDate.AutoSize = true;
            this.labelStartingDate.Location = new System.Drawing.Point(79, 59);
            this.labelStartingDate.Name = "labelStartingDate";
            this.labelStartingDate.Size = new System.Drawing.Size(72, 13);
            this.labelStartingDate.TabIndex = 3;
            this.labelStartingDate.Text = "Starting Date:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(460, 59);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 4;
            this.dateTimePicker2.Value = new System.DateTime(2016, 12, 18, 0, 0, 0, 0);
            // 
            // labelEndingDate
            // 
            this.labelEndingDate.AutoSize = true;
            this.labelEndingDate.Location = new System.Drawing.Point(385, 59);
            this.labelEndingDate.Name = "labelEndingDate";
            this.labelEndingDate.Size = new System.Drawing.Size(69, 13);
            this.labelEndingDate.TabIndex = 5;
            this.labelEndingDate.Text = "Ending Date:";
            // 
            // dataGridViewAlarms
            // 
            this.dataGridViewAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlarms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Element,
            this.Description});
            this.dataGridViewAlarms.Location = new System.Drawing.Point(56, 97);
            this.dataGridViewAlarms.Name = "dataGridViewAlarms";
            this.dataGridViewAlarms.Size = new System.Drawing.Size(789, 360);
            this.dataGridViewAlarms.TabIndex = 7;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 55;
            // 
            // Element
            // 
            this.Element.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Element.HeaderText = "Element";
            this.Element.Name = "Element";
            this.Element.ReadOnly = true;
            this.Element.Width = 70;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // dataGridViewLogs
            // 
            this.dataGridViewLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridViewLogs.Location = new System.Drawing.Point(56, 97);
            this.dataGridViewLogs.Name = "dataGridViewLogs";
            this.dataGridViewLogs.Size = new System.Drawing.Size(791, 360);
            this.dataGridViewLogs.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Element";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Time";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Minimum";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Average";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "Maximum";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAlarms);
            this.tabControl1.Controls.Add(this.tabLogs);
            this.tabControl1.Controls.Add(this.Statistics);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(961, 544);
            this.tabControl1.TabIndex = 9;
            // 
            // tabAlarms
            // 
            this.tabAlarms.Controls.Add(this.dateTimePicker3);
            this.tabAlarms.Controls.Add(this.labelElements);
            this.tabAlarms.Controls.Add(this.checkedListBox1);
            this.tabAlarms.Controls.Add(this.checkBoxAll);
            this.tabAlarms.Controls.Add(this.dataGridViewAlarms);
            this.tabAlarms.Controls.Add(this.labelEndingDate);
            this.tabAlarms.Controls.Add(this.dateTimePicker2);
            this.tabAlarms.Controls.Add(this.labelStartingDate);
            this.tabAlarms.Location = new System.Drawing.Point(4, 22);
            this.tabAlarms.Name = "tabAlarms";
            this.tabAlarms.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlarms.Size = new System.Drawing.Size(953, 518);
            this.tabAlarms.TabIndex = 0;
            this.tabAlarms.Text = "Alarms";
            this.tabAlarms.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(157, 59);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker3.TabIndex = 11;
            // 
            // labelElements
            // 
            this.labelElements.AutoSize = true;
            this.labelElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelElements.Location = new System.Drawing.Point(868, 104);
            this.labelElements.Name = "labelElements";
            this.labelElements.Size = new System.Drawing.Size(66, 17);
            this.labelElements.TabIndex = 10;
            this.labelElements.Text = "Elements";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Enabled = false;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "PH",
            "Cl2",
            "NH3"});
            this.checkedListBox1.Location = new System.Drawing.Point(871, 156);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(55, 79);
            this.checkedListBox1.TabIndex = 9;
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Checked = true;
            this.checkBoxAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAll.Location = new System.Drawing.Point(871, 133);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(37, 17);
            this.checkBoxAll.TabIndex = 8;
            this.checkBoxAll.Text = "All";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.groupBoxLogsWeekly);
            this.tabLogs.Controls.Add(this.groupBoxLogsDaily);
            this.tabLogs.Controls.Add(this.comboBoxLogs);
            this.tabLogs.Controls.Add(this.dataGridViewLogs);
            this.tabLogs.Controls.Add(this.groupBoxLogsBetweenDates);
            this.tabLogs.Location = new System.Drawing.Point(4, 22);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(953, 518);
            this.tabLogs.TabIndex = 1;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // groupBoxLogsWeekly
            // 
            this.groupBoxLogsWeekly.Controls.Add(this.labelLogsWeekly);
            this.groupBoxLogsWeekly.Controls.Add(this.comboBox1);
            this.groupBoxLogsWeekly.Location = new System.Drawing.Point(247, 5);
            this.groupBoxLogsWeekly.Name = "groupBoxLogsWeekly";
            this.groupBoxLogsWeekly.Size = new System.Drawing.Size(791, 50);
            this.groupBoxLogsWeekly.TabIndex = 14;
            this.groupBoxLogsWeekly.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Semana 1",
            "Semana 2",
            "Semana 3"});
            this.comboBox1.Location = new System.Drawing.Point(141, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBoxLogsDaily
            // 
            this.groupBoxLogsDaily.Controls.Add(this.labelLogsDaily);
            this.groupBoxLogsDaily.Controls.Add(this.buttonLogsDaily);
            this.groupBoxLogsDaily.Controls.Add(this.dateTimePickerLogsDaily);
            this.groupBoxLogsDaily.Location = new System.Drawing.Point(40, 468);
            this.groupBoxLogsDaily.Name = "groupBoxLogsDaily";
            this.groupBoxLogsDaily.Size = new System.Drawing.Size(791, 50);
            this.groupBoxLogsDaily.TabIndex = 13;
            this.groupBoxLogsDaily.TabStop = false;
            // 
            // buttonLogsDaily
            // 
            this.buttonLogsDaily.Location = new System.Drawing.Point(348, 14);
            this.buttonLogsDaily.Name = "buttonLogsDaily";
            this.buttonLogsDaily.Size = new System.Drawing.Size(75, 23);
            this.buttonLogsDaily.TabIndex = 14;
            this.buttonLogsDaily.Text = "Print";
            this.buttonLogsDaily.UseVisualStyleBackColor = true;
            this.buttonLogsDaily.Click += new System.EventHandler(this.buttonLogsDaily_Click);
            // 
            // dateTimePickerLogsDaily
            // 
            this.dateTimePickerLogsDaily.Location = new System.Drawing.Point(128, 16);
            this.dateTimePickerLogsDaily.Name = "dateTimePickerLogsDaily";
            this.dateTimePickerLogsDaily.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerLogsDaily.TabIndex = 14;
            // 
            // comboBoxLogs
            // 
            this.comboBoxLogs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLogs.Items.AddRange(new object[] {
            "Daily",
            "Between Dates",
            "Weekly"});
            this.comboBoxLogs.Location = new System.Drawing.Point(56, 20);
            this.comboBoxLogs.Name = "comboBoxLogs";
            this.comboBoxLogs.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLogs.TabIndex = 0;
            this.comboBoxLogs.SelectedIndexChanged += new System.EventHandler(this.comboBoxLogs_SelectedIndexChanged);
            // 
            // groupBoxLogsBetweenDates
            // 
            this.groupBoxLogsBetweenDates.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBoxLogsBetweenDates.Controls.Add(this.buttonLogsBetweenDates);
            this.groupBoxLogsBetweenDates.Controls.Add(this.labelLogsStartingDate);
            this.groupBoxLogsBetweenDates.Controls.Add(this.labelLogsEndingDate);
            this.groupBoxLogsBetweenDates.Controls.Add(this.dateTimePickerLogsEndingDate);
            this.groupBoxLogsBetweenDates.Controls.Add(this.dateTimePickerLogsStartingDate);
            this.groupBoxLogsBetweenDates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxLogsBetweenDates.Location = new System.Drawing.Point(56, 44);
            this.groupBoxLogsBetweenDates.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxLogsBetweenDates.Name = "groupBoxLogsBetweenDates";
            this.groupBoxLogsBetweenDates.Size = new System.Drawing.Size(791, 50);
            this.groupBoxLogsBetweenDates.TabIndex = 12;
            this.groupBoxLogsBetweenDates.TabStop = false;
            this.groupBoxLogsBetweenDates.Visible = false;
            // 
            // labelLogsStartingDate
            // 
            this.labelLogsStartingDate.AutoSize = true;
            this.labelLogsStartingDate.Location = new System.Drawing.Point(23, 19);
            this.labelLogsStartingDate.Name = "labelLogsStartingDate";
            this.labelLogsStartingDate.Size = new System.Drawing.Size(72, 13);
            this.labelLogsStartingDate.TabIndex = 16;
            this.labelLogsStartingDate.Text = "Starting Date:";
            // 
            // labelLogsEndingDate
            // 
            this.labelLogsEndingDate.AutoSize = true;
            this.labelLogsEndingDate.Location = new System.Drawing.Point(334, 19);
            this.labelLogsEndingDate.Name = "labelLogsEndingDate";
            this.labelLogsEndingDate.Size = new System.Drawing.Size(69, 13);
            this.labelLogsEndingDate.TabIndex = 18;
            this.labelLogsEndingDate.Text = "Ending Date:";
            // 
            // dateTimePickerLogsEndingDate
            // 
            this.dateTimePickerLogsEndingDate.Location = new System.Drawing.Point(409, 17);
            this.dateTimePickerLogsEndingDate.Name = "dateTimePickerLogsEndingDate";
            this.dateTimePickerLogsEndingDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerLogsEndingDate.TabIndex = 17;
            this.dateTimePickerLogsEndingDate.Value = new System.DateTime(2016, 12, 18, 0, 0, 0, 0);
            // 
            // Statistics
            // 
            this.Statistics.Location = new System.Drawing.Point(4, 22);
            this.Statistics.Name = "Statistics";
            this.Statistics.Size = new System.Drawing.Size(907, 518);
            this.Statistics.TabIndex = 2;
            this.Statistics.Text = "Statistics";
            this.Statistics.UseVisualStyleBackColor = true;
            // 
            // labelLogsWeekly
            // 
            this.labelLogsWeekly.AutoSize = true;
            this.labelLogsWeekly.Location = new System.Drawing.Point(82, 18);
            this.labelLogsWeekly.Name = "labelLogsWeekly";
            this.labelLogsWeekly.Size = new System.Drawing.Size(39, 13);
            this.labelLogsWeekly.TabIndex = 1;
            this.labelLogsWeekly.Text = "Week:";
            // 
            // labelLogsDaily
            // 
            this.labelLogsDaily.AutoSize = true;
            this.labelLogsDaily.Location = new System.Drawing.Point(78, 19);
            this.labelLogsDaily.Name = "labelLogsDaily";
            this.labelLogsDaily.Size = new System.Drawing.Size(33, 13);
            this.labelLogsDaily.TabIndex = 15;
            this.labelLogsDaily.Text = "Date:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 575);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "SmartH2O Statistics-Visualizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlarms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabAlarms.ResumeLayout(false);
            this.tabAlarms.PerformLayout();
            this.tabLogs.ResumeLayout(false);
            this.groupBoxLogsWeekly.ResumeLayout(false);
            this.groupBoxLogsWeekly.PerformLayout();
            this.groupBoxLogsDaily.ResumeLayout(false);
            this.groupBoxLogsDaily.PerformLayout();
            this.groupBoxLogsBetweenDates.ResumeLayout(false);
            this.groupBoxLogsBetweenDates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLogsBetweenDates;
        private System.Windows.Forms.DateTimePicker dateTimePickerLogsStartingDate;
        private System.Windows.Forms.Label labelStartingDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label labelEndingDate;
        private System.Windows.Forms.DataGridView dataGridViewAlarms;
        private System.Windows.Forms.DataGridView dataGridViewLogs;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAlarms;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.TabPage Statistics;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Element;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.Label labelElements;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label labelLogsEndingDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerLogsEndingDate;
        private System.Windows.Forms.Label labelLogsStartingDate;
        private System.Windows.Forms.GroupBox groupBoxLogsBetweenDates;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ComboBox comboBoxLogs;
        private System.Windows.Forms.GroupBox groupBoxLogsDaily;
        private System.Windows.Forms.Button buttonLogsDaily;
        private System.Windows.Forms.DateTimePicker dateTimePickerLogsDaily;
        private System.Windows.Forms.GroupBox groupBoxLogsWeekly;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelLogsWeekly;
        private System.Windows.Forms.Label labelLogsDaily;
    }
}

