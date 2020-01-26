using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImperatorSaveParser;
using Microsoft.AspNetCore.Mvc;
using ImperatorStats.Models;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Stats()
        {
            return View(new StatsViewModel(null));
        }
        public IActionResult SaveList()
        {
            return View(new SavesListViewModel(_db.Saves.Take(20).ToList()));
        }
        [HttpPost]
        [RequestSizeLimit(200000000)]
        public async Task<IActionResult> Stats(List<IFormFile> files)
        {
            Save save = null;
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
                            save = ParadoxParser.Parse(stream, new Save());
                            _db.Saves.Add(save);
                            _db.Countries.AddRange(save.CountryManager.Countries.Values.Where(x => x != null));
                            _db.Families.AddRange(save.FamilyManager.Families.Values.Where(x => x != null));
                            await _db.SaveChangesAsync();
                        }
                    }
                }
            }
 
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return View(new StatsViewModel(save));
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
