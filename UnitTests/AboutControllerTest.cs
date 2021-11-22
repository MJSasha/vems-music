using Microsoft.AspNetCore.Mvc;
using Moq;
using VemsMusic.Controllers;
using VemsMusic.Interfaces;
using VemsMusic.Models;
using Xunit;


namespace UnitTests
{
    public class AboutControllerTest
    {
        [Fact]
        public void IndexTest()
        {
            AboutController controller = new AboutController();

            ViewResult viewResult = controller.Index() as ViewResult;

            Assert.IsType<ViewResult>(viewResult);
        }
    }
}
