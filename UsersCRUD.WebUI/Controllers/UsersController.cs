using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsersCRUD.WebUI.Models;

namespace UsersCRUD.WebUI.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;
    private readonly IMediator mediator;

    public UsersController(ILogger<UsersController> logger, IMediator mediator)
    {
        _logger = logger;
        this.mediator = mediator;
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
    public async Task<IActionResult> New(UserModel user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        await mediator.Send(new Application.Users.Commands.CreateOne.Request { User = user.ToDto() });

        return RedirectToAction("Index");
    }
}
