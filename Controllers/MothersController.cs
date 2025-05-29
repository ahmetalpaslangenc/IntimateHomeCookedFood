using Microsoft.AspNetCore.Mvc;
using IntimateHomeCookedFood.Models;
using System.Collections.Generic;

namespace IntimateHomeCookedFood.Controllers
{
    public class MothersController : Controller
    {
        private static readonly Dictionary<string, List<MenuItem>> Menus = new()
        {
            ["Ayla Hanım"] = new List<MenuItem>
            {
                new MenuItem { Id = "ayla-corba", Category = "Çorba", Name = "Mercimek Çorbası", Price = 10 },
                new MenuItem { Id = "ayla-ana", Category = "Ana Yemek", Name = "Karnıyarık", Price = 35 },
                new MenuItem { Id = "ayla-salata", Category = "Salata", Name = "Mevsim Salata", Price = 12 },
                new MenuItem { Id = "ayla-tatli", Category = "Tatlı", Name = "Kadayıf", Price = 18 },
                new MenuItem { Id = "ayla-icecek", Category = "İçecek", Name = "Limonata", Price = 8 }
            },
            ["Selma Hanım"] = new List<MenuItem>
            {
                new MenuItem { Id = "selma-corba", Category = "Çorba", Name = "Ezogelin Çorbası", Price = 12 },
                new MenuItem { Id = "selma-ana", Category = "Ana Yemek", Name = "Mantı", Price = 28 },
                new MenuItem { Id = "selma-salata", Category = "Salata", Name = "Çoban Salata", Price = 10 },
                new MenuItem { Id = "selma-tatli", Category = "Tatlı", Name = "Sütlaç", Price = 14 },
                new MenuItem { Id = "selma-icecek", Category = "İçecek", Name = "Şalgam", Price = 7 }
            },
            ["Gülsüm Hanım"] = new List<MenuItem>
            {
                new MenuItem { Id = "gulsum-corba", Category = "Çorba", Name = "Tarhana Çorbası", Price = 11 },
                new MenuItem { Id = "gulsum-ana", Category = "Ana Yemek", Name = "Fırın Tavuk", Price = 30 },
                new MenuItem { Id = "gulsum-salata", Category = "Salata", Name = "Göbek Salata", Price = 9 },
                new MenuItem { Id = "gulsum-tatli", Category = "Tatlı", Name = "Revani", Price = 13 },
                new MenuItem { Id = "gulsum-icecek", Category = "İçecek", Name = "Ayran", Price = 6 }
            },
            ["Sedef Hanım"] = new List<MenuItem>
            {
                new MenuItem { Id = "sedef-corba", Category = "Çorba", Name = "Yayla Çorbası", Price = 9 },
                new MenuItem { Id = "sedef-ana", Category = "Ana Yemek", Name = "Kuru Fasulye", Price = 25 },
                new MenuItem { Id = "sedef-salata", Category = "Salata", Name = "Zeytinyağlı Enginar", Price = 15 },
                new MenuItem { Id = "sedef-tatli", Category = "Tatlı", Name = "Baklava", Price = 22 },
                new MenuItem { Id = "sedef-icecek", Category = "İçecek", Name = "Kola", Price = 10 }
            }
        };

        public IActionResult Index()
        {
            var mothers = new List<MotherDetailViewModel>
            {
                new MotherDetailViewModel { Name = "Ayla Hanım", Rating = 4.5 },
                new MotherDetailViewModel { Name = "Selma Hanım", Rating = 3.8 },
                new MotherDetailViewModel { Name = "Gülsüm Hanım", Rating = 4.1 },
                new MotherDetailViewModel { Name = "Sedef Hanım", Rating = 3.4 }
            };

            return View(mothers);
        }

        public IActionResult Details(string name)
        {
            if (!Menus.ContainsKey(name))
                return NotFound();

            var viewModel = new MotherDetailViewModel
            {
                Name = name,
                Rating = name switch
                {
                    "Ayla Hanım" => 4.5,
                    "Selma Hanım" => 3.8,
                    "Gülsüm Hanım" => 4.1,
                    "Sedef Hanım" => 3.4,
                    _ => 3.0
                },
                Menu = Menus[name]
            };

            return View(viewModel);
        }
    }
}
