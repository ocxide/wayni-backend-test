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

    public async Task<IActionResult> Index()
    {
        var users = await mediator.Send(new Application.Users.Queries.GetAll.Request());
        return View(new { Users = users });
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

        var response = await mediator.Send(
            new Application.Users.Commands.CreateOne.Request { User = user.ToDto() }
        );

        return RedirectToAction("Index");
    }
}
