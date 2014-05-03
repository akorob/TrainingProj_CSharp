using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;



namespace SnakeArray
{
	/// Класс для хранения и сериализации/десереализации 
	/// настроек приложения в XML.
    public class Settings
    {
        private int _numColumns;
        private int _numRows;
        private String _path;
	    private bool _appSettingsChanged;

	    public int NumColumns
	    {
		    get { return _numColumns; }
		    set
		    {
			    if(value != _numColumns)
				{
					_numColumns = value;
					_appSettingsChanged = true;
				}
				
		    }
	    }

	    public int NumRows
	    {
		    get { return _numRows; }
		    set
		    {
			    if(value != _numRows)
				{
					_numRows = value;
					_appSettingsChanged = true;
				}
		    }
	    }

	    public string Path
	    {
		    get { return _path; }
		    set
		    {
			    if(value != _path)
				{
					_path = value;
					_appSettingsChanged = true;
				}
		    }
	    }


      public bool SaveAppSettings()
      {
         if(_appSettingsChanged)
         {
            StreamWriter myWriter = null;
            XmlSerializer mySerializer = null;
            try
            {
               mySerializer = new XmlSerializer( 
                 typeof(Settings));
               myWriter = 
                 new StreamWriter(Application.CommonAppDataPath
                 + @"\app.config",false);
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
         return _appSettingsChanged;
      }


      public bool LoadAppSettings()
      {
         XmlSerializer mySerializer = null;
         FileStream myFileStream = null;
         bool fileExists = false;

         try
         {
            mySerializer = new XmlSerializer(typeof(Settings));
            var fi = new FileInfo(Application.CommonAppDataPath
               + @"\app.config");
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
