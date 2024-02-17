using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using TinyGarage.Api.Services.Abstract;
using TinyGarage.Models;
using TinyGarage.Repositories;
using TinyGarage.Server.BindingModels;

namespace TinyGarage.Api.Services
{
    public class CarService(DataRepository repository, IHttpContextAccessor httpContextAccessor) : EntityService<Car>(repository, httpContextAccessor), ICarService
    {
        public async void Create(CarCreateBindingModel model)
        {
            var owner = CurrentUser;

            Car entity = new Car()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                CarModel = await _repository.Get<CarModel>(Guid.Parse(model.CarModelId)),
                Garage = await _repository.Get<Garage>(Guid.Parse(model.GarageId)),
                Notes = model.Notes,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                CreatedBy = owner,
                Owner = owner,
            };

            _repository.Create(entity);
            _repository.Save();
        }

        public async void Update(CarBindingModel model)
        {
            var entity = await _repository.Get<Car>(model.Id);

            if (entity != null)
            {
                entity.Name = model.Name;
                entity.CarModel = await _repository.Get<CarModel>(model.CarModel.Id);
                entity.Garage = await _repository.Get<Garage>(model.Garage.Id);
                entity.Notes = model.Notes;

                _repository.Update(entity);
                _repository.Save();
            }
            else
            {
                throw new Exception($"Entity to be updated not found. Id: ${model.Id}");
            }
        }
    }

    public class ModelService(DataRepository repository, IHttpContextAccessor httpContextAccessor) : EntityService<CarModel>(repository, httpContextAccessor), IModelService
    {
        public async void Create(CarModelCreateBindingModel model)
        {
            CarModel entity = new CarModel()
            {
                Id = Guid.NewGuid(),
                ModelName = model.ModelName,
                ModelCode = model.ModelCode,
                ModelCollection = await _repository.Get<ModelCollection>(Guid.Parse(model.ModelCollectionId)),
                Manufacturer = await _repository.Get<Manufacturer>(Guid.Parse(model.ManufacturerId)),
                Description = model.Description,
                Color = model.Color,
                CollectionOrder = model.CollectionOrder,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Year = model.Year,
                CreatedBy = CurrentUser
            };

            _repository.Create(entity);
            _repository.Save();
        }

        public async void Update(CarModelBindingModel model)
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

                    _repository.Update(entity);
                    _repository.Save();
                }
            }
            else
            {
                throw new Exception($"Entity to be updated not found. Id: ${model.Id}");
            }
        }
    }

    public class CollectionService(DataRepository repository, IHttpContextAccessor httpContextAccessor) : EntityService<ModelCollection>(repository, httpContextAccessor), ICollectionService
    {
        public async void Create(ModelCollectionCreateBindingModel model)
        {
            ModelCollection entity = new ModelCollection()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Notes = model.Notes,
                Manufacturer = await _repository.Get<Manufacturer>(Guid.Parse(model.ManufacturerId)),
                TotalCount = model.TotalCount,
                CreatedBy = CurrentUser,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            _repository.Create(entity);
            _repository.Save();
        }

        public async void Update(ModelCollectionBindingModel model)
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

                    _repository.Update(entity);
                    _repository.Save();
                }
            }
            else
            {
                throw new Exception($"Entity to be updated not found. Id: ${model.Id}");
            }
        }
    }

    public class ManufacturerService(DataRepository repository, IHttpContextAccessor httpContextAccessor) : EntityService<Manufacturer>(repository, httpContextAccessor), IManufacturerService
    {
        public void Create(ManufacturerCreateBindingModel model)
        {
            Manufacturer entity = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                CreatedBy = CurrentUser,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            _repository.Create(entity);
            _repository.Save();
        }

        public async void Update(ManufacturerBindingModel model)
        {
            var entity = await _repository.Get<Manufacturer>(model.Id);

            if (entity != null)
            {
                entity.Name = model.Name;
                entity.Description = model.Description;

                _repository.Update(entity);
                _repository.Save();
            }
            else
            {
                throw new Exception($"Entity to be updated not found. Id: ${model.Id}");
            }
        }
    }

    public class GarageService(DataRepository repository, IHttpContextAccessor httpContextAccessor) : EntityService<Garage>(repository, httpContextAccessor), IGarageService
    {
        public void Create(GarageCreateBindingModel model)
        {
            Garage entity = new Garage()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                CreatedBy = CurrentUser,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            _repository.Create(entity);
            _repository.Save();
        }

        public async void Update(GarageBindingModel model)
        {
            var entity = await _repository.Get<Garage>(model.Id);

            if (entity != null)
            {
                entity.Name = model.Name;
                entity.Description = model.Description;

                _repository.Update(entity);
                _repository.Save();
            }
            else
            {
                throw new Exception($"Entity to be updated not found. Id: ${model.Id}");
            }
        }
    }
}
