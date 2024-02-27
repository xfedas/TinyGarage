using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TinyGarage.Models;

namespace TinyGarage.Server.BindingModels
{
    public class ModelCollectionBindingModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ManufacturerBindingModel Manufacturer { get; set; }
        public int? TotalCount { get; set; }
        public string Notes { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public ModelCollectionBindingModel() { }

        public ModelCollectionBindingModel(ModelCollection model) 
        {
            Id = model.Id;
            Name = model.Name;
            Manufacturer = new ManufacturerBindingModel(model.Manufacturer);
            TotalCount = model.TotalCount;
            Notes = model.Notes;
            CreatedDate = model.CreatedDate;
            //Author = model.CreatedBy.UserName;
        }
    }

    public class ModelCollectionCreateBindingModel
    {
        public string Name { get; set; } = string.Empty;
        public string ManufacturerId { get; set; } = string.Empty;
        public int? TotalCount { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}