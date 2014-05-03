namespace MyApplication {
    partial class FormView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.button1 = new System.Windows.Forms.Button();
			this.columnsUpDown = new System.Windows.Forms.NumericUpDown();
			this.rowsUpDown = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.dataGrid = new System.Windows.Forms.DataGridView();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.columnsUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rowsUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(33, 311);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Построить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// columnsUpDown
			// 
			this.columnsUpDown.Location = new System.Drawing.Point(87, 245);
			this.columnsUpDown.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
			this.columnsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.columnsUpDown.Name = "columnsUpDown";
			this.columnsUpDown.Size = new System.Drawing.Size(43, 20);
			this.columnsUpDown.TabIndex = 1;
			this.columnsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.columnsUpDown.ValueChanged += new System.EventHandler(this.columnsUpDown_ValueChanged);
			// 
			// rowsUpDown
			// 
			this.rowsUpDown.Location = new System.Drawing.Point(166, 245);
			this.rowsUpDown.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
			this.rowsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.rowsUpDown.Name = "rowsUpDown";
			this.rowsUpDown.Size = new System.Drawing.Size(43, 20);
			this.rowsUpDown.TabIndex = 2;
			this.rowsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.rowsUpDown.ValueChanged += new System.EventHandler(this.rowsUpDown_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(84, 229);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Столбцы";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(163, 229);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Строки";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(135, 112);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// dataGrid
			// 
			this.dataGrid.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid.ColumnHeadersVisible = false;
			this.dataGrid.Location = new System.Drawing.Point(3, 4);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.RowHeadersVisible = false;
			this.dataGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGrid.Size = new System.Drawing.Size(286, 222);
			this.dataGrid.TabIndex = 7;
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(179, 311);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "Сохранить";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 279);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(194, 20);
			this.textBox1.TabIndex = 9;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(214, 279);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 10;
			this.button3.Text = "Файл...";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// FormView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 346);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dataGrid);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rowsUpDown);
			this.Controls.Add(this.columnsUpDown);
			this.Controls.Add(this.button1);
			this.Name = "FormView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Змейка";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormView_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.columnsUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rowsUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown columnsUpDown;
        private System.Windows.Forms.NumericUpDown rowsUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGrid;
    }
}

