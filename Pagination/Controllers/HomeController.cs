using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pagination.Data;
using Pagination.Models;
using System.Diagnostics;

namespace Pagination.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationContext _db)
        {
            _logger = logger;
            db = _db;
        }

        public async Task<IActionResult> Index(int page = 1, string name = "", string companyName = "")
        {
            int pageSize = 10;   // количество элементов на странице

            IQueryable<User> source = db.Users.Include(x => x.Company);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            List<User> result = items.Where(i => i.Name.Contains(name)).Where(i => i.Company.Name.Contains(companyName)).ToList();
            PageModel pageViewModel = new PageModel(count, page, pageSize);
            IndexVM viewModel = new IndexVM
            {
                PageModel = pageViewModel,
                Users = result
            };
            return View(viewModel);
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