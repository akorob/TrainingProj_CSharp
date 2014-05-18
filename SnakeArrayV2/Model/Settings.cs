using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using NLog;

namespace SnakeArray.Model
{
    ///<summary>
	/// Класс - singlton для хранения и сериализации/десереализации 
	/// настроек приложения в XML.
    /// </summary>
    [Serializable]
    public class Settings
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private int _numColumns;
        private int _numRows;
        private string _path;

        private XmlSerializer _mySerializer = new XmlSerializer(typeof(Settings));
        private static  Settings _instance = new Settings();

        ///<summary>
        /// Возвращает экземпляр класса.
        /// </summary>
        public static Settings Instance
        {
                get { return _instance; }
        }
        private Settings() { }

        ///<summary>
        /// Количество столбцов матрицы.
        /// </summary>
        [XmlElement]
	    public int NumColumns
	    {
		    get { return _numColumns; }
		    set { _numColumns = value; }
	    }

        ///<summary>
        /// Количество строк матрицы.
        /// </summary>
        [XmlElement]
        public int NumRows
        {
            get { return _numRows; }
            set { _numRows = value; }
        }

        ///<summary>
        /// Путь к файлу вывода.
        /// </summary>
        [XmlElement]
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        ///<summary>
        /// Метод сохранения настроек.
        /// </summary>
        public void SaveAppSettings()
        {
            StreamWriter myWriter = null;
            try
            {
               var filePath = System.IO.Path.Combine(Application.CommonAppDataPath, "app.config");
               myWriter = new StreamWriter(filePath, false);
               _mySerializer.Serialize(myWriter, this);
               logger.Debug("Настройки сохранены успешно.");
            }
            catch(Exception ex)
            {
                logger.Debug("Ошибка сохранения настроек. " + ex.ToString());
                MessageBox.Show("Произошла ошибка \n" + ex.ToString(), 
					"Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            finally
            {
               if(myWriter != null)
               {
                  myWriter.Close();
               }
            }
      }

      ///<summary>
      /// Метод загрузки настроек.
      /// </summary>  
      public bool LoadAppSettings()
      {
         FileStream myFileStream = null;
         bool fileExists = false;
         try
         {
            var filePath = System.IO.Path.Combine(Application.CommonAppDataPath, "app.config");
            var fi = new FileInfo(filePath);
            if(fi.Exists)
            {
               myFileStream = fi.OpenRead();
               var myAppSettings = (Settings)_mySerializer.Deserialize(myFileStream);
               _numColumns = myAppSettings.NumColumns;
               _numRows = myAppSettings.NumRows;
               _path = myAppSettings.Path;
               fileExists = true;
               logger.Debug("Настройки успешно загружены из файла.");
            }
         }
         catch(Exception ex)
         {
             logger.Debug("Ошибка загрузки настроек. " + ex.ToString());
             MessageBox.Show("Произошла ошибка \n" + ex.ToString(), 
					"Инициализация", MessageBoxButtons.OK, MessageBoxIcon.Error );
         }
         finally
         {
            if(myFileStream != null)
            {
               myFileStream.Close();
            }
         }
         return fileExists;
      }


    }
}
