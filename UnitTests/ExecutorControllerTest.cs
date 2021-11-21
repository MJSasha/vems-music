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
        [Fact]
        public void InGenreTest()
        {
            var mockGroup = new Mock<IAllGroups>();
            mockGroup.Setup(repo => repo.GetMusicalGroupById(1)).Returns(GetTestGroup());
            var controller = new ExecutorController(mockGroup.Object);

            var result = controller.Index(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<MusicalGroup>(viewResult.Model);
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
    }
}
