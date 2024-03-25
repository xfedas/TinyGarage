using TinyGarage.Api.Services.Abstract;
using TinyGarage.Models;
using TinyGarage.Repositories.Abstract;
using TinyGarage.Server.BindingModels;

namespace TinyGarage.Api.Services
{
    public class CarService(IDataRepository repository, IHttpContextAccessor httpContextAccessor) : EntityService<Car>(repository, httpContextAccessor), ICarService
    {
        public async Task<Guid?> Create(CarCreateBindingModel model)
        {
            Car entity = new Car()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                CarModel = await _repository.Get<CarModel>(Guid.Parse(model.CarModelId)),
                Garage = await _repository.Get<Garage>(Guid.Parse(model.GarageId)),
                Notes = model.Notes,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Owner = null,
                CreatedBy = null
            };

            try
            {
                await _repository.Create(entity);
                return entity.Id;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public async Task<Guid?> Update(Car model)
        {
            var entity = await _repository.Get<Car>(model.Id);

            if (entity != null)
            {
                entity.Name = model.Name;
                entity.CarModel = await _repository.Get<CarModel>(model.CarModel.Id);
                entity.Garage = await _repository.Get<Garage>(model.Garage.Id);
                entity.Notes = model.Notes;

                try
                {
                    await _repository.Update(entity);
                    return entity.Id;
                }
                catch (Exception)
                {
                }
            }

            return null;
        }
    }

    public class ModelService(IDataRepository repository, IHttpContextAccessor httpContextAccessor) : EntityService<CarModel>(repository, httpContextAccessor), IModelService
    {
        public async Task<Guid?> Create(CarModelCreateBindingModel model)
        {
            var collection = await _repository.Get<ModelCollection>(Guid.Parse(model.ModelCollectionId));
            var manufacturer = await _repository.Get<Manufacturer>(Guid.Parse(model.ManufacturerId));

            CarModel entity = new CarModel()
            {
                Id = Guid.NewGuid(),
                ModelName = model.ModelName,
                ModelCode = model.ModelCode,
                ModelCollection = collection,
                Manufacturer = manufacturer,
                Description = model.Description,
                Color = model.Color,
                CollectionOrder = model.CollectionOrder,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Year = model.Year,
                CreatedBy = null
            };

            try
            {
                await _repository.Create(entity);
                return entity.Id;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public async Task<Guid?> Update(CarModel model)
        {
            var entity = await _repository.Get<CarModel>(model.Id);

            if (entity != null)
            {
                var collection = await _repository.Get<ModelCollection>(model.ModelCollection.Id);
                var manufacturer = await _repository.Get<Manufacturer>(model.Manufacturer.Id);
                if (collection != null && manufacturer != null)
                {

                    entity.ModelName = model.ModelName;
                    entity.ModelCode = model.ModelCode;
                    entity.ModelCollection = collection;
                    entity.Color = model.Color;
                    entity.Description = model.Description;
                    entity.CollectionOrder = model.CollectionOrder;
                    entity.Manufacturer = manufacturer;
                    entity.Year = model.Year;

                    try
                    {
                        await _repository.Update(entity);
                        return entity.Id;
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            return null;
        }
    }

    public class CollectionService(IDataRepository repository, IHttpContextAccessor httpContextAccessor) : EntityService<ModelCollection>(repository, httpContextAccessor), ICollectionService
    {
        public async Task<Guid?> Create(ModelCollectionCreateBindingModel model)
        {
            ModelCollection entity = new ModelCollection()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Notes = model.Notes,
                Manufacturer = await _repository.Get<Manufacturer>(Guid.Parse(model.ManufacturerId)),
                TotalCount = model.TotalCount,
                CreatedBy = null,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            try
            {
                await _repository.Create(entity);
                return entity.Id;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public async Task<Guid?> Update(ModelCollection model)
        {
            var entity = await _repository.Get<ModelCollection>(model.Id);

            if (entity != null)
            {
                var manufacturer = await _repository.Get<Manufacturer>(model.Manufacturer.Id);
                if (manufacturer != null)
                {
                    entity.Name = model.Name;
                    entity.Notes = model.Notes;
                    entity.Manufacturer = manufacturer;
                    entity.TotalCount = model.TotalCount;

                    try
                    {
                        await _repository.Update(entity);
                        return entity.Id;
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            return null;
        }
    }

    public class ManufacturerService(IDataRepository repository, IHttpContextAccessor httpContextAccessor) : EntityService<Manufacturer>(repository, httpContextAccessor), IManufacturerService
    {
        public async Task<Guid?> Create(ManufacturerCreateBindingModel model)
        {
            Manufacturer entity = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                CreatedBy = null,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };


            try
            {
                await _repository.Create(entity);
                return entity.Id;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public async Task<Guid?> Update(Manufacturer model)
        {
            var entity = await _repository.Get<Manufacturer>(model.Id);

            if (entity != null)
            {
                entity.Name = model.Name;
                entity.Description = model.Description;

                try
                {
                    await _repository.Update(entity);
                    return entity.Id;
                }
                catch (Exception)
                {
                }
            }

            return null;
        }
    }

    public class GarageService(IDataRepository repository, IHttpContextAccessor httpContextAccessor) : EntityService<Garage>(repository, httpContextAccessor), IGarageService
    {
        public async Task<Guid?> Create(GarageCreateBindingModel model)
        {
            Garage entity = new Garage()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                CreatedBy = null,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            try
            {
                await _repository.Create(entity);
                return entity.Id;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public async Task<Guid?> Update(Garage model)
        {
            var entity = await _repository.Get<Garage>(model.Id);

            if (entity != null)
            {
                entity.Name = model.Name;
                entity.Description = model.Description;

                try
                {
                    await _repository.Update(entity);
                    return entity.Id;
                }
                catch (Exception)
                {
                }
            }

            return null;
        }
    }
}
