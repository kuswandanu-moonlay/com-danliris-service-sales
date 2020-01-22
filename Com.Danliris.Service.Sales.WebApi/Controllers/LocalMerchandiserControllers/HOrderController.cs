using Com.Danliris.Service.Sales.Lib;
using Com.Danliris.Service.Sales.WebApi.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Sales.WebApi.Controllers.LocalMerchandiserControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/horders")]
    //[Authorize]
    public class HOrderController : Controller
    {
        private readonly static string apiVersion = "1.0";
        private readonly ILocalMerchandiserDbContext dbContext;

        public HOrderController(ILocalMerchandiserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("kode-by-no")]
        public IActionResult Read(string no = null)
        {
            try
            {
                var reader = dbContext.ExecuteReader($"select Kode from HOrder where No='{no}'", null);
                List<string> data = new List<string>();
                while (reader.Read())
                {
                    data.Add(reader.GetString(0));
                }
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(Common.INTERNAL_ERROR_STATUS_CODE, e.Message);
            }
        }
    }
}
