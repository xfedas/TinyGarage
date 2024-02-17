using System;
using TinyGarage.Models;

namespace TinyGarage.Server.BindingModels
{
    public class ManufacturerBindingModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string Author { get; set; } = string.Empty;
        public ManufacturerBindingModel() { }

        public ManufacturerBindingModel(Manufacturer model) 
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            CreatedDate = model.CreatedDate;
            Author = model.CreatedBy.UserName;
        }
    }

    public class ManufacturerCreateBindingModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
    
}