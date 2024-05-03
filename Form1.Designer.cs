namespace HW2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.FolderArea2 = new System.Windows.Forms.Panel();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.DrawingArea = new System.Windows.Forms.Panel();
            this.PieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BarChartBtn = new System.Windows.Forms.Button();
            this.PieChartBtn = new System.Windows.Forms.Button();
            this.DrawingArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PieChart)).BeginInit();
            this.SuspendLayout();
            // 
            // FolderArea2
            // 
            this.FolderArea2.AutoScroll = true;
            this.FolderArea2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FolderArea2.Location = new System.Drawing.Point(31, 12);
            this.FolderArea2.Name = "FolderArea2";
            this.FolderArea2.Size = new System.Drawing.Size(280, 630);
            this.FolderArea2.TabIndex = 0;
            this.FolderArea2.Paint += new System.Windows.Forms.PaintEventHandler(this.FolderArea2_Paint_1);
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BrowseBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BrowseBtn.Location = new System.Drawing.Point(114, 552);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseBtn.TabIndex = 2;
            this.BrowseBtn.Text = "Browse";
            this.BrowseBtn.UseVisualStyleBackColor = false;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // DrawingArea
            // 
            this.DrawingArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawingArea.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DrawingArea.Controls.Add(this.PieChart);
            this.DrawingArea.Location = new System.Drawing.Point(317, 68);
            this.DrawingArea.Name = "DrawingArea";
            this.DrawingArea.Size = new System.Drawing.Size(358, 654);
            this.DrawingArea.TabIndex = 3;
            this.DrawingArea.Paint += new System.Windows.Forms.PaintEventHandler(this.Drawing_Area_Paint);
            this.DrawingArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drawing_Area_MouseDown);
            // 
            // PieChart
            // 
            chartArea1.Name = "ChartArea1";
            this.PieChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.PieChart.Legends.Add(legend1);
            this.PieChart.Location = new System.Drawing.Point(320, 50);
            this.PieChart.Name = "PieChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "s1";
            this.PieChart.Series.Add(series1);
            this.PieChart.Size = new System.Drawing.Size(600, 600);
            this.PieChart.TabIndex = 0;
            this.PieChart.Text = "chart1";
            this.PieChart.Visible = false;
            // 
            // BarChartBtn
            // 
            this.BarChartBtn.Location = new System.Drawing.Point(370, 28);
            this.BarChartBtn.Name = "BarChartBtn";
            this.BarChartBtn.Size = new System.Drawing.Size(75, 23);
            this.BarChartBtn.TabIndex = 4;
            this.BarChartBtn.Text = "Bar Chart";
            this.BarChartBtn.UseVisualStyleBackColor = true;
            this.BarChartBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // PieChartBtn
            // 
            this.PieChartBtn.Location = new System.Drawing.Point(484, 28);
            this.PieChartBtn.Name = "PieChartBtn";
            this.PieChartBtn.Size = new System.Drawing.Size(75, 23);
            this.PieChartBtn.TabIndex = 5;
            this.PieChartBtn.Text = "Pie Chart";
            this.PieChartBtn.UseVisualStyleBackColor = true;
            this.PieChartBtn.Click += new System.EventHandler(this.PieChartBtn_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(687, 499);
            this.Controls.Add(this.PieChartBtn);
            this.Controls.Add(this.BarChartBtn);
            this.Controls.Add(this.DrawingArea);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.FolderArea2);
            this.Name = "Form1";
            this.Text = "Mini File Explorer";
            this.DrawingArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PieChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FolderArea;
        private System.Windows.Forms.Label TestLable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel FolderArea2;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.Panel DrawingArea;
        private System.Windows.Forms.Button BarChartBtn;
        private System.Windows.Forms.Button PieChartBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart PieChart;
    }
}

