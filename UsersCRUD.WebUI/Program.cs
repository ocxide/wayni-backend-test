using UsersCRUD.Application;
using UsersCRUD.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddApplicationServices();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var isDev = app.Environment.IsDevelopment();

if (isDev)
{
    app.Services.UseDbMigrations();
}
// Configure the HTTP request pipeline.
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Users}/{action=Index}/{id?}");

app.MapGet(
    "/",
    (ctx) =>
    {
        ctx.Response.Redirect("/Users");
        return Task.CompletedTask;
    }
);

app.Run();
