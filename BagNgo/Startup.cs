using BagNgo.Helpers;
using BagNgo.ViewModels.Implementation;
using DataLayer.Data;
using DataLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RepositoryLayer.RepImplementation;
using RepositoryLayer.RepInterface;
using ServicesLayer.ServImplementation;
using ServicesLayer.ServInterface;
using System;
using System.IO;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BagNgo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
    
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            var emailConfig = Configuration
             .GetSection("EmailConfiguration")
            .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();


            services.AddIdentity<Users, IdentityRole>
                (options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 2;
                    options.User.RequireUniqueEmail = false;
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Lockout.MaxFailedAccessAttempts = 20;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
            opt.TokenLifespan = TimeSpan.FromHours(2));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    var frontendURL = Configuration.GetValue<string>("frontend_url");

                    builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader()
                    .WithExposedHeaders(new string[] { "totalAmountOfRecords" });
                });
            });

            var builder = services.AddIdentityServer()
                    .AddApiAuthorization<Users, ApplicationDbContext>();


            services.AddHttpContextAccessor();
            services.AddAuthentication()
                .AddIdentityServerJwt();

            //services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


            services.AddRazorPages();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(
                             Encoding.UTF8.GetBytes(Configuration["keyjwt"])),
                         ClockSkew = TimeSpan.Zero
                     };
                 });

            services.AddAuthorization(options =>
                {
                options.AddPolicy("CreateExperiencePolicy",
                policy => policy.RequireClaim("Create Experience"));
                options.AddPolicy("EditExperiencePolicy",
                policy => policy.RequireClaim("Edit Experience"));
                options.AddPolicy("DeleteExperiencePolicy",
                policy => policy.RequireClaim("Delete Experience"));
                options.AddPolicy("EditProfilPolicy",
                policy => policy.RequireClaim("Edit Profil"));
               
            });

          
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BagNgoAPI", Version = "v1" });
            });


            // Adding Repository List :
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IClientRepository), typeof(ClientRepository));
            services.AddScoped(typeof(IHostRepository), typeof(HostRepository));
            services.AddScoped(typeof(ICommercantRepository), typeof(CommercantIRepository));
            services.AddScoped(typeof(IAdminRepository), typeof(AdminRepository));
            services.AddScoped(typeof(ICommentsRepository), typeof(CommentsRepository));
            services.AddScoped(typeof(ILikesRepository), typeof(LikesRepository));


            services.AddScoped(typeof(IReservationExperienceRepository), typeof(ReservationExperienceRepository));
            services.AddScoped(typeof(IReservationFoodRespository), typeof(ReservationFoodRepository));
            services.AddScoped(typeof(IReservationLodgingRepository), typeof(ReservationLodgingRepository));
            services.AddScoped(typeof(IReservationTransportRepository), typeof(ReservationTransportRepository));


            services.AddScoped(typeof(IExperienceRepository), typeof(ExperienceRepository));
            services.AddScoped(typeof(IDatesExpRepository), typeof(DatesExpRepository));
            services.AddScoped(typeof(ITransportExperienceRepository), typeof(TransportExperienceRepository));
            services.AddScoped(typeof(IFoodExpRepository), typeof(FoodExpRepository));
            services.AddScoped(typeof(IActivityRepository), typeof(ActivityRepository));
            services.AddScoped(typeof(ILodgingExpRepository), typeof(LodgingExpRepository));


            services.AddScoped(typeof(ILodgingServiceRepository), typeof(LodgingServiceRepository));
            services.AddScoped(typeof(ITransportServiceRepository), typeof(TransportServiceRepositroy));
            services.AddScoped(typeof(IFoodServiceRepository), typeof(FoodServiceRepository));


            services.AddSingleton<IEmailSender, EmailSender>();

            // Adding Services List :
            services.AddScoped<IUserClaimsPrincipalFactory<Users>, ApplicationUserClaimsPrincipalFactory>();

            services.AddTransient<IAdminService, AdminServices>();
            services.AddTransient<ICommentService, CommentsServices>();
            services.AddTransient<ILikesService, LikeServices>();
            services.AddTransient<IUserService, UserServices>();
            services.AddTransient<IClientservice, ClientServices>();
            services.AddTransient<IHostService, HostServices>();
            services.AddTransient<ICommercantService, CommercantServices>();

            services.AddTransient<IReservationExperienceService, ReservationExperienceService>();
            services.AddTransient<IReservationFoodService, ReservationFoodService>();
            services.AddTransient<IReservationLodgingService, ReservationLodgingService>();
            services.AddTransient<IReservationTransportService, ReservationTransportService>();


            services.AddTransient<IExperienceService, ExperienceService>();
            services.AddTransient<ITransportExperienceServices, TransportExperienceServices>();
            services.AddTransient<ILodgingExperienceService, LodgingExperienceService>();
            services.AddTransient<IActivityServices, ActivityServices>();
            services.AddTransient<IFoodExperienceService, FoodExperienceService>();
            services.AddTransient<IExperiencesDatesServices, ExperiencesDatesServices>();

            services.AddTransient<IFoodService, FoodServices>();
            services.AddTransient<ITransportService, TransportServices>();
            services.AddTransient<ILodgingService, LodgingServices>();

            //Cloudinary Service for photos
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySrttings"));
            services.AddScoped<IPhotoService, PhotoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseMigrationsEndPoint();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BagNgoAPI v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

           // app.UseHttpsRedirection();
            app.UseStaticFiles();
           
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            // app.UseCors("AllowOrigin");
           
            app.UseCors(builder => builder
             .WithOrigins("http://localhost:44370", "http://localhost:4200")
                 .AllowAnyMethod()
                 .AllowCredentials()
                 .AllowAnyHeader()
                 .WithHeaders("Accept", "Content-Type", "Origin", "X-My-Header"));

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            var config = new HttpConfiguration();
            var cors = new EnableCorsAttribute("http://localhost:4200","*","*");
            config.EnableCors(cors);
            //app.UseWebApi(config);
            app.UseSpa(spa =>
            {
                    // To learn more about options for serving an Angular SPA from ASP.NET Core,
                    // see https://go.microsoft.com/fwlink/?linkid=864501

                    spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
    
}
