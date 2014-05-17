using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TestMVP
{
    public interface IView
    {
        /// <summary>
        /// Вывод градусов Фаренгейта
        /// </summary>
        double Farenheit { set; }

        /// <summary>
        /// Вывод градусов Цельсия
        /// </summary>
        double Celsius { set; }

        /// <summary>
        /// Ввод нового значения градусов
        /// </summary>
        double InputDegree { get; }

        /// <summary>
        /// Событие ввода значения по Фаренгейту
        /// </summary>
        event EventHandler<EventArgs> SetFarenheit;

        /// <summary>
        /// Событие ввода значения по цельсию
        /// </summary>
        event EventHandler<EventArgs> SetCelsius;
    }
}
