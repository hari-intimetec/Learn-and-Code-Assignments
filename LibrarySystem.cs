using System.Text.Json;

namespace LibrarySystem
{

    public class Book
    {
        private int currentPageIndex;
        private readonly List<string> pages;

        public string Title { get; }
        public string Author { get; }

        public Book(string title, string author, List<string> pages)
        {
            Title = title;
            Author = author;
            this.pages = pages ?? new List<string>();
            currentPageIndex = 0;
        }

        public void TurnPage()
        {
            if (currentPageIndex < pages.Count - 1)
            {
                currentPageIndex++;
            }
        }

        public string GetCurrentPage()
        {
            return pages.Count > 0 ? pages[currentPageIndex] : string.Empty;
        }
    }

    public interface IBookProvider
    {
        Book GetBook();
    }

    public class InMemoryBookProvider : IBookProvider
    {
        public Book GetBook()
        {
            return new Book(
                "Clean Code",
                "Robert C. Martin",
                new List<string>
                {
                    "Chapter 1: Clean Code",
                    "Chapter 2: Meaningful Names",
                    "Chapter 3: Functions"
                }
            );
        }
    }

    public interface IPagePrinter
    {
        void PrintPage(string pageContent);
    }

    public class PlainTextPrinter : IPagePrinter
    {
        public void PrintPage(string pageContent)
        {
            Console.WriteLine(pageContent);
        }
    }

    public class HtmlPagePrinter : IPagePrinter
    {
        public void PrintPage(string pageContent)
        {
            Console.WriteLine(
                $"<div class=\"single-page\">{System.Net.WebUtility.HtmlEncode(pageContent)}</div>"
            );
        }
    }


    public interface IBookStorage
    {
        void Save(Book book);
    }

    public class FileBookStorage : IBookStorage
    {
        private readonly string directoryPath;

        public FileBookStorage(string directoryPath)
        {
            this.directoryPath = directoryPath;
            Directory.CreateDirectory(directoryPath);
        }

        public void Save(Book book)
        {
            string filePath = Path.Combine(directoryPath, $"{book.Title}.json");
            string json = JsonSerializer.Serialize(book, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }
    }


    public class LibraryLocation
    {
        public string Shelf { get; }
        public string Room { get; }

        public LibraryLocation(string shelf, string room)
        {
            Shelf = shelf;
            Room = room;
        }

        public string GetLocation()
        {
            return $"Shelf: {Shelf}, Room: {Room}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IBookProvider bookProvider = new InMemoryBookProvider();
            IPagePrinter printer = new PlainTextPrinter();
            IBookStorage storage = new FileBookStorage("Documents");

            Book book = bookProvider.GetBook();

            printer.PrintPage(book.GetCurrentPage());
            book.TurnPage();
            printer.PrintPage(book.GetCurrentPage());

            storage.Save(book);

            LibraryLocation location = new LibraryLocation("A3", "Room 101");
            Console.WriteLine(location.GetLocation());
        }
    }
}
