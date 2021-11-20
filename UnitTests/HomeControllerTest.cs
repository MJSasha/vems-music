using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using VemsMusic.Controllers;
using VemsMusic.Interfaces;
using VemsMusic.Models;
using Xunit;

namespace UnitTests
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexViewTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            mockGenre.Setup(repo => repo.GetAllGenres).Returns(GetTestGenres());
            mockGroup.Setup(repo => repo.GetMusicalGroups).Returns(GetTestGroups());
            var controller = new HomeController(mockGenre.Object, mockGroup.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Genre>>(viewResult.Model);
            Assert.NotEmpty(model);
        }
        [Fact]
        public void InGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            mockGenre.Setup(repo => repo.GetAllGenres).Returns(GetTestGenres());
            mockGroup.Setup(repo => repo.GetMusicalGroups).Returns(GetTestGroups());
            var controller = new HomeController(mockGenre.Object, mockGroup.Object);

            var result = controller.InGenre("Рок");

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<MusicalGroup>>(viewResult.Model);
            Assert.NotEmpty(model);
        }

        private List<Genre> GetTestGenres()
        {
            var genres = new List<Genre>()
            {
                new Genre{Name ="Кулибяка", Description="Кулибячит", PicturePath=""},
                new Genre{Name ="Запевака", Description="Поет", PicturePath=""},
                new Genre{Name ="Танцевака", Description="Танцует", PicturePath=""}
            };
            return genres;
        }
        private List<MusicalGroup> GetTestGroups()
        {
            var groups = new List<MusicalGroup>()
            {
                new MusicalGroup
                    {
                        Name = "Анархисты",
                        Description = "Анархируют",
                        Picture = "",
                        GenreName = "Рок"
                    },
                new MusicalGroup
                    {
                        Name = "Анархисты",
                        Description = "Анархируют",
                        Picture = "",
                        GenreName = "Рок"
                    },
                new MusicalGroup
                    {
                        Name = "Анархисты",
                        Description = "Анархируют",
                        Picture = "",
                        GenreName = "Не рок"
                    }
            };
            return groups;
        }
    }
}
