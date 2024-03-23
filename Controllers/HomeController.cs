using Microsoft.AspNetCore.Mvc;
using Mission11_Marshall.Models;
using System.Diagnostics;
using Mission11_Marshall.Repositories;

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

        public ActionResult Index(int? page)
        {
            const int pageSize = 10;
            int currentPage = page ?? 1;

            // Fetch the total count of books
            int totalCount = _bookRepository.GetTotalCount();

            // Fetch books for the current page
            var books = _bookRepository.GetBooks(currentPage, pageSize);

            ViewBag.TotalCount = totalCount;
            ViewBag.CurrentPage = currentPage;

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
