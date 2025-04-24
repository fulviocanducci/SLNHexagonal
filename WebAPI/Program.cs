using Application;
using Infrastructure;
namespace WebAPI
{
   public class Program
   {
      public static void Main(string[] args)
      {
         WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
         ConfigurationManager configuration = builder.Configuration;

         builder.Services.AddFluentValidation();
         builder.Services.AddControllers();
         builder.Services.AddEndpointsApiExplorer();
         builder.Services.AddSwaggerGen();
         builder.Services.AddApplication();
         builder.Services.AddInfrastructure(configuration);
         builder.Services.AddCors(options =>
         {
            options.AddDefaultPolicy(
               builder =>
               {
                  builder.WithOrigins("*")
                         .AllowAnyMethod()
                         .AllowAnyHeader();
               });            
         });
         builder.Services.Configure<RouteOptions>(configuration =>
         {
            configuration.LowercaseUrls = true;            
         });

         WebApplication app = builder.Build();
         if (app.Environment.IsDevelopment())
         {
            app.UseSwagger();
            app.UseSwaggerUI();
         }
         app.UseCors();
         app.UseHttpsRedirection();
         app.UseAuthorization();
         app.MapControllers();
         app.Run();
      }
   }
}
