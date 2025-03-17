using Application;
using Identity.Models;
using Identity.Seeds;
using Microsoft.AspNetCore.Identity;
using Persistense;
using Shared;
using WebApi.Extensions;
using Identity;

var builder = WebApplication.CreateBuilder(args);
try
{
    var MyAllowSpecificOrigins = "MyCors";
    builder.Services.AddCors(options =>
    {
    
        options.AddPolicy(name: MyAllowSpecificOrigins,
            policy =>
            {
                //policy.WithOrigins("http://localhost:4200/");
                policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowCredentials();
            });
    });
    

    // Rerencia a metodo de aplication
    builder.Services.AddApplicationLayer(builder.Configuration);


    // envio de configuracion del Api
    builder.Services.AddPersistenseInfraestructure(builder.Configuration);

    //Agrega el proyecto Shared
    builder.Services.AddSharedInfraestructure(builder.Configuration);

    //matricular capa identity
    builder.Services.AddIdentityInfraestructure(builder.Configuration);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Identity Auth
    var services = app.Services.CreateAsyncScope();
    var userManager = services.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await DefaultRoles.SeedAsync(userManager, roleManager);
    await DefaultAdministratorUser.SeedAsync(userManager, roleManager);
    await DefaultCustomerUser.SeedAsync(userManager, roleManager);
    app.UseAuthentication();

    app.UseCors(MyAllowSpecificOrigins);


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();
    //configure personalized errors
    app.UseErrorHandlingMiddleware();

    app.MapControllers();

    app.Run();

}
catch (Exception e)
{

	throw;
}

