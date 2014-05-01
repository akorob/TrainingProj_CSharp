using System;
// Ver 0.2 : учтены замечания по v 0.1
namespace ConsoleApplication2 {
    class Pointer 
    {
        // Текущий элемент строки x.  
        public int x = 0;
        // Текущая строка y.
        public int y = 0;
        // Обрабатываемый массив
        public int[,] array {get; set;}
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
            while (true) {
                switch (currentDir) {
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


    class Program {
        static void Main(string[] args) 
        {
            int m = 0; //rows
            int n = 0; //columns
            // Пользовательский ввод
            while (true) 
                {
                Console.WriteLine("Enter number of columns n and rows m separated by space:");
                String[] consInput = Console.ReadLine().Split(' ');
                if (consInput.Length != 2) 
                {
                    // Неверное кол-во параметров.
                    Console.WriteLine("Must be two parameters. Try again.");
                } else if (Int32.TryParse(consInput[0], out n) &
                                 Int32.TryParse(consInput[1], out m)) 
                {
                    // Введено число типа int.
                    if (n > 0 && n < 101 && m > 0 && m < 101) break;
                    else Console.WriteLine("Dimensions must be in range 0..100. Try again.");
                } else 
                {
                    // Не число типа int.
                    Console.WriteLine("Entered digits uncorrect. Try again.");
                }
            }

            // Логика приложения
            int counter = 0;
            Pointer p = new Pointer(new int[n, m]);
            do 
            {
                counter++;
                p.array[p.x, p.y] = counter;
            }
            while (p.FindNext());

            //Вывод
            PrintArray(p.array);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void PrintArray(int[,] array)
        {
            for (int j = 0; j <= array.GetUpperBound(1); j++)
            {
                for (int i = 0; i <= array.GetUpperBound(0); i++)
                {
                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
