using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using RealEstate.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(x=> x.IdleTimeout=TimeSpan.FromHours(24));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(x =>
	{
		x.LoginPath = "/User/Login";
	});
// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(fv =>
{
	fv.RegisterValidatorsFromAssemblyContaining<Program>();
}).AddRazorRuntimeCompilation();
builder.Services.AddServices();
builder.Services.AddNotyf(provider => { provider.HasRippleEffect = true; provider.Position = NotyfPosition.TopRight; provider.DurationInSeconds = 4; provider.IsDismissable = true; });

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
app.UseHttpsRedirection();
app.UseSession();
app.UseNotyf();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
