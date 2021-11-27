using Microsoft.AspNetCore.Mvc;
using Moq;
using VemsMusic.Controllers;
using VemsMusic.Models;
using VemsMusic.Other_Data.Interfaces;
using VemsMusic.Other_Data.ViewModels;
using Xunit;

namespace UnitTests
{
    public class UserControllerTest
    {
        [Fact]
        public void MyMusicTest()
        {
            var mockMusics = new Mock<IAllMusic>();
            mockMusics.Setup(repo => repo.GetMusicsById(1)).Returns(new Music { Name = "lalala" });
            var mockUser = new Mock<IAllUsers>();
            mockUser.Setup(repo => repo.GetUserByEmail("ss")).Returns(new User { Email = "ss" });
            var controller = new UserController(mockMusics.Object, mockUser.Object);

            var result = controller.MyMusic();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MusicViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllMusic);
        }
    }
}
