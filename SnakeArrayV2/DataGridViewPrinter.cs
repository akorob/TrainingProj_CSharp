using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SnakeArray
{
    
    class DataGridViewPrinter: IPrinter
    {
    
        public DataGridView DataGrid { get; set; }

        public void Print(Model model)
        {
 			try
	        {

				DataGrid.Rows.Clear();
				DataGrid.ColumnCount = model.NumColumns;
				DataGrid.RowCount = model.NumRows;
                for (var j = 0; j < model.NumRows; j++)
				{
                    for (var i = 0; i < model.NumColumns; i++)
					{
						DataGrid.Rows[j].Cells[i].Value = model.Array[i, j];
					}
				}
	        }
	        catch (InvalidOperationException ex)
	        {
		            MessageBox.Show(ex.ToString());
	        }
			catch (ArgumentException ex)
	        {
		            MessageBox.Show(ex.ToString());
	        }
			catch (IndexOutOfRangeException ex)
			{
				MessageBox.Show(ex.ToString());
			}

		
        }
    }
}
