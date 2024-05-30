namespace Api.Casts.Request.OwnerVehicle
{
    public class OwnerVehicleRequest
    {
        public int OwnerId { get; set; }
        public int VehicleId { get; set; }
        public decimal AmountInvested { get; set; }
    }
}