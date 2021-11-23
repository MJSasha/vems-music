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
        public void AllGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGenre.Setup(repo => repo.GetAllGenres).Returns(GetTestGenres());
            mockGroup.Setup(repo => repo.GetMusicalGroupById(1)).Returns(GetTestGroup());
            mockMusics.Setup(repo => repo.GetAllMusic).Returns(GetTestMusics());
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = controller.AllGenre();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GenreViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGenres);
        }
        [Fact]
        public void AllGroupTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGenre.Setup(repo => repo.GetAllGenres).Returns(GetTestGenres());
            mockGroup.Setup(repo => repo.GetMusicalGroups).Returns(GetTestGroups());
            mockGroup.Setup(repo => repo.GetMusicalGroupById(1)).Returns(GetTestGroup());
            mockMusics.Setup(repo => repo.GetAllMusic).Returns(GetTestMusics());
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = controller.AllGroup();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GroupsViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGroups);
        }
        [Fact]
        public void AllMusicTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGenre.Setup(repo => repo.GetAllGenres).Returns(GetTestGenres());
            mockGroup.Setup(repo => repo.GetMusicalGroupById(1)).Returns(GetTestGroup());
            mockMusics.Setup(repo => repo.GetAllMusic).Returns(GetTestMusics());
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = controller.AllMusic();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MusicViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllMusic);
        }

        [Fact]
        public void AddGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = controller.AddGenre(new Genre { Name="Рок", Description="Анархия"});

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGenre", redirectResult.Url);
        }
        [Fact]
        public void AddGroupTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = controller.AddGroup(new MusicalGroup { Name="Рокеры",Description="Рочат"});

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGroup", redirectResult.Url);
        }
        [Fact]
        public void AddMusicTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = controller.AddMusic(new Music { Name = "ТуцТуц", GroupId = 1 });

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllMusic", redirectResult.Url);
        }

        [Fact]
        public void DeleteGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = controller.DeleteGenre(new Genre { Name = "Рок", Description = "Анархия" });

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AddGenre", redirectResult.Url);
        }
        [Fact]
        public void DeleteGroupTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = controller.DeleteGroup(new MusicalGroup { Name = "Рокеры", Description = "Рочат" });

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AddGroup", redirectResult.Url);
        }
        [Fact]
        public void DeleteMusicTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = controller.DeleteMusic(new Music { Name = "ТуцТуц", GroupId = 1 });

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AddMusic", redirectResult.Url);
        }

        [Fact]
        public void RedactGenresTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = controller.RedactGenres(new Genre { Name = "Рок", Description = "Анархия" });

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGenre", redirectResult.Url);
        }
        [Fact]
        public void RedactGroupsTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = controller.RedactGroups(new MusicalGroup { Name = "Рокеры", Description = "Рочат" });

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGroup", redirectResult.Url);
        }
        [Fact]
        public void RedactMusicsTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = controller.RedactMusics(new Music { Name = "ТуцТуц", GroupId = 1 });

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
