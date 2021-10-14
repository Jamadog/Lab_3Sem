using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
 

namespace lab32
{
    abstract class Solution{
        public string line_write;
        public double x1, x2, disc, x;
        public string lineeer = "----------------------------------------";
        public string filename = "C:/Users/Jamadog/Desktop/My_Docs/Учеба 2 курс/ооп/my_v9/lab32/word.txt";
        public int z;

        public void PrintSquare(){
            Console.WriteLine(lineeer);
            Console.WriteLine("Дискриминант уравнение {0}", disc);
            Console.WriteLine("Первый корень уравнения {0}\nВторой корень уравнения {1}", x1, x2);
            Console.WriteLine(lineeer);
        }

        public void PrintLinear(){
            Console.WriteLine(lineeer);
            Console.WriteLine("Корень уравнения {0}", x);
            Console.WriteLine(lineeer);
        }

        public List<Series> SortSolution(List<Series> series_list){
            Console.WriteLine("Выберите значение сортировки:\n1 - X\n2 - X1\n3 - X2\n4 - Disc");
            z = Convert.ToInt32(Console.ReadLine());

            if (z == 1){
                series_list = series_list.OrderBy(i => i.X).ToList();
                Console.WriteLine("Список отсортированный по x");
                
            } else if (z == 2) {
                series_list = series_list.OrderBy(i => i.X1).ToList();
                Console.WriteLine("Список отсортированный по x1");
                
            } else if (z == 3) {
                series_list = series_list.OrderBy(i => i.X2).ToList();
                Console.WriteLine("Список отсортированный по x2");
                
            } else if (z == 4) {
                series_list = series_list.OrderBy(i => i.Disc).ToList();
                Console.WriteLine("Список отсортированный по disc");
                
            }
            return series_list;
        }

        public void PrintSolution(List<Series> series_list){
            Console.WriteLine("Все доступные решения: ");
            Console.WriteLine("Их {0}", series_list.Count);
            Console.WriteLine(lineeer);
            for (int i = 0; i < series_list.Count; i++){
                Console.WriteLine("x - {0}", series_list[i].X);
                Console.WriteLine("x1 - {0}", series_list[i].X1);
                Console.WriteLine("x2 - {0}", series_list[i].X2);
                Console.WriteLine("Disc - {0}", series_list[i].Disc);
                Console.WriteLine(lineeer);
            }
        }

        public void EnterFile(List<Series> series_list){
            
            using (FileStream fstream = new FileStream(filename, FileMode.Create)){
                for (int i = 0; i < series_list.Count; i++){
                    line_write = series_list[i].X + "\t" + series_list[i].X1 + "\t" + series_list[i].X2 + "\t" + series_list[i].Disc + "\n";
                    byte[] array = System.Text.Encoding.Default.GetBytes(line_write);
                    fstream.Write(array, 0, array.Length);
                }
                Console.WriteLine("Решения записаны.");
            }
        }

        public void ReadFile(){
            using (FileStream fstream = File.OpenRead(filename)){
                
                byte[] array = new byte[fstream.Length];
                
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла:\nX\tX1\tX2\tDisc\n{textFromFile}");
            }
        }

    }

    class SolutionLinear : Solution{
        public void SolLinear(double a, double b, List<Series> series_list){
            x = -(b/a);
            series_list.Add(new Series() {X = x});
        }
    }
    
    class SolutionSquare : Solution{
        public void SolSquare(double a, double b, double c, List<Series> series_list){
            disc = (b*b) - (4*a*c);
            series_list.Add(new Series() {Disc = disc});
            if (disc > 0){
                x1 = ((-b)+disc)/(2*a);
                x2 = ((-b)-disc)/(2*a);
                series_list.Add(new Series() {X1 = x1});
                series_list.Add(new Series() {X2 = x2});
            } else if (disc == 0) {
                x1 = -(b/2*a);
                x2 = x1;
                series_list.Add(new Series() {X1 = x1});
                series_list.Add(new Series() {X2 = x2});
            } else {
                Console.WriteLine("Корней уравнения нет!\nДискриминант < 0");
            }
        }
    }

    class Method : Solution{}

    class Series{
        public double X {get; set;}
        public double X1 {get; set;}
        public double X2 {get; set;}
        public double Disc {get; set;}    
    }

    class Program{

        static void Main(string[] args){
            string choice;
            double a, b, c;
            SolutionLinear equationlinear = new SolutionLinear();
            SolutionSquare equationsquare = new SolutionSquare();
            Method method = new Method();
            List<Series> series_list = new List<Series>();

            do{
                Console.WriteLine("1 - Линейное уравнение");
                Console.WriteLine("2 - Квадратное уравнение");
                Console.WriteLine("3 - Вывод всех решений");
                Console.WriteLine("4 - Сортировка по критерию");
                Console.WriteLine("5 - Внести вычисления в файл");
                Console.WriteLine("6 - Считать вычисления с файла");
                Console.WriteLine("Exit - Выход из программы");

                choice = Console.ReadLine();
                switch (choice){
                    case "1":                        
                        Console.WriteLine("Уравнение вида a*x + b = 0\nНапишите a, b");
                        a = double.Parse(Console.ReadLine());
                        b = double.Parse(Console.ReadLine());
                        if (a != 0){
                            equationlinear.SolLinear(a, b, series_list);
                            equationlinear.PrintLinear();
                        } else {
                            Console.WriteLine("A не должно равняться 0");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Уравнение вида a*x^2 + b*x + c = 0\nНапишите a, b, c");
                        a = double.Parse(Console.ReadLine());
                        b = double.Parse(Console.ReadLine());
                        c = double.Parse(Console.ReadLine());
                        if (a != 0 ){
                            equationsquare.SolSquare(a, b, c, series_list);
                            equationsquare.PrintSquare();
                        } else {
                            Console.WriteLine("A не должно равняться 0");
                        }
                        break;
                    case "3":
                        method.PrintSolution(series_list);
                        break;
                    case "4":
                        series_list = method.SortSolution(series_list);
                        break;
                    case "5":
                        method.EnterFile(series_list);
                        break;
                    case "6":
                        method.ReadFile();
                        break;
                }
            } while (choice != "Exit");
        }
    }
}
