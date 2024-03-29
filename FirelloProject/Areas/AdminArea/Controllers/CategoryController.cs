﻿using FirelloProject.DAL;
using FirelloProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirelloProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Categories.ToList());

        }

        public IActionResult Detail(int id)
        {
            Category category=_appDbContext.Categories.SingleOrDefault(c=>c.ID==id);
            if (category == null) return NotFound();
            return View(category);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
