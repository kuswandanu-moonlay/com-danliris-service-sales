using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Danliris.Service.Sales.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/api/Default")]
    public class DefaultController : Controller
    {
        protected readonly IMapper Mapper;

        public DefaultController(IMapper mapper)
        {
            Mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            DefaultModel defaultModel = new DefaultModel
            {
                Code = "Code"
            };

            DefaultViewModel defaultViewModel = new DefaultViewModel
            {
                Code = "Code",
                Quantity = 1
            };

            //var viewModel = Mapper.Map<DefaultViewModel>(defaultModel);
            //var model = Mapper.Map<DefaultModel>(defaultViewModel);

            //return Ok(new { model, viewModel });

            var mc = new MapperConfiguration(c => c.CreateMap<DefaultModel, DefaultViewModel>());
            var mapper = mc.CreateMapper();
            var model = Mapper.Map<DefaultModel>(defaultViewModel);
            var viewModel = Mapper.Map<DefaultViewModel>(defaultModel);

            return Ok(new { model, viewModel });
        }
    }

    public class DefaultMapper : Profile
    {
        public DefaultMapper()
        {
            CreateMap<DefaultModel, DefaultViewModel>()
                .ReverseMap();
        }
    }

    public class DefaultModel
    {
        public string Code { get; set; }
    }

    public class DefaultViewModel
    {
        public string Code { get; set; }
        public int? Quantity { get; set; }
    }
}