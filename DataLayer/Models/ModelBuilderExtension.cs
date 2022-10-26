using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Guid AdminId = Guid.NewGuid();
            Guid ClientId = Guid.NewGuid();
            Guid HostId = Guid.NewGuid();
            Guid CommercantId = Guid.NewGuid();

            Guid AdminConcurrencyStamp = Guid.NewGuid();
            Guid HostConcurrencyStamp = Guid.NewGuid();
            Guid ClientIdConcurrencyStamp = Guid.NewGuid();
            Guid CommercantIdConcurrencyStamp = Guid.NewGuid();


            modelBuilder.Entity<IdentityRole>().HasData(
                                new IdentityRole()
                                {
                                    Id = AdminId.ToString(),
                                    Name = "Adminisatrateur",
                                    ConcurrencyStamp = AdminConcurrencyStamp.ToString(),
                                    NormalizedName = "ADMINISTRATEUR"
                                },
                                  new IdentityRole()
                                  {
                                      Id = HostId.ToString(),
                                      Name = "Host",
                                      ConcurrencyStamp = HostConcurrencyStamp.ToString(),
                                      NormalizedName = "HOST"
                                  },
                                    new IdentityRole()
                                    {
                                        Id = ClientId.ToString(),
                                        Name = "Client",
                                        ConcurrencyStamp = ClientIdConcurrencyStamp.ToString(),
                                        NormalizedName = "CLIENT"
                                    },
                                      new IdentityRole()
                                  {
                                      Id = CommercantId.ToString(),
                                      Name = "Commercant",
                                      ConcurrencyStamp = CommercantIdConcurrencyStamp.ToString(),
                                      NormalizedName = "COMMERCANT"
                                  }

                ) ;
            modelBuilder.Entity<SubTheme>().HasData(
              new List<SubTheme> {
                 new SubTheme{SubThemeId=1, Name="Camping",ThemeID=1   } ,new SubTheme{SubThemeId=2,Name="Hicking",ThemeID=1}
                 ,new SubTheme{SubThemeId=3,Name="Prepare meals in nature",ThemeID=1}
                 ,new SubTheme{SubThemeId=4,Name="walking",ThemeID=1}
                 ,new SubTheme{SubThemeId=5,Name="hunt",ThemeID=1}
                 ,new SubTheme{SubThemeId=6,Name="fishing",ThemeID=1}
                 ,new SubTheme{SubThemeId=7,Name="sand diving",ThemeID=1}
                 ,new SubTheme{SubThemeId=8,Name="Ski Palmier",ThemeID=1}
                 ,new SubTheme{SubThemeId=9,Name="Back packing",ThemeID=1}
                 ,new SubTheme{SubThemeId=10,Name="Night sky",ThemeID=1}
                 ,new SubTheme{SubThemeId=11,Name="Back packing",ThemeID=1}
                 ,new SubTheme{SubThemeId=12,Name="Nature and ecology tour",ThemeID=1}

                 ,new SubTheme{SubThemeId=13,Name="plante et agriculture",ThemeID=1}




                 ,new SubTheme{SubThemeId=14,Name="Activité plein air",ThemeID=1}


                 ,new SubTheme{SubThemeId=15,Name="Beauté",ThemeID=2}
                 ,new SubTheme{SubThemeId=16,Name="spa",ThemeID=2}
                 ,new SubTheme{SubThemeId=17,Name="pleine conscience",ThemeID=2}
                 ,new SubTheme{SubThemeId=18,Name="thérapie de corps",ThemeID=2}
                 ,new SubTheme{SubThemeId=19,Name="Etat d’esprit",ThemeID=2}
                 ,new SubTheme{SubThemeId=20,Name="Yoga",ThemeID=2}
                 ,new SubTheme{SubThemeId=21,Name="santé holistique",ThemeID=2}
                 ,new SubTheme{SubThemeId=22,Name="Divination",ThemeID=2}
                 ,new SubTheme{SubThemeId=23,Name="Autre Expérience Bien-être",ThemeID=2}

                 ,new SubTheme{SubThemeId=24,Name="cuisineet alimentation",ThemeID=3}

                 ,new SubTheme{SubThemeId=25,Name="degustation gastroNameique",ThemeID=3}
                 ,new SubTheme{SubThemeId=26,Name="diner en groupe",ThemeID=3}
                 ,new SubTheme{SubThemeId=27,Name="Visite de marché et gastroNameie",ThemeID=3}
                 ,new SubTheme{SubThemeId=28,Name="sport",ThemeID=4}



                 ,new SubTheme{SubThemeId=29,Name="sycling",ThemeID=4}
                 ,new SubTheme{SubThemeId=30,Name="Divertissement",ThemeID=4}
                 ,new SubTheme{SubThemeId=31,Name="Cours sur l’entrepreneuriat",ThemeID=5}
                 ,new SubTheme{SubThemeId=32,Name="Conférence culturelle",ThemeID=5}
                 ,new SubTheme{SubThemeId=33,Name="Cours de langue ",ThemeID=5}
                 ,new SubTheme{SubThemeId=34,Name=" Visite d’usine",ThemeID=5}
                 ,new SubTheme{SubThemeId=35,Name="Visite de campagne ",ThemeID=5}
                 ,new SubTheme{SubThemeId=36,Name=" Autre activité culturelle",ThemeID=5}
                 ,new SubTheme{SubThemeId=37,Name=" Cours de sciences ",ThemeID=5}
                 ,new SubTheme{SubThemeId=38,Name="conférence sur des enjeux sociaux",ThemeID=5}
                 ,new SubTheme{SubThemeId=39,Name="Danse culturelle",ThemeID=5}
                 ,new SubTheme{SubThemeId=40,Name="Visite culturelle ",ThemeID=5}
                 ,new SubTheme{SubThemeId=41,Name="visite de bureau",ThemeID=5}
                 ,new SubTheme{SubThemeId=42,Name=" Festival Culturelle",ThemeID=5}
                 ,new SubTheme{SubThemeId=43,Name=" Mariage traditionnelle",ThemeID=5}
                 ,new SubTheme{SubThemeId=44,Name="tatouage traditionnelle ",ThemeID=5}
                 ,new SubTheme{SubThemeId=45,Name=" Vivre une experience avec une famille",ThemeID=5}
                 ,new SubTheme{SubThemeId=46,Name="SeaDiving",ThemeID=6}
                 ,new SubTheme{SubThemeId=47,Name="Parachute",ThemeID=6}
                 ,new SubTheme{SubThemeId=48,Name=" Location pédale a eau/bateau",ThemeID=6}
                 ,new SubTheme{SubThemeId=49,Name="Snorking",ThemeID=6}
                 ,new SubTheme{SubThemeId=50,Name=" Bataille d’eau ",ThemeID=6}
                 ,new SubTheme{SubThemeId=51,Name="Apprendre à nager",ThemeID=6}
                 ,new SubTheme{SubThemeId=52,Name="sport nautrique",ThemeID=6}
                 ,new SubTheme{SubThemeId=53,Name="chercher des coquillages ",ThemeID=6}
                 ,new SubTheme{SubThemeId=54,Name="Bâtir des châteaux de sable",ThemeID=6}
                 ,new SubTheme{SubThemeId=55,Name="S’enterrer dans les sables",ThemeID=6}
                 ,new SubTheme{SubThemeId=56,Name="Morpion dans le sable",ThemeID=6}
                 ,new SubTheme{SubThemeId=57,Name="découvrir le chair à voile ",ThemeID=6}
                 ,new SubTheme{SubThemeId=58,Name="Jeux de ballon",ThemeID=6}
                 ,new SubTheme{SubThemeId=59,Name="Jetski",ThemeID=7}

                 ,new SubTheme{SubThemeId=60,Name="shooping",ThemeID=7}

                 ,new SubTheme{SubThemeId=61,Name="boisson",ThemeID=7}
                 ,new SubTheme{SubThemeId=62,Name="animaux",ThemeID=7}
                 ,new SubTheme{SubThemeId=63,Name="gambling",ThemeID=7}
                 ,new SubTheme{SubThemeId=64,Name="tour de bar",ThemeID=7}

            });

            modelBuilder.Entity<Theme>().HasData(new List<Theme> {
                 new Theme{ThemeID=1,Name="Nature"},
                 new Theme{ThemeID=2,Name="Health"},
                new Theme{ThemeID=3,Name="Food"},
                new Theme{ThemeID=4,Name="Event"},
                new Theme{ThemeID=5,Name="Culture"},
                new Theme{ThemeID=6,Name="Seaside"},
                new Theme{ThemeID=7,Name="autres"}
             });
        }
    }
}

