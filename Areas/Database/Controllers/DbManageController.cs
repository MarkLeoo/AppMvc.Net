using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public DbManageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteDb()
        {
            return View();
        }

        [TempData]
        public string StatusMessage { get; set; }


        [HttpPost]
        public async Task<IActionResult> DeleteDbAsync()
        {
            var isSuccess = await _appDbContext.Database.EnsureDeletedAsync();
            StatusMessage = isSuccess ? "Database was deleted" : "There was an error when deleting the database";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Migrate()
        {
            await _appDbContext.Database.MigrateAsync();
            StatusMessage = "Update migration successfully";
            return RedirectToAction("Index");
        }
    }
}