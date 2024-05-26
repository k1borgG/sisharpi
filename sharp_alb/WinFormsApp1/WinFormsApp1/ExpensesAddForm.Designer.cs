namespace WinFormsApp1
{
    partial class ExpensesAddForm
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(146, 134);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 25);
            label1.TabIndex = 0;
            label1.Text = "Сумма";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(116, 205);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(116, 25);
            label2.TabIndex = 1;
            label2.Text = "Дата выдачи";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(263, 134);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(284, 31);
            textBox1.TabIndex = 4;
            textBox1.KeyPress += textBox2_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(125, 330);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(123, 76);
            button1.TabIndex = 6;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(356, 330);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(123, 76);
            button2.TabIndex = 7;
            button2.Text = "Закрыть";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(144, 72);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(88, 25);
            label4.TabIndex = 41;
            label4.Text = "Работник";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(263, 69);
            comboBox1.Margin = new Padding(4, 5, 4, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(284, 33);
            comboBox1.TabIndex = 40;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(263, 205);
            dateTimePicker1.Margin = new Padding(4, 5, 4, 5);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(284, 31);
            dateTimePicker1.TabIndex = 53;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(144, 275);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(261, 29);
            checkBox1.TabIndex = 54;
            checkBox1.Text = "Экспортировать в MS Excel";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // ExpensesAddForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 457);
            Controls.Add(checkBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ExpensesAddForm";
            Text = "Выдать сумму";
            Load += productAddForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Label label4;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private CheckBox checkBox1;
    }
}