using CatchUpBackend.Social.Core.Application;
using CatchUpBackend.Social.Core.Ports.Incomming;
using CatchUpBackend.Social.Core.Ports.Outgoing;
using CatchUpBackend.Social.Infrastructure;
namespace CatchUpBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Dependency Injection for Core Services and Repositories
            builder.Services.AddScoped<IProfileUseCases, ProfileService>();
            builder.Services.AddScoped<IProfileRepository, ProfileDbAdapter>();
            builder.Services.AddScoped<IPostRepository, PostDbAdapter>();
            builder.Services.AddScoped<IPostUseCases, PostService>();

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

            app.Run();
        }
    }
}
