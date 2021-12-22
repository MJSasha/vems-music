using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VemsMusic.Models;
using VemsMusic.Other_Data.Interfaces;
using VemsMusic.Other_Data.ViewModels;

namespace VemsMusic.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class UserController : Controller
    {
        private readonly IAllMusic _allMusic;
        private readonly IAllUsers _allUsers;

        public UserController(IAllMusic allMusic, IAllUsers allUsers)
        {
            _allMusic = allMusic;
            _allUsers = allUsers;
        }

        [Route("~/User/MyMusic")]
        public async Task<IActionResult> MyMusic()
        {
            string userId = HttpContext.Request.Cookies["id"];
            var user = await _allUsers.GetUserByIdAsync(Convert.ToInt32(userId));

            if (user.Musics.IsEmpty())
            {
                return Redirect("~/Home/NoItems/Музыка не добавлена");
            }

            var musicObj = new MusicViewModel();
            var musicList = new List<Music>();

            foreach (var item in user.Musics)
            {
                musicList.Add(await _allMusic.GetMusicsByIdAsync(item.Id));
            }

            ViewBag.Id = userId;
            musicObj.AllMusic = musicList;
            return View(musicObj);
        }

        [Route("~/AddMusicToUser/{musicId}")]
        public async Task<IActionResult> AddMusicToUser(int musicId)
        {
            string userId = HttpContext.Request.Cookies["id"];
            await _allUsers.AddMusicToUserAsync(musicId, Convert.ToInt32(userId));

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [Route("~/RemoveMusic/{musicId}")]
        public async Task<IActionResult> RemoveMusic(int musicId)
        {
            string userId = HttpContext.Request.Cookies["id"];
            await _allUsers.RemoveMusicAsync(musicId, Convert.ToInt32(userId));

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
