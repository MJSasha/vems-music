using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Threading.Tasks;
using VemsMusic.Models;
using VemsMusic.Other_Data.Interfaces;


namespace VemsMusic.Other_Data.Components
{
    [ViewComponent]
    public class AddOrDeleteButtonForMusicComponent
    {
        private readonly IAllUsers _allUsers;

        public AddOrDeleteButtonForMusicComponent(IAllUsers allUsers)
        {
            _allUsers = allUsers;
        }

        public async Task<IViewComponentResult> InvokeAsync(Music music, string userId)
        {
            if (userId == null)
            {
                return new HtmlContentViewComponentResult(AddButtonForMusic(music));
            }

            var user = await _allUsers.GetUserByIdAsync(Convert.ToInt32(userId));

            if (user.Musics.Contains(music))
            {
                return new HtmlContentViewComponentResult(DeleteButtonForMusic(music));
            }
            else
            {
                return new HtmlContentViewComponentResult(AddButtonForMusic(music));
            }
        }

        private static HtmlString AddButtonForMusic(Music music)
        {
            return new HtmlString($"<a href=\"/AddMusicToUser/{music.Id}\">" +
                    $"\n<img class=\"music-add\" src=\"/img/add.png\"/> \n</a>");
        }
        private static HtmlString DeleteButtonForMusic(Music music)
        {
            return new HtmlString($"<a href=\"/RemoveMusic/{music.Id}\">Удалить</a>");
        }
    }
}
