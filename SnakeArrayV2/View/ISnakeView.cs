﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnakeArray.View
{
    /// <summary>
    /// Интерфейс главной формы приложения, для реализации V в MVP.
    /// </summary>
    public interface ISnakeView
    {
        /// <summary>
        /// Нажатие кнопки "Построить".
        /// </summary>
        event EventHandler<EventArgs> BuildClicked;

        /// <summary>
        /// Нажатие кнопки для выбора файла.
        /// </summary>
        event EventHandler<EventArgs> FileSelectClicked;

        /// <summary>
        /// Путь к файлу вывода.
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Количество строк матрицы.
        /// </summary>
        int NumRows { get; set; }

        /// <summary>
        /// Количество столбцов матрицы.
        /// </summary>
        int NumColumns { get; set; }

        /// <summary>
        /// Объект для вывода матрицы на экран.
        /// </summary>
        DataGridView MyDataGridView { get; }

    }
}
