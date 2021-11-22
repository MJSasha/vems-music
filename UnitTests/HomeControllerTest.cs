using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using VemsMusic.Controllers;
using VemsMusic.Interfaces;
using VemsMusic.Models;
using VemsMusic.Models.ViewModels;
using Xunit;

namespace UnitTests
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexViewTestWithNonZeroGenres()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            mockGenre.Setup(repo => repo.GetAllGenres).Returns(GetTestGenres());
            mockGroup.Setup(repo => repo.GetMusicalGroups).Returns(GetTestGroups());
            var controller = new HomeController(mockGenre.Object, mockGroup.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GenreViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGenres);
        }
        [Fact]
        public void IndexViewTestWithZeroGenres()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            mockGenre.Setup(repo => repo.GetAllGenres).Returns(GetZeroGenres());
            mockGroup.Setup(repo => repo.GetMusicalGroups).Returns(GetTestGroups());
            var controller = new HomeController(mockGenre.Object, mockGroup.Object);

            var result = controller.Index();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Жанры не добавлены", redirectResult.Url);
        }
        [Fact]
        public void InGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            mockGenre.Setup(repo => repo.GetAllGenres).Returns(GetZeroGenres());
            mockGenre.Setup(repo => repo.GetGenreById(1)).Returns(new Genre { Name = "Рок", Description = "" });
            mockGroup.Setup(repo => repo.GetMusicalGroups).Returns(GetTestGroups());
            var controller = new HomeController(mockGenre.Object, mockGroup.Object);

            var result = controller.InGenre(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GroupsViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGroups);
        }
        [Fact]
        public void InGenreTestWithZeroGenres()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            mockGenre.Setup(repo => repo.GetAllGenres).Returns(GetZeroGenres());
            mockGroup.Setup(repo => repo.GetMusicalGroups).Returns(GetTestGroups());
            var controller = new HomeController(mockGenre.Object, mockGroup.Object);

            var result = controller.InGenre(3);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Группы не добавлены", redirectResult.Url);
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
        private static List<Genre> GetZeroGenres()
        {
            var genres = new List<Genre>();
            return genres;
        }
    }
}
