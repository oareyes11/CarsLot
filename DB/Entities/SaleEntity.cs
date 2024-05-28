using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DB.Entities
{
    [Table(name: "sal_sale")]
    public class SaleEntity : BaseEntity
    {
        [ForeignKey("VehicleEntity")]
        public int VehicleId { get; set; }
        public VehicleEntity Vehicle { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal SalePrice { get; set; }
    }
}