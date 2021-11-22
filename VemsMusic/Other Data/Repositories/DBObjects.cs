using System.Linq;
using System.Threading.Tasks;
using VemsMusic.Models;

namespace VemsMusic.Repositories
{
    public class DBObjects
    {
        public static async Task InitialAsync(AppDBContext context)
        {
            if (!context.Genres.Any())
            {
                await context.AddRangeAsync(
                    new Genre
                    {
                        Name = "Рок",
                        Description = "Анархия",
                        PicturePath = "/img/genre-icon/rock.png"
                    },
                    new Genre
                    {
                        Name = "Реп",
                        Description = "Кал",
                        PicturePath = "/img/genre-icon/hip-hop.png"
                    },
                    new Genre
                    {
                        Name = "Инди",
                        Description = "Индюк",
                        PicturePath = ""
                    });
            }
            if (!context.Groups.Any())
            {
                await context.AddRangeAsync(
                    new MusicalGroup
                    {
                        Name = "Анархисты",
                        Description = "Анархируют",
                        Picture = "",
                        GenreId = 1
                    },
                    new MusicalGroup
                    {
                        Name = "Реперы",
                        Description = "Читают",
                        Picture = "",
                        GenreId = 2
                    },
                    new MusicalGroup
                    {
                        Name = "Рокеры",
                        Description = "Рочат",
                        Picture = "",
                        GenreId = 1
                    });
            }
            if (!context.Musics.Any())
            {
                await context.AddRangeAsync(
                    new Music
                    {
                        Name = "Песенка",
                        AudioPath = "",
                        GroupId = 1,
                        ImagePath = "",
                        Text = "Поется",
                    },
                    new Music
                    {
                        Name = "Рокинка",
                        AudioPath = "",
                        GroupId = 1,
                        ImagePath = "",
                        Text = "Поется",
                    },
                    new Music
                    {
                        Name = "Трип",
                        AudioPath = "",
                        GroupId = 1,
                        ImagePath = "",
                        Text = "Поется",
                    });
            }
            await context.SaveChangesAsync();
        }

    }
}
