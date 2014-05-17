namespace TestMVP
{
    partial class FormView
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._celsiusButton = new System.Windows.Forms.Button();
            this._farenheitButton = new System.Windows.Forms.Button();
            this._celsiusBox = new System.Windows.Forms.TextBox();
            this._farenheitBox = new System.Windows.Forms.TextBox();
            this._inputBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _celsiusButton
            // 
            this._celsiusButton.Location = new System.Drawing.Point(39, 96);
            this._celsiusButton.Name = "_celsiusButton";
            this._celsiusButton.Size = new System.Drawing.Size(107, 23);
            this._celsiusButton.TabIndex = 0;
            this._celsiusButton.Text = "_celsiusButton";
            this._celsiusButton.UseVisualStyleBackColor = true;
            this._celsiusButton.Click += new System.EventHandler(this._celsiusButton_Click);
            // 
            // _farenheitButton
            // 
            this._farenheitButton.Location = new System.Drawing.Point(171, 96);
            this._farenheitButton.Name = "_farenheitButton";
            this._farenheitButton.Size = new System.Drawing.Size(98, 23);
            this._farenheitButton.TabIndex = 1;
            this._farenheitButton.Text = "_farenheitButton";
            this._farenheitButton.UseVisualStyleBackColor = true;
            this._farenheitButton.Click += new System.EventHandler(this._farenheitButton_Click);
            // 
            // _celsiusBox
            // 
            this._celsiusBox.Location = new System.Drawing.Point(43, 12);
            this._celsiusBox.Name = "_celsiusBox";
            this._celsiusBox.Size = new System.Drawing.Size(71, 20);
            this._celsiusBox.TabIndex = 2;
            // 
            // _farenheitBox
            // 
            this._farenheitBox.Location = new System.Drawing.Point(194, 12);
            this._farenheitBox.Name = "_farenheitBox";
            this._farenheitBox.Size = new System.Drawing.Size(63, 20);
            this._farenheitBox.TabIndex = 3;
            // 
            // _inputBox
            // 
            this._inputBox.Location = new System.Drawing.Point(99, 57);
            this._inputBox.Name = "_inputBox";
            this._inputBox.Size = new System.Drawing.Size(100, 20);
            this._inputBox.TabIndex = 4;
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 131);
            this.Controls.Add(this._inputBox);
            this.Controls.Add(this._farenheitBox);
            this.Controls.Add(this._celsiusBox);
            this.Controls.Add(this._farenheitButton);
            this.Controls.Add(this._celsiusButton);
            this.Name = "FormView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _celsiusButton;
        private System.Windows.Forms.Button _farenheitButton;
        private System.Windows.Forms.TextBox _celsiusBox;
        private System.Windows.Forms.TextBox _farenheitBox;
        private System.Windows.Forms.TextBox _inputBox;
    }
}

