using System.Collections.Generic;
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
using ImperatorStats.Data;
using ImperatorStats.Extensions;
using Z.EntityFramework.Plus;

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
            return View("GameList",new GamesListViewModel(_db.Games.Include(x => x.Saves).ToList()));
        }
        [HttpGet("/AddGame")]
        public IActionResult AddGame()
        {
            return View();
        }
        [HttpGet("/GameList")]
        public IActionResult GameList()
        {
            return View(new GamesListViewModel(_db.Games.Include(x => x.Saves).ToList()));
        }
        [HttpPost("/GameList")]
        public IActionResult AddGamePost(string gameName, string gamePassword)
        {
            string response = "You didn't specify a name.";
            if (gameName != null)
            {
                var game = new Game {Name = gameName};
                if (gamePassword != null)
                {
                    game.PasswordHash = gamePassword.GetSha1();
                }
                _db.Games.Add(game);
                _db.SaveChanges();
                response = "Game added successfully.";
            }
            return View("GameList",new GamesListViewModel(_db.Games.Include(x => x.Saves).ToList(),response));
        }

        [HttpGet("/Game/{id:int}/{hash?}")]
        public IActionResult Game(int id, string hash)
        {
            var game = _db.Games
                .Where(x => x.GameId == id && (x.PasswordHash == null || x.PasswordHash == hash))
                .Include(x => x.Saves)
                .FirstOrDefault();
            string response = null;
            if (game == null)
            {
                response = hash == null ? "Accessing this game requires a password." : "You are using an invalid URL.";
            }
            return View(new GameViewModel(game, id, response));
        }
        [HttpPost("/Game/{id:int}")]
        public IActionResult GameAuth(int id, string gamePassword)
        {
            var hash = gamePassword?.GetSha1();
            var game = _db.Games.Where(x => x.GameId == id && (x.PasswordHash == null || x.PasswordHash == hash))
                .Include(x => x.Saves)
                .FirstOrDefault();
            if (game == null)
            {
                return View("Game",new GameViewModel(null, id, "Wrong password."));
            }
            return RedirectPermanent("/Game/" + id + "/" + hash);
            
        }
        [HttpPost("/Game/{id:int}/Upload/{hash?}")]
        [RequestSizeLimit(200000000)]
        public async Task<IActionResult> UploadSave(List<IFormFile> files, int id, string hash)
        {
            var game = _db.Games.Where(x => x.GameId == id && (x.PasswordHash == null || x.PasswordHash == hash))
                .Include(x => x.Saves)
                .FirstOrDefault();
            if (game == null)
            {
                return View("Game", new GameViewModel(null, id, "You don't have access to this game."));
            }
            int saveId = 0;
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
                            if (_db.Saves.Any(s => s.SaveKey == save.SaveKey && s.GameId == id && (s.Game.PasswordHash == null || s.Game.PasswordHash == hash)))
                            {
                                var oldSave =_db.Saves.Where(s => s.SaveKey == save.SaveKey && (s.Game.PasswordHash == null || s.Game.PasswordHash == hash))
                                    .Include(x => x.Game)
                                    .FirstOrDefault();
                                return View("Save",new SaveViewModel(oldSave));
                            }

                            save.GameId = game.GameId;
                            saveId = _db.BulkSave(save);
                        }
                    }
                }
            }
            if (saveId == 0)
            {
                return View("Game", new GameViewModel(game, game.GameId, "The file you uploaded isn't a decompressed Imperator save or it couldn't be parsed."));
            }
            return View("Game", new GameViewModel(game, game.GameId));
        }
        [HttpGet("/UploadLocations")]
        public IActionResult LoadLocations()
        {
            _db.UploadLocations();
            return View("AddGame");
        }
        
        [HttpGet("/Save/{id:int}/{hash?}")]
        public IActionResult Save(int id, string hash)
        {
            var save =_db.Saves.Where(x => x.SaveId == id && (x.Game.PasswordHash == null || x.Game.PasswordHash == hash))
                .Include(x => x.Game)
                .FirstOrDefault();
            return View(new SaveViewModel(save));
        }
        [HttpGet("Save/{id:int}/Facts/{hash?}")]
        public IActionResult Facts(int id, string hash)
        {
            var save =_db.Saves.FirstOrDefault(x => x.SaveId == id && (x.Game.PasswordHash == null || x.Game.PasswordHash == hash));
            return View(new FactsViewModel(save, _db));
        }
        [HttpGet("Save/{id:int}/Religion/{hash?}")]
        public IActionResult Religion(int id, string hash)
        {
            var save =_db.Saves.FirstOrDefault(x => x.SaveId == id && (x.Game.PasswordHash == null || x.Game.PasswordHash == hash));
            return View(new ReligionViewModel(save, _db));
        }
        [HttpGet("Save/{id:int}/TradeGoods/{hash?}")]
        public IActionResult TradeGoods(int id, string hash)
        {
            var save =_db.Saves.FirstOrDefault(x => x.SaveId == id && (x.Game.PasswordHash == null || x.Game.PasswordHash == hash));
            return View(new TradeGoodsViewModel(save, _db));
        }
        [HttpGet("Save/{id:int}/Culture/{hash?}")]
        public IActionResult Culture(int id, string hash)
        {
            var save =_db.Saves.FirstOrDefault(x => x.SaveId == id && (x.Game.PasswordHash == null || x.Game.PasswordHash == hash));
            return View(new CultureViewModel(save, _db));
        }
        [HttpGet("Save/{id:int}/Economy/{hash?}")]
        public IActionResult Economy(int id, string hash)
        {
            var countries =_db.Countries.Where(x => x.SaveId == id && (x.Save.Game.PasswordHash == null || x.Save.Game.PasswordHash == hash))
                .Include(x => x.Name)
                .Include(x => x.Players)
                .Where(x => x.Players.Count > 0)
                .OrderByDescending(x => x.AveragedIncome).ToList();
            return View(new CountriesViewModel(countries));
        }
        [HttpGet("Save/{id:int}/Technology/{hash?}")]
        public IActionResult Technology(int id, string hash)
        {
            var countries =_db.Countries.Where(x => x.SaveId == id && (x.Save.Game.PasswordHash == null || x.Save.Game.PasswordHash == hash))
                .Include(x => x.Name)
                .IncludeOptimized(x => x.Players)
                .IncludeOptimized(x => x.Technologies)
                .Where(x => x.Players.Count > 0)
                .ToList().OrderByDescending(x => x.AverageTechLevel).ToList();
            return View(new CountriesViewModel(countries));
        }
        [HttpGet("Save/{id:int}/DemographyProvinces/{hash?}")]
        public IActionResult DemographyProvinces(int id, string hash)
        {
            var countries =_db.Countries.Where(x => x.SaveId == id && (x.Save.Game.PasswordHash == null || x.Save.Game.PasswordHash == hash))
                .Include(x => x.Name)
                .Include(x => x.Players)
                .Include(x => x.Provinces)
                .ThenInclude(x => x.Pops)
                .Where(x => x.Players.Count > 0)
                .OrderByDescending(x => x.TotalPopulation).ToList();
            return View(new CountriesViewModel(countries));
        }
        [HttpGet("Save/{id:int}/DemographyPops/{hash?}")]
        public IActionResult DemographyPops(int id, string hash)
        {
            var countries =_db.Countries.Where(x => x.SaveId == id && (x.Save.Game.PasswordHash == null || x.Save.Game.PasswordHash == hash))
                .Include(x => x.Name)
                .Include(x => x.Players)
                .Include(x => x.Provinces)
                .ThenInclude(x => x.Pops)
                .Where(x => x.Players.Count > 0)
                .OrderByDescending(x => x.TotalPopulation).ToList();
            return View(new CountriesViewModel(countries));
        }
        [HttpGet("Save/{id:int}/ArmyComposition/{hash?}")]
        public IActionResult ArmyComposition(int id, string hash)
        {
            var countries =_db.Countries.Where(x => x.SaveId == id && (x.Save.Game.PasswordHash == null || x.Save.Game.PasswordHash == hash))
                .Include(x => x.Name)
                .Include(x => x.Players)
                .Include(x => x.Armies)
                .Where(x => x.Players.Count > 0)
                .OrderByDescending(x => x.TotalCohorts).ToList();
            return View(new CountriesViewModel(countries));
        }
        [HttpGet("Save/{id:int}/NavyComposition/{hash?}")]
        public IActionResult NavyComposition(int id, string hash)
        {
            var countries =_db.Countries.Where(x => x.SaveId == id && (x.Save.Game.PasswordHash == null || x.Save.Game.PasswordHash == hash))
                .Include(x => x.Name)
                .Include(x => x.Players)
                .Include(x => x.Armies)
                .Where(x => x.Players.Count > 0)
                .OrderByDescending(x => x.TotalCohorts).ToList();
            return View(new CountriesViewModel(countries));
        }
        [HttpGet("Save/{id:int}/Military/{hash?}")]
        public IActionResult Military(int id, string hash)
        {
            var countries =_db.Countries.Where(x => x.SaveId == id && (x.Save.Game.PasswordHash == null || x.Save.Game.PasswordHash == hash))
                .Include(x => x.Name)
                .Include(x => x.Players)
                .Include(x => x.Armies)
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