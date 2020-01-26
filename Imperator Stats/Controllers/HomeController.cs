using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImperatorSaveParser;
using Microsoft.AspNetCore.Mvc;
using ImperatorStats.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Pdoxcl2Sharp;

namespace ImperatorStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly MySqlContext _db;

        public HomeController(MySqlContext db)
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
                            var save = ParadoxParser.Parse(stream, new Save());
                            if (_db.Saves.Any(s => s.SaveKey == save.SaveKey))
                            {
                                response = "The save you uploaded already exists in the database.";
                            }
                            else
                            {
                                _db.Saves.Add(save);
                                response = "Save added correctly.";
                            }
                            await _db.SaveChangesAsync();
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
                .Include(x => x.CurrencyData)
                .Include(x => x.Players)
                .OrderBy(x => x.Tag).ToList();
            return View(new EconomyViewModel(countries));
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
