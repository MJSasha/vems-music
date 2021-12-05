using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using VemsMusic.Controllers;
using VemsMusic.Interfaces;
using VemsMusic.Models;
using VemsMusic.Other_Data.Interfaces;
using Xunit;

namespace UnitTests
{
    public class ExecutorControllerTest
    {
        [Fact]
        public async void IndexTestAsync()
        {
            var mockGroup = new Mock<IAllGroups>();
            mockGroup.Setup(repo => repo.GetMusicalGroupByIdAsync(1)).ReturnsAsync(GetTestGroup());
            var controller = new ExecutorController(mockGroup.Object);

            var result = await controller.Index(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MusicalGroup>(viewResult.Model);
            Assert.NotEmpty(model.Musics);
            Assert.NotNull(model);
        }
        [Fact]
        public async void IndexTestWithZeroMusicAsync()
        {
            var mockGroup = new Mock<IAllGroups>();
            mockGroup.Setup(repo => repo.GetMusicalGroupByIdAsync(1)).ReturnsAsync(GetTestGroupWithZeroMusic());
            var controller = new ExecutorController(mockGroup.Object);

            var result = await controller.Index(1);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("~/Home/NoItems/Музыка не добавлена", redirectResult.Url);
        }

        private static MusicalGroup GetTestGroup()
        {
            return new MusicalGroup
            {
                Id = 1,
                Name = "Анархисты",
                Description = "Анархируют",
                Picture = "",
                GenreId = 1,
                Musics = new List<Music> { new Music { Name = "lalala" } }
            };
        }
        private static MusicalGroup GetTestGroupWithZeroMusic()
        {
            return new MusicalGroup
            {
                Id = 1,
                Name = "Анархисты",
                Description = "Анархируют",
                Picture = "",
                GenreId = 1
            };
        }
    }
}
