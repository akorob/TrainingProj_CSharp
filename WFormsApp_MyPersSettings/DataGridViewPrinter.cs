using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MyApplication
{
    
    class DataGridViewPrinter: IPrinter
    {
        private FormView GetMainForm()
        {
            foreach (var form in Application.OpenForms)
            {
                var res = form as FormView;
                if (res != null)
                {
                    return res;
                }
            }
            throw new MissingMemberException("Main Form not found");
        }




        public void Print(int[,] array)
        {
            var mainForm = GetMainForm();
            var numColumns = array.GetUpperBound(0)+1;
            var numRows = array.GetUpperBound(1)+1;
            mainForm.MyDataGrid.Rows.Clear();
            mainForm.MyDataGrid.ColumnCount = numColumns;
            mainForm.MyDataGrid.RowCount = numRows;
            for (var j = 0; j < numRows; j++)
                for (var i = 0; i < numColumns; i++)
                {
                    mainForm.MyDataGrid.Rows[j].Cells[i].Value = array[i, j];
                }
        }
    }
}
