using System.Windows.Forms.DataVisualization;

namespace WinFormsApp1
{
    partial class PieChartForm
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
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            checkedListBox1 = new CheckedListBox();
            label3 = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 117);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 9;
            label2.Text = "Конец";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 65);
            label1.Name = "label1";
            label1.Size = new Size(73, 25);
            label1.TabIndex = 8;
            label1.Text = "Начало";
            // 
            // button1
            // 
            button1.Location = new Point(161, 360);
            button1.Name = "button1";
            button1.Size = new Size(185, 97);
            button1.TabIndex = 7;
            button1.Text = "Сформировать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(118, 117);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(300, 31);
            dateTimePicker2.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(118, 65);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.Value = new DateTime(2024, 5, 1, 0, 0, 0, 0);
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(144, 187);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(229, 144);
            checkedListBox1.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 187);
            label3.Name = "label3";
            label3.Size = new Size(90, 50);
            label3.TabIndex = 11;
            label3.Text = "Cтатьи \r\nрасходов";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(456, 35);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(450, 450);
            chart1.TabIndex = 12;
            chart1.Text = "chart1";
            // 
            // PieChartForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 508);
            Controls.Add(chart1);
            Controls.Add(label3);
            Controls.Add(checkedListBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Name = "PieChartForm";
            Text = "PieChartForm";
            Load += PieChartForm_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private Button button1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private CheckedListBox checkedListBox1;
        private Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}