using AutoMapper;
using Com.Danliris.Service.Sales.Lib.ViewModels.CostCalculationGarment;
using Com.Danliris.Service.Sales.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Sales.Test.AutoMapper
{
    public class Class1
    {
        [Fact]
        public void CostCalculationGarmentMappers_Model_To_ViewModel()
        {
            var config = new MapperConfiguration(c => c.AddProfile<DefaultMapper>());
            var mapper = config.CreateMapper();

            var viewModel = mapper.Map<DefaultViewModel>(new DefaultModel());
            Assert.NotNull(viewModel);
        }

        [Fact]
        public void CostCalculationGarmentMappers_ViewModel_To_Model()
        {
            var config = new MapperConfiguration(c => c.AddProfile<DefaultMapper>());
            var mapper = config.CreateMapper();

            var model = mapper.Map<DefaultModel>(new DefaultViewModel());
            Assert.NotNull(model);
        }
    }
}
