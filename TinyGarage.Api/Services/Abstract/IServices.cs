using TinyGarage.Models;
using TinyGarage.Server.BindingModels;

namespace TinyGarage.Api.Services.Abstract
{
    public interface ICarService : IEntityService<Car>
    {
        Task<Guid?> Create(CarCreateBindingModel entity);
        Task<Guid?> Update(Car entity);
    }

    public interface IModelService : IEntityService<CarModel>
    {
        Task<Guid?> Create(CarModelCreateBindingModel entity);
        Task<Guid?> Update(CarModel entity);
    }

    public interface ICollectionService : IEntityService<ModelCollection>
    {
        Task<Guid?> Create(ModelCollectionCreateBindingModel entity);
        Task<Guid?> Update(ModelCollection entity);
    }

    public interface IManufacturerService : IEntityService<Manufacturer>
    {
        Task<Guid?> Create(ManufacturerCreateBindingModel entity);
        Task<Guid?> Update(Manufacturer entity);

    }

    public interface IGarageService : IEntityService<Garage>
    {
        Task<Guid?> Create(GarageCreateBindingModel entity);
        Task<Guid?> Update(Garage entity);

    }
}
