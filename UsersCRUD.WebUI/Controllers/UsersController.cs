using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UsersCRUD.WebUI.Models;

namespace UsersCRUD.WebUI.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult New()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }

		[HttpPost]
    public IActionResult New(UserModel user)
    {
			if (!ModelState.IsValid) {
				return View(user);
			}

			Console.WriteLine($"User: {user.Name}, {user.Surname}, {user.DNI}");
			return RedirectToAction("Index");
    }
}
