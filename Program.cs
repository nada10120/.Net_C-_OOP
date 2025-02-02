namespace Task3___OOP
{

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }

        public Book(string title = "none" , string author = "none" , string isbn="", bool av =true)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Availability = av;
        }



    }

    class Library
    {
        public List<Book> CollectionOfBooks { get; set; }

        public Library()
        {
            CollectionOfBooks = new List<Book>();
        }

        public void AddBook(Book obj)
        {
            CollectionOfBooks.Add(obj);

            Console.WriteLine("book added successfully"); 
        }
        public void SearchBook(string search)
        {
            bool found = false;

            for (int i = 0; i < CollectionOfBooks.Count; i++)
            {
                if (CollectionOfBooks[i].Title.Contains(search) || CollectionOfBooks[i].Author.Contains(search))

                {
                    found = true;
                    Console.WriteLine(CollectionOfBooks[i].Title + "is found and it's index is " + i); 
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("No such book exist try checking the title or author");

            }


        }
        public void BorrowBook(string book)
        {
            bool found = false;
          
            for (int i = 0; i < CollectionOfBooks.Count; i++)
            {
                if (CollectionOfBooks[i].Title.Contains(book) || CollectionOfBooks[i].Author.Contains(book))
                {
                    found = true;
                    if (CollectionOfBooks[i].Availability ) {

                        CollectionOfBooks[i].Availability = false;

                        Console.WriteLine(CollectionOfBooks[i].Title + "is borrowed successfully "); 


                    }
                    else
                    {
                        Console.WriteLine(CollectionOfBooks[i].Title + "is not available right now please check later "); 
                    }



                }

            }
            if (!found)
            {
                Console.WriteLine("No such book exist try checking the title or author");

            }

        }

        public void ReturnBook (string book)
        {
            bool found = false;
            for (int i = 0; i < CollectionOfBooks.Count; i++)
            {
                if (CollectionOfBooks[i].Title.Contains(book) || CollectionOfBooks[i].Author.Contains(book))
                {
                    found = true;
                    if (!CollectionOfBooks[i].Availability)
                    {


                        CollectionOfBooks[i].Availability = true;

                        Console.WriteLine( CollectionOfBooks[i].Title + "is Returned successfully ");;


                    }
                    else
                    {
                        Console.WriteLine( CollectionOfBooks[i].Title + "wasn't borrowed from here ");;
                    }



                }
               
            }
            if (!found)
            {
                Console.WriteLine("No such book exist try checking the title or author");

            }
        }
    }

    class Library2
    {
        public List<Book> CollectionOfBooks { get; set; }

        public Library2()
        {
            CollectionOfBooks = new List<Book>();
        }

        public void AddBook(Book obj)
        {
            CollectionOfBooks.Add(obj);

            Console.WriteLine("book added successfully");
        }
        public Book SearchBook(string book)
        {
            bool found = false;

            for (int i = 0; i < CollectionOfBooks.Count; i++)
            {
                if (CollectionOfBooks[i].Title.Contains(book) || CollectionOfBooks[i].Author.Contains(book))

                {
                    found = true;
                    return CollectionOfBooks[i];
                    
                }
            }
            if (!found)
            {
                Console.WriteLine("this book doesn't exist in this library");
            }
            return null;
            
        }
        public void BorrowBook(string book)
        {



            Book books = this.SearchBook(book);

            if (books != null)
            {
                if (books.Availability)
                {
                    books.Availability = false;
                    Console.WriteLine($"the book {book} is borrowed successfuly");

                }

                else
                {
                    Console.WriteLine("this book is not available at the moment");
                }

            }
        }
        
        public void ReturnBook(string book)
        {

            Book books = this.SearchBook(book);
            
                if (books != null)
                {
                    if (!books.Availability)
                    {
                        books.Availability = true;

                        Console.WriteLine($"the book {book} is returned successfuly");
                    }
                    else
                    {
                        Console.WriteLine("this book is not borrowed at the moment");
                    }

                }

            
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Library library = new Library();

            //// Adding books to the library
            //library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            //library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            //library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            //// Searching and borrowing books
            //Console.WriteLine("Searching and borrowing books...");
            //library.BorrowBook("Gatsby");
            //library.BorrowBook("1984");
            //library.BorrowBook("Harry Potter"); // This book is not in the library

            //// Returning books
            //Console.WriteLine("\nReturning books...");
            //library.ReturnBook("Gatsby");
            //library.ReturnBook("Harry Potter"); // This book is not borrowed

            //Console.ReadLine();

            Library2 library2 = new Library2();

            // Adding books to the library
            library2.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library2.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library2.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library2.BorrowBook("1984");

            library2.BorrowBook("Gatsby");
            library2.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library2.ReturnBook("1984");
            library2.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();
        }
    }
}
