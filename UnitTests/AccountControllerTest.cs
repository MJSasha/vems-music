using Microsoft.AspNetCore.Mvc;
using Moq;
using VemsMusic.Controllers;
using VemsMusic.Models;
using VemsMusic.Models.ViewModels;
using VemsMusic.Other_Data.Interfaces;
using VemsMusic.Other_Data.PersonalExceptions;
using VemsMusic.Other_Data.ViewModels;
using Xunit;

namespace UnitTests
{
    public class AccountControllerTest
    {
        Mock<IAllUsers> MockUser = new();
        RegisterViewModel registerModel = new RegisterViewModel
        {
            ConfirmPassword = "111",
            Email = "som@gmail.com",
            Password = "111"
        };
        User user = new User
        {
            Email = "som@gmail.com",
            Password = "111",
            RoleId = 1
        };

        [Fact]
        public async void RegisterValidTest()
        {
            MockUser.Setup(repo => repo.GetUserByRegistraterModelAsync(registerModel)).
                ReturnsAsync(user);
            var controller = new AccountController(MockUser.Object);

            var result = await controller.Register(registerModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<RegisterViewModel>(viewResult.Model);
            Assert.NotEmpty(model.Email);
        }

        //TODO - Add tests for the AccountController
    }
}
