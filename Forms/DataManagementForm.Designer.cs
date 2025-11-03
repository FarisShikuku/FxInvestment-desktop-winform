namespace FxInvestmentAdmin
{
    partial class DataManagementForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPerformance = new System.Windows.Forms.TabPage();
            this.dgvPerformance = new System.Windows.Forms.DataGridView();
            this.btnDeleteSelectedPerformance = new System.Windows.Forms.Button();
            this.btnDeleteAllPerformance = new System.Windows.Forms.Button();
            this.btnRefreshPerformance = new System.Windows.Forms.Button();
            this.tabAccounts = new System.Windows.Forms.TabPage();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.btnDeleteSelectedAccount = new System.Windows.Forms.Button();
            this.btnDeleteAllAccounts = new System.Windows.Forms.Button();
            this.btnRefreshAccounts = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPerformance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).BeginInit();
            this.tabAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPerformance);
            this.tabControl.Controls.Add(this.tabAccounts);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(984, 500);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPerformance
            // 
            this.tabPerformance.Controls.Add(this.dgvPerformance);
            this.tabPerformance.Controls.Add(this.btnDeleteSelectedPerformance);
            this.tabPerformance.Controls.Add(this.btnDeleteAllPerformance);
            this.tabPerformance.Controls.Add(this.btnRefreshPerformance);
            this.tabPerformance.Location = new System.Drawing.Point(4, 24);
            this.tabPerformance.Name = "tabPerformance";
            this.tabPerformance.Padding = new System.Windows.Forms.Padding(3);
            this.tabPerformance.Size = new System.Drawing.Size(976, 472);
            this.tabPerformance.TabIndex = 0;
            this.tabPerformance.Text = "Performance Records";
            this.tabPerformance.UseVisualStyleBackColor = true;
            // 
            // dgvPerformance
            // 
            this.dgvPerformance.AllowUserToAddRows = false;
            this.dgvPerformance.AllowUserToDeleteRows = false;
            this.dgvPerformance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPerformance.Location = new System.Drawing.Point(10, 10);
            this.dgvPerformance.Name = "dgvPerformance";
            this.dgvPerformance.ReadOnly = true;
            this.dgvPerformance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerformance.Size = new System.Drawing.Size(950, 400);
            this.dgvPerformance.TabIndex = 0;
            // 
            // btnDeleteSelectedPerformance
            // 
            this.btnDeleteSelectedPerformance.BackColor = System.Drawing.Color.Orange;
            this.btnDeleteSelectedPerformance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSelectedPerformance.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDeleteSelectedPerformance.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSelectedPerformance.Location = new System.Drawing.Point(10, 420);
            this.btnDeleteSelectedPerformance.Name = "btnDeleteSelectedPerformance";
            this.btnDeleteSelectedPerformance.Size = new System.Drawing.Size(180, 35);
            this.btnDeleteSelectedPerformance.TabIndex = 1;
            this.btnDeleteSelectedPerformance.Text = "Delete Selected Records";
            this.btnDeleteSelectedPerformance.UseVisualStyleBackColor = false;
            this.btnDeleteSelectedPerformance.Click += new System.EventHandler(this.btnDeleteSelectedPerformance_Click);
            // 
            // btnDeleteAllPerformance
            // 
            this.btnDeleteAllPerformance.BackColor = System.Drawing.Color.Red;
            this.btnDeleteAllPerformance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAllPerformance.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDeleteAllPerformance.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAllPerformance.Location = new System.Drawing.Point(200, 420);
            this.btnDeleteAllPerformance.Name = "btnDeleteAllPerformance";
            this.btnDeleteAllPerformance.Size = new System.Drawing.Size(220, 35);
            this.btnDeleteAllPerformance.TabIndex = 2;
            this.btnDeleteAllPerformance.Text = "Delete All Performance Records";
            this.btnDeleteAllPerformance.UseVisualStyleBackColor = false;
            this.btnDeleteAllPerformance.Click += new System.EventHandler(this.btnDeleteAllPerformance_Click);
            // 
            // btnRefreshPerformance
            // 
            this.btnRefreshPerformance.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnRefreshPerformance.Location = new System.Drawing.Point(780, 420);
            this.btnRefreshPerformance.Name = "btnRefreshPerformance";
            this.btnRefreshPerformance.Size = new System.Drawing.Size(180, 35);
            this.btnRefreshPerformance.TabIndex = 3;
            this.btnRefreshPerformance.Text = "Refresh";
            this.btnRefreshPerformance.UseVisualStyleBackColor = true;
            this.btnRefreshPerformance.Click += new System.EventHandler(this.btnRefreshPerformance_Click);
            // 
            // tabAccounts
            // 
            this.tabAccounts.Controls.Add(this.dgvAccounts);
            this.tabAccounts.Controls.Add(this.btnDeleteSelectedAccount);
            this.tabAccounts.Controls.Add(this.btnDeleteAllAccounts);
            this.tabAccounts.Controls.Add(this.btnRefreshAccounts);
            this.tabAccounts.Location = new System.Drawing.Point(4, 24);
            this.tabAccounts.Name = "tabAccounts";
            this.tabAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccounts.Size = new System.Drawing.Size(976, 472);
            this.tabAccounts.TabIndex = 1;
            this.tabAccounts.Text = "Account Records";
            this.tabAccounts.UseVisualStyleBackColor = true;
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.AllowUserToDeleteRows = false;
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccounts.Location = new System.Drawing.Point(10, 10);
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(950, 400);
            this.tabAccounts.TabIndex = 0;
            // 
            // btnDeleteSelectedAccount
            // 
            this.btnDeleteSelectedAccount.BackColor = System.Drawing.Color.Orange;
            this.btnDeleteSelectedAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSelectedAccount.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDeleteSelectedAccount.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSelectedAccount.Location = new System.Drawing.Point(10, 420);
            this.btnDeleteSelectedAccount.Name = "btnDeleteSelectedAccount";
            this.btnDeleteSelectedAccount.Size = new System.Drawing.Size(180, 35);
            this.btnDeleteSelectedAccount.TabIndex = 1;
            this.btnDeleteSelectedAccount.Text = "Delete Selected Account";
            this.btnDeleteSelectedAccount.UseVisualStyleBackColor = false;
            this.btnDeleteSelectedAccount.Click += new System.EventHandler(this.btnDeleteSelectedAccount_Click);
            // 
            // btnDeleteAllAccounts
            // 
            this.btnDeleteAllAccounts.BackColor = System.Drawing.Color.Red;
            this.btnDeleteAllAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAllAccounts.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDeleteAllAccounts.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAllAccounts.Location = new System.Drawing.Point(200, 420);
            this.btnDeleteAllAccounts.Name = "btnDeleteAllAccounts";
            this.btnDeleteAllAccounts.Size = new System.Drawing.Size(220, 35);
            this.btnDeleteAllAccounts.TabIndex = 2;
            this.btnDeleteAllAccounts.Text = "Delete All Accounts";
            this.btnDeleteAllAccounts.UseVisualStyleBackColor = false;
            this.btnDeleteAllAccounts.Click += new System.EventHandler(this.btnDeleteAllAccounts_Click);
            // 
            // btnRefreshAccounts
            // 
            this.btnRefreshAccounts.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnRefreshAccounts.Location = new System.Drawing.Point(780, 420);
            this.btnRefreshAccounts.Name = "btnRefreshAccounts";
            this.btnRefreshAccounts.Size = new System.Drawing.Size(180, 35);
            this.btnRefreshAccounts.TabIndex = 3;
            this.btnRefreshAccounts.Text = "Refresh";
            this.btnRefreshAccounts.UseVisualStyleBackColor = true;
            this.btnRefreshAccounts.Click += new System.EventHandler(this.btnRefreshAccounts_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(20, 520);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 15);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Select period to view";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClose.Location = new System.Drawing.Point(880, 515);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DataManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "DataManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data Management - Edit/Clear Records";
            this.tabControl.ResumeLayout(false);
            this.tabPerformance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).EndInit();
            this.tabAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPerformance;
        private System.Windows.Forms.DataGridView dgvPerformance;
        private System.Windows.Forms.Button btnDeleteSelectedPerformance;
        private System.Windows.Forms.Button btnDeleteAllPerformance;
        private System.Windows.Forms.Button btnRefreshPerformance;
        private System.Windows.Forms.TabPage tabAccounts;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.Button btnDeleteSelectedAccount;
        private System.Windows.Forms.Button btnDeleteAllAccounts;
        private System.Windows.Forms.Button btnRefreshAccounts;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClose;
    }
}