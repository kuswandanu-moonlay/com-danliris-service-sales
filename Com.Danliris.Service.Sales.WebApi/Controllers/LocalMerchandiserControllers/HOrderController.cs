using Com.Danliris.Service.Sales.Lib.Models.LocalMerchandiserModels;
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
        private readonly LocalMerchandiserDbContext dbContext;

        public HOrderController(LocalMerchandiserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Read(string no = null) // 1911790
        {
            try
            {
                var query = dbContext.Horder;
                var data = query.Where(w => w.No == no)
                    .Select(s => s.Kode);
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(Common.INTERNAL_ERROR_STATUS_CODE, e.Message);
            }
        }
    }
}
