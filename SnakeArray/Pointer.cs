using System;

namespace SnakeArray
{
		/// Класс для хранения и обработки массива.
        class Pointer
        {

            /// Обрабатываемый массив.
            public int[,] Array { get; private set; }

            // Текущий элемент строки x.  
            private int _x = 0;
            // Текущая строка y.
            private int _y = 0;
            private enum Direction { Right, Down, Left, Up };
            private Direction _currentDir = Direction.Right;

            public Pointer(int[,] array)
            {
                this.Array = array;
            }


            /// Заполняет массив "змейкой".
            public void DoMagic()
            {
                var counter = 0;
                do
                {
                    counter++;
                    Array[_x, _y] = counter;
                }
                while (FindNext());
            }





            // Поиск следующего элемента массива в заданном порядке;
            // возвращает false, если элемент отсутствует.
            private bool FindNext()
            {
                var tmpX = _x;
                var tmpY = _y;
                var fails = 0;
                while (true)
                {
                    switch (_currentDir)
                    {
                        case Direction.Right:
                            tmpX++;
                            break;
                        case Direction.Down:
                            tmpY++;
                            break;
                        case Direction.Left:
                            tmpX--;
                            break;
                        case Direction.Up:
                            tmpY--;
                            break;
                    }

                    if (tmpX >= 0 && tmpX <= Array.GetUpperBound(0) &&
                         tmpY >= 0 && tmpY <= Array.GetUpperBound(1))
                    {

                        if (Array[tmpX, tmpY] == 0)
                        {
                            _x = tmpX;
                            _y = tmpY;
                            return true;
                        }
                    }
                    // Вышли за границу массива или элемент уже преобразован.
                    tmpX = _x;
                    tmpY = _y;
                    _currentDir = NewDirection(_currentDir);
                    // Нет подходящих элементов по всем направлениям.
                    if (++fails == 4) 
						return false;
                }
            }

            private Direction NewDirection(Direction dir)
            {
                switch (dir)
                {
                    case Direction.Right:
                        return Direction.Down;
                    case Direction.Down:
                        return Direction.Left;
                    case Direction.Left:
                        return Direction.Up;
                    case Direction.Up:
                        return Direction.Right;
                }
                throw new MissingMemberException("Enum do not contains such element");
            }
        }
}
