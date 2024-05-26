namespace WinFormsApp1
{
    partial class ExpRepForm
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
            button2 = new Button();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            checkBox1 = new CheckBox();
            npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            label7 = new Label();
            label8 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(671, 553);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(170, 77);
            button2.TabIndex = 23;
            button2.Text = "Закрыть";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonCancel_Click;
            // 
            // button1
            // 
            button1.Location = new Point(261, 553);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(254, 77);
            button1.TabIndex = 22;
            button1.Text = "Оплатить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(114, 119);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 18;
            label2.Text = "Заплачено";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 67);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 17;
            label1.Text = "Общая сумма";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(132, 464);
            checkBox1.Margin = new Padding(4, 5, 4, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(22, 21);
            checkBox1.TabIndex = 31;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // npgsqlDataAdapter1
            // 
            npgsqlDataAdapter1.DeleteCommand = null;
            npgsqlDataAdapter1.InsertCommand = null;
            npgsqlDataAdapter1.SelectCommand = null;
            npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(572, 119);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(522, 370);
            dataGridView1.TabIndex = 32;
            dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
            dataGridView1.CellValidating += DataGridView1_CellValidating;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(254, 67);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(64, 25);
            label3.TabIndex = 33;
            label3.Text = "сумма";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(254, 119);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(79, 25);
            label4.TabIndex = 34;
            label4.Text = "сумма 2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(174, 464);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(339, 25);
            label5.TabIndex = 35;
            label5.Text = "Добавить остальные средства в остаток";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(572, 67);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(163, 25);
            label6.TabIndex = 36;
            label6.Text = "Включено в отчёт:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(261, 230);
            comboBox1.Margin = new Padding(4, 5, 4, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(178, 33);
            comboBox1.TabIndex = 43;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(261, 298);
            numericUpDown1.Margin = new Padding(4, 5, 4, 5);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(171, 31);
            numericUpDown1.TabIndex = 46;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(88, 238);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(147, 25);
            label7.TabIndex = 47;
            label7.Text = "Статья расходов";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(128, 304);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(107, 25);
            label8.TabIndex = 48;
            label8.Text = "Количество";
            // 
            // button3
            // 
            button3.Location = new Point(174, 364);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(170, 41);
            button3.TabIndex = 49;
            button3.Text = "Добавить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ExpRepForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(button3);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ExpRepForm";
            Text = "Отчитаться за сумму";
            Load += invoiceAddForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Button button1;
        private Label label2;
        private Label label1;
        private CheckBox checkBox1;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private DataGridView dataGridView1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private Label label7;
        private Label label8;
        private Button button3;
    }
}