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
    public class DBRedactionControllerTest
    {
        [Fact]
        public async void AllGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGenre.Setup(repo => repo.GetAllGenresAsync()).ReturnsAsync(GetTestGenres());
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AllGenre();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GenreViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGenres);
        }
        [Fact]
        public async void AllGroupTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGroup.Setup(repo => repo.GetMusicalGroupsAsync()).ReturnsAsync(GetTestGroups());
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AllGroup();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GroupsViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGroups);
        }
        [Fact]
        public async void AllMusicTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockMusics.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(GetTestMusics());
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AllMusic();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MusicViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllMusic);
        }

        [Fact]
        public async void AllGenreTestWithZeroGenre()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGenre.Setup(repo => repo.GetAllGenresAsync()).ReturnsAsync(GetZeroGenres());
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AllGenre();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Жанры не добавлены", redirectResult.Url);
        }
        [Fact]
        public async void AllGroupTestWithZeroGroup()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGroup.Setup(repo => repo.GetMusicalGroupsAsync()).ReturnsAsync(GetZeroGroup());
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AllGroup();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Группы не добавлены", redirectResult.Url);
        }
        [Fact]
        public async void AllMusicTestWithZeroMusic()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockMusics.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(GetZeroMusic());
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AllMusic();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Музыка не добавлена", redirectResult.Url);
        }

        [Fact]
        public async void AddGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AddGenre(new Genre { Name = "Рок", Description = "Анархия" });

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGenre", redirectResult.Url);
        }
        [Fact]
        public async void AddGroupTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AddGroup(new MusicalGroup { Name = "Рокеры", Description = "Рочат" });

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGroup", redirectResult.Url);
        }
        [Fact]
        public async void AddMusicTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AddMusic(new Music { Name = "ТуцТуц", GroupId = 1 });

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllMusic", redirectResult.Url);
        }

        [Fact]
        public async void DeleteGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.DeleteGenre(1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGenre", redirectResult.Url);
        }
        [Fact]
        public async void DeleteGroupTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.DeleteGroup(1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGroup", redirectResult.Url);
        }
        [Fact]
        public async void DeleteMusicTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.DeleteMusic(1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllMusic", redirectResult.Url);
        }

        [Fact]
        public async void RedactGenresTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.RedactGenres(new Genre { Name = "Рок", Description = "Анархия" }, 1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGenre", redirectResult.Url);
        }
        [Fact]
        public async void RedactGroupsTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.RedactGroups(new MusicalGroup { Name = "Рокеры", Description = "Рочат" }, 1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGroup", redirectResult.Url);
        }
        [Fact]
        public async void RedactMusicsTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.RedactMusics(new Music { Name = "ТуцТуц", GroupId = 1 }, 1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllMusic", redirectResult.Url);
        }

        [Fact]
        public async void DeleteGroupsGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.DeleteGroupsGenre(1, 1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGroup", redirectResult.Url);
        }
        [Fact]
        public async void DeleteMusicsGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.DeleteMusicsGenre(1, 1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllMusic", redirectResult.Url);
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
        private static List<Genre> GetZeroGenres()
        {
            var genres = new List<Genre>();
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
                        GenreId = 1
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
        private static MusicalGroup GetTestGroup()
        {
            return new MusicalGroup
            {
                Id = 1,
                Name = "Анархисты",
                Description = "Анархируют",
                Picture = "",
                GenreId = 1
            };
        }
        private static List<MusicalGroup> GetZeroGroup()
        {
            var group = new List<MusicalGroup>();
            return group;
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
        private static List<Music> GetZeroMusic()
        {
            var music = new List<Music>();
            return music;
        }
    }
}
