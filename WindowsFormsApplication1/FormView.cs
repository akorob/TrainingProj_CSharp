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

namespace WindowsFormsApplication1 {
    public partial class FormView : Form {

        public FormView() {
            InitializeComponent();
        }
        
        // Для доступа из DataGridViewPrinter
        public DataGridView MyDataGrid
        {
            get { return dataGrid; } 
        }

        // Для доступа из FilePrinter
        public TextBox MyTextBox
        {
            get { return textBox1; }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
	        try
	        {
		        textBox1.Text = Properties.Settings.Default.Path;
		        rowsUpDown.Value = Properties.Settings.Default.NumRows;
		        columnsUpDown.Value = Properties.Settings.Default.NumColumns;
	        }
			catch ( ConfigurationException ex)
			{   
				var config = ((System.Configuration.ConfigurationException)ex.InnerException).Filename;
				MessageBox.Show("Восстановление настроек невозможно, загрузите приложение заново \n"
					+ ex.ToString(), "Инициализация приложения", MessageBoxButtons.OK, MessageBoxIcon.Error );   
				System.IO.File.Delete(config);
				Application.Exit();
			}
	        catch (ArgumentOutOfRangeException ex)
	        {
				MessageBox.Show("Восстановление настроек невозможно \n"+ex.ToString(), 
					"Инициализация приложения", MessageBoxButtons.OK, MessageBoxIcon.Error );        
			}

			
		}




        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            var numRows = (int)rowsUpDown.Value;
            var numColumns = (int)columnsUpDown.Value;
            var p = new Pointer(new int[numColumns, numRows]);
            p.DoMagic();

	        try
	        {
		        IPrinter printer = new DataGridViewPrinter();
		        printer.Print(p.Array);
	        }
	        catch (InvalidOperationException ex)
	        {
		         MessageBox.Show("Произошла ошибка \n" + ex.ToString(), "Построение", 
					MessageBoxButtons.OK, MessageBoxIcon.Error );
	        }
			catch (ArgumentOutOfRangeException ex)
	        {
		         MessageBox.Show("Произошла ошибка \n" + ex.ToString(), "Построение", 
					MessageBoxButtons.OK, MessageBoxIcon.Error );
	        }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
            {
                MessageBox.Show("Файл не указан", "Сохранение файла", 
					MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            var numRows = (int)rowsUpDown.Value;
            var numColumns = (int)columnsUpDown.Value;
            var p = new Pointer(new int[numColumns, numRows]);
            p.DoMagic();

            try
            {
                IPrinter printer = new FilePrinter();
                printer.Print(p.Array);
                MessageBox.Show("Данные успешно сохранены", 
					"Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.None );
            }
            catch (IOException error)
            {
                MessageBox.Show("Ошибка при сохранении файла \n"+ error.ToString(), 
					"Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.None );
            }

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
			try
			{
				Properties.Settings.Default.NumRows = (int) rowsUpDown.Value;
				Properties.Settings.Default.NumColumns = (int) columnsUpDown.Value;
				Properties.Settings.Default.Path = textBox1.Text;
				Properties.Settings.Default.Save();
			}
			catch ( ConfigurationException ex)
			{
				MessageBox.Show("Возникла ошибка при сохранении настроек \n" + ex.ToString(),
					 "Закрытие приложения", MessageBoxButtons.OK, MessageBoxIcon.Error );        
			}
			
		}

        
    }
}
