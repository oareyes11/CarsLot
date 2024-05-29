namespace Api.Casts.Reqest.Vehicle
{
    public class VehicleRequest
    {
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int Mileage { get; set; }
        public decimal PurchaseCost { get; set; }
        public decimal Price { get; set; }
    }
}