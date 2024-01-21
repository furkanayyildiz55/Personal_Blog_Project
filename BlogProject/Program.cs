
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.Name = "NetCoreMvc.Auth";
    options.LoginPath= "/Admin/Login";
    options.AccessDeniedPath = "/Admin/Login";
});  

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromSeconds(10);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(x => {
//        x.LoginPath = "/Admin/Login";
//        x.AccessDeniedPath = "/Home/Index";
//    });

//builder.Services.ConfigureApplicationCookie(opts => // birden fazla yönlerdirme hatasý aldým bunun ile çözüldü
//{
//    //Cookie settings
//    opts.Cookie.HttpOnly = true;
//    opts.ExpireTimeSpan = TimeSpan.FromMinutes(25);
//    opts.AccessDeniedPath = new PathString("/Login/AccessDenied/");  //yetkisi olmayan sayfalarda gideceði path 
//    opts.LoginPath = "/Home/Index";
//    opts.SlidingExpiration = true;
//});

var app = builder.Build();

app.UseStatusCodePagesWithReExecute("/Error/Index", "?code={0}");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

//app.UseSession();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{title?}");

app.Run();
