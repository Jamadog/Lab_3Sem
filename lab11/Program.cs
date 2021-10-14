using System;
using System.Collections.Generic;
using System.Linq;


namespace Test{

    class MassiveCreate{
        public string Str {get; set;}
    }

    class MassiveEdit{
        public string str;
        public int index_;
        public int ind1, ind2;

        public void InputStr(List<MassiveCreate> massive){
            Console.WriteLine("Напишите строку...");
            str = Console.ReadLine();
            massive.Add(new MassiveCreate() {Str = str});
        }

        public void PrintStr(List<MassiveCreate> massive){
            Console.WriteLine("Размер массива {0}", massive.Count);
            Console.WriteLine("Ваш массив:");
            for (int i = 0; i < massive.Count; i++){
                Console.WriteLine("Строка {0}", i+1);
                Console.WriteLine(massive[i].Str);
            }
        }

        public void PrintWithIndex(List<MassiveCreate> massive){
            Console.WriteLine("Введите индекс в пределах 0 - {0}", Convert.ToInt32(massive.Count)-1);
            index_ = Convert.ToInt32(Console.ReadLine());
            
            if (index_ >= 0 && index_ < massive.Count){
                Console.WriteLine("Ваша строка по индексу: ");
                Console.WriteLine(massive[index_].Str);
            }else{
                Console.WriteLine("Такого индекса не существует!");
            }
        }

        public void ConnectStrWithIndex(List<MassiveCreate> massive){
            Console.WriteLine("Введите индекс в пределах 0 - {0}", Convert.ToInt32(massive.Count)-1);
            Console.WriteLine("Введите 1-ый индекс");
            ind1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите 2-ый индекс");
            ind2 = Convert.ToInt32(Console.ReadLine());
                        
            if (ind1 >= 0 && ind2 >= 0){
                if (ind1 < massive.Count && ind2 < massive.Count){
                    string result = massive[ind1].Str + massive[ind2].Str;
                    Console.WriteLine("Строки сцеплены:");
                    Console.WriteLine(result);
                    massive.Add(new MassiveCreate() {Str = result});
                }else{
                    Console.WriteLine("Такого массива нет!");
                }
            }else{
                Console.WriteLine("Такого массива нет!");
            }
        }

        public void ConnectStrNoCopy(List<MassiveCreate> massive){
            Console.WriteLine("Введите индекс в пределах 0 - {0}", Convert.ToInt32(massive.Count)-1);
            Console.WriteLine("Введите 1-ый индекс");
            ind1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите 2-ый индекс");
            ind2 = Convert.ToInt32(Console.ReadLine());
                        
            if (ind1 >= 0 && ind2 >= 0){
                if (ind1 < massive.Count && ind2 < massive.Count){
                    string result = massive[ind1].Str + massive[ind2].Str;
                    if (massive.FindIndex(x => x.Str.Contains(result)) > 0){
                        Console.WriteLine("Извините, эти массивы уже были сцеплены ранее!");
                    }else{
                        Console.WriteLine("Строки сцеплены:");
                        Console.WriteLine(result);
                        massive.Add(new MassiveCreate() {Str = result});
                    }
                }else{
                    Console.WriteLine("Такого массива нет!");
                }
            }else{
                Console.WriteLine("Такого массива нет!");
            }
        }
    }

    class Program{
        static void Main(string[] args){

            List<MassiveCreate> massive = new List<MassiveCreate>();
            MassiveEdit test = new MassiveEdit();

            string choice;
            do{
                if (massive != null && massive.Count == 0){
                    Console.WriteLine("Массив пустой!\nНажмите 1");
                }
                Console.WriteLine("1 - Внесение строки");
                Console.WriteLine("2 - Вывести весь массив");
                Console.WriteLine("3 - Вывести по индексу");
                Console.WriteLine("4 - Сцепление строк по индексам");
                Console.WriteLine("5 - Слияния массивов без повторения");
                Console.WriteLine("6 - Выход из программы");
                choice = Console.ReadLine();

                switch(choice){
                    case "1":
                        test.InputStr(massive);
                        break;
                    case "2":
                        test.PrintStr(massive);
                        break;
                    case "3":
                        test.PrintWithIndex(massive);
                        break;
                    case "4":
                        test.ConnectStrWithIndex(massive);
                        break;
                    case "5":
                        test.ConnectStrNoCopy(massive);
                        break; 
                }
            } while (choice != "6");
        }
    }
}