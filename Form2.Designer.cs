﻿namespace Dnevnik_2._0
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Januar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Februar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.April = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Avgust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Septembar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Oktobar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Novembar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Decembar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Statistika";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(111, 12);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series5.Legend = "Legend1";
            series5.Name = "s1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(585, 384);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ime,
            this.Januar,
            this.Februar,
            this.Mart,
            this.April,
            this.Maj,
            this.Jun,
            this.Jul,
            this.Avgust,
            this.Septembar,
            this.Oktobar,
            this.Novembar,
            this.Decembar});
            this.dataGridView1.Location = new System.Drawing.Point(0, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1353, 305);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Visible = false;
            // 
            // ime
            // 
            this.ime.HeaderText = "Column1";
            this.ime.Name = "ime";
            // 
            // Januar
            // 
            this.Januar.HeaderText = "I";
            this.Januar.Name = "Januar";
            // 
            // Februar
            // 
            this.Februar.HeaderText = "II";
            this.Februar.Name = "Februar";
            // 
            // Mart
            // 
            this.Mart.HeaderText = "III";
            this.Mart.Name = "Mart";
            // 
            // April
            // 
            this.April.HeaderText = "IV";
            this.April.Name = "April";
            // 
            // Maj
            // 
            this.Maj.HeaderText = "V";
            this.Maj.Name = "Maj";
            // 
            // Jun
            // 
            this.Jun.HeaderText = "VI";
            this.Jun.Name = "Jun";
            // 
            // Jul
            // 
            this.Jul.HeaderText = "VII";
            this.Jul.Name = "Jul";
            // 
            // Avgust
            // 
            this.Avgust.HeaderText = "VIII";
            this.Avgust.Name = "Avgust";
            // 
            // Septembar
            // 
            this.Septembar.HeaderText = "IX";
            this.Septembar.Name = "Septembar";
            // 
            // Oktobar
            // 
            this.Oktobar.HeaderText = "X";
            this.Oktobar.Name = "Oktobar";
            // 
            // Novembar
            // 
            this.Novembar.HeaderText = "XI";
            this.Novembar.Name = "Novembar";
            // 
            // Decembar
            // 
            this.Decembar.HeaderText = "XII";
            this.Decembar.Name = "Decembar";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 451);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Januar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Februar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mart;
        private System.Windows.Forms.DataGridViewTextBoxColumn April;
        private System.Windows.Forms.DataGridViewTextBoxColumn Maj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jun;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jul;
        private System.Windows.Forms.DataGridViewTextBoxColumn Avgust;
        private System.Windows.Forms.DataGridViewTextBoxColumn Septembar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Oktobar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Novembar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Decembar;
    }
}