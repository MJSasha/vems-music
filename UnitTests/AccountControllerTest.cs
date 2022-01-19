using Microsoft.AspNetCore.Mvc;
using Moq;
using VemsMusic.Controllers;
using VemsMusic.Other_Data.Interfaces;
using VemsMusic.Other_Data.ViewModels;
using Xunit;

namespace UnitTests
{
    public class AccountControllerTest
    {
        Mock<IAllUsers> MockUser = new();
        RegisterViewModel registerModel = new RegisterViewModel { Email = "sasha@gmail.com" };

        [Fact]
        public async void RegisterTestWithObjectInDatabase()
        {
            MockUser.Setup(repo => repo.UserIsInDatabase(registerModel)).
                ReturnsAsync(true);
            var controller = new AccountController(MockUser.Object);

            var result = await controller.Register(registerModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<RegisterViewModel>(viewResult.Model);
            Assert.NotEmpty(model.Email);
        }

        //TODO - Add tests for the AccountController
    }
}
