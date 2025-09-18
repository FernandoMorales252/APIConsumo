using FrontAuth.WebApp.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Defincion de la url base de la Api
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7273/api/");
});

builder.Services.AddScoped<AuthService>();

// Configutracion de la autenticacion por cookies
builder.Services.AddAuthentication("AuthCookie")
    .AddCookie("AuthCookie", Options =>
    {
        Options.LoginPath = "/Auth/Login";
        Options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //Duracion de la cookie
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
