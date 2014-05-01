using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class FormView : Form {
        public FormView() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Логика приложения
            int numRows = (int)rowsUpDown.Value;
            int numColumns = (int)columnsUpDown.Value;
            int counter = 0;
            Pointer p = new Pointer(new int[numColumns, numRows]);
            do
            {
                counter++;
                p.array[p.x, p.y] = counter;
            }
            while (p.FindNext());

            // Вывод
            dataGrid.Rows.Clear();
            dataGrid.ColumnCount = numColumns;
            dataGrid.RowCount = numRows;
            for (int j = 0; j < numRows; j++)
                for (int i = 0; i < numColumns; i++)
                {
                    dataGrid.Rows[j].Cells[i].Value = p.array[i, j];
                }
        }
    }
}
