using Api.Casts.Base.Response;
namespace Api.Casts.Response.Vehicle
{
    public class VehicleResponse : BaseResponse
    {
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int Mileage { get; set; }
        public decimal PurchaseCost { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; } = true;
    }
}