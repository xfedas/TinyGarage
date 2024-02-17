using System.ComponentModel.DataAnnotations;

namespace TinyGarage.Models
{
    public class Garage : BaseModel
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
