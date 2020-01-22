using Com.Danliris.Service.Sales.WebApi.Controllers.LocalMerchandiserControllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Sales.Test.WebApi.Controllers.LocalMerchandiserControllerTests
{
    public class HOrderControllerTest
    {
        [Fact]
        public void Get_Success()
        {
            HOrderController controller = new HOrderController();
            var result = controller.Read("");
            Assert.NotNull(result);
        }
    }
}
