using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VemsMusic.Controllers;
using VemsMusic.Interfaces;
using VemsMusic.Models;
using VemsMusic.Other_Data.Interfaces;
using VemsMusic.Other_Data.ViewModels;
using Xunit;

namespace UnitTests
{
    public class ExecutorControllerTest
    {
        [Fact]
        public async void IndexTestAsync()
        {
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGroup.Setup(repo => repo.GetMusicalGroupByIdAsync(1)).ReturnsAsync(GetTestGroup());
            mockMusics.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(GetTestMusics());
            var controller = new ExecutorController(mockGroup.Object, mockMusics.Object);

            var result = await controller.Index(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GroupWithMusicsViewModel>(viewResult.Model);
            Assert.NotEmpty(model.GetAllMusic);
            Assert.NotNull(model.MusicalGroup);
        }
        [Fact]
        public async void IndexTestWithZeroMusicAsync()
        {
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGroup.Setup(repo => repo.GetMusicalGroupByIdAsync(1)).ReturnsAsync(GetTestGroup());
            mockMusics.Setup(repo => repo.GetAllMusicAsync()).ReturnsAsync(GetZeroMusic());
            var controller = new ExecutorController(mockGroup.Object, mockMusics.Object);

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
                GenreId = 1
            };
        }
        private static List<Music> GetTestMusics()
        {
            return new List<Music>()
            {
                new Music
                {
                    Name = "Песенка",
                    AudioPath = "",
                    GroupId = 1,
                    ImagePath = "",
                    Text = "Поется",
                },
                new Music
                {
                    Name = "Рокинка",
                    AudioPath = "",
                    GroupId = 1,
                    ImagePath = "",
                    Text = "Поется",
                },
                new Music
                {
                    Name = "Трип",
                    AudioPath = "",
                    GroupId = 1,
                    ImagePath = "",
                    Text = "Поется",
                }
            };
        }
        private static List<Music> GetZeroMusic()
        {
            var music = new List<Music>();
            return music;
        }
    }
}
