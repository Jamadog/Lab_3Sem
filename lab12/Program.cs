using System;
using System.Collections.Generic;
using System.Linq;


namespace lab12{

    class HomeLibraryCreate{
        public string Author {get; set;}
        public string Name {get; set;}
        public int Year {get; set;}
    }

    class HomeLibraryEdit{
        public string autor;
        public string name;
        public int year;
        public string linee = "---------------------------------------------------";
        public int y;
        public int z;

        public void InputBook(List<HomeLibraryCreate> lib){
            Console.WriteLine("Ок!\nВы вносите нового писателя!");
            Console.WriteLine("Введите автора: ");
            autor = Console.ReadLine();
            Console.WriteLine("Введите название: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите год: ");
            year = Convert.ToInt32(Console.ReadLine());
            lib.Add(new HomeLibraryCreate() {Author = autor, Name = name, Year = year});
            Console.WriteLine("Отлично! Автор введен...");
        }

        public void PrintLib(List<HomeLibraryCreate> lib){
            Console.WriteLine("Вывод библиотеки:");
            Console.WriteLine(linee);
            for (int i = 0; i < lib.Count; i++){
                Console.WriteLine("Автор:\t\t{0}\nНазвание:\t{1}\nГод:\t\t{2}\n{3}", lib[i].Author, lib[i].Name, lib[i].Year, linee);
            }
        }

        public void SearchBook(List<HomeLibraryCreate> lib){
            Console.WriteLine("1 - Поиск по Автору\n2 - Поиск по дате(году)");
            y = Convert.ToInt32(Console.ReadLine());
            if (y == 1){
                string author_search;
                Console.WriteLine("Введите автора:");
                author_search = Console.ReadLine();
                HomeLibraryCreate found_book = lib.Find(item => item.Author==author_search);
                Console.WriteLine(linee);
                            
                Console.WriteLine("Автор:\t\t{0}\nНазвание:\t{1}\nГод:\t\t{2}\n{3}", found_book.Author, found_book.Name, found_book.Year, linee);
                            
            }
            if (y == 2){
                int year_search;
                Console.WriteLine("Введите год:");
                year_search = Convert.ToInt32(Console.ReadLine());
                HomeLibraryCreate found_book = lib.Find(item => item.Year==year_search);
                Console.WriteLine(linee);         
                Console.WriteLine("Автор:\t\t{0}\nНазвание:\t{1}\nГод:\t\t{2}\n{3}", found_book.Author, found_book.Name, found_book.Year, linee);               
            }
        }

        public void RemoveBook(List<HomeLibraryCreate> lib){
            string name_delete;
            Console.WriteLine("Введите название книги: ");
            name_delete = Console.ReadLine();
            HomeLibraryCreate found_book_delete = lib.Find(item => item.Name==name_delete);
            lib.Remove(found_book_delete);                    
            Console.WriteLine("Книга {0} год {1}", found_book_delete.Name, found_book_delete.Year);
            Console.WriteLine("Удалена!");
        }

        public void SortLib(List<HomeLibraryCreate> lib){
            Console.WriteLine("Выберите значение сортировки:\n1 - по автору\n2 - по названию\n3 - по дате");
            z = Convert.ToInt32(Console.ReadLine());

            if (z == 1){
                lib = lib.OrderBy(i => i.Author).ToList();
                Console.WriteLine("Вывод сортированной по автору:");
                Console.WriteLine(linee);

                for (int i = 0; i < lib.Count; i++){
                    Console.WriteLine("Автор:\t\t{0}\nНазвание:\t{1}\nГод:\t\t{2}\n{3}", lib[i].Author, lib[i].Name, lib[i].Year, linee);
                }
            }else if (z == 2){
                lib = lib.OrderBy(i => i.Name).ToList();
                Console.WriteLine("Вывод сортированной по названию книг:");
                Console.WriteLine(linee);

                for (int i = 0; i < lib.Count; i++){
                    Console.WriteLine("Автор:\t\t{0}\nНазвание:\t{1}\nГод:\t\t{2}\n{3}", lib[i].Author, lib[i].Name, lib[i].Year, linee);
                }
            }else if (z == 3){
                lib = lib.OrderBy(i => i.Year).ToList();
                Console.WriteLine("Вывод сортированной по дате:");
                Console.WriteLine(linee);

                for (int i = 0; i < lib.Count; i++){
                    Console.WriteLine("Автор:\t\t{0}\nНазвание:\t{1}\nГод:\t\t{2}\n{3}", lib[i].Author, lib[i].Name, lib[i].Year, linee);
                }
            }
        }
    }

    class Program12{
        static void Main(string[] args){
            string choice;
            
            List<HomeLibraryCreate> lib = new List<HomeLibraryCreate>();
            HomeLibraryEdit test = new HomeLibraryEdit();

            do{
                if (lib != null && lib.Count == 0){
                    Console.WriteLine("Извините, библиотека пустая, внесите книги!\nНажмите 1");
                }
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Внести новую книгу");
                Console.WriteLine("2 - Вывести библиотеку");
                Console.WriteLine("3 - Поиск книги (по автору или году издания)");
                Console.WriteLine("4 - Удаление книги");
                Console.WriteLine("5 - Сортировка по полю");
                Console.WriteLine("6 - Выйти из программы");
                choice = Console.ReadLine();

                switch(choice){
                    case "1":
                        test.InputBook(lib);
                        break;

                    case "2":
                        test.PrintLib(lib);
                        break;

                    case "3":
                        test.SearchBook(lib);
                        break;

                    case "4":
                        test.RemoveBook(lib);
                        break;

                    case "5":
                        test.SortLib(lib);
                        break;
                }
            } while (choice != "6");
        }
    }
}