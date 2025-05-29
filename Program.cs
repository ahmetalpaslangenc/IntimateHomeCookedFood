using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using IntimateHomeCookedFood.Data;
using Microsoft.AspNetCore.Identity;
using IntimateHomeCookedFood.Models; // Meal modelini kullanmak için gerekli
using System.Linq; // LINQ sorguları için gerekli

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Razor Pages için servis eklendi

// Use SQLite for the database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));

// Identity services with default configuration
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add HttpContextAccessor and Session services
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Use Session and Authentication middleware
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); // Razor Pages için rota ekleme

// Seed data
using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
    
    if (!context.Meals.Any())
    {
        context.Meals.AddRange(
            new Meal { Name = "Mercimek Çorbası", Description = "Lezzetli ve sağlıklı mercimek çorbası.", Price = 10.0m, Type = "Çorba", ImageUrl = "mercimek.jpg" },
            new Meal { Name = "Domates Çorbası", Description = "Taze domateslerden yapılmış çorba.", Price = 12.0m, Type = "Çorba", ImageUrl = "domates.jpg" },
            new Meal { Name = "Ezogelin Çorbası", Description = "Türk mutfağının geleneksel çorbası.", Price = 11.0m, Type = "Çorba", ImageUrl = "ezogelin.jpg" },
            new Meal { Name = "Tavuk Çorbası", Description = "Tavuklu ve sebzeli besleyici çorba.", Price = 14.0m, Type = "Çorba", ImageUrl = "tavuk.jpg" },
            new Meal { Name = "Kremalı Mantar Çorbası", Description = "Kremalı ve mantarlı lezzetli çorba.", Price = 15.0m, Type = "Çorba", ImageUrl = "mantar.jpg" },
            new Meal { Name = "Tarhana Çorbası", Description = "Anadolu'nun geleneksel tarhana çorbası.", Price = 9.0m, Type = "Çorba", ImageUrl = "tarhana.jpg" },
            new Meal { Name = "Pilav", Description = "Lezzetli pilav.", Price = 10.0m, Type = "Ana Yemek", ImageUrl = "pilav.jpg" },
            new Meal { Name = "Tavuk Sote", Description = "Lezzetli tavuk sote.", Price = 20.0m, Type = "Ana Yemek", ImageUrl = "tavuksote.jpg" },
            new Meal { Name = "Karnıyarık", Description = "Lezzetli karnıyarık.", Price = 25.0m, Type = "Ana Yemek", ImageUrl = "karniyarik.jpg" },
            new Meal { Name = "Cacık", Description = "Ferah cacık.", Price = 5.0m, Type = "Salata", ImageUrl = "cacik.jpg" },
            new Meal { Name = "Çoban Salatası", Description = "Lezzetli çoban salatası.", Price = 7.0m, Type = "Salata", ImageUrl = "cobansalatasi.jpg" },
            new Meal { Name = "Baklava", Description = "Tatlı baklava.", Price = 15.0m, Type = "Tatlı", ImageUrl = "baklava.jpg" },
            new Meal { Name = "Sütlaç", Description = "Tatlı sütlaç.", Price = 10.0m, Type = "Tatlı", ImageUrl = "sutlac.jpg" },
            new Meal { Name = "Ayran", Description = "Ferah ayran.", Price = 3.0m, Type = "İçecek", ImageUrl = "ayran.jpg" },
            new Meal { Name = "Kola", Description = "Serinletici kola.", Price = 5.0m, Type = "İçecek", ImageUrl = "kola.jpg" }
        );
        context.SaveChanges();
    }
}

app.Run();
