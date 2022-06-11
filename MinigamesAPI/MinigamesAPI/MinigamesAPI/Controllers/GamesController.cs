using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MinigamesBusinessLayerMethods;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MinigamesDatabase.Models;
using MinigamesDatabase;

namespace MinigamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {

        #region private fields
        private readonly ILogger<GamesController> _logger;
        private readonly IBusiness _business;
        private readonly IWebHostEnvironment _hostEnvironment;
        #endregion

        #region Constructor
        public GamesController(IBusiness business, ILogger<GamesController> logger, DataContext dataContext, IWebHostEnvironment hostEnvironment)
        {
            _business = business;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }
        #endregion

        #region Management methods
        /// <summary>
        /// Returns a list of all  games description
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> GetGameInfoListAsync()
        {
            var games = await _business.GetGameInfoListAsync();
            if (games != null)
                return StatusCode(200, games);
            else
                return StatusCode(500);
        }

        [HttpGet("SingleGame/{id}")]
        public async Task<IActionResult> GetSingleGame(int id)
        {
            GameDetail gameInfo = await _business.SingleGameAsync(id);

            if (gameInfo != null)
            {
                return StatusCode(200, gameInfo);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a game with only descriptions
        /// </summary>
        /// <param name="gameDetail"></param>
        /// <returns></returns>
        [HttpPost("CreateGame")]
        public async Task<ActionResult<GameInfo>> CreateGame([FromForm] GameDetail gameDetail)
        {
            gameDetail.ImageName = await SaveImage(gameDetail.ImageFile);

            GameInfo gameInfo = await _business.CreateGameAsync(gameDetail);


            if (gameInfo != null)
            {
                return StatusCode(201, gameInfo);
            }
            else
            {
                return StatusCode(422, gameInfo);
            }
        }

        /// <summary>
        /// Modifies an existing game 
        /// </summary>
        /// <param name="gameDetail"></param>
        /// <returns></returns>

        [HttpPatch("ModifyGame")]
        public async Task<ActionResult<GameInfo>> ModifyGame([FromForm] GameDetail gameDetail)
        {
            if (gameDetail.ImageFile != null)
            {
                DeleteImage(gameDetail.OldImageName);
                gameDetail.ImageName = await SaveImage(gameDetail.ImageFile);

            }

            GameInfo gameInfo = await _business.ModifyGameAsync(gameDetail);


            if (gameInfo != null)
            {
                return StatusCode(200, gameInfo);
            }
            else
            {
                return StatusCode(422, gameInfo);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteGame(int id)
        {
            GameInfo gameInfo = await _business.DeleteGameAsync(id);


            if (gameInfo.ImagePath != null || gameInfo.ImagePath != "")
            {
                DeleteImage(gameInfo.ImagePath);
            }
            return StatusCode(200, gameInfo);

        }
        // Stores the image statically in the Image folder and returns a modified version of the name. 
        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("ttmmssffff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddGameInfo(GameInfo gameInfo)
        {
            if (await _business.AddGameInfoAsync(gameInfo))
                return StatusCode(201);
            else
                return StatusCode(500);
        }
        #endregion





        #region WTP

        [HttpGet("wtp")]
        public async Task<IActionResult> GetRandomPokemon()
        {
            var pokemon = await _business.WhosThatPokemonGameAsync();
            return StatusCode(200, pokemon);
        }

        [HttpPost("WtpWin")]
        public async Task<IActionResult> WtpWinAsync(int userId)
        {
            var success = await _business.WtpWinAsync(userId);
            if (success)
            {
                return StatusCode(200, success);
            }
            return BadRequest(new { message = "Error, Something went wrong.", status = -1 });
        }

        [HttpPost("WtpLose")]
        public async Task<IActionResult> WtpLose(int userId)
        {
            var success = await _business.WtpLoseAsync(userId);
            if (success)
            {
                return StatusCode(200, success);
            }
            return BadRequest(new { message = "Error, Something went wrong.", status = -1 });
        }

        [HttpGet("WtpRecord/{userId}")]
        public async Task<IActionResult> WtpRecord(int userId)
        {
            var success = await _business.WtpRecordAsync(userId);
            return StatusCode(200, success);
        }
        #endregion





        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath)) 
            {
                System.IO.File.Delete(imagePath);
            }
        }


        #region RPS
        [HttpPost("RpsWin")]
        public async Task<IActionResult> RpsWin(int userId)
        {
            var success = await _business.RpsWinAsync(userId);
            if (success)
            {
                return StatusCode(200, success);
            }
            return BadRequest(new { message = "Error, Something went wrong.", status = -1 });
        }

        [HttpPost("RpsLose")]
        public async Task<IActionResult> RpsLose(int userId)
        {
            var success = await _business.RpsLoseAsync(userId);
            if (success)
            {
                return StatusCode(200, success);
            }
            return BadRequest(new { message = "Error, Something went wrong.", status = -1 });
        }

        [HttpGet("RpsRecord/{userId}")]
        public async Task<IActionResult> RpsRecord(int userId)
        {
            var success = await _business.RpsRecordAsync(userId);
            return StatusCode(200, success);
        }
        #endregion

        #region CAP
        [HttpPost("CapWin")]
        public async Task<IActionResult> CapWin(int userId)
        {
            var success = await _business.CapWinAsync(userId);
            if (success)
            {
                return StatusCode(200, success);
            }
            return BadRequest(new { message = "Error, Something went wrong.", status = -1 });
        }

        [HttpPost("CapLose")]
        public async Task<IActionResult> CapLose(int userId)
        {
            var success = await _business.CapLoseAsync(userId);
            if (success)
            {
                return StatusCode(200, success);
            }
            return BadRequest(new { message = "Error, Something went wrong.", status = -1 });
        }

        [HttpGet("CapRecord/{userId}")]
        public async Task<IActionResult> CapRecord(int userId)
        {
            var success = await _business.CapRecordAsync(userId);
            return StatusCode(200, success);
        }
        #endregion

        #region PHM
        [HttpPut("PhmPlayed/{userId}")]
        public async Task<IActionResult> PhmPlayed(int userId)
        {
            var success = await _business.PhmPlayedAsync(userId);
            return StatusCode(200, success);
        }

        [HttpPut("PhmWin/{userId}")]
        public async Task<IActionResult> PhmWin(int userId)
        {
            var success = await _business.PhmWinAsync(userId);
            return StatusCode(200, success);
        }

        [HttpGet("PhmRecord/{userId}")]
        public async Task<IActionResult> PhmRecord(int userId)
        {
            var success = await _business.PhmRecordAsync(userId);
            return StatusCode(200, success);
        }
        #endregion

        #region WAM
        [HttpPut("WamPlayed/{userId}")]
        public async Task<IActionResult> WamPlayed(int userId, int highScore)
        {
            var success = await _business.WamPlayedAsync(userId, highScore);
            return StatusCode(200, success);
        }

        [HttpGet("WamRecord/{userId}")]
        public async Task<IActionResult> WamRecord(int userId)
        {
            var success = await _business.WamHighScoreAsync(userId);
            return StatusCode(200, success);
        }
        #endregion






    }
}