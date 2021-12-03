using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VemsMusic.Models;

namespace VemsMusic.Other_Data.Repositories
{
    public class StartDBObjects
    {
        public static async Task InitialAsync(AppDBContext dBContext)
        {
            Genre HipHop = new()
            {
                Name = "Hip-hop",
                Description = "Качает будь здоров",
                PicturePath = "/img/genre-icon/hip-hop.png"
            };
            Genre Rock = new()
            {
                Name = "Рок",
                Description = "Жоский",
                PicturePath = "/img/genre-icon/rock.png"
            };
            Genre IndiRock = new()
            {
                Name = "Инди-рок",
                Description = "Грустненько",
                PicturePath = "/img/genre-icon/indie-rock.png"
            };

            Music BreakingUpSlowly = new()
            {
                Name = "Breaking Up Slowly",
                AudioPath = "/music/lana-del-rey/chemtrails-over-the-country-club/Lana Del Rey" +
                " - Breaking Up Slowly.mp3",
                Genre = IndiRock,
                ImagePath = "/img/music-icon/chemtrails-over-the-country-club.png",
                Text = "Поется"
            };
            Music Chemtrails = new()
            {
                Name = "Chemtrails Over The Country Club",
                AudioPath = "/music/lana-del-rey/chemtrails-over-the-country-club/Lana Del Rey " +
                "- Chemtrails Over The Country Club.mp3",
                Genre = IndiRock,
                ImagePath = "/img/music-icon/chemtrails-over-the-country-club.png",
                Text = "Поется",
            };
            Music Borders = new()
            {
                Name = "Borders",
                AudioPath = "/music/lana-del-rey/chemtrails-over-the-country-club/M.I.A. - Borders.mp3",
                Genre = HipHop,
                ImagePath = "/img/music-icon/aim.png",
                Text = "Поется",
            };
            Music GoOff = new()
            {
                Name = "Go Off",
                AudioPath = "/music/lana-del-rey/chemtrails-over-the-country-club/M.I.A. - Go Off.mp3",
                Genre = HipHop,
                ImagePath = "/img/music-icon/aim.png",
                Text = "Поется",
            };

            MusicalGroup LanaDeRey = new()
            {
                Name = "Lana del Rey",
                Description = "Sadness woman..",
                Picture = "/img/group-icon/lana-del-rey.png",
                Genres = new List<Genre> { IndiRock },
                Musics = new List<Music> { BreakingUpSlowly, Chemtrails }
            };
            MusicalGroup ImagineDragons = new()
            {
                Name = "Imagine Dragons",
                Description = "Imagine.. dragons",
                Picture = "/img/group-icon/imagine-dragons.png",
                Genres = new List<Genre> { IndiRock }
            };
            MusicalGroup Slipknot = new()
            {
                Name = "Slipknot",
                Description = "Орут",
                Picture = "/img/group-icon/slipknot.jpg",
                Genres = new List<Genre> { Rock }
            };
            MusicalGroup MIA = new()
            {
                Name = "M.I.A.",
                Description = "Миа",
                Picture = "/img/group-icon/mia.png",
                Genres = new List<Genre> { HipHop },
                Musics = new List<Music> { Borders, GoOff }
            };
            MusicalGroup Beatles = new()
            {
                Name = "Beatles",
                Description = "Битлы",
                Picture = "/img/group-icon/beatles.jpg",
                Genres = new List<Genre> { Rock }
            };


            Role admin = new() { Name = "admin" };
            Role user = new() { Name = "user" };

            User Sasha = new()
            {
                Email = "Sasha@gmail.com",
                Password = "sasha-sasha",
                Role = admin,
            };
            User Matvey = new()
            {
                Email = "matvey@gmail.com",
                Password = "matvey124",
                Role = admin
            };

            if (!dBContext.Groups.Any())
            {
                await dBContext.AddRangeAsync(LanaDeRey, ImagineDragons, Slipknot, MIA, Beatles);
            }
            if (!dBContext.Users.Any())
            {
                await dBContext.AddRangeAsync(Sasha, Matvey);
                await dBContext.AddRangeAsync(user);
            }

            await dBContext.SaveChangesAsync();
        }
    }
}
