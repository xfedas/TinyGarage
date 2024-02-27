using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TinyGarage.Models;

namespace TinyGarage.Server.BindingModels
{
    public class GarageBindingModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public GarageBindingModel() { }

        public GarageBindingModel(Garage garageEntity)
        {
            Id = garageEntity.Id;
            Name = garageEntity.Name;   
            Description = garageEntity.Description;
            //Author = garageEntity.CreatedBy.UserName;
            CreatedDate = garageEntity.CreatedDate;
        }
    }

    public class GarageCreateBindingModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}