using System;

namespace ConsoleApplication2{
    class Pointer {
        public int x = 0;
        public int y = 0;
        private int currentDir = 0;

        public bool findNext(int[,] a) {
            int tX = x; //rows
            int tY = y;  //columns
            int fails = 0;
            while (true) {
                switch (currentDir) {
                    case 0: //right
                        tX++;
                        break;
                    case 1: //down
                        tY++;
                        break;
                    case 2: //left
                        tX--;
                        break;
                    case 3: //up
                        tY--;
                        break;
                }
                try {
                    if (a[tX,tY] == 0) {
                        x = tX;
                        y = tY;
                        fails = 0;
                        return true;
                    }
                } catch  { }
                tX = x;
                tY = y;
                if (currentDir >= 3) currentDir = 0; 
                else currentDir++;
                if (++fails == 4) return false;
            }
        }
    }


    class Program {
        static void Main(string[] args){
            int m = 0; //rows
            int n = 0; //columns
            // user input
            while (true) {
                Console.WriteLine("Enter number of columns n and rows m separated by space:");
                String consInput = Console.ReadLine();
                if (consInput.Split(' ').Length != 2) {
                    // check number of parameters
                    Console.WriteLine("Must be two parameters. Try again.");
                } else if (Int32.TryParse(consInput.Split(' ')[0], out n) &
                                 Int32.TryParse(consInput.Split(' ')[1], out m)) {
                    //this is an int
                    if (n > 0 && n < 101 && m > 0 && m < 101) break;
                    else Console.WriteLine("Dimensions must be in range 0..100. Try again.");
                } else {
                    // this is not an int
                    Console.WriteLine("Entered digits uncorrect. Try again.");
                }
            }
            
            //application logic
            int counter = 0;
    	    int [,] array = new int[n,m];
    
            Pointer p = new Pointer();
	   	    do {
    		    counter++;
    		    array[p.x,p.y] = counter;
	        } while (p.findNext(array));


            //output
            for (int j = 0; j < m; j++) {
                for (int i = 0; i < n; i++) {
                    Console.Write("{0,4}", array[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
