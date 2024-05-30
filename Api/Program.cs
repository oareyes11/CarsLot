using Api.Casts.Request.Vehicle;
using Api.Casts.Request.Vehicle;
using Api.Casts.Response.Vehicle;
using Api.Filters.Base;
using Api.Repositories.Generic;
using Api.Services.Base.Interfaces;
using Api.Services.Owner.Implementation;
using Api.Services.Vehicle;
using Core.Implementations.Specification;
using Core.Repository.Interfaces;
using DB.context;
using DB.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Repository
#region Generic repository
builder.Services.AddScoped(typeof(IGenericGetAllRepo<>), typeof(GenericGetAllRepositoryImpl<>));
builder.Services.AddScoped(typeof(IGenericGetByIdRepo<>), typeof(GenericGetByIdRepositoryImpl<>));
builder.Services.AddScoped(typeof(IGenericGetByRepo<>), typeof(GenericGetByRepositoryImpl<>));
builder.Services.AddScoped(typeof(IGenericPostRepo<>), typeof(GenericPostRepositoryImpl<>));
builder.Services.AddScoped(typeof(IGenericPutRepo<>), typeof(GenericPutRepositoryImpl<>));
builder.Services.AddScoped(typeof(IGenericDeleteRepo<>), typeof(GenericDeleteRepositoryImpl<>));
#endregion
// Service
#region Owner
builder.Services.AddScoped(typeof(IGenericPostAsync<OwnerRequest, OwnerResponse>), typeof(OwnerImpl));
builder.Services.AddScoped(typeof(IGenericGetByAsync<OwnerEntity, EmailFilter>), typeof(OwnerImpl));
#endregion
#region Vehicle
builder.Services.AddScoped(typeof(IGenericPostAsync<VehicleRequest, VehicleResponse>), typeof(VehicleImpl));
#endregion
//Tools
builder.Services.AddScoped(typeof(ISpecification<>), typeof(SpecificationImpl<>));
builder.Services.AddSingleton<IMapper, Mapper>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using IServiceScope? scope = app.Services.CreateScope();
IServiceProvider? services = scope.ServiceProvider;
StoreContext? context = services.GetRequiredService<StoreContext>();
ILogger<Program>? logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    // await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during migration");
}

app.Run();
