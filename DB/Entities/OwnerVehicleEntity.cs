using System.ComponentModel.DataAnnotations.Schema;
namespace DB.Entities
{
    [Table(name: "own_owner_vehicle")]
    public class OwnerVehicleEntity : BaseEntity
    {
        [ForeignKey("OwnerEntity")]
        public int OwnerId { get; set; }
        public virtual OwnerEntity Owner { get; set; } = null!;
        [ForeignKey("VehicleEntity")]
        public int VehicleId { get; set; }
        public virtual VehicleEntity Vehicle { get; set; } = null!;
        public decimal AmountInvested { get; set; }
    }
}
