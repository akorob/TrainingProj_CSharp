using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using NLog;
using SnakeArray.Model;
using SnakeArray.Service;
using SnakeArray.View;

namespace SnakeArray 
{
    static class Program 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Главная точка входа в приложение.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ISnakeService, SnakeService>();
            var view = container.Resolve<SnakeFormView>();
            view.Load += new EventHandler(LoadAppSettings);
            view.Closing += new CancelEventHandler(SaveAppSettings);
            Application.Run(view);
        }



        private static void LoadAppSettings(object sender, EventArgs e)
        {
            var view = sender as ISnakeView;
            if (view == null)
                return;
            var appSettings = Settings.Instance;
            if (!appSettings.LoadAppSettings())
            {
                logger.Info("Приложение запущено, чтение настроек из файла невозможно.");
                return;
            }
                
            view.FilePath = appSettings.Path;
            try
            {
                view.NumRows = appSettings.NumRows;
                view.NumColumns = appSettings.NumColumns;
                logger.Info("Приложение запущено, последние настройки успешно загружены из файла.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("В конфигурационном файле неверные данные \n" + ex.ToString(),
                "Инициализация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Info("Приложение запущено, в конфигурационном файле неверные данные :" + ex.ToString());
            }
        }

        private static void SaveAppSettings(object sender, EventArgs e)
        {
            logger.Info("Приложение закрыто, настройки будут сохранены.");
            var view = sender as ISnakeView;
            if (view == null)
                return;
            var appSettings = Settings.Instance;
            appSettings.Path = view.FilePath;
            appSettings.NumRows = view.NumRows;
            appSettings.NumColumns = view.NumColumns;
            appSettings.SaveAppSettings();	
        }
    }
}
