using Microsoft.AspNetCore.Mvc;
using VemsMusic.Controllers;
using Xunit;


namespace UnitTests
{
    public class AboutControllerTest
    {
        [Fact]
        public void IndexTest()
        {
            AboutController controller = new AboutController();

            ViewResult viewResult = controller.Index();

            Assert.IsType<ViewResult>(viewResult);
        }
    }
}
