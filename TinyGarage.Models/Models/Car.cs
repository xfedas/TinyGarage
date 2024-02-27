using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyGarage.Models
{
    public class Car : BaseModel 
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(150)]
        public string? Notes { get; set; }

        public string? OwnerId { get; set; }

        public Guid GarageId { get; set; }
        
        public Guid CarModelId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual ApplicationUser? Owner { get; set; }

        [ForeignKey("GarageId")]
        public virtual Garage Garage { get; set; }

        [ForeignKey("CarModelId")]
        public virtual CarModel CarModel { get; set; }
    }
}
