using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
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
        public void InGenreTest()
        {
            var mockGroup = new Mock<IAllGroups>();
            var mockMusics = new Mock<IAllMusic>();
            mockGroup.Setup(repo => repo.GetMusicalGroupById(1)).Returns(GetTestGroup());
            mockMusics.Setup(repo => repo.GetAllMusic).Returns(GetTestMusics());
            var controller = new ExecutorController(mockGroup.Object, mockMusics.Object);

            var result = controller.Index(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<GroupWithMusicsViewModel>(viewResult.Model);
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
    }
}
