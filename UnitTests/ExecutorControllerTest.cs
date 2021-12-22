using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VemsMusic.Controllers;
using VemsMusic.Interfaces;
using VemsMusic.Models;
using Xunit;

namespace UnitTests
{
    public class ExecutorControllerTest
    {
        //TODO The test doesn't work. Problems getting id value from cookies
        [Fact]
        public async void IndexTestAsync()
        {
            var mockGroup = new Mock<IAllGroups>();
            var mockHttpContex = new Mock<HttpContext>();
            mockHttpContex.Setup(repo => repo.Request.Cookies["id"]).Returns("1");
            mockGroup.Setup(repo => repo.GetMusicalGroupByIdAsync(1)).ReturnsAsync(TestData.LanaDeRey);
            var controller = new ExecutorController(mockGroup.Object);

            var result = await controller.Index(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MusicalGroup>(viewResult.Model);
            Assert.NotEmpty(model.Musics);
            Assert.NotNull(model);
        }
        //TODO The test doesn't work. Problems getting id value from cookies
        [Fact]
        public async void IndexTestWithZeroMusicAsync()
        {
            var mockGroup = new Mock<IAllGroups>();
            var mockHttpContex = new Mock<HttpContext>();
            mockHttpContex.Setup(repo => repo.Request.Cookies["id"]).Returns("1");
            mockGroup.Setup(repo => repo.GetMusicalGroupByIdAsync(1)).ReturnsAsync(TestData.ImagineDragons);
            var controller = new ExecutorController(mockGroup.Object);

            var result = await controller.Index(2);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Музыка не добавлена", redirectResult.Url);
        }
    }
}
