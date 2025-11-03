namespace FxInvestmentAdmin.Forms
{
    partial class AccountManagementForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountManagementForm));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageCreate = new System.Windows.Forms.TabPage();
            this.panelCreateContent = new System.Windows.Forms.Panel();
            this.groupBoxAccountDetails = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dtpCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.numInitialDeposit = new System.Windows.Forms.NumericUpDown();
            this.lblInitialDeposit = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.btnGenerateId = new System.Windows.Forms.Button();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.lblAccountId = new System.Windows.Forms.Label();
            this.lblCreateTitle = new System.Windows.Forms.Label();
            this.panelCreateButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabPageView = new System.Windows.Forms.TabPage();
            this.panelViewContent = new System.Windows.Forms.Panel();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTotalProfit = new System.Windows.Forms.Label();
            this.lblTotalBalance = new System.Windows.Forms.Label();
            this.lblTotalAccounts = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabPageCreate.SuspendLayout();
            this.panelCreateContent.SuspendLayout();
            this.groupBoxAccountDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialDeposit)).BeginInit();
            this.panelCreateButtons.SuspendLayout();
            this.tabPageView.SuspendLayout();
            this.panelViewContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.panelSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageCreate);
            this.tabControlMain.Controls.Add(this.tabPageView);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(884, 561);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageCreate
            // 
            this.tabPageCreate.BackColor = System.Drawing.Color.White;
            this.tabPageCreate.Controls.Add(this.panelCreateContent);
            this.tabPageCreate.Controls.Add(this.panelCreateButtons);
            this.tabPageCreate.Location = new System.Drawing.Point(4, 26);
            this.tabPageCreate.Name = "tabPageCreate";
            this.tabPageCreate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCreate.Size = new System.Drawing.Size(876, 531);
            this.tabPageCreate.TabIndex = 0;
            this.tabPageCreate.Text = "Create Account";
            // 
            // panelCreateContent
            // 
            this.panelCreateContent.Controls.Add(this.groupBoxAccountDetails);
            this.panelCreateContent.Controls.Add(this.lblCreateTitle);
            this.panelCreateContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCreateContent.Location = new System.Drawing.Point(3, 3);
            this.panelCreateContent.Name = "panelCreateContent";
            this.panelCreateContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelCreateContent.Size = new System.Drawing.Size(870, 475);
            this.panelCreateContent.TabIndex = 0;
            // 
            // groupBoxAccountDetails
            // 
            this.groupBoxAccountDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAccountDetails.Controls.Add(this.txtDescription);
            this.groupBoxAccountDetails.Controls.Add(this.lblDescription);
            this.groupBoxAccountDetails.Controls.Add(this.dtpCreatedDate);
            this.groupBoxAccountDetails.Controls.Add(this.lblCreatedDate);
            this.groupBoxAccountDetails.Controls.Add(this.cmbCurrency);
            this.groupBoxAccountDetails.Controls.Add(this.lblCurrency);
            this.groupBoxAccountDetails.Controls.Add(this.numInitialDeposit);
            this.groupBoxAccountDetails.Controls.Add(this.lblInitialDeposit);
            this.groupBoxAccountDetails.Controls.Add(this.txtAccountName);
            this.groupBoxAccountDetails.Controls.Add(this.lblAccountName);
            this.groupBoxAccountDetails.Controls.Add(this.btnGenerateId);
            this.groupBoxAccountDetails.Controls.Add(this.txtAccountId);
            this.groupBoxAccountDetails.Controls.Add(this.lblAccountId);
            this.groupBoxAccountDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAccountDetails.Location = new System.Drawing.Point(23, 60);
            this.groupBoxAccountDetails.Name = "groupBoxAccountDetails";
            this.groupBoxAccountDetails.Size = new System.Drawing.Size(824, 380);
            this.groupBoxAccountDetails.TabIndex = 1;
            this.groupBoxAccountDetails.TabStop = false;
            this.groupBoxAccountDetails.Text = "Account Details";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(150, 240);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(400, 100);
            this.txtDescription.TabIndex = 9;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(30, 243);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(77, 17);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Description:";
            // 
            // dtpCreatedDate
            // 
            this.dtpCreatedDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedDate.Location = new System.Drawing.Point(150, 200);
            this.dtpCreatedDate.Name = "dtpCreatedDate";
            this.dtpCreatedDate.Size = new System.Drawing.Size(200, 25);
            this.dtpCreatedDate.TabIndex = 7;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedDate.Location = new System.Drawing.Point(30, 203);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(87, 17);
            this.lblCreatedDate.TabIndex = 6;
            this.lblCreatedDate.Text = "Created Date:";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Items.AddRange(new object[] {
            "USD",
            "EUR",
            "GBP",
            "JPY"});
            this.cmbCurrency.Location = new System.Drawing.Point(150, 160);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(120, 25);
            this.cmbCurrency.TabIndex = 5;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrency.Location = new System.Drawing.Point(30, 163);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(63, 17);
            this.lblCurrency.TabIndex = 4;
            this.lblCurrency.Text = "Currency:";
            // 
            // numInitialDeposit
            // 
            this.numInitialDeposit.DecimalPlaces = 2;
            this.numInitialDeposit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numInitialDeposit.Location = new System.Drawing.Point(150, 120);
            this.numInitialDeposit.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numInitialDeposit.Name = "numInitialDeposit";
            this.numInitialDeposit.Size = new System.Drawing.Size(120, 25);
            this.numInitialDeposit.TabIndex = 3;
            this.numInitialDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numInitialDeposit.ThousandsSeparator = true;
            this.numInitialDeposit.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblInitialDeposit
            // 
            this.lblInitialDeposit.AutoSize = true;
            this.lblInitialDeposit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialDeposit.Location = new System.Drawing.Point(30, 123);
            this.lblInitialDeposit.Name = "lblInitialDeposit";
            this.lblInitialDeposit.Size = new System.Drawing.Size(92, 17);
            this.lblInitialDeposit.TabIndex = 2;
            this.lblInitialDeposit.Text = "Initial Deposit:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(150, 80);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(300, 25);
            this.txtAccountName.TabIndex = 2;
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.Location = new System.Drawing.Point(30, 83);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(98, 17);
            this.lblAccountName.TabIndex = 1;
            this.lblAccountName.Text = "Account Name:";
            // 
            // btnGenerateId
            // 
            this.btnGenerateId.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGenerateId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateId.ForeColor = System.Drawing.Color.White;
            this.btnGenerateId.Location = new System.Drawing.Point(280, 40);
            this.btnGenerateId.Name = "btnGenerateId";
            this.btnGenerateId.Size = new System.Drawing.Size(75, 25);
            this.btnGenerateId.TabIndex = 1;
            this.btnGenerateId.Text = "Generate";
            this.btnGenerateId.UseVisualStyleBackColor = false;
            this.btnGenerateId.Click += new System.EventHandler(this.btnGenerateId_Click);
            // 
            // txtAccountId
            // 
            this.txtAccountId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccountId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountId.Location = new System.Drawing.Point(150, 40);
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(120, 25);
            this.txtAccountId.TabIndex = 0;
            // 
            // lblAccountId
            // 
            this.lblAccountId.AutoSize = true;
            this.lblAccountId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountId.Location = new System.Drawing.Point(30, 43);
            this.lblAccountId.Name = "lblAccountId";
            this.lblAccountId.Size = new System.Drawing.Size(74, 17);
            this.lblAccountId.TabIndex = 0;
            this.lblAccountId.Text = "Account ID:";
            // 
            // lblCreateTitle
            // 
            this.lblCreateTitle.AutoSize = true;
            this.lblCreateTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateTitle.Location = new System.Drawing.Point(19, 20);
            this.lblCreateTitle.Name = "lblCreateTitle";
            this.lblCreateTitle.Size = new System.Drawing.Size(239, 25);
            this.lblCreateTitle.TabIndex = 0;
            this.lblCreateTitle.Text = "Create New FX Account";
            // 
            // panelCreateButtons
            // 
            this.panelCreateButtons.BackColor = System.Drawing.SystemColors.Control;
            this.panelCreateButtons.Controls.Add(this.btnCancel);
            this.panelCreateButtons.Controls.Add(this.btnSave);
            this.panelCreateButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCreateButtons.Location = new System.Drawing.Point(3, 478);
            this.panelCreateButtons.Name = "panelCreateButtons";
            this.panelCreateButtons.Size = new System.Drawing.Size(870, 50);
            this.panelCreateButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(760, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 1;
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
            this.btnSave.Location = new System.Drawing.Point(660, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabPageView
            // 
            this.tabPageView.BackColor = System.Drawing.Color.White;
            this.tabPageView.Controls.Add(this.panelViewContent);
            this.tabPageView.Location = new System.Drawing.Point(4, 26);
            this.tabPageView.Name = "tabPageView";
            this.tabPageView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageView.Size = new System.Drawing.Size(876, 531);
            this.tabPageView.TabIndex = 1;
            this.tabPageView.Text = "View Accounts";
            // 
            // panelViewContent
            // 
            this.panelViewContent.Controls.Add(this.dgvAccounts);
            this.panelViewContent.Controls.Add(this.panelSummary);
            this.panelViewContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViewContent.Location = new System.Drawing.Point(3, 3);
            this.panelViewContent.Name = "panelViewContent";
            this.panelViewContent.Padding = new System.Windows.Forms.Padding(10);
            this.panelViewContent.Size = new System.Drawing.Size(870, 525);
            this.panelViewContent.TabIndex = 0;
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.AllowUserToDeleteRows = false;
            this.dgvAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAccounts.BackgroundColor = System.Drawing.Color.White;
            this.dgvAccounts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAccounts.ColumnHeadersHeight = 35;
            this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAccounts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAccounts.Location = new System.Drawing.Point(13, 83);
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAccounts.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAccounts.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(844, 429);
            this.dgvAccounts.TabIndex = 1;
            this.dgvAccounts.SelectionChanged += new System.EventHandler(this.dgvAccounts_SelectionChanged);
            // 
            // panelSummary
            // 
            this.panelSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSummary.BackColor = System.Drawing.Color.AliceBlue;
            this.panelSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummary.Controls.Add(this.btnRefresh);
            this.panelSummary.Controls.Add(this.lblTotalProfit);
            this.panelSummary.Controls.Add(this.lblTotalBalance);
            this.panelSummary.Controls.Add(this.lblTotalAccounts);
            this.panelSummary.Location = new System.Drawing.Point(13, 13);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(844, 60);
            this.panelSummary.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(740, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.AutoSize = true;
            this.lblTotalProfit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProfit.Location = new System.Drawing.Point(450, 20);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Size = new System.Drawing.Size(83, 17);
            this.lblTotalProfit.TabIndex = 2;
            this.lblTotalProfit.Text = "Total Profit: ";
            // 
            // lblTotalBalance
            // 
            this.lblTotalBalance.AutoSize = true;
            this.lblTotalBalance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBalance.Location = new System.Drawing.Point(250, 20);
            this.lblTotalBalance.Name = "lblTotalBalance";
            this.lblTotalBalance.Size = new System.Drawing.Size(98, 17);
            this.lblTotalBalance.TabIndex = 1;
            this.lblTotalBalance.Text = "Total Balance: ";
            // 
            // lblTotalAccounts
            // 
            this.lblTotalAccounts.AutoSize = true;
            this.lblTotalAccounts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAccounts.Location = new System.Drawing.Point(30, 20);
            this.lblTotalAccounts.Name = "lblTotalAccounts";
            this.lblTotalAccounts.Size = new System.Drawing.Size(106, 17);
            this.lblTotalAccounts.TabIndex = 0;
            this.lblTotalAccounts.Text = "Total Accounts: ";
            // 
            // AccountManagementForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tabControlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FX Account Management";
            this.Load += new System.EventHandler(this.AccountManagementForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageCreate.ResumeLayout(false);
            this.panelCreateContent.ResumeLayout(false);
            this.panelCreateContent.PerformLayout();
            this.groupBoxAccountDetails.ResumeLayout(false);
            this.groupBoxAccountDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialDeposit)).EndInit();
            this.panelCreateButtons.ResumeLayout(false);
            this.tabPageView.ResumeLayout(false);
            this.panelViewContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageCreate;
        private System.Windows.Forms.TabPage tabPageView;
        private System.Windows.Forms.Panel panelCreateContent;
        private System.Windows.Forms.GroupBox groupBoxAccountDetails;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.DateTimePicker dtpCreatedDate;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.NumericUpDown numInitialDeposit;
        private System.Windows.Forms.Label lblInitialDeposit;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Button btnGenerateId;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.Label lblAccountId;
        private System.Windows.Forms.Label lblCreateTitle;
        private System.Windows.Forms.Panel panelCreateButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelViewContent;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTotalProfit;
        private System.Windows.Forms.Label lblTotalBalance;
        private System.Windows.Forms.Label lblTotalAccounts;
    }
}