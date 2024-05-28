using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DB.Entities
{
    [Table(name: "car_vehicle")]
    public class VehicleEntity : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Make { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int Mileage { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PurchaseCost { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        [Required]
        public bool Status { get; set; } = true;
    }
}