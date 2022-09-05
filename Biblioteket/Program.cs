using static Biblioteket.Program;

namespace Biblioteket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<Book> loan = new Stack<Book>();//A stack that stores the books the user has loaned
            List<Book> library = new List<Book>();//A List that store the books in the library
            //Creates and adds the book to the library
            library.Add(new Book("Bog1", "torben", 2021, 320));
            library.Add(new Book("Bog2", "henning", 2016, 823));
            library.Add(new Book("Bog3", "Kenneth", 2007, 935));
            GUI gui = new GUI();//Creates an object for the gui
            char userInterface;//User interface variable
            int bookShowcaseNumber = 1;//Variable to show the book number

            do//a do-while loop that keeps running unless the user presses 2
            {
                gui.Menu();//Displays the gui in console
                userInterface = char.Parse(Console.ReadLine());//Collects the data from console
                if (userInterface == '1')//If the user presses 1 it runs this code
                {
                    Console.Clear();//Clears console
                    Console.WriteLine("Her er dine valg");
                    foreach (Book b in library)//For each book in the library it runs this code
                    {
                        Console.WriteLine(bookShowcaseNumber+ ". " + b.Title);
                        bookShowcaseNumber++;
                    }
                    Console.Write("Indtast index på din bog: ");
                    userInterface = char.Parse(Console.ReadLine());//checks what the user pressed
                    if (userInterface == '1')//If the user pressed 1
                    {
                        loan.Push(library[0]);//Pushes the book from the list to the stack
                        library.Remove(library[0]);//Removes the book from the list
                    }
                    else if (userInterface == '2')//If the user presses 2
                    {
                        loan.Push(library[1]);//Pushes the book from the list to the stack
                        library.Remove(library[1]);//removes the book from the list
                    }
                    else if (userInterface == '3')//If the user presses 3
                    {
                        loan.Push(library[2]);//Pushes the book from the list to the stack
                        library.Remove(library[2]);//removes the book from the list
                    }
                    Console.Write("Her er hvad du har lånt: " + loan.Peek().Title);//Shows the user what he loaned
                    Console.WriteLine("\r\nChecker ud... \n\r");
                    Thread.Sleep(2500);//Makes the code pause for 2.5 seconds
                    loan.Pop();//removes the element from the top of the stack
                }

            } while (Console.ReadKey().Key != ConsoleKey.D2);


        }
        internal class Book//Class for the book
        {
            //Instance variables
            private string title;
            private int pages;
            private string author;
            private int year;

            //encapsulations
            public string Title { get { return title; } }
            public int Pages { get { return pages; } }
            public string Author { get { return author; } }
            public int Year { get { return year; } }

            //Constructor
            public Book(string title, string author, int year, int pages)
            {
                this.title = title;
                this.pages = pages;
                this.author = author;
                this.year = year;
            }
        }

        internal class GUI//Class for the gui
        {
            public void Menu()
            { 
                //menu
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