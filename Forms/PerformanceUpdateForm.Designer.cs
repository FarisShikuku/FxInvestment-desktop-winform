namespace FxInvestmentAdmin.Forms
{
    partial class PerformanceUpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerformanceUpdateForm));
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxPerformance = new System.Windows.Forms.GroupBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.txtCsvFile = new System.Windows.Forms.TextBox();
            this.btnBrowseCsv = new System.Windows.Forms.Button();
            this.lblCsvFile = new System.Windows.Forms.Label();
            this.txtFxId = new System.Windows.Forms.TextBox();
            this.lblFxId = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.numWeek = new System.Windows.Forms.NumericUpDown();
            this.lblWeek = new System.Windows.Forms.Label();
            this.dtpSystemDate = new System.Windows.Forms.DateTimePicker();
            this.lblSystemDate = new System.Windows.Forms.Label();
            this.cmbAccounts = new System.Windows.Forms.ComboBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.groupBoxPerformance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxPerformance);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(684, 561);
            this.panelMain.TabIndex = 0;
            // 
            // groupBoxPerformance
            // 
            this.groupBoxPerformance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPerformance.Controls.Add(this.txtComments);
            this.groupBoxPerformance.Controls.Add(this.lblComments);
            this.groupBoxPerformance.Controls.Add(this.txtCsvFile);
            this.groupBoxPerformance.Controls.Add(this.btnBrowseCsv);
            this.groupBoxPerformance.Controls.Add(this.lblCsvFile);
            this.groupBoxPerformance.Controls.Add(this.txtFxId);
            this.groupBoxPerformance.Controls.Add(this.lblFxId);
            this.groupBoxPerformance.Controls.Add(this.numYear);
            this.groupBoxPerformance.Controls.Add(this.lblYear);
            this.groupBoxPerformance.Controls.Add(this.numWeek);
            this.groupBoxPerformance.Controls.Add(this.lblWeek);
            this.groupBoxPerformance.Controls.Add(this.dtpSystemDate);
            this.groupBoxPerformance.Controls.Add(this.lblSystemDate);
            this.groupBoxPerformance.Controls.Add(this.cmbAccounts);
            this.groupBoxPerformance.Controls.Add(this.lblAccount);
            this.groupBoxPerformance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPerformance.Location = new System.Drawing.Point(23, 60);
            this.groupBoxPerformance.Name = "groupBoxPerformance";
            this.groupBoxPerformance.Size = new System.Drawing.Size(638, 400);
            this.groupBoxPerformance.TabIndex = 2;
            this.groupBoxPerformance.TabStop = false;
            this.groupBoxPerformance.Text = "Weekly Performance Update";
            // 
            // txtComments
            // 
            this.txtComments.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComments.Location = new System.Drawing.Point(150, 320);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComments.Size = new System.Drawing.Size(400, 60);
            this.txtComments.TabIndex = 9;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComments.Location = new System.Drawing.Point(30, 323);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(77, 17);
            this.lblComments.TabIndex = 8;
            this.lblComments.Text = "Comments:";
            // 
            // txtCsvFile
            // 
            this.txtCsvFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCsvFile.Location = new System.Drawing.Point(150, 280);
            this.txtCsvFile.Name = "txtCsvFile";
            this.txtCsvFile.ReadOnly = true;
            this.txtCsvFile.Size = new System.Drawing.Size(350, 25);
            this.txtCsvFile.TabIndex = 7;
            // 
            // btnBrowseCsv
            // 
            this.btnBrowseCsv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseCsv.Location = new System.Drawing.Point(510, 280);
            this.btnBrowseCsv.Name = "btnBrowseCsv";
            this.btnBrowseCsv.Size = new System.Drawing.Size(40, 25);
            this.btnBrowseCsv.TabIndex = 8;
            this.btnBrowseCsv.Text = "...";
            this.btnBrowseCsv.UseVisualStyleBackColor = true;
            this.btnBrowseCsv.Click += new System.EventHandler(this.btnBrowseCsv_Click);
            // 
            // lblCsvFile
            // 
            this.lblCsvFile.AutoSize = true;
            this.lblCsvFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCsvFile.Location = new System.Drawing.Point(30, 283);
            this.lblCsvFile.Name = "lblCsvFile";
            this.lblCsvFile.Size = new System.Drawing.Size(60, 17);
            this.lblCsvFile.TabIndex = 6;
            this.lblCsvFile.Text = "CSV File:";
            // 
            // txtFxId
            // 
            this.txtFxId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFxId.Location = new System.Drawing.Point(150, 200);
            this.txtFxId.Name = "txtFxId";
            this.txtFxId.ReadOnly = true;
            this.txtFxId.Size = new System.Drawing.Size(200, 25);
            this.txtFxId.TabIndex = 5;
            this.txtFxId.BackColor = System.Drawing.SystemColors.Control;
            // 
            // lblFxId
            // 
            this.lblFxId.AutoSize = true;
            this.lblFxId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFxId.Location = new System.Drawing.Point(30, 203);
            this.lblFxId.Name = "lblFxId";
            this.lblFxId.Size = new System.Drawing.Size(41, 17);
            this.lblFxId.TabIndex = 4;
            this.lblFxId.Text = "FX ID:";
            // 
            // numYear
            // 
            this.numYear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numYear.Location = new System.Drawing.Point(240, 160);
            this.numYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(80, 25);
            this.numYear.TabIndex = 4;
            this.numYear.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            this.numYear.ValueChanged += new System.EventHandler(this.Parameters_Changed);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(200, 163);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(36, 17);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Year:";
            // 
            // numWeek
            // 
            this.numWeek.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWeek.Location = new System.Drawing.Point(150, 160);
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
            this.numWeek.Size = new System.Drawing.Size(60, 25);
            this.numWeek.TabIndex = 3;
            this.numWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeek.ValueChanged += new System.EventHandler(this.Parameters_Changed);
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeek.Location = new System.Drawing.Point(30, 163);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(44, 17);
            this.lblWeek.TabIndex = 0;
            this.lblWeek.Text = "Week:";
            // 
            // dtpSystemDate
            // 
            this.dtpSystemDate.Enabled = false;
            this.dtpSystemDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSystemDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSystemDate.Location = new System.Drawing.Point(150, 120);
            this.dtpSystemDate.Name = "dtpSystemDate";
            this.dtpSystemDate.Size = new System.Drawing.Size(150, 25);
            this.dtpSystemDate.TabIndex = 2;
            // 
            // lblSystemDate
            // 
            this.lblSystemDate.AutoSize = true;
            this.lblSystemDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemDate.Location = new System.Drawing.Point(30, 123);
            this.lblSystemDate.Name = "lblSystemDate";
            this.lblSystemDate.Size = new System.Drawing.Size(86, 17);
            this.lblSystemDate.TabIndex = 2;
            this.lblSystemDate.Text = "System Date:";
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccounts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccounts.FormattingEnabled = true;
            this.cmbAccounts.Location = new System.Drawing.Point(150, 80);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Size = new System.Drawing.Size(300, 25);
            this.cmbAccounts.TabIndex = 1;
            this.cmbAccounts.SelectedIndexChanged += new System.EventHandler(this.cmbAccounts_SelectedIndexChanged);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.Location = new System.Drawing.Point(30, 83);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(94, 17);
            this.lblAccount.TabIndex = 0;
            this.lblAccount.Text = "Select Account:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(19, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "📊 Performance Update";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(20, 481);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(644, 60);
            this.panelButtons.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(534, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(434, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PerformanceUpdateForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PerformanceUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Weekly Performance Update";
            this.Load += new System.EventHandler(this.PerformanceUpdateForm_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.groupBoxPerformance.ResumeLayout(false);
            this.groupBoxPerformance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBoxPerformance;
        private System.Windows.Forms.ComboBox cmbAccounts;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.DateTimePicker dtpSystemDate;
        private System.Windows.Forms.Label lblSystemDate;
        private System.Windows.Forms.NumericUpDown numWeek;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtFxId;
        private System.Windows.Forms.Label lblFxId;
        private System.Windows.Forms.TextBox txtCsvFile;
        private System.Windows.Forms.Button btnBrowseCsv;
        private System.Windows.Forms.Label lblCsvFile;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label lblComments;
    }
}