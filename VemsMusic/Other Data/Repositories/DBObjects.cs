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
                        Name = "Hip-hop",
                        Description = "Качает будь здоров",
                        PicturePath = "/img/genre-icon/hip-hop.png"
                    },
                    new Genre
                    {
                        Name = "Рок",
                        Description = "Жоский",
                        PicturePath = "/img/genre-icon/rock.png"
                    },
                    new Genre
                    {
                        Name = "Инди-рок",
                        Description = "Грустненько",
                        PicturePath = "/img/genre-icon/indie-rock.png"
                    });
            }
            if (!context.Groups.Any())
            {
                await context.AddRangeAsync(
                    new MusicalGroup
                    {
                        Name = "Lana del Rey",
                        Description = "Sadness woman..",
                        Picture = "/img/group-icon/lana-del-rey.png",
                        GenreId = 3
                    },
                    new MusicalGroup
                    {
                        Name = "Imagine Dragons",
                        Description = "Imagine.. dragons",
                        Picture = "/img/group-icon/imagine-dragons.png",
                        GenreId = 3
                    },
                    new MusicalGroup
                    {
                        Name = "Рокеры",
                        Description = "Рочат",
                        Picture = "",
                        GenreId = 2
                    });

                    // !!! Прописать M.I.A. и её треки
            }
            if (!context.Musics.Any())
            {
                await context.AddRangeAsync(
                    new Music
                    {
                        Name = "Breaking Up Slowly",
                        AudioPath = "/music/lana-del-rey/chemtrails-over-the-country-club/Lana Del Rey - Breaking Up Slowly.mp3",
                        GroupId = 1,
                        GenreId = 2,
                        ImagePath = "/img/music-icon/chemtrails-over-the-country-club.png",
                        Text = "Поется",
                    },
                    new Music
                    {
                        Name = "Chemtrails Over The Country Club",
                        AudioPath = "/music/lana-del-rey/chemtrails-over-the-country-club/Lana Del Rey - Chemtrails Over The Country Club.mp3",
                        GroupId = 1,
                        GenreId = 2,
                        ImagePath = "/img/music-icon/chemtrails-over-the-country-club.png",
                        Text = "Поется",
                    },
                    new Music
                    {
                        Name = "Трип",
                        AudioPath = "",
                        GroupId = 1,
                        GenreId = 2,
                        ImagePath = "",
                        Text = "Поется",
                    });
            }
            if (!context.Users.Any())
            {
                await context.AddRangeAsync(
                    new User
                    {
                        Email = "Sasha@gmail.com",
                        Password = "sasha-sasha",
                    },
                    new User
                    {
                        Email = "matvey@gmail.com",
                        Password = "matvey124",
                    });
            }
            if (!context.Roles.Any())
            {
                await context.AddRangeAsync(
                    new Role
                    {
                        Name = "admin"
                    },
                    new Role
                    {
                        Name = "user"
                    });
            }
            await context.SaveChangesAsync();
        }

    }
}
