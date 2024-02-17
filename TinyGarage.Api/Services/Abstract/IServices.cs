using TinyGarage.Models;
using TinyGarage.Server.BindingModels;

namespace TinyGarage.Api.Services.Abstract
{
    public interface ICarService : IEntityService<Car>
    {
        void Update(CarBindingModel entity);
        void Create(CarCreateBindingModel entity);
    }

    public interface IModelService : IEntityService<CarModel>
    {
        void Create(CarModelCreateBindingModel entity);
        void Update(CarModelBindingModel entity);
    }

    public interface ICollectionService : IEntityService<ModelCollection>
    {
        void Create(ModelCollectionCreateBindingModel entity);
        void Update(ModelCollectionBindingModel entity);
    }

    public interface IManufacturerService : IEntityService<Manufacturer>
    {
        void Create(ManufacturerCreateBindingModel entity);
        void Update(ManufacturerBindingModel entity);

    }

    public interface IGarageService : IEntityService<Garage>
    {
        void Create(GarageCreateBindingModel entity);
        void Update(GarageBindingModel entity);

    }
}
