using Microsoft.AspNetCore.Mvc;
using Mission11_Marshall.Models;
using System.Diagnostics;
using Mission11_Marshall.Repositories;
using Mission11_Marshall.Models;

namespace Mission11_Marshall.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookRepository _bookRepository;

        public HomeController(ILogger<HomeController> logger, BookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public IActionResult Index(int page = 1)
        {
            const int pageSize = 10;
            var books = _bookRepository.GetAllBooks()
                                       .Skip((page - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToList();

            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
