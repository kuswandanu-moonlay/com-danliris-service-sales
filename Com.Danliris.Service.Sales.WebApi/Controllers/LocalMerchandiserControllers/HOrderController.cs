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

        public HOrderController()
        {
        }

        [HttpGet]
        public IActionResult Read(string no = null)
        {
            try
            {
                string connectionString = "Server=tcp:175.106.17.18,5671;Initial Catalog=Merchandiser;Persist Security Info=False;User ID=sa;Password=AdminDL-dev-123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
                List<string> data = new List<string>();

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string query = $"select Kode from HOrder where No='{no}'";

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                data.Add(reader.GetString(0));
                            }

                            return Ok(data);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(Common.INTERNAL_ERROR_STATUS_CODE, e.Message);
            }
        }
    }
}
