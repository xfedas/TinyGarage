using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TinyGarage.Models;

namespace TinyGarage.Server.BindingModels
{
    public class CarModelBindingModel
    {
        public Guid Id { get; set; }
        public string ModelCode { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
        public ManufacturerBindingModel Manufacturer { get; set; }
        public ModelCollectionBindingModel ModelCollection { get; set; }
        public int? Year { get; set; }
        public int? CollectionOrder { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public CarModelBindingModel() { }

        public CarModelBindingModel(CarModel model)
        {
            Id = model.Id;
            ModelCode = model.ModelCode;
            ModelName = model.ModelName;
            Manufacturer = new ManufacturerBindingModel(model.Manufacturer);
            ModelCollection = new ModelCollectionBindingModel(model.ModelCollection);
            Year = model.Year;
            CollectionOrder = model.CollectionOrder;
            Color = model.Color;
            Description = model.Description;
            CreatedDate = model.CreatedDate;
            //Author = model.CreatedBy.UserName;
        }
    }

    public class CarModelCreateBindingModel
    {
        public string ModelCode { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
        public string ManufacturerId { get; set; } = string.Empty;
        public string ModelCollectionId { get; set; } = string.Empty;
        public int? Year { get; set; }
        public int? CollectionOrder { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public IEnumerable<Manufacturer> AvailableManufacturers { get; set; }
        public IEnumerable<ModelCollection> AvailableCollections { get; set; }
    }
}