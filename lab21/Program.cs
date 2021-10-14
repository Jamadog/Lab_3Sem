using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2{
    class NoteBookCreate{
        public string Name {get; set;}
        public DateTime DataBirth {get; set;}
        public long Number {get; set;}
    }

    class NoteBookEdit{
        public string name;
        public long number;
        public string linee = "---------------------------------------------------";

        public void PrintNoteBook(List<NoteBookCreate> notebook){
            Console.WriteLine("Вывод контактов:");
            Console.WriteLine(linee);
            for (int i = 0; i < notebook.Count; i++){
                Console.WriteLine("Фамилия:\t\t{0}\nДата рождения:\t{1}\nНомер тф.:\t\t+{2}\n{3}", notebook[i].Name, notebook[i].DataBirth, notebook[i].Number, linee);
            }
        }

        public void InputNoteBook(List<NoteBookCreate> notebook){
            Console.WriteLine("Внесение нового контакта:");
            Console.WriteLine("Введите Фамилию");
            name = Console.ReadLine();

            Console.WriteLine("Введите дату рождения(Год Месяц День)");
            int year = Convert.ToInt32(Console.ReadLine());
            int month = Convert.ToInt32(Console.ReadLine());
            int day = Convert.ToInt32(Console.ReadLine());
            DateTime datebirth = new DateTime(year, month, day);

            Console.WriteLine("Введите номер телефона");
            number = long.Parse(Console.ReadLine());        

            notebook.Add(new NoteBookCreate() {Name = name, DataBirth = datebirth, Number = number});
        }

        public void RemoveNoteBook(List<NoteBookCreate> notebook){
            string name_delete;
            long number_delete;
            int x;
            Console.WriteLine("Введите критерий удаления\n1 - Фамилия\n2 - Дате\n3 - Номеру");
            x = Convert.ToInt32(Console.ReadLine());
            if (x == 1){
                Console.WriteLine("Введите фамилию");
                name_delete = Console.ReadLine();
                NoteBookCreate found_book_delete = notebook.Find(item => item.Name == name_delete);
                notebook.Remove(found_book_delete);                    
                Console.WriteLine("{0} {1} +{2}", found_book_delete.Name, found_book_delete.DataBirth, found_book_delete.Number);
                Console.WriteLine("Удалена!");

            } else if (x == 2){
                Console.WriteLine("Введите искомую дату рождения(Год Месяц День) для удаления");
                int year = Convert.ToInt32(Console.ReadLine());
                int month = Convert.ToInt32(Console.ReadLine());
                int day = Convert.ToInt32(Console.ReadLine());
                DateTime datebirth_delete = new DateTime(year, month, day);
                NoteBookCreate found_book_delete = notebook.Find(item => item.DataBirth == datebirth_delete);
                notebook.Remove(found_book_delete);                    
                Console.WriteLine("{0} {1} +{2}", found_book_delete.Name, found_book_delete.DataBirth, found_book_delete.Number);
                Console.WriteLine("Удалена!");

            } else if (x == 3){
                Console.WriteLine("Введите номер телефон");
                number_delete = long.Parse(Console.ReadLine());
                NoteBookCreate found_book_delete = notebook.Find(item => item.Number == number_delete);
                notebook.Remove(found_book_delete);                    
                Console.WriteLine("{0} {1} +{2}", found_book_delete.Name, found_book_delete.DataBirth, found_book_delete.Number);
                Console.WriteLine("Удалена!");
            }
        }

        public void SearchNoteBook(List<NoteBookCreate> notebook){
            int y;
            Console.WriteLine("1 - Поиск по Автору\n2 - Поиск по дате(году)\n3 - Поиск по телефону");
            y = Convert.ToInt32(Console.ReadLine());
            if (y == 1){

                string name_search;
                Console.WriteLine("Введите автора");
                name_search = Console.ReadLine();
                NoteBookCreate found_book = notebook.Find(item => item.Name==name_search);
                Console.WriteLine(linee);     
                Console.WriteLine("Автор:\t\t{0}\nНазвание:\t{1}\nГод:\t\t+{2}\n{3}", found_book.Name, found_book.DataBirth, found_book.Number, linee);            
            
            } else if (y == 2){

                Console.WriteLine("Введите искомую дату рождения(Год Месяц День)");
                int year = Convert.ToInt32(Console.ReadLine());
                int month = Convert.ToInt32(Console.ReadLine());
                int day = Convert.ToInt32(Console.ReadLine());
                DateTime datebirth_delete = new DateTime(year, month, day);
                NoteBookCreate found_book_delete = notebook.Find(item => item.DataBirth == datebirth_delete);
                Console.WriteLine("{0} {1} +{2}", found_book_delete.Name, found_book_delete.DataBirth, found_book_delete.Number);

            }else if (y == 3){

                int number_search;
                Console.WriteLine("Введите год");
                number_search = Convert.ToInt32(Console.ReadLine());
                NoteBookCreate found_book = notebook.Find(item => item.Number==number_search);
                Console.WriteLine(linee);         
                Console.WriteLine("Автор:\t\t{0}\nНазвание:\t{1}\nГод:\t\t+{2}\n{3}", found_book.Name, found_book.DataBirth, found_book.Number, linee);
            }
        }

        public void SortNoteBook(List<NoteBookCreate> notebook){
            int z;
            Console.WriteLine("Выберите значение сортировки:\n1 - По Фамилии\n2 - По Дате\n3 - По Номеру телефона");
            z = Convert.ToInt32(Console.ReadLine());

            if (z == 1){
                notebook = notebook.OrderBy(i => i.Name).ToList();
                Console.WriteLine("Вывод сортированной по Фамилии");
                Console.WriteLine(linee);

                for (int i = 0; i < notebook.Count; i++){
                    Console.WriteLine("Фамилия:\t\t{0}\nДата рождения:\t{1}\nНомер тф.:\t\t+{2}\n{3}", notebook[i].Name, notebook[i].DataBirth, notebook[i].Number, linee);
                }
            }else if (z == 2){
                notebook = notebook.OrderBy(i => i.DataBirth).ToList();
                Console.WriteLine("Вывод сортированной по дате рождения");
                Console.WriteLine(linee);

                for (int i = 0; i < notebook.Count; i++){
                    Console.WriteLine("Фамилия:\t\t{0}\nДата рождения:\t{1}\nНомер тф.:\t\t+{2}\n{3}", notebook[i].Name, notebook[i].DataBirth, notebook[i].Number, linee);
                }
            }else if (z == 3){
                notebook = notebook.OrderBy(i => i.Number).ToList();
                Console.WriteLine("Вывод сортированной по номеру телефона");
                Console.WriteLine(linee);

                for (int i = 0; i < notebook.Count; i++){
                    Console.WriteLine("Фамилия:\t\t{0}\nДата рождения:\t{1}\nНомер тф.:\t\t+{2}\n{3}", notebook[i].Name, notebook[i].DataBirth, notebook[i].Number, linee);
                }
            }
        }
    }

    class Program{
        static void Main(string[] args){
            List<NoteBookCreate> notebook = new List<NoteBookCreate>();
            NoteBookEdit test = new NoteBookEdit();
            string choice;
            do{
                if (notebook != null && notebook.Count == 0){
                    Console.WriteLine("Извините, книжка пустая, внесите контакты!\nНажмите 2");
                }
                Console.WriteLine("1 - Вывод всей книжки");
                Console.WriteLine("2 - Добавление записи");
                Console.WriteLine("3 - Удаление записи по (Фамилии, дате или номеру телефона)");
                Console.WriteLine("4 - Поиск по значение (Фамилии, дате или номеру телефона)");
                Console.WriteLine("5 - Сортировка по (Фамилии, дате или номеру телефона)");
                Console.WriteLine("6 - Выйти из программы");
                choice = Console.ReadLine();

                switch (choice){
                    case "1":
                        test.PrintNoteBook(notebook);
                        break;

                    case "2":
                        test.InputNoteBook(notebook);
                        break;

                    case "3":
                        test.RemoveNoteBook(notebook);
                        break;

                    case "4":
                        test.SearchNoteBook(notebook);
                        break;

                    case "5":
                        test.SortNoteBook(notebook);
                        break;
                }
            } while (choice != "6");  
        }
    }
}