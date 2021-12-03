using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using VemsMusic.Controllers;
using VemsMusic.Interfaces;
using VemsMusic.Models;
using VemsMusic.Models.ViewModels;
using VemsMusic.Other_Data.Interfaces;
using VemsMusic.Other_Data.ViewModels;
using Xunit;

namespace UnitTests
{
    public class HomeControllerTest
    {
        [Fact]
        public async void IndexViewTestWithNonZeroGenres()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusic = new Mock<IAllMusic>();
            mockGenre.Setup(repo => repo.GetAllGenresAsync()).ReturnsAsync(GetTestGenres());
            mockGroup.Setup(repo => repo.GetMusicalGroupsAsync()).ReturnsAsync(GetTestGroups());
            mockMusic.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(GetTestMusics());
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GenreViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGenres);
        }
        [Fact]
        public async void IndexViewTestWithZeroGenres()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusic = new Mock<IAllMusic>();
            mockGenre.Setup(repo => repo.GetAllGenresAsync()).ReturnsAsync(GetZeroGenres());
            mockGroup.Setup(repo => repo.GetMusicalGroupsAsync()).ReturnsAsync(GetTestGroups());
            mockMusic.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(GetTestMusics());
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.Index();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Жанры не добавлены", redirectResult.Url);
        }
        [Fact]
        public async void InGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusic = new Mock<IAllMusic>();
            mockGenre.Setup(repo => repo.GetAllGenresAsync()).ReturnsAsync(GetZeroGenres());
            mockGenre.Setup(repo => repo.GetGenreByIdAsync(1)).ReturnsAsync(new Genre
            {
                Id = 1,
                Name = "Рок",
                Description = ""
            });
            mockGroup.Setup(repo => repo.GetMusicalGroupsAsync()).ReturnsAsync(GetTestGroups());
            mockMusic.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(GetTestMusics);
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.InGenre(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GroupsViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGroups);
        }
        [Fact]
        public async void InGenreTestWithZeroGenresAsync()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusic = new Mock<IAllMusic>();
            mockGenre.Setup(repo => repo.GetGenreByIdAsync(1)).ReturnsAsync(new Genre
            {
                Name = "Рок",
                Description = ""
            });
            mockGroup.Setup(repo => repo.GetMusicalGroupsAsync()).ReturnsAsync(GetZeroGroup());
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.InGenre(3);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Группы не добавлены", redirectResult.Url);
        }
        [Fact]
        public async void ExecutorsTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusic = new Mock<IAllMusic>();
            mockGenre.Setup(repo => repo.GetAllGenresAsync()).ReturnsAsync(GetTestGenres());
            mockGroup.Setup(repo => repo.GetMusicalGroupsAsync()).ReturnsAsync(GetTestGroups());
            mockMusic.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(GetTestMusics());
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.Executors();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GroupsViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGroups);
        }
        [Fact]
        public async void AllMusicTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusic = new Mock<IAllMusic>();
            mockGenre.Setup(repo => repo.GetAllGenresAsync()).ReturnsAsync(GetTestGenres());
            mockGroup.Setup(repo => repo.GetMusicalGroupsAsync()).ReturnsAsync(GetTestGroups());
            mockMusic.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(GetTestMusics());
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.AllMusic();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MusicViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllMusic);
        }

        private static List<Genre> GetTestGenres()
        {
            var genres = new List<Genre>()
            {
                new Genre{Name ="Кулибяка", Description="Кулибячит", PicturePath=""},
                new Genre{Name ="Запевака", Description="Поет", PicturePath=""},
                new Genre{Name ="Танцевака", Description="Танцует", PicturePath=""}
            };
            return genres;
        }
        private static List<MusicalGroup> GetTestGroups()
        {
            var groups = new List<MusicalGroup>()
            {
                new MusicalGroup
                    {
                        Name = "Анархисты",
                        Description = "Анархируют",
                        Picture = "",
                        Genres = new List<Genre>{ new Genre{Id =1, Name = "Рок",Description = ""}}
                    },
                new MusicalGroup
                    {
                        Name = "Анархисты",
                        Description = "Анархируют",
                        Picture = "",
                        GenreId = 2
                    },
                new MusicalGroup
                    {
                        Name = "Анархисты",
                        Description = "Анархируют",
                        Picture = "",
                        GenreId = 1
                    }
            };
            return groups;
        }
        private static List<MusicalGroup> GetZeroGroup()
        {
            var group = new List<MusicalGroup>();
            return group;
        }
        private static List<Genre> GetZeroGenres()
        {
            var genres = new List<Genre>();
            return genres;
        }
        private static List<Music> GetTestMusics()
        {
            return new List<Music>()
            {
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
                }
            };
        }
    }
}
