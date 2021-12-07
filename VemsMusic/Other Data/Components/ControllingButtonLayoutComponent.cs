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
    public class ControllingButtonLayoutComponent
    {
        private readonly IAllUsers _allUsers;
        private readonly IAllMusic _allMusic;

        public ControllingButtonLayoutComponent(IAllUsers allUsers, IAllMusic allMusic)
        {
            _allUsers = allUsers;
            _allMusic = allMusic;
        }

        public async Task<IViewComponentResult> InvokeAsync(Music music, string id)
        {
            var user = await _allUsers.GetUserByIdAsync(Convert.ToInt32(id));
            if (user.Musics.Contains(music))
            {
                return new HtmlContentViewComponentResult(
                    new HtmlString($"<a href=\"/RemoveMusic/{music.Id}\">Удалить</a>"));
            }
            else
            {
                return new HtmlContentViewComponentResult(
                    new HtmlString($"<a href=\"/AddMusicToUser/{music.Id}\">" +
                    $"\n<img class=\"music-add\" src=\"/img/add.png\"/> \n</a>"));
            }
        }
    }
}
