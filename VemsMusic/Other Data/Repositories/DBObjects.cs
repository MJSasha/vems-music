﻿using System.Linq;
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
                        Description = "Качает",
                        PicturePath = "/img/genre-icon/hip-hop.png"
                    },
                    new Genre
                    {
                        Name = "Рок",
                        Description = "Рокирует",
                        PicturePath = "/img/genre-icon/rock.png"
                    },
                    new Genre
                    {
                        Name = "Инди-рок",
                        Description = "Индюширует",
                        PicturePath = ""
                    });
            }
            if (!context.Groups.Any())
            {
                await context.AddRangeAsync(
                    new MusicalGroup
                    {
                        Name = "Lana del Rey",
                        Description = "Sadness woman...",
                        Picture = "/img/group-icon/lana-del-rey.png",
                        GenreId = 3
                    },
                    new MusicalGroup
                    {
                        Name = "Imagine Dragons",
                        Description = "/img/group-icon/imagine-dragons.png",
                        Picture = "",
                        GenreId = 3
                    },
                    new MusicalGroup
                    {
                        Name = "Рокеры",
                        Description = "Рочат",
                        Picture = "",
                        GenreId = 2
                    });
            }
            if (!context.Musics.Any())
            {
                await context.AddRangeAsync(
                    new Music
                    {
                        Name = "Breaking Up Slowly",
                        AudioPath = "/music/lana-del-rey/chemtrails-over-the-country-club/Lana Del Rey - Breaking Up Slowly.mp3",
                        GroupId = 1,
                        ImagePath = "/img/music-icon/chemtrails-over-the-country-club.png",
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