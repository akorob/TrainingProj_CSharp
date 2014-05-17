using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeArray
{
    class Model
    {
        public int NumRows { get; private set; }
        public int NumColumns { get; private set; }
        public int[,] Array { get; private set; }

        public Model(int numColumns, int numRows, int[,] array)
        {
            NumColumns = numColumns;
            NumRows = numRows;
            Array = array;
        }
    }
}
