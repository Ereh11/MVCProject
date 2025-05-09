using Microsoft.AspNetCore.Mvc;
using MVC.Intro.Models;

namespace MVC.Intro.Controllers;

public class BooksController : Controller
{
    private static List<Book> _books = Book.GetBooksList();
    private readonly IConfiguration _configuration;

    public BooksController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(_books);// Views/Books/Index.cshtml
    }

    [HttpGet]
    public IActionResult Details(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);// Views/Books/Details.cshtml
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();// Views/Books/Add.cshtml
    }

    [HttpPost]
    public IActionResult Add(AddBookDto bookDto)
    {
        if (!ModelState.IsValid)
        {
            return View(bookDto);
        }

        // Logic to add book to db
        return RedirectToAction("Index");
    }
}
