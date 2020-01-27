﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Imperator.Save;
using Microsoft.AspNetCore.Mvc;
using ImperatorStats.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Pdoxcl2Sharp;
using Imperator.Save.Parser;

namespace ImperatorStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ImperatorContext _db;

        public HomeController(ImperatorContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SaveList()
        {
            return View(new SavesListViewModel(_db.Saves.ToList()));
        }
        [HttpPost]
        [RequestSizeLimit(200000000)]
        public async Task<IActionResult> UploadSave(List<IFormFile> files)
        {
            string response = "The file you uploaded isn't a decompressed Imperator save.";
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();
                    if (formFile.FileName.EndsWith(".rome"))
                    {
                        await using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                       
                        }
                        await using (var stream = new FileStream(filePath, FileMode.Open))
                        {
                            var save = ParadoxParser.Parse(stream, new SaveParser());
                            if (_db.Saves.Any(s => s.SaveKey == save.SaveKey))
                            {
                                response = "The save you uploaded already exists in the database.";
                            }
                            else
                            {
                                _db.Saves.Add((Save)save);
                                response = "Save added correctly.";
                            }
                            _db.SaveChanges();
                        }
                    }
                }
            }
            
            return View("SaveList", new SavesListViewModel(_db.Saves.Take(20).ToList(), response));
        }

        [HttpGet("/Home/Save/{id:int}")]
        public IActionResult Save(int id)
        {
            var save =_db.Saves.Find(id);
            return View(new SaveViewModel(save));
        }
        [HttpGet("/Home/Economy/{id:int}")]
        public IActionResult Economy(int id)
        {
            var countries =_db.Countries.Where(x => x.SaveId == id)
                .Include(x => x.Players)
                .Where(x => x.Players.Count > 0)
                .OrderByDescending(x => x.AveragedIncome).ToList();
            return View(new CountriesViewModel(countries));
        }
        [HttpGet("/Home/Technology/{id:int}")]
        public IActionResult Technology(int id)
        {
            var countries =_db.Countries.Where(x => x.SaveId == id)
                .Include(x => x.Players)
                .Include(x => x.Technologies)
                .Where(x => x.Players.Count > 0)
                .ToList().OrderByDescending(x => x.AverageTechLevel).ToList();
            return View(new CountriesViewModel(countries));
        }
        [HttpGet("/Home/Demography/{id:int}")]
        public IActionResult Demography(int id)
        {
            var countries =_db.Countries.Where(x => x.SaveId == id)
                .Include(x => x.Players)
                .Where(x => x.Players.Count > 0)
                .OrderByDescending(x => x.TotalPopulation).ToList();
            return View(new CountriesViewModel(countries));
        }
        [HttpGet("/Home/Military/{id:int}")]
        public IActionResult Military(int id)
        {
            var countries =_db.Countries.Where(x => x.SaveId == id)
                .Include(x => x.Players)
                .Where(x => x.Players.Count > 0)
                .OrderByDescending(x => x.TotalCohorts).ToList();
            return View(new CountriesViewModel(countries));
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
