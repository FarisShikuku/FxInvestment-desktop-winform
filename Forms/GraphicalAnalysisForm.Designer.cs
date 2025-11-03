namespace FxInvestmentAdmin
{
    partial class GraphicalAnalysisForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartPerformance = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartPerformance)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // chartPerformance
            chartArea1.Name = "ChartArea1";
            this.chartPerformance.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPerformance.Legends.Add(legend1);
            this.chartPerformance.Location = new System.Drawing.Point(20, 80);
            this.chartPerformance.Name = "chartPerformance";
            this.chartPerformance.Size = new System.Drawing.Size(940, 450);
            this.chartPerformance.TabIndex = 0;
            title1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            title1.Name = "Title1";
            title1.Text = "Account Performance Analysis";
            this.chartPerformance.Titles.Add(title1);

            // cmbPeriod
            this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Location = new System.Drawing.Point(90, 45);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.Size = new System.Drawing.Size(250, 25);
            this.cmbPeriod.TabIndex = 1;
            this.cmbPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbPeriod_SelectedIndexChanged);

            // btnLoadData
            this.btnLoadData.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLoadData.Location = new System.Drawing.Point(360, 43);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(100, 30);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "Refresh";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);

            // btnExport
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnExport.Location = new System.Drawing.Point(600, 550);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 35);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            // btnPrint
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnPrint.Location = new System.Drawing.Point(710, 550);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 35);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // btnClose
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClose.Location = new System.Drawing.Point(820, 550);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // lblPeriod
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPeriod.Location = new System.Drawing.Point(20, 48);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(64, 17);
            this.lblPeriod.TabIndex = 6;
            this.lblPeriod.Text = "Time View:";

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(20, 560);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 15);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Select period to view";

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(984, 40);
            this.panelHeader.TabIndex = 8;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(15, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(172, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Graphical Analysis";

            // GraphicalAnalysisForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.cmbPeriod);
            this.Controls.Add(this.chartPerformance);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "GraphicalAnalysisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FX Investment - Graphical Analysis";
            ((System.ComponentModel.ISupportInitialize)(this.chartPerformance)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPerformance;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
    }
}