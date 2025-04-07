using Microsoft.AspNetCore.Mvc;
using SalesManagement.Models;
using System.Diagnostics;

namespace SalesManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SalesManagementDBContext _context;
        public HomeController(ILogger<HomeController> logger, SalesManagementDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Expenses()
        {
            return View();
        }
        public IActionResult CreateExpense(Expense model)
        {
            _context.Expenses.Add(model);
            _context.SaveChanges();
            return RedirectToAction("ExpenseDetail");
        }
        public IActionResult ExpenseDetail()
        {
            var totalExpense = _context.Expenses.OrderBy(x => x.Id).ToList();
            return View(totalExpense);
        }
        public IActionResult DeleteExpense(int id)
        {
            var deleteData = _context.Expenses.SingleOrDefault(x => x.Id == id);
            _context.Expenses.Remove(deleteData);
            _context.SaveChanges();
            return RedirectToAction("ExpenseDetail");
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
