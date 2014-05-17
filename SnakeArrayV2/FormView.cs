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
using NLog;

namespace SnakeArray 
{
    ///<summary>
    /// Главная форма приложения.
    /// </summary>

    public partial class FormView : Form 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public FormView() 
        {
            InitializeComponent();
			_appSettings = Settings.Instance;
        }
        

	    private Settings _appSettings;

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            var numRows = (int)rowsUpDown.Value;
            var numColumns = (int)columnsUpDown.Value;
            var model = new Service().CalculateModel(numColumns, numRows);
		    var printer = new DataGridViewPrinter();
            printer.DataGrid = this.dataGrid;
		    printer.Print(model);

            var result = MessageBox.Show("Сохранить в файл?", "Сохранение в файл",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result != DialogResult.OK)
                return;
            
            // Валидация данных TextBox.
            if (string.IsNullOrEmpty(textBoxFilePath.Text))
            {
                MessageBox.Show("Файл не указан", "Сохранение файла",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var prntr = new FilePrinter();
            prntr.Path = textBoxFilePath.Text;
            prntr.Print(model);
            
	       

        }


        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = openFileDialog1.FileName;
            }
            
        }


		private void FormView_FormClosing(object sender, FormClosingEventArgs e)
		{
			_appSettings.Path = textBoxFilePath.Text;
			_appSettings.NumRows = (int) rowsUpDown.Value;
			_appSettings.NumColumns = (int) columnsUpDown.Value;
			_appSettings.SaveAppSettings();	
		}

        private void FormView_Load(object sender, EventArgs e)
        {
            logger.Trace("Sample trace message");
            logger.Debug("Sample debug message");
            logger.Info("Sample informational message");
            logger.Warn("Sample warning message");
            logger.Error("Sample error message");
            logger.Fatal("Sample fatal error message");
            textBoxFilePath.Text = _appSettings.Path;
           if (_appSettings.LoadAppSettings())
            {
               
                try
                {
                    rowsUpDown.Value = _appSettings.NumRows;
                    columnsUpDown.Value = _appSettings.NumColumns;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show("В конфигурационном файле неверные данные \n" + ex.ToString(),
                    "Инициализация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }



       

    }

}
