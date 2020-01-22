using Com.Danliris.Service.Sales.Lib;
using Com.Danliris.Service.Sales.WebApi.Controllers.LocalMerchandiserControllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;
using Xunit;

namespace Com.Danliris.Sales.Test.WebApi.Controllers.LocalMerchandiserControllerTests
{
    public class HOrderControllerTest
    {
        private int GetStatusCode(IActionResult response)
        {
            return (int)response.GetType().GetProperty("StatusCode").GetValue(response, null);
        }

        [Fact]
        public void Get_Success()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Kode", typeof(string));
            dataTable.Rows.Add("KODE");

            Mock<ILocalMerchandiserDbContext> mockDbContext = new Mock<ILocalMerchandiserDbContext>();
            mockDbContext.Setup(s => s.ExecuteReader(It.IsAny<string>(), null))
                .Returns(dataTable.CreateDataReader());

            HOrderController controller = new HOrderController(mockDbContext.Object);

            var response = controller.Read();

            Assert.Equal((int)HttpStatusCode.OK, GetStatusCode(response));
        }

        [Fact]
        public void Get_Error()
        {
            Mock<ILocalMerchandiserDbContext> mockDbContext = new Mock<ILocalMerchandiserDbContext>();

            mockDbContext.Setup(s => s.ExecuteReader(It.IsAny<string>(), null))
                .Throws(new Exception());

            HOrderController controller = new HOrderController(mockDbContext.Object);

            var response = controller.Read();

            Assert.Equal((int)HttpStatusCode.InternalServerError, GetStatusCode(response));
        }
    }
}
