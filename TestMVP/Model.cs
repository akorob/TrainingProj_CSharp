﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestMVP
{
    class Model
    {
        private double _valueFahrenheit = 32;
        private double _valueCelsius = 0;

        /// <summary>
        /// Градусы в шкале Фаренгейта
        /// </summary>
        public double ValueFahrenheit
        {
            get { return _valueFahrenheit; }
            set
            {
                _valueFahrenheit = value;
                _valueCelsius = (_valueFahrenheit - 32) * 5 / 9;
            }
        }

        /// <summary>
        /// Градусы в шкале Цельсия
        /// </summary>
        public double ValueCelsius
        {
            get { return _valueCelsius; }
            set
            {
                _valueCelsius = value;
                _valueFahrenheit = _valueCelsius * 9 / 5 + 32;
            }
        }
    }
}
