using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Auth0.AspNetCore.Authentication;
using System.Text.Json;
using oscars_games.Data;
using Microsoft.EntityFrameworkCore;
using oscars_games.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
});

builder.Services.AddDbContextFactory<CosmosDbContext>(options =>
{
    options.UseCosmos(
        builder.Configuration["Cosmos:Endpoint"],
        builder.Configuration["Cosmos:AccessKey"],
        builder.Configuration["Cosmos:Database"]
    );
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserSelectionRepository, UserSelectionRepository>();

builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var jsonString = File.ReadAllText("Data/nominees.json");
var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    IncludeFields = true
};
var categories = JsonSerializer.Deserialize<Categories>(jsonString, options)!;

builder.Services.AddSingleton(categories);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
