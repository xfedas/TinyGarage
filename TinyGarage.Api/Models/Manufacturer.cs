using System.ComponentModel.DataAnnotations;

namespace TinyGarage.Models
{
    public class Manufacturer : BaseModel
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(150)]
        public string? Description { get; set; }

        public virtual ICollection<ModelCollection>? ModelCollections { get; set; }
    }
}
