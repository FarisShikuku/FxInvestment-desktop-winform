namespace FxInvestmentAdmin.Forms
{
    partial class ReportsDashboardForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsDashboardForm));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.panelReportsContent = new System.Windows.Forms.Panel();
            this.dgvPerformance = new System.Windows.Forms.DataGridView();
            this.btnViewSummary = new System.Windows.Forms.Button();
            this.btnGeneratePdf = new System.Windows.Forms.Button();
            this.panelQuarterlyParams = new System.Windows.Forms.Panel();
            this.numQuarterlyYear = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numQuarter = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMonthlyParams = new System.Windows.Forms.Panel();
            this.numMonthlyYear = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numMonth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panelWeeklyParams = new System.Windows.Forms.Panel();
            this.numWeeklyYear = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.numWeek = new System.Windows.Forms.NumericUpDown();
            this.lblWeek = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.cmbAccounts = new System.Windows.Forms.ComboBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.panelReportsContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).BeginInit();
            this.panelQuarterlyParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuarterlyYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuarter)).BeginInit();
            this.panelMonthlyParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonthlyYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).BeginInit();
            this.panelWeeklyParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeeklyYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageReports);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(984, 661);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageReports
            // 
            this.tabPageReports.BackColor = System.Drawing.Color.White;
            this.tabPageReports.Controls.Add(this.panelReportsContent);
            this.tabPageReports.Location = new System.Drawing.Point(4, 37);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReports.Size = new System.Drawing.Size(976, 620);
            this.tabPageReports.TabIndex = 0;
            this.tabPageReports.Text = "Performance Reports";
            // 
            // panelReportsContent
            // 
            this.panelReportsContent.Controls.Add(this.dgvPerformance);
            this.panelReportsContent.Controls.Add(this.btnViewSummary);
            this.panelReportsContent.Controls.Add(this.btnGeneratePdf);
            this.panelReportsContent.Controls.Add(this.panelQuarterlyParams);
            this.panelReportsContent.Controls.Add(this.panelMonthlyParams);
            this.panelReportsContent.Controls.Add(this.panelWeeklyParams);
            this.panelReportsContent.Controls.Add(this.cmbReportType);
            this.panelReportsContent.Controls.Add(this.lblReportType);
            this.panelReportsContent.Controls.Add(this.cmbAccounts);
            this.panelReportsContent.Controls.Add(this.lblAccount);
            this.panelReportsContent.Controls.Add(this.lblTitle);
            this.panelReportsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportsContent.Location = new System.Drawing.Point(3, 3);
            this.panelReportsContent.Name = "panelReportsContent";
            this.panelReportsContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelReportsContent.Size = new System.Drawing.Size(970, 614);
            this.panelReportsContent.TabIndex = 0;
            // 
            // dgvPerformance
            // 
            this.dgvPerformance.AllowUserToAddRows = false;
            this.dgvPerformance.AllowUserToDeleteRows = false;
            this.dgvPerformance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPerformance.BackgroundColor = System.Drawing.Color.White;
            this.dgvPerformance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPerformance.ColumnHeadersHeight = 35;
            this.dgvPerformance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPerformance.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPerformance.Location = new System.Drawing.Point(23, 320);
            this.dgvPerformance.Name = "dgvPerformance";
            this.dgvPerformance.ReadOnly = true;
            this.dgvPerformance.RowHeadersWidth = 62;
            this.dgvPerformance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerformance.Size = new System.Drawing.Size(924, 271);
            this.dgvPerformance.TabIndex = 10;
            // 
            // btnViewSummary
            // 
            this.btnViewSummary.BackColor = System.Drawing.Color.SteelBlue;
            this.btnViewSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSummary.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSummary.ForeColor = System.Drawing.Color.White;
            this.btnViewSummary.Location = new System.Drawing.Point(200, 270);
            this.btnViewSummary.Name = "btnViewSummary";
            this.btnViewSummary.Size = new System.Drawing.Size(120, 35);
            this.btnViewSummary.TabIndex = 9;
            this.btnViewSummary.Text = "📊 View Summary";
            this.btnViewSummary.UseVisualStyleBackColor = false;
            this.btnViewSummary.Click += new System.EventHandler(this.btnViewSummary_Click);
            // 
            // btnGeneratePdf
            // 
            this.btnGeneratePdf.BackColor = System.Drawing.Color.LimeGreen;
            this.btnGeneratePdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneratePdf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePdf.ForeColor = System.Drawing.Color.White;
            this.btnGeneratePdf.Location = new System.Drawing.Point(23, 270);
            this.btnGeneratePdf.Name = "btnGeneratePdf";
            this.btnGeneratePdf.Size = new System.Drawing.Size(170, 35);
            this.btnGeneratePdf.TabIndex = 8;
            this.btnGeneratePdf.Text = "📄 Generate PDF Report";
            this.btnGeneratePdf.UseVisualStyleBackColor = false;
            this.btnGeneratePdf.Click += new System.EventHandler(this.btnGeneratePdf_Click);
            // 
            // panelQuarterlyParams
            // 
            this.panelQuarterlyParams.Controls.Add(this.numQuarterlyYear);
            this.panelQuarterlyParams.Controls.Add(this.label4);
            this.panelQuarterlyParams.Controls.Add(this.numQuarter);
            this.panelQuarterlyParams.Controls.Add(this.label3);
            this.panelQuarterlyParams.Location = new System.Drawing.Point(23, 200);
            this.panelQuarterlyParams.Name = "panelQuarterlyParams";
            this.panelQuarterlyParams.Size = new System.Drawing.Size(400, 40);
            this.panelQuarterlyParams.TabIndex = 7;
            this.panelQuarterlyParams.Visible = false;
            // 
            // numQuarterlyYear
            // 
            this.numQuarterlyYear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuarterlyYear.Location = new System.Drawing.Point(240, 8);
            this.numQuarterlyYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.numQuarterlyYear.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numQuarterlyYear.Name = "numQuarterlyYear";
            this.numQuarterlyYear.Size = new System.Drawing.Size(80, 33);
            this.numQuarterlyYear.TabIndex = 3;
            this.numQuarterlyYear.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(200, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "Year:";
            // 
            // numQuarter
            // 
            this.numQuarter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuarter.Location = new System.Drawing.Point(70, 8);
            this.numQuarter.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numQuarter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuarter.Name = "numQuarter";
            this.numQuarter.Size = new System.Drawing.Size(60, 33);
            this.numQuarter.TabIndex = 1;
            this.numQuarter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Quarter:";
            // 
            // panelMonthlyParams
            // 
            this.panelMonthlyParams.Controls.Add(this.numMonthlyYear);
            this.panelMonthlyParams.Controls.Add(this.label2);
            this.panelMonthlyParams.Controls.Add(this.numMonth);
            this.panelMonthlyParams.Controls.Add(this.label1);
            this.panelMonthlyParams.Location = new System.Drawing.Point(23, 200);
            this.panelMonthlyParams.Name = "panelMonthlyParams";
            this.panelMonthlyParams.Size = new System.Drawing.Size(400, 40);
            this.panelMonthlyParams.TabIndex = 6;
            this.panelMonthlyParams.Visible = false;
            // 
            // numMonthlyYear
            // 
            this.numMonthlyYear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonthlyYear.Location = new System.Drawing.Point(240, 8);
            this.numMonthlyYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.numMonthlyYear.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numMonthlyYear.Name = "numMonthlyYear";
            this.numMonthlyYear.Size = new System.Drawing.Size(80, 33);
            this.numMonthlyYear.TabIndex = 3;
            this.numMonthlyYear.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(200, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Year:";
            // 
            // numMonth
            // 
            this.numMonth.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonth.Location = new System.Drawing.Point(70, 8);
            this.numMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonth.Name = "numMonth";
            this.numMonth.Size = new System.Drawing.Size(60, 33);
            this.numMonth.TabIndex = 1;
            this.numMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Month:";
            // 
            // panelWeeklyParams
            // 
            this.panelWeeklyParams.Controls.Add(this.numWeeklyYear);
            this.panelWeeklyParams.Controls.Add(this.lblYear);
            this.panelWeeklyParams.Controls.Add(this.numWeek);
            this.panelWeeklyParams.Controls.Add(this.lblWeek);
            this.panelWeeklyParams.Location = new System.Drawing.Point(23, 200);
            this.panelWeeklyParams.Name = "panelWeeklyParams";
            this.panelWeeklyParams.Size = new System.Drawing.Size(400, 40);
            this.panelWeeklyParams.TabIndex = 5;
            // 
            // numWeeklyYear
            // 
            this.numWeeklyYear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWeeklyYear.Location = new System.Drawing.Point(240, 8);
            this.numWeeklyYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.numWeeklyYear.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numWeeklyYear.Name = "numWeeklyYear";
            this.numWeeklyYear.Size = new System.Drawing.Size(80, 33);
            this.numWeeklyYear.TabIndex = 3;
            this.numWeeklyYear.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(200, 10);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(52, 28);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Year:";
            // 
            // numWeek
            // 
            this.numWeek.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWeek.Location = new System.Drawing.Point(70, 8);
            this.numWeek.Maximum = new decimal(new int[] {
            52,
            0,
            0,
            0});
            this.numWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeek.Name = "numWeek";
            this.numWeek.Size = new System.Drawing.Size(60, 33);
            this.numWeek.TabIndex = 1;
            this.numWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeek.Location = new System.Drawing.Point(10, 10);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(64, 28);
            this.lblWeek.TabIndex = 0;
            this.lblWeek.Text = "Week:";
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "Weekly Report",
            "Monthly Report",
            "Quarterly Report"});
            this.cmbReportType.Location = new System.Drawing.Point(120, 120);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(200, 36);
            this.cmbReportType.TabIndex = 3;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.Location = new System.Drawing.Point(20, 123);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(121, 28);
            this.lblReportType.TabIndex = 2;
            this.lblReportType.Text = "Report Type:";
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccounts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccounts.FormattingEnabled = true;
            this.cmbAccounts.Location = new System.Drawing.Point(120, 80);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Size = new System.Drawing.Size(200, 36);
            this.cmbAccounts.TabIndex = 1;
            this.cmbAccounts.SelectedIndexChanged += new System.EventHandler(this.cmbAccounts_SelectedIndexChanged);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.Location = new System.Drawing.Point(20, 83);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(145, 28);
            this.lblAccount.TabIndex = 1;
            this.lblAccount.Text = "Select Account:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(19, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(359, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Performance Reports";
            // 
            // ReportsDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.tabControlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportsDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reports Dashboard";
            this.Load += new System.EventHandler(this.ReportsDashboardForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageReports.ResumeLayout(false);
            this.panelReportsContent.ResumeLayout(false);
            this.panelReportsContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).EndInit();
            this.panelQuarterlyParams.ResumeLayout(false);
            this.panelQuarterlyParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuarterlyYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuarter)).EndInit();
            this.panelMonthlyParams.ResumeLayout(false);
            this.panelMonthlyParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonthlyYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).EndInit();
            this.panelWeeklyParams.ResumeLayout(false);
            this.panelWeeklyParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeeklyYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.Panel panelReportsContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbAccounts;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.Panel panelWeeklyParams;
        private System.Windows.Forms.NumericUpDown numWeeklyYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.NumericUpDown numWeek;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.Panel panelMonthlyParams;
        private System.Windows.Forms.NumericUpDown numMonthlyYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelQuarterlyParams;
        private System.Windows.Forms.NumericUpDown numQuarterlyYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numQuarter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGeneratePdf;
        private System.Windows.Forms.Button btnViewSummary;
        private System.Windows.Forms.DataGridView dgvPerformance;
    }
}