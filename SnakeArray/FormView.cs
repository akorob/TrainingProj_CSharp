using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace SnakeArray {
	/// Главная форма приложения.
    public partial class FormView : Form {

        public FormView() {
            InitializeComponent();
			_appSettings = new Settings();
        }
        
        /// Свойство для доступа из класса DataGridViewPrinter.
        public DataGridView MyDataGrid
        {
            get { return dataGrid; } 
        }

        /// Свойство для доступа из класса FilePrinter.
        public TextBox MyTextBox
        {
            get { return textBox1; }
        }

	    private Settings _appSettings;
		private Pointer _snakePointer;

        private void Form1_Load(object sender, EventArgs e)
        {
			if(_appSettings.LoadAppSettings() )
			{
				textBox1.Text = _appSettings.Path;
				try
				{
					rowsUpDown.Value = _appSettings.NumRows;
					columnsUpDown.Value = _appSettings.NumColumns;
				}
				catch (ArgumentOutOfRangeException ex)
				{
					MessageBox.Show("В конфигурационном файле неверные данные \n" + ex.ToString(), 
					"Инициализация", MessageBoxButtons.OK, MessageBoxIcon.Error );
				}
				
			}
		}




        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            var numRows = (int)rowsUpDown.Value;
            var numColumns = (int)columnsUpDown.Value;
            _snakePointer = new Pointer(new int[numColumns, numRows]);
            _snakePointer.DoMagic();
		    IPrinter printer = new DataGridViewPrinter();
		    printer.Print(_snakePointer.Array);
	       

        }

        private void button2_Click(object sender, EventArgs e)
        {
			// Валидация данных TextBox.
            if (textBox1.Text.Length < 1)
            {
                MessageBox.Show("Файл не указан", "Сохранение файла", 
					MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            IPrinter printer = new FilePrinter();
            printer.Print(_snakePointer.Array);
		}

        private void button3_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
            
        }

        private void columnsUpDown_ValueChanged(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void rowsUpDown_ValueChanged(object sender, EventArgs e)
        {
             button2.Enabled = false;
        }

		private void FormView_FormClosing(object sender, FormClosingEventArgs e)
		{
			_appSettings.Path = textBox1.Text;
			_appSettings.NumRows = (int) rowsUpDown.Value;
			_appSettings.NumColumns = (int) columnsUpDown.Value;
			_appSettings.SaveAppSettings();	
		}

        

}

}
