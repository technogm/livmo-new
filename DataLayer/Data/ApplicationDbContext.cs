using DataLayer.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataLayer.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<Users>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Experience one to many :


            modelBuilder.Entity<Experience>()
                .HasOne(c => c.Host)
                .WithMany(e => e.Experiences)
                .HasForeignKey(s => s.HostId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PhotosExperience>()
               .HasOne(c => c.Experience)
               .WithMany(e => e.Photos)
               .HasForeignKey(s => s.ExperienceIDFK)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Activity>()
              .HasOne(c => c.Experience)
              .WithMany(e => e.Activites)
              .HasForeignKey(s => s.ExperienceId)
              .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PhotosActivity>()
              .HasOne(c => c.Activity)
              .WithMany(e => e.Activityphoto)
              .HasForeignKey(s => s.ActivitiyId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LodgingExperience>()
             .HasOne(c => c.experience)
             .WithMany(e => e.LodgingExperience)
             .HasForeignKey(s => s.ExperienceId)
             .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PhotosLodgingsExp>()
              .HasOne(c => c.LodgingExperience)
              .WithMany(e => e.Lodgingphoto)
              .HasForeignKey(s => s.LodgingExperineceId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TransportExperience>()
             .HasOne(c => c.eperience)
             .WithMany(e => e.TransportExperience)
             .HasForeignKey(s => s.ExperienceId)
             .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PhotosTransportsExp>()
              .HasOne(c => c.TransportExperience)
              .WithMany(e => e.Transphoto)
              .HasForeignKey(s => s.TransportExperineceId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FoodExperience>()
             .HasOne(c => c.experience)
             .WithMany(e => e.FoodExperience)
             .HasForeignKey(s => s.ExperienceId)
             .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PhotosFoodExp>()
              .HasOne(c => c.FoodExperience)
              .WithMany(e => e.Foodphoto)
              .HasForeignKey(s => s.FoodxperineceId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PhotosRestaurants>()
              .HasOne(c => c.restaurantService)
              .WithMany(e => e.RestaurantPhotos)
              .HasForeignKey(s => s.FoodServId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FoodService>()
               .HasOne(c => c.Commercant)
               .WithMany(e => e.FoodServices)
               .HasForeignKey(s => s.CommercantId)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PhotosFood>()
              .HasOne(c => c.foodService)
              .WithMany(e => e.Foodhoto)
              .HasForeignKey(s => s.FoodServId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TransportService>()
             .HasOne(c => c.Commercant)
             .WithMany(e => e.TransportServices)
             .HasForeignKey(s => s.CommercantId)
             .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PhotosTransports>()
           .HasOne(c => c.TransportService)
           .WithMany(e => e.Transportphoto)
           .HasForeignKey(s => s.TransportId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LodgingService>()
             .HasOne(c => c.Commercant)
             .WithMany(e => e.LodgingServices)
             .HasForeignKey(s => s.CommercantId)
             .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PhotosLodgings>()
            .HasOne(c => c.lodgingService)
            .WithMany(e => e.Lodgingphoto)
            .HasForeignKey(s => s.LodgingId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Photo>()
          .HasOne(a => a.AppUser)
          .WithMany(b => b.Photos)
          .HasForeignKey(b => b.UserId)
          .OnDelete(DeleteBehavior.Cascade);

          
            //Adding Data
            modelBuilder.Seed();

            //////////////////////////////////////////////////////////////////////////////////////////////////////

             

            modelBuilder.Entity<TransportReservation>()
              .HasOne(g => g.TransportServicee)
              .WithMany(c => c.TransportReservations)
              .HasForeignKey(d => d.TransportId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TransportReservation>()
              .HasOne(g => g.Client)
              .WithMany(c => c.TransportReservations)
              .HasForeignKey(d => d.ClientId)
              .OnDelete(DeleteBehavior.Cascade);

           
            modelBuilder.Entity<LodgingReservation>()
              .HasOne(g => g.LodgingServicee)
              .WithMany(c => c.LodgingReservations)
              .HasForeignKey(d => d.LodgingId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LodgingReservation>()
              .HasOne(g => g.Client)
              .WithMany(c => c.LodgingReservations)
              .HasForeignKey(d => d.ClientId)
              .OnDelete(DeleteBehavior.Cascade);

           
            modelBuilder.Entity<FoodReservation>()
              .HasOne(g => g.FoodServicee)
              .WithMany(c => c.FoodReservations)
              .HasForeignKey(d => d.FoodServId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FoodReservation>()
              .HasOne(g => g.Client)
              .WithMany(c => c.FoodReservations)
              .HasForeignKey(d => d.ClientId)
              .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ExperiencesReservation>()
             .HasOne(g => g.Experience)
             .WithMany(c => c.ExperiencesReservation)
             .HasForeignKey(d => d.ExperienceId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ExperiencesReservation>()
              .HasOne(g => g.Client)
              .WithMany(c => c.ExperiencesReservation)
              .HasForeignKey(d => d.ClientId)
              .OnDelete(DeleteBehavior.Cascade);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Theme

            modelBuilder.Entity<SubTheme>()
           .HasOne(p => p.theme)
           .WithMany(b => b.themes)
           .HasForeignKey(p => p.ThemeID);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
            ///  Comments :


            modelBuilder.Entity<Comments>()
          .HasOne(c => c.users)
            .WithMany(e => e.Comments)
                .HasForeignKey(s => s.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Comments>()
               .HasOne(c => c.experience)
                 .WithMany(e => e.Comments)
                      .HasForeignKey(s => s.ExperienceId)
                      .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comments>()
                 .HasOne(c => c.foodService)
                     .WithMany(e => e.Comments)
                          .HasForeignKey(s => s.FoodServId)
                           .OnDelete(DeleteBehavior.NoAction);
            ;
            modelBuilder.Entity<Comments>()
              .HasOne(c => c.lodgingService)
                  .WithMany(e => e.Comments)
                       .HasForeignKey(s => s.LodgingId)
                       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comments>()
              .HasOne(c => c.transportService)
                  .WithMany(e => e.Comments)
                       .HasForeignKey(s => s.TransportId)
                       .OnDelete(DeleteBehavior.NoAction);


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
            ///  LIKES :

            modelBuilder.Entity<ServicesLikes>()
                 .HasOne(c => c.users)
                   .WithMany(e => e.servicesLike)
                       .HasForeignKey(s => s.Id)
                            .OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<ServicesLikes>()
                  .HasOne(c => c.experience)
                    .WithMany(e => e.ServicesLikes)
                        .HasForeignKey(s => s.ExperienceId)
                             .OnDelete(DeleteBehavior.NoAction);

                modelBuilder.Entity<ServicesLikes>()
                .HasOne(c => c.lodgingService)
                  .WithMany(e => e.ServicesLikes)
                      .HasForeignKey(s => s.LodgingId)
                           .OnDelete(DeleteBehavior.NoAction);
                modelBuilder.Entity<ServicesLikes>()
                .HasOne(c => c.transportService)
                  .WithMany(e => e.ServicesLikes)
                      .HasForeignKey(s => s.TransportId)
                           .OnDelete(DeleteBehavior.NoAction);
                modelBuilder.Entity<ServicesLikes>()
                .HasOne(c => c.foodService)
                  .WithMany(e => e.ServicesLikes)
                      .HasForeignKey(s => s.FoodServId)
                           .OnDelete(DeleteBehavior.NoAction);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<UserLikes>()
           .HasOne(c => c.users)
             .WithMany(e => e.UserLike)
                 .HasForeignKey(s => s.userLikesId)
                      .OnDelete(DeleteBehavior.Cascade);

          


            modelBuilder.Entity<Experience>().Property(p => p.Price)
            .HasColumnType("decimal(18,4)");
            modelBuilder.Entity<FoodService>().Property(p => p.FoodPrice)
            .HasColumnType("decimal(18,4)");
            modelBuilder.Entity<TransportService>().Property(p => p.PricePerDay)
            .HasColumnType("decimal(18,4)");
            modelBuilder.Entity<LodgingService>().Property(p => p.PricePerNight)
            .HasColumnType("decimal(18,4)");

        }

        public DbSet<Users> User { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Hote> Hosts { get; set; }
        public DbSet<Commercant> Commercants { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<LodgingExperience> LodgingExperience { get; set; }
        public DbSet<TransportExperience> TransportExperience { get; set; }
        public DbSet<FoodExperience> Foodxperience { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ExperienceDates> ExperienceDates { get; set; }
        public DbSet<FoodService> foodServices { get; set; }
        public DbSet<TransportService> transportServices { get; set; }
        public DbSet<LodgingService> lodgingServices { get; set; }
        public DbSet<PhotosActivity> PhotosActivities { get; set; }
        public DbSet<PhotosExperience> photosExperiences { get; set; }
        public DbSet<PhotosFood> photosFoods { get; set; }
        public DbSet<PhotosFoodExp> photosFoodExps { get; set; }
        public DbSet<PhotosLodgings> photosLodgings { get; set; }
        public DbSet<PhotosLodgingsExp> photosLodgingsExps { get; set; }
        public DbSet<PhotosRestaurants> photosRestaurants { get; set; }
        public DbSet<PhotosTransports> photosTransports { get; set; }
        public DbSet<PhotosTransportsExp> photosTransportsExps { get; set; }
        public DbSet<TransportReservation> TransportReservation { get; set; }
        public DbSet<LodgingReservation> LodgingReservation { get; set; }
        public DbSet<FoodReservation> FoodReservation { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<SubTheme> SubThemes { get; set; }
        public DbSet<Comments> Comments { get; set; }
         public DbSet<UserLikes> UserLikes { get; set; }
        public DbSet<ServicesLikes> ServicesLikes { get; set; }
        public DbSet<ExperiencesReservation> ExperienceReservations { get; set; }




    }
}
