using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;



namespace SnakeArray
{
    ///<summary>
	/// Класс для хранения и сериализации/десереализации 
	/// настроек приложения в XML.
    /// </summary>
    [Serializable]
    public class Settings
    {
        private int _numColumns;
        private int _numRows;
        private string _path;

        private static  Settings _instance = new Settings();
        public static Settings Instance
        {
                get { return _instance; }
        }
        private Settings() { }


        [XmlElement]
	    public int NumColumns
	    {
		    get { return _numColumns; }
		    set { _numColumns = value; }
	    }

        [XmlElement]
        public int NumRows
        {
            get { return _numRows; }
            set { _numRows = value; }
        }

        [XmlElement]
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }


        public void SaveAppSettings()
        {
            StreamWriter myWriter = null;
            XmlSerializer mySerializer = null;
            try
            {
               mySerializer = new XmlSerializer(typeof(Settings));
               var filePath = System.IO.Path.Combine(Application.CommonAppDataPath, "app.config");
               myWriter = new StreamWriter(filePath, false);
               mySerializer.Serialize(myWriter, this);
            }
            catch(Exception ex)
            {
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


      public bool LoadAppSettings()
      {
         XmlSerializer mySerializer = null;
         FileStream myFileStream = null;
         bool fileExists = false;

         try
         {
            mySerializer = new XmlSerializer(typeof(Settings));
            var filePath = System.IO.Path.Combine(Application.CommonAppDataPath, "app.config");
            var fi = new FileInfo(filePath);
            if(fi.Exists)
            {
               myFileStream = fi.OpenRead();
               var myAppSettings = 
                 (Settings)mySerializer.Deserialize(
                  myFileStream);
               _numColumns = myAppSettings.NumColumns;
               _numRows = myAppSettings.NumRows;
               _path = myAppSettings.Path;
               fileExists = true;
            }
         }
         catch(Exception ex)
         {
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
