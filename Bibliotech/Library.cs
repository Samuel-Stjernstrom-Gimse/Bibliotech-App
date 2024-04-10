using System.Net;
using System.Reflection;
using System.Text.Json;

namespace Bibliotech;

public class Library
{
    private List<Book>? books = [];

    public void AddBook()
    {
        Console.Write("Book title: ");
        var title = Console.ReadLine()!;

        Console.Write("Book author: ");
        var author = Console.ReadLine()!;

        Console.Write("Book year: ");
        var year = int.Parse(Console.ReadLine()!);

        var book = new Book(title, author, year);

        books.Add(book);
    }

    public void RemoveBook()
    {
        var title = Console.ReadLine();
        var bookToRemove = books.Find(book => book.Title == title);

        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
        }
        else
        {
            Console.WriteLine($"{title} not found");
        }
    }

    public void ViewAllBooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }

    public void SaveLibrary()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(books, options: options);
        File.WriteAllText("library.json", json);
    }

    public void LoadLibrary()
    {
        if (File.Exists("library.json"))
        {
            var json = File.ReadAllText("library.json");
            books = JsonSerializer.Deserialize<List<Book>>(json);
        }
    }
}