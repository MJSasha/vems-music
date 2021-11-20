using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
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
            var mock = new Mock<IAllGenre>();
            mock.Setup(repo => repo.GetAllGenres).Returns(GetTestGenres());
            var controller = new HomeController(mock.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Genre>>(viewResult.Model);
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
    }
}
