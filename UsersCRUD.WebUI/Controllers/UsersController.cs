using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsersCRUD.Domain.Users;
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

        return response.Match<IActionResult>(
            _ => RedirectToAction("Index"),
            err =>
            {
                if (err is DuplicatedDNIError)
                {
                    ModelState.AddModelError("DNI", "DNI already exists");
                }

                return View(user);
            }
        );
    }

    [HttpGet]
    public async Task<IActionResult> Edit(UserId id)
    {
        var user = (
            await mediator.Send(new Application.Users.Queries.GetById.Request { Id = id })
        ).Unwrap();
        return View(
            new UserModel
            {
                Name = user.Name.Value,
                Surname = user.Surname.Value,
                DNI = user.DNI.Value,
            }
        );
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserId id, UserModel user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        await mediator.Send(
            new Application.Users.Commands.UpdateOne.Request { User = user.ToDto().ToUser(id) }
        );

        return RedirectToAction("Index");
    }

    [HttpPost("Delete/{id}")]
    public async Task<IActionResult> Delete(UserId id)
    {
        await mediator.Send(new Application.Users.Commands.DeleteOne.Request { Id = id });
        return RedirectToAction("Index");
    }
}
