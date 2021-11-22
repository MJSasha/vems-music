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

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("NoGenres", redirectResult.ActionName);
        }
        [Fact]
        public void InGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            mockGenre.Setup(repo => repo.GetAllGenres).Returns(GetTestGenres());
            mockGroup.Setup(repo => repo.GetMusicalGroups).Returns(GetTestGroups());
            var controller = new HomeController(mockGenre.Object, mockGroup.Object);

            var result = controller.InGenre(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GroupsViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGroups);
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
