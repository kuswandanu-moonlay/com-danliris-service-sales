using AutoMapper;
using Com.Danliris.Service.Sales.Lib.AutoMapperProfiles.CostCalculationGarmentProfiles;
using Com.Danliris.Service.Sales.Lib.Models.CostCalculationGarments;
using Com.Danliris.Service.Sales.Lib.ViewModels.CostCalculationGarment;
using Xunit;

namespace Com.Danliris.Sales.Test.AutoMapper.Garment.GarmentMerchandiser
{
    public class CostCalculationGarment
    {
        [Fact]
        public void CostCalculationGarmentMapper()
        {
            Mapper.Initialize(i => i.AddProfile<CostCalculationGarmentMapper>());
            Mapper.AssertConfigurationIsValid();
        }

        [Fact]
        public void CostCalculationGarmentMappers_Model_To_ViewModel()
        {
            var config = new MapperConfiguration(c => c.AddProfile<CostCalculationGarmentMapper>());
            var mapper = config.CreateMapper();

            var viewModel = mapper.Map<CostCalculationGarmentViewModel>(new CostCalculationGarment());
            Assert.NotNull(viewModel);
        }

        [Fact]
        public void CostCalculationGarmentMappers_ViewModel_To_Model()
        {
            var config = new MapperConfiguration(c => c.AddProfile<CostCalculationGarmentMapper>());
            var mapper = config.CreateMapper();

            var model = mapper.Map<CostCalculationGarment>(new CostCalculationGarmentViewModel()); 
            Assert.NotNull(model);
        }

        [Fact]
        public void CostCalculationGarmentMaterialMapper()
        {
            Mapper.Initialize(i => i.AddProfile<CostCalculationGarmentMaterialMapper>());
            Mapper.AssertConfigurationIsValid();
        }

        [Fact]
        public void CostCalculationGarmentMaterialMappers()
        {
            var config = new MapperConfiguration(c => c.AddProfile<CostCalculationGarmentMaterialMapper>());
            var mapper = config.CreateMapper();

            var viewModel = mapper.Map<CostCalculationGarment_MaterialViewModel>(new CostCalculationGarment_Material());
            Assert.NotNull(viewModel);

            var model = mapper.Map<CostCalculationGarment_Material>(new CostCalculationGarment_MaterialViewModel());
            Assert.NotNull(model);
        }
    }
}
