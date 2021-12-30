using Microsoft.AspNetCore.Mvc;
using Moq;
using VemsMusic.Controllers;
using VemsMusic.Interfaces;
using VemsMusic.Models;
using VemsMusic.Models.ViewModels;
using VemsMusic.Other_Data.Interfaces;
using VemsMusic.Other_Data.ViewModels;
using Xunit;

namespace UnitTests
{
    public class HomeControllerTest
    {
        Mock<IAllGenre> mockGenre = new();
        Mock<IAllGroups> mockGroup = new();
        Mock<IAllMusic> mockMusic = new();

        [Fact]
        public async void IndexViewTestWithNonZeroGenres()
        {
            mockGenre.Setup(repo => repo.GetAllGenresAsync()).ReturnsAsync(TestData.GetTestGenres);
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GenreViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGenres);
        }
        [Fact]
        public async void IndexViewTestWithZeroGenres()
        {
            mockGenre.Setup(repo => repo.GetAllGenresAsync()).ReturnsAsync(TestData.GetZeroGenres);
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.Index();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Жанры не добавлены", redirectResult.Url);
        }

        [Fact]
        public async void NewMusicTest()
        {
            mockMusic.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(TestData.GetTestMusics);
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.NewMusic();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MusicViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllMusic);
        }
        [Fact]
        public async void NewMusicTestWithZeroMusic()
        {
            mockMusic.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(TestData.GetZeroMusic);
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.NewMusic();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Музыка не добавлена", redirectResult.Url);
        }

        [Fact]
        public async void InGenreTest()
        {
            mockGenre.Setup(repo => repo.GetGenreByIdAsync(1)).ReturnsAsync(TestData.HipHop);
            mockGroup.Setup(repo => repo.GetAllMusicalGroupsAsync()).ReturnsAsync(TestData.GetTestGroups);
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.InGenre(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GroupsViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGroups);
        }
        [Fact]
        public async void InGenreTestWithZeroGenresAsync()
        {
            mockGenre.Setup(repo => repo.GetGenreByIdAsync(1)).ReturnsAsync(new Genre
            {
                Name = "Рок",
                Description = ""
            });
            mockGroup.Setup(repo => repo.GetAllMusicalGroupsAsync()).ReturnsAsync(TestData.GetZeroGroup);
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.InGenre(3);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Группы не добавлены", redirectResult.Url);
        }

        [Fact]
        public async void ExecutorsTest()
        {
            mockGroup.Setup(repo => repo.GetAllMusicalGroupsAsync()).ReturnsAsync(TestData.GetTestGroups);
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.Executors();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GroupsViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGroups);
        }

        [Fact]
        public async void AllMusicTest()
        {
            mockMusic.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(TestData.GetTestMusics);
            var controller = new HomeController(mockGenre.Object, mockGroup.Object, mockMusic.Object);

            var result = await controller.AllMusic();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MusicViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllMusic);
        }
    }
}
