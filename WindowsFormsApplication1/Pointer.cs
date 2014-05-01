using System;

namespace WindowsFormsApplication1
{
        class Pointer
        {
            // Текущий элемент строки x.  
            public int x = 0;
            // Текущая строка y.
            public int y = 0;
            // Обрабатываемый массив
            public int[,] array { get; set; }
            private enum Direction { Right, Down, Left, Up };
            private Direction currentDir = Direction.Right;
            // Конструктор
            public Pointer(int[,] a)
            {
                x = 0;
                y = 0;
                array = a;
            }
            // Поиск следующего элемента массива в заданном порядке;
            // возвращает false, если элемент отсутствует.
            public bool FindNext()
            {
                int tmpX = x;
                int tmpY = y;
                int fails = 0;
                while (true)
                {
                    switch (currentDir)
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

                    if (tmpX >= 0 && tmpX <= array.GetUpperBound(0) &&
                         tmpY >= 0 && tmpY <= array.GetUpperBound(1))
                    {
                        Console.WriteLine("tmpX={0}, tmpY={1}", tmpX, tmpY);
                        if (array[tmpX, tmpY] == 0)
                        {
                            x = tmpX;
                            y = tmpY;
                            return true;
                        }
                    }
                    // Вышли за границу массива или элемент уже преобразован.
                    tmpX = x;
                    tmpY = y;
                    currentDir = NewDirection(currentDir);
                    // Нет подходящих элементов по всем направлениям.
                    if (++fails == 4) return false;
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
