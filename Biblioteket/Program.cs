using static Biblioteket.Program;

namespace Biblioteket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<Book> loan = new Stack<Book>();
            List<Book> library = new List<Book>();
            library.Add(new Book("Bog1", "torben", 2021, 320));
            library.Add(new Book("Bog2", "henning", 2016, 823));
            library.Add(new Book("Bog3", "Kenneth", 2007, 935));
            GUI gui = new GUI();
            char userInterface;
            int bookShowcaseNumber = 1;

            do
            {
                gui.Menu();
                userInterface = char.Parse(Console.ReadLine());
                if (userInterface == '1')
                {
                    Console.Clear();
                    Console.WriteLine("Her er dine valg");
                    foreach (Book b in library)
                    {
                        Console.WriteLine(bookShowcaseNumber+ ". " + b.Title);
                        bookShowcaseNumber++;
                    }
                    Console.Write("Indtast index på din bog: ");
                    userInterface = char.Parse(Console.ReadLine());
                    if (userInterface == '1')
                    {
                        loan.Push(library[0]);
                        library.Remove(library[0]);
                    }
                    else if (userInterface == '2')
                    {
                        loan.Push(library[1]);
                        library.Remove(library[1]);
                    }
                    else if (userInterface == '3')
                    {
                        loan.Push(library[2]);
                        library.Remove(library[2]);
                    }
                    Console.Write("Her er hvad du har lånt: " + loan.Peek().Title);
                    Console.WriteLine("\r\nChecker ud... \n\r");
                    Thread.Sleep(2500);
                    loan.Pop();
                }

            } while (Console.ReadKey().Key != ConsoleKey.D2);


        }
        internal class Book
        {
            private string title;
            private int pages;
            private string author;
            private int year;

            public string Title { get { return title; } }
            public int Pages { get { return pages; } }
            public string Author { get { return author; } }
            public int Year { get { return year; } }

            public Book(string title, string author, int year, int pages)
            {
                this.title = title;
                this.pages = pages;
                this.author = author;
                this.year = year;
            }
        }

        internal class GUI
        {
            public void Menu()
            {
                Console.WriteLine("-----------------------------------------------------------------------\r\n");
                Console.WriteLine("                          Velkommen til biblioteket");
                Console.WriteLine("\r\n-----------------------------------------------------------------------");
                Console.WriteLine("1. Lån en bog");
                Console.WriteLine("2. Luk");
                Console.Write("\r\nVælg en mulighed: ");
            }
        }        
    }
}