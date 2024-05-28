using System.ComponentModel.DataAnnotations.Schema;
namespace DB.Entities
{
    public class OwnerVehicleEntity : BaseEntity
    {
        [ForeignKey("OwnerEntity")]
        public int OwnerId { get; set; }
        public OwnerEntity Owner { get; set; } = null!;
        [ForeignKey("VehicleEntity")]
        public int VehicleId { get; set; }
        public VehicleEntity Vehicle { get; set; } = null!;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal AmountInvested { get; set; }
    }
}
