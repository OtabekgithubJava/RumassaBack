
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;
using Rumassa.Application;
using Rumassa.Domain.Entities.Auth;
using Rumassa.Infrastructure;
using Rumassa.Infrastructure.Persistance;
using Serilog;

namespace Rumassa.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Add services to the container.
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<RumassaDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddMemoryCache();

            //builder.Services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        options.ClientId = builder.Configuration["Auth:Google:ClientId"]!;
            //        options.ClientSecret = builder.Configuration["Auth:Google:ClientSecret"]!;
            //    })
            //    .AddFacebook(options =>
            //    {
            //        options.AppId = builder.Configuration["Auth:Facebook:AppId"]!;
            //        options.AppSecret = builder.Configuration["Auth:Facebook:AppSecret"]!;
            //    });

            builder.Services.AddControllers().
                AddJsonOptions(options=>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();
            //builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
            builder.Services.AddControllers();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = 
                    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                var roles = new[] { "Admin", "User" };

                foreach (var role in roles)
                {
                    if (!roleManager.RoleExistsAsync(role).Result)
                        roleManager.CreateAsync(new IdentityRole<Guid>(role)).Wait();
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                string email = "admin@massa.com";
                string password = "Admin01!";

                if (userManager.FindByEmailAsync(email).Result == null)
                {
                    var user = new User()
                    {
                        UserName = "Admin",
                        Name = "Admin",
                        Surname = "Admin",
                        Email = email,
                        PhotoUrl = "https://ih1.redbubble.net/image.2955130987.9629/raf,360x360,075,t,fafafa:ca443f4786.jpg",
                        Password = password,
                        PhoneNumber = "+998777777777",
                        Role = "Admin"
                    };

                    userManager.CreateAsync(user, password).Wait();

                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            app.Run();
        }
    }
}
