using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace TestMVP
{
    public class Presenter
    {
        private Model _model = new Model();
        private IView _view;

        public void SetView(IView view)
        {
            this._view = view;
            _view.SetCelsius += new EventHandler<EventArgs>(OnSetCelsius);
            _view.SetFarenheit += new EventHandler<EventArgs>(OnSetFarenheit);
            RefreshView();
        }

        /// <summary>
        /// Обработка события, установка нового значения градусов по Фаренгейту
        /// </summary>
        private void OnSetFarenheit(object sender, EventArgs e)
        {
            _model.ValueFahrenheit = _view.InputDegree;
            RefreshView();
        }

        /// <summary>
        /// Обработка события, установка нового значения градусов Цельсия
        /// </summary>
        private void OnSetCelsius(object sender, EventArgs e)
        {
            _model.ValueCelsius = _view.InputDegree;
            RefreshView();
        }

        /// <summary>
        /// Обновление Представления новыми значениями модели.
        /// По сути Binding (привязка) значений модели к Представлению. 
        /// </summary>
        private void RefreshView()
        {
            _view.Celsius = _model.ValueCelsius;
            _view.Farenheit = _model.ValueFahrenheit;
        }
    }
}
