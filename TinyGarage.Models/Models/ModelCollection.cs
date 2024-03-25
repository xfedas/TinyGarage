using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyGarage.Models
{
    public class ModelCollection : BaseModel
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public Guid ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }

        public int? TotalCount { get; set; }

        [StringLength(150)]
        public string? Notes { get; set; }
    }
}
