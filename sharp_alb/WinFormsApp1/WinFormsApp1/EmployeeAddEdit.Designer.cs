namespace WinFormsApp1
{
    partial class EmployeeAddEdit
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
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(259, 237);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(107, 57);
            button2.TabIndex = 15;
            button2.Text = "Закрыть";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonCancel_Click;
            // 
            // button1
            // 
            button1.Location = new Point(62, 237);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(107, 57);
            button1.TabIndex = 14;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonSave_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(181, 95);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(241, 31);
            textBox1.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 95);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(47, 25);
            label1.TabIndex = 8;
            label1.Text = "Имя";
            // 
            // EmployeeAddEdit
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 335);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "EmployeeAddEdit";
            Text = "Добавить сотрудника";
            Load += EmployeeAddEdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
    }
}