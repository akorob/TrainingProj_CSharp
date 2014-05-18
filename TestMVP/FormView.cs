using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.Unity;


namespace TestMVP
{
    public partial class FormView : Form, IView
    {
        private Presenter _presenter;
        public FormView()
        {
            InitializeComponent();
        }

        [Dependency]
        public Presenter MyPresenter
        {
            get { return _presenter; }
            set
            {
                _presenter = value;
                _presenter.SetView(this);
            }
        }

        private void _celsiusButton_Click(object sender, EventArgs e)
        {
            if (SetCelsius != null)
                SetCelsius(this, EventArgs.Empty);
        }

        private void _farenheitButton_Click(object sender, EventArgs e)
        {
           if (SetFarenheit != null)
                SetFarenheit(this, EventArgs.Empty);
        }


        public double Farenheit
        {
            set { _farenheitBox.Text = value.ToString("N2"); }
        }

        public double  Celsius
        {
            set { _celsiusBox.Text = value.ToString("N2"); }
        }

        public double InputDegree
        {
            get { return Convert.ToDouble(_inputBox.Text); }
        }

        public event EventHandler<EventArgs> SetFarenheit;

        public event EventHandler<EventArgs> SetCelsius;
    }
}