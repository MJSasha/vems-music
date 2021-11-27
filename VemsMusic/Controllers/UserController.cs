using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public IActionResult MyMusic()
        {
            string userEmail = ClaimsIdentity.DefaultNameClaimType.ToString();
            var user = _allUsers.GetUserByEmail(userEmail);

            if (user.MusicId == null)
            {
                return Redirect("~/Home/NoItems/Музыка не добавлена");
            }

            var musicId = user.MusicId.Split(',');
            var musicObj = new MusicViewModel();
            var musicList = new List<Music>();

            foreach (var item in musicId)
            {
                musicList.Add(_allMusic.GetMusicsById(Convert.ToInt32(item)));
            }

            if (!musicList.Any())
            {
                return Redirect("~/Home/NoItems/Музыка не добавлена");
            }

            musicObj.AllMusic = musicList;
            return View(musicObj);
        }
    }
}
