using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

var supportedCulturesList = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("tr-TR"),
    new CultureInfo("az-Latn-AZ"),
    new CultureInfo("ru-RU")
};
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
 {
     var supportedCultures = new[] { "az-Latn-AZ", "en-US", "tr-TR", "ru-RU" };
     options.SetDefaultCulture(supportedCultures[1])
         .AddSupportedCultures(supportedCultures)
         .AddSupportedUICultures(supportedCultures);
 });

var app = builder.Build();

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCulturesList,
    SupportedUICultures = supportedCulturesList
});

app.UseRequestLocalization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Index");
    app.UseStatusCodePagesWithReExecute("/Error/Index");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();