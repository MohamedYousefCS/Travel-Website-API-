
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Travel_Website_System_API.Models;
using Travel_Website_System_API_.DTO.PaymentClasses;
using Travel_Website_System_API_.Hubs;
using Travel_Website_System_API_.Repositories;
using Travel_Website_System_API_.UnitWork;
using ServiceProvider = Travel_Website_System_API.Models.ServiceProvider;


namespace Travel_Website_System_API_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // inject unit of work
            builder.Services.AddScoped<UnitOFWork>();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddSwaggerGen(op=>
            //op.SwaggerDoc("Version 1",new Microsoft.OpenApi.Models.OpenApiInfo()
            //{
            //                    Version = "v2",
            //                     Title = "Web API Travel Website",
            //                     Description = "This is a web api for Travel Website"

            //})
            //);

            builder.Services.AddDbContext<ApplicationDBContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
            builder.Services.Configure<PayPalSettings>(builder.Configuration.GetSection("PayPal"));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            })
             .AddEntityFrameworkStores<ApplicationDBContext>()
             .AddDefaultTokenProviders();

            builder.Services.AddScoped<UserRepo>();
            builder.Services.AddScoped<IGenericRepo<Client>, GenericRepo<Client>>();
            builder.Services.AddScoped<IGenericRepo<Admin>, GenericRepo<Admin>>();
            builder.Services.AddScoped<IGenericRepo<CustomerService>, GenericRepo<CustomerService>>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();


            builder.Services.AddScoped<GenericRepository<Service>>();
            builder.Services.AddScoped<GenericRepository<Package>>();
            builder.Services.AddScoped<GenericRepository<ServiceProvider>>();
            builder.Services.AddScoped<GenericRepository<LoveService>>();
            builder.Services.AddScoped<GenericRepository<LovePackage>>();
            builder.Services.AddScoped<GenericRepository<Category>>();




            //[Authorize] used JWT token in check authentication 
            // JWT Authentication configuration

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
                    ValidAudience = builder.Configuration["Jwt:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };
            });


            builder.Services.AddAuthentication()
            .AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection =
                   builder.Configuration.GetSection("Authentication:Google");

                options.ClientId = googleAuthNSection["ClientId"];
                options.ClientSecret = googleAuthNSection["ClientSecret"];
            })
            .AddFacebook(options =>
            {
                IConfigurationSection fbAuthNSection =
                    builder.Configuration.GetSection("Authentication:Facebook");

                options.AppId = fbAuthNSection["AppId"];
                options.AppSecret = fbAuthNSection["AppSecret"];
            })
            .AddTwitter(options =>
            {
                IConfigurationSection twitterAuthNSection =
                    builder.Configuration.GetSection("Authentication:Twitter");

                options.ConsumerKey = twitterAuthNSection["ConsumerKey"];
                options.ConsumerSecret = twitterAuthNSection["ConsumerSecret"];
            });


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Now, you can use roleManager within this using block
                // For example, you can seed roles here
                var seed = new DataSeed(roleManager);
                seed.SeedRolesAsync().GetAwaiter().GetResult();
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // Add CORS policy
            app.UseCors(policy =>

            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();//check JWT token

            app.UseAuthorization();
            app.MapControllers();
            app.UseStaticFiles();
            app.Run();

        }


        // signalR Configuration
        public IConfiguration Configuration { get; }

        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services , IApplicationBuilder app)
        {
            // Add SignalR services
            services.AddSignalR();

            // other services like Identity, DbContext
            services.AddDbContext<ApplicationDBContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("Data Source=.;Initial Catalog=Traveling;Integrated Security=True;TrustServerCertificate=True")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDBContext>()
               .AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Middleware for handling authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Configure SignalR
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chathub");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }


    }

}



