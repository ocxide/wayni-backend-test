using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UsersCRUD.WebUI.Models;
using MediatR;

namespace UsersCRUD.WebUI.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;
    private readonly IMediator mediator;

    public UsersController(ILogger<UsersController> logger, IMediator mediator)
    {
        Console.WriteLine("UsersController");
        _logger = logger;
        this.mediator = mediator;
    }

    public IActionResult Index()
    {
        Console.WriteLine("index");
        return View();
    }

    public IActionResult New()
    {
        Console.WriteLine("New");
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
    public async Task<IActionResult> New(UserModel user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        await mediator.Send(
            new Application.Users.Commands.CreateOne.Request { User = user.ToDto() }
        );

        return RedirectToAction("Index");
    }
}
