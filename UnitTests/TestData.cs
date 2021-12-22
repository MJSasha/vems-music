using System;
using System.Collections.Generic;
using VemsMusic.Models;

namespace UnitTests
{
    public class TestData
    {
        public static List<Genre> GetTestGenres()
        {
            return new List<Genre> { HipHop, Rock, IndiRock };
        }
        public static List<Genre> GetZeroGenres()
        {
            return new List<Genre>();
        }
        public static List<MusicalGroup> GetTestGroups()
        {
            return new List<MusicalGroup> { LanaDeRey, ImagineDragons, Slipknot, MIA };
        }
        public static List<MusicalGroup> GetZeroGroup()
        {
            return new List<MusicalGroup>();
        }
        public static List<Music> GetTestMusics()
        {
            return new List<Music> { BreakingUpSlowly, Chemtrails, Borders, GoOff };
        }
        public static List<Music> GetZeroMusic()
        {
            return new List<Music>();
        }


        public static Genre HipHop = new()
        {
            Id = 1,
            Name = "Hip-hop",
            Description = "Качает будь здоров",
            PicturePath = "/img/genre-icon/hip-hop.png"
        };
        public static Genre Rock = new()
        {
            Id = 2,
            Name = "Рок",
            Description = "Жоский",
            PicturePath = "/img/genre-icon/rock.png"
        };
        public static Genre IndiRock = new()
        {
            Id = 3,
            Name = "Инди-рок",
            Description = "Грустненько",
            PicturePath = "/img/genre-icon/indie-rock.png"
        };

        public static Music BreakingUpSlowly = new()
        {
            Id = 1,
            Name = "Breaking Up Slowly",
            AudioPath = "/music/lana-del-rey/chemtrails-over-the-country-club/Lana Del Rey" +
            " - Breaking Up Slowly.mp3",
            Genres = new List<Genre> { IndiRock },
            ImagePath = "/img/music-icon/chemtrails-over-the-country-club.png",
            Text = "Поется",
            AdditionDateAndTime = DateTime.Now.ToString("MM.dd.yyyy  HH:mm:ss")
        };
        public static Music Chemtrails = new()
        {
            Id = 2,
            Name = "Chemtrails Over The Country Club",
            AudioPath = "/music/lana-del-rey/chemtrails-over-the-country-club/Lana Del Rey " +
            "- Chemtrails Over The Country Club.mp3",
            Genres = new List<Genre> { IndiRock },
            ImagePath = "/img/music-icon/chemtrails-over-the-country-club.png",
            Text = "Поется",
            AdditionDateAndTime = DateTime.Now.ToString("MM.dd.yyyy  HH:mm:ss")
        };
        public static Music Borders = new()
        {
            Id = 3,
            Name = "Borders",
            AudioPath = "/music/mia/aim/M.I.A. - Borders.mp3",
            Genres = new List<Genre> { HipHop },
            ImagePath = "/img/music-icon/aim.png",
            Text = "Поется",
            AdditionDateAndTime = DateTime.Now.ToString("MM.dd.yyyy  HH:mm:ss")
        };
        public static Music GoOff = new()
        {
            Id = 4,
            Name = "Go Off",
            AudioPath = "/music/mia/aim/M.I.A. - Go Off.mp3",
            Genres = new List<Genre> { HipHop },
            ImagePath = "/img/music-icon/aim.png",
            Text = "Поется",
            AdditionDateAndTime = DateTime.Now.ToString("MM.dd.yyyy  HH:mm:ss")
        };

        public static MusicalGroup LanaDeRey = new()
        {
            Id = 1,
            Name = "Lana del Rey",
            Description = "Sadness woman..",
            Picture = "/img/group-icon/lana-del-rey.png",
            Genres = new List<Genre> { IndiRock },
            Musics = new List<Music> { BreakingUpSlowly, Chemtrails }
        };
        public static MusicalGroup ImagineDragons = new()
        {
            Id = 2,
            Name = "Imagine Dragons",
            Description = "Imagine.. dragons",
            Picture = "/img/group-icon/imagine-dragons.png",
            Genres = new List<Genre> { IndiRock }
        };
        public static MusicalGroup Slipknot = new()
        {
            Id = 3,
            Name = "Slipknot",
            Description = "Орут",
            Picture = "/img/group-icon/slipknot.jpg",
            Genres = new List<Genre> { Rock }
        };
        public static MusicalGroup MIA = new()
        {
            Id = 4,
            Name = "M.I.A.",
            Description = "Миа",
            Picture = "/img/group-icon/mia.png",
            Genres = new List<Genre> { HipHop },
            Musics = new List<Music> { Borders, GoOff }
        };
    }
}
