using Microsoft.EntityFrameworkCore;
using YalstBack.Data;
using YalstBack.Services;
using YetAnotherLeagueStatTracker.Data;

namespace YalstBack;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        var debugOrigin = "_localhostOrigin";
        var kitten = "_kittenOrigin";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: kitten,
                policy =>
                {
                    policy.WithOrigins("https://yalst.kitten.rs").WithMethods(["GET", "PATCH"]);
                });
            #if DEBUG
            options.AddPolicy(name: debugOrigin,
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200").WithMethods(["GET", "PATCH"]);
                });
            #endif
        });
        
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        var serverVersion = new MariaDbServerVersion(new Version(11,4,12));
        builder.Services.AddDbContextFactory<ApplicationDbContext>(options => 
                options.UseMySql(connectionString,  serverVersion)
#if DEBUG
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
#endif
        );
        
        builder.Services.AddSingleton<RiotClient>();
        

        var app = builder.Build();


        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        
        app.UseCors(kitten);
        
#if DEBUG
        app.UseCors(debugOrigin);
#endif
        
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}