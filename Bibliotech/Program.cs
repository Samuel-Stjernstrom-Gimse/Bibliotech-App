using Bibliotech;

var library = new Library();
var isRunning = true;

library.LoadLibrary();

while (isRunning)
{
    Console.WriteLine("Welcome to the Bibliotech");
    Console.WriteLine("1. add book");
    Console.WriteLine("2. remove book");
    Console.WriteLine("3. view books");
    Console.WriteLine("4. exit");

    var input = Console.ReadLine()!;

    switch (input)
    {
        case "1":
            library.AddBook();
            library.SaveLibrary();
            break;
        case "2":
            library.RemoveBook();
            library.SaveLibrary();
            break;
        case "3":
            library.ViewAllBooks();
            break;
        default:
            library.SaveLibrary();
            isRunning = false;
            break;
    }
} 
