using System.Text.Json;
using DB.context;



namespace Api.DB
{
    // public class StoreContextSeed
    // {
    //     public static async Task SeedAsync(StoreContext context)
    //     {
    //         if (!context.StatusCode.Any())
    //         {
    //             var brandsData = File.ReadAllText("../Db/Data/statusCode.json");
    //             var brands = JsonSerializer.Deserialize<List<StatusCodeEntity>>(brandsData);
    //             context.StatusCode.AddRange(brands!);
    //         }
        

    //         if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
    //     }
    // }

}