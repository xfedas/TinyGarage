using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyGarage.Models
{
    public class CarModel : BaseModel
    {
        [Required]
        [StringLength(10)]
        public string ModelCode { get; set; }

        [Required]
        [StringLength(30)]
        public string ModelName { get; set; }

        public Guid ManufacturerId { get; set; }

        public Guid ModelCollectionId { get; set; }

        public int? Year { get; set; }

        public int? CollectionOrder { get; set; }

        [StringLength(25)]
        public string Color { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }

        [ForeignKey("ModelCollectionId")]
        public virtual ModelCollection ModelCollection { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
