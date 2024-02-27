using TinyGarage.Models;

namespace TinyGarage.Server.BindingModels
{
    public class CarBindingModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public CarModelBindingModel CarModel { get; set; }
        public GarageBindingModel Garage { get; set; }
        public string Owner { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public CarBindingModel() { }

        public CarBindingModel(Car model)
        {
            Id = model.Id;
            Name = model.Name;
            Notes = model.Notes;
            CarModel = new CarModelBindingModel(model.CarModel);
            Garage = new GarageBindingModel(model.Garage);
            CreatedDate = model.CreatedDate;
            //Owner = model.Owner.UserName;
            //Author = model.CreatedBy.UserName;
        }
    }

    public class CarCreateBindingModel
    {
        public string Name { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string CarModelId { get; set; } = string.Empty;
        public string GarageId { get; set; } = string.Empty;
        public IEnumerable<CarModel> AvailableCarModels { get; set; } = Enumerable.Empty<CarModel>();
        public IEnumerable<Garage> AvailableGarages { get; set; } = Enumerable.Empty<Garage>();
    }
}