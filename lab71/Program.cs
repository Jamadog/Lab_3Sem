using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
 
namespace lab71
{
    class Program{
        static void Main(string[] args){
            int n;
            string filename = "text.txt";
            int k = 0;

            Console.WriteLine("Введите нужное кол-во слов");
            n = Convert.ToInt32(Console.ReadLine());

            using (FileStream fstream = File.OpenRead(filename)){

                byte[] array = new byte[fstream.Length];                                // преобразуем строку в байты
                fstream.Read(array, 0, array.Length);                                   // считываем данные
                string textFromFile = System.Text.Encoding.Default.GetString(array);    // декодируем байты в строку
                
                string[] subc = textFromFile.Split('\n');
                for (int i = 0; i < subc.Count(); i++){
                    // Console.WriteLine(subc[i]);
                    subc[i] = subc[i].Trim(new char[] { ',', '.' });            // удаляем . ,
                    string[] textArray = subc[i].Split(new char[] { ' ' });     // преобразуем i-ю строку в отдельный массив
                    if (textArray.Length == n){
                        Console.WriteLine(subc[i]);
                    } else {
                        k += 1;
                    }
                    while (subc[i].Contains("  ")){             // пока есть двойные пробелы
                        subc[i] = subc[i].Replace("  ", " ");   // заменяем двойной на одиночный
                    }
                }
                if (k == subc.Count()){
                    Console.WriteLine("Заданного кол-во слов нет");
                }
            }
        }
    }
}
