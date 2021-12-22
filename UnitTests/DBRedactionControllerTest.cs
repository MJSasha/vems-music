using Microsoft.AspNetCore.Mvc;
using Moq;
using VemsMusic.Controllers;
using VemsMusic.Interfaces;
using VemsMusic.Models.ViewModels;
using VemsMusic.Other_Data.Interfaces;
using VemsMusic.Other_Data.ViewModels;
using Xunit;

namespace UnitTests
{
    public class DBRedactionControllerTest
    {
        [Fact]
        public async void AllGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGenre.Setup(repo => repo.GetAllGenresAsync()).ReturnsAsync(TestData.GetTestGenres);
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AllGenre();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GenreViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGenres);
        }
        [Fact]
        public async void AllGroupTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGroup.Setup(repo => repo.GetMusicalGroupsAsync()).ReturnsAsync(TestData.GetTestGroups);
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AllGroup();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GroupsViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllGroups);
        }
        [Fact]
        public async void AllMusicTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockMusics.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(TestData.GetTestMusics);
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AllMusic();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MusicViewModel>(viewResult.Model);
            Assert.NotEmpty(model.AllMusic);
        }

        [Fact]
        public async void AllGenreTestWithZeroGenre()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGenre.Setup(repo => repo.GetAllGenresAsync()).ReturnsAsync(TestData.GetZeroGenres);
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AllGenre();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Жанры не добавлены", redirectResult.Url);
        }
        [Fact]
        public async void AllGroupTestWithZeroGroup()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGroup.Setup(repo => repo.GetMusicalGroupsAsync()).ReturnsAsync(TestData.GetZeroGroup);
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AllGroup();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Группы не добавлены", redirectResult.Url);
        }
        [Fact]
        public async void AllMusicTestWithZeroMusic()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockMusics.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(TestData.GetZeroMusic);
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AllMusic();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Музыка не добавлена", redirectResult.Url);
        }

        [Fact]
        public async void AddGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AddGenre(TestData.Rock);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGenre", redirectResult.Url);
        }
        [Fact]
        public async void AddGroupTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AddGroup(TestData.Slipknot);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGroup", redirectResult.Url);
        }
        [Fact]
        public async void AddMusicTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.AddMusic(TestData.Borders);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllMusic", redirectResult.Url);
        }

        [Fact]
        public async void DeleteGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.DeleteGenre(1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGenre", redirectResult.Url);
        }
        [Fact]
        public async void DeleteGroupTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.DeleteGroup(1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGroup", redirectResult.Url);
        }
        [Fact]
        public async void DeleteMusicTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.DeleteMusic(1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllMusic", redirectResult.Url);
        }

        [Fact]
        public async void RedactGenresTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.RedactGenres(TestData.HipHop, 1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGenre", redirectResult.Url);
        }
        [Fact]
        public async void RedactGroupsTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.RedactGroups(TestData.LanaDeRey, 1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGroup", redirectResult.Url);
        }
        [Fact]
        public async void RedactMusicsTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.RedactMusics(TestData.BreakingUpSlowly, 1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllMusic", redirectResult.Url);
        }

        [Fact]
        public async void DeleteGroupsGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.DeleteGroupsGenre(1, 1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllGroup", redirectResult.Url);
        }
        [Fact]
        public async void DeleteMusicsGenreTest()
        {
            var mockGenre = new Mock<IAllGenre>();
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            var controller = new DBRedactionController(mockGenre.Object, mockGroup.Object, mockMusics.Object);

            var result = await controller.DeleteMusicsGenre(1, 1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/DBRedaction/AllMusic", redirectResult.Url);
        }
    }
}
