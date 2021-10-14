using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
 
namespace lab61
{
    class Complex{
        public int x {get; set;}
        public int y {get; set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            int x1, x2;

            Complex A = new Complex();
            Complex B = new Complex();

            do{
                try{
                    Console.WriteLine("Введите комплексные числа A (целое число)");
                    Console.Write("a - ");
                    A.x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("b - ");
                    A.y = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите комплексные числа B (целое число)");
                    Console.Write("a - ");
                    B.x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("b - ");
                    B.y = Convert.ToInt32(Console.ReadLine());
                    if (A.x == 0 | A.y == 0 | B.x == 0 | B.y == 0){
                        Console.WriteLine("Вы ввели 0, введите заново целое число!\n");
                    }
                }
                catch{
                    Console.WriteLine("Вы ввели не число! \n");
                }
            } while (A.x == 0 | A.y == 0 | B.x == 0 | B.y == 0);
            Console.WriteLine("Окей! Ваши комплексные числа");
            Console.WriteLine("A: {0} + {1}i", A.x, A.y);
            Console.WriteLine("B: {0} + {1}i", B.x, B.y);
            
            x1 = ( ( ( A.x*B.x ) + ( A.y*B.y ) ) / ( ( B.x*B.x ) + ( B.y*B.y ) ) );
            x2 = ( ( ( B.x*A.y ) - ( A.x*B.y ) ) / ( ( B.x*B.x ) + ( B.y*B.y ) ) );

            Console.WriteLine("Деление ваших комплексных чисел");
            Console.WriteLine("{0} + {1}i", x1, x2);
        }
    }
}
