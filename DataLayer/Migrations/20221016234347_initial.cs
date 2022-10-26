using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrenomAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Client_Telephone = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersAContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Verified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gouvernorate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delegation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CINCopy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RNECopy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenceCopy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCnss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaleWorkforce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FemaleWorkforce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasicActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CADTouristTraansp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantSpeciality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    ThemeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.ThemeID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PriceUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spots = table.Column<int>(type: "int", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTheme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationDays = table.Column<int>(type: "int", nullable: false),
                    DaysOff = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationHours = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodExist = table.Column<bool>(type: "bit", nullable: false),
                    LodgingExist = table.Column<bool>(type: "bit", nullable: false),
                    TransportExist = table.Column<bool>(type: "bit", nullable: false),
                    PetsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    OtherCritics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HostId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.ExperienceId);
                    table.ForeignKey(
                        name: "FK_Experience_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Experience_AspNetUsers_HostId",
                        column: x => x.HostId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "foodServices",
                columns: table => new
                {
                    FoodServId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    RestaurantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slogan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Rules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantRules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DishDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaysOff = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercantId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foodServices", x => x.FoodServId);
                    table.ForeignKey(
                        name: "FK_foodServices_AspNetUsers_CommercantId",
                        column: x => x.CommercantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lodgingServices",
                columns: table => new
                {
                    LodgingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LodgingCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LodgingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LodgingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LodgingAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LodgingWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LodgingDescript = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercantId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lodgingServices", x => x.LodgingId);
                    table.ForeignKey(
                        name: "FK_lodgingServices_AspNetUsers_CommercantId",
                        column: x => x.CommercantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transportServices",
                columns: table => new
                {
                    TransportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehuculeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gouvernorate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfSeatd = table.Column<int>(type: "int", nullable: false),
                    VehiculeRules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercantId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transportServices", x => x.TransportId);
                    table.ForeignKey(
                        name: "FK_transportServices_AspNetUsers_CommercantId",
                        column: x => x.CommercantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLikes",
                columns: table => new
                {
                    LikeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikes", x => x.LikeId);
                    table.ForeignKey(
                        name: "FK_UserLikes_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLikes_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubThemes",
                columns: table => new
                {
                    SubThemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThemeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubThemes", x => x.SubThemeId);
                    table.ForeignKey(
                        name: "FK_SubThemes_Themes_ThemeID",
                        column: x => x.ThemeID,
                        principalTable: "Themes",
                        principalColumn: "ThemeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    activiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDateActivity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTimeActivity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateActivity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTimeActivity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.activiteId);
                    table.ForeignKey(
                        name: "FK_Activity_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceDates",
                columns: table => new
                {
                    ExperienceDatesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTimeExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTimeExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceDates", x => x.ExperienceDatesId);
                    table.ForeignKey(
                        name: "FK_ExperienceDates_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceReservations",
                columns: table => new
                {
                    ExperienceReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IntervalTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceReservations", x => x.ExperienceReservationId);
                    table.ForeignKey(
                        name: "FK_ExperienceReservations_AspNetUsers_ClientID",
                        column: x => x.ClientID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceReservations_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "ExperienceId");
                });

            migrationBuilder.CreateTable(
                name: "Foodxperience",
                columns: table => new
                {
                    FoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameDish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foodxperience", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Foodxperience_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LodgingExperience",
                columns: table => new
                {
                    LodgingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateLodgignExp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateLodgingExp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LodgingExperience", x => x.LodgingId);
                    table.ForeignKey(
                        name: "FK_LodgingExperience_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "photosExperiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceIDFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photosExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photosExperiences_Experience_ExperienceIDFK",
                        column: x => x.ExperienceIDFK,
                        principalTable: "Experience",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportExperience",
                columns: table => new
                {
                    TransportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehiculeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    ToGoFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToGoFromDeparture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToGoTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToGoToArrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToReturnFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToReturnFromDeparture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToReturnTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToReturnToArrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportExperience", x => x.TransportId);
                    table.ForeignKey(
                        name: "FK_TransportExperience_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodReservation",
                columns: table => new
                {
                    FoodReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodServId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceFood = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Seats = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodReservation", x => x.FoodReservationId);
                    table.ForeignKey(
                        name: "FK_FoodReservation_AspNetUsers_ClientID",
                        column: x => x.ClientID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodReservation_foodServices_FoodServId",
                        column: x => x.FoodServId,
                        principalTable: "foodServices",
                        principalColumn: "FoodServId");
                });

            migrationBuilder.CreateTable(
                name: "photosFoods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodServId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photosFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photosFoods_foodServices_FoodServId",
                        column: x => x.FoodServId,
                        principalTable: "foodServices",
                        principalColumn: "FoodServId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "photosRestaurants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodServId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photosRestaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photosRestaurants_foodServices_FoodServId",
                        column: x => x.FoodServId,
                        principalTable: "foodServices",
                        principalColumn: "FoodServId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LodgingReservation",
                columns: table => new
                {
                    LodgingReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LodgingServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceLodging = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Seats = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReservationLArrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationLDeparture = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LodgingReservation", x => x.LodgingReservationId);
                    table.ForeignKey(
                        name: "FK_LodgingReservation_AspNetUsers_ClientID",
                        column: x => x.ClientID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LodgingReservation_lodgingServices_LodgingServiceId",
                        column: x => x.LodgingServiceId,
                        principalTable: "lodgingServices",
                        principalColumn: "LodgingId");
                });

            migrationBuilder.CreateTable(
                name: "photosLodgings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LodgingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photosLodgings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photosLodgings_lodgingServices_LodgingId",
                        column: x => x.LodgingId,
                        principalTable: "lodgingServices",
                        principalColumn: "LodgingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Post = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FoodServId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LodgingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransportId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "ExperienceId");
                    table.ForeignKey(
                        name: "FK_Comments_foodServices_FoodServId",
                        column: x => x.FoodServId,
                        principalTable: "foodServices",
                        principalColumn: "FoodServId");
                    table.ForeignKey(
                        name: "FK_Comments_lodgingServices_LodgingId",
                        column: x => x.LodgingId,
                        principalTable: "lodgingServices",
                        principalColumn: "LodgingId");
                    table.ForeignKey(
                        name: "FK_Comments_transportServices_TransportId",
                        column: x => x.TransportId,
                        principalTable: "transportServices",
                        principalColumn: "TransportId");
                });

            migrationBuilder.CreateTable(
                name: "photosTransports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photosTransports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photosTransports_transportServices_TransportId",
                        column: x => x.TransportId,
                        principalTable: "transportServices",
                        principalColumn: "TransportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesLikes",
                columns: table => new
                {
                    ServiceLikeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodServId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LodgingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesLikes", x => x.ServiceLikeId);
                    table.ForeignKey(
                        name: "FK_ServicesLikes_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesLikes_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "ExperienceId");
                    table.ForeignKey(
                        name: "FK_ServicesLikes_foodServices_FoodServId",
                        column: x => x.FoodServId,
                        principalTable: "foodServices",
                        principalColumn: "FoodServId");
                    table.ForeignKey(
                        name: "FK_ServicesLikes_lodgingServices_LodgingId",
                        column: x => x.LodgingId,
                        principalTable: "lodgingServices",
                        principalColumn: "LodgingId");
                    table.ForeignKey(
                        name: "FK_ServicesLikes_transportServices_TransportId",
                        column: x => x.TransportId,
                        principalTable: "transportServices",
                        principalColumn: "TransportId");
                });

            migrationBuilder.CreateTable(
                name: "TransportReservation",
                columns: table => new
                {
                    TransportReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceTransport = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateReservation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportReservation", x => x.TransportReservationId);
                    table.ForeignKey(
                        name: "FK_TransportReservation_AspNetUsers_ClientID",
                        column: x => x.ClientID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportReservation_transportServices_TransportServiceId",
                        column: x => x.TransportServiceId,
                        principalTable: "transportServices",
                        principalColumn: "TransportId");
                });

            migrationBuilder.CreateTable(
                name: "PhotosActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivitiyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotosActivities_Activity_ActivitiyId",
                        column: x => x.ActivitiyId,
                        principalTable: "Activity",
                        principalColumn: "activiteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "photosFoodExps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodxperineceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photosFoodExps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photosFoodExps_Foodxperience_FoodxperineceId",
                        column: x => x.FoodxperineceId,
                        principalTable: "Foodxperience",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "photosLodgingsExps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LodgingExperineceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photosLodgingsExps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photosLodgingsExps_LodgingExperience_LodgingExperineceId",
                        column: x => x.LodgingExperineceId,
                        principalTable: "LodgingExperience",
                        principalColumn: "LodgingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "photosTransportsExps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportExperineceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photosTransportsExps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photosTransportsExps_TransportExperience_TransportExperineceId",
                        column: x => x.TransportExperineceId,
                        principalTable: "TransportExperience",
                        principalColumn: "TransportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ea27411c-4e0f-4173-986f-8dff44f25a18", "13f8bce5-2197-4b92-93fd-a930fa870b42", "Adminisatrateur", "ADMINISTRATEUR" },
                    { "2ce052c5-c29a-4d95-abd7-a9a5118a7506", "5e1a2960-6720-4f79-8909-10bb2c919cdc", "Host", "HOST" },
                    { "73ad3d98-ebad-44fc-adee-4301ca8abdc5", "ba3cee45-6b41-41d2-ba64-d5b44daf9165", "Client", "CLIENT" },
                    { "51203033-112b-4d2a-989f-46e6d72abe1a", "df60d79d-b85c-4871-9aba-9c55c6f0bc84", "Commercant", "COMMERCANT" }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "ThemeID", "Name" },
                values: new object[,]
                {
                    { 1, "Nature" },
                    { 2, "Health" },
                    { 3, "Food" },
                    { 4, "Event" },
                    { 5, "Culture" },
                    { 6, "Seaside" },
                    { 7, "autres" }
                });

            migrationBuilder.InsertData(
                table: "SubThemes",
                columns: new[] { "SubThemeId", "Name", "ThemeID" },
                values: new object[,]
                {
                    { 1, "Camping", 1 },
                    { 35, "Visite de campagne ", 5 },
                    { 36, " Autre activité culturelle", 5 },
                    { 37, " Cours de sciences ", 5 },
                    { 38, "conférence sur des enjeux sociaux", 5 },
                    { 39, "Danse culturelle", 5 },
                    { 40, "Visite culturelle ", 5 },
                    { 41, "visite de bureau", 5 },
                    { 42, " Festival Culturelle", 5 },
                    { 43, " Mariage traditionnelle", 5 },
                    { 44, "tatouage traditionnelle ", 5 },
                    { 45, " Vivre une experience avec une famille", 5 },
                    { 46, "SeaDiving", 6 },
                    { 47, "Parachute", 6 },
                    { 34, " Visite d’usine", 5 },
                    { 48, " Location pédale a eau/bateau", 6 },
                    { 50, " Bataille d’eau ", 6 },
                    { 51, "Apprendre à nager", 6 },
                    { 52, "sport nautrique", 6 },
                    { 53, "chercher des coquillages ", 6 },
                    { 54, "Bâtir des châteaux de sable", 6 },
                    { 55, "S’enterrer dans les sables", 6 },
                    { 56, "Morpion dans le sable", 6 },
                    { 57, "découvrir le chair à voile ", 6 },
                    { 58, "Jeux de ballon", 6 },
                    { 59, "Jetski", 7 },
                    { 60, "shooping", 7 },
                    { 61, "boisson", 7 },
                    { 62, "animaux", 7 },
                    { 49, "Snorking", 6 },
                    { 33, "Cours de langue ", 5 },
                    { 32, "Conférence culturelle", 5 },
                    { 31, "Cours sur l’entrepreneuriat", 5 },
                    { 2, "Hicking", 1 },
                    { 3, "Prepare meals in nature", 1 },
                    { 4, "walking", 1 },
                    { 5, "hunt", 1 },
                    { 6, "fishing", 1 },
                    { 7, "sand diving", 1 },
                    { 8, "Ski Palmier", 1 },
                    { 9, "Back packing", 1 },
                    { 10, "Night sky", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubThemes",
                columns: new[] { "SubThemeId", "Name", "ThemeID" },
                values: new object[,]
                {
                    { 11, "Back packing", 1 },
                    { 12, "Nature and ecology tour", 1 },
                    { 13, "plante et agriculture", 1 },
                    { 14, "Activité plein air", 1 },
                    { 15, "Beauté", 2 },
                    { 16, "spa", 2 },
                    { 17, "pleine conscience", 2 },
                    { 18, "thérapie de corps", 2 },
                    { 19, "Etat d’esprit", 2 },
                    { 20, "Yoga", 2 },
                    { 21, "santé holistique", 2 },
                    { 22, "Divination", 2 },
                    { 23, "Autre Expérience Bien-être", 2 },
                    { 24, "cuisineet alimentation", 3 },
                    { 25, "degustation gastroNameique", 3 },
                    { 26, "diner en groupe", 3 },
                    { 27, "Visite de marché et gastroNameie", 3 },
                    { 28, "sport", 4 },
                    { 29, "sycling", 4 },
                    { 30, "Divertissement", 4 },
                    { 63, "gambling", 7 },
                    { 64, "tour de bar", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ExperienceId",
                table: "Activity",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ExperienceId",
                table: "Comments",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FoodServId",
                table: "Comments",
                column: "FoodServId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Id",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_LodgingId",
                table: "Comments",
                column: "LodgingId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TransportId",
                table: "Comments",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_ClientId",
                table: "Experience",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_HostId",
                table: "Experience",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceDates_ExperienceId",
                table: "ExperienceDates",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceReservations_ClientID",
                table: "ExperienceReservations",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceReservations_ExperienceId",
                table: "ExperienceReservations",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodReservation_ClientID",
                table: "FoodReservation",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodReservation_FoodServId",
                table: "FoodReservation",
                column: "FoodServId");

            migrationBuilder.CreateIndex(
                name: "IX_foodServices_CommercantId",
                table: "foodServices",
                column: "CommercantId");

            migrationBuilder.CreateIndex(
                name: "IX_Foodxperience_ExperienceId",
                table: "Foodxperience",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_LodgingExperience_ExperienceId",
                table: "LodgingExperience",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_LodgingReservation_ClientID",
                table: "LodgingReservation",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_LodgingReservation_LodgingServiceId",
                table: "LodgingReservation",
                column: "LodgingServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_lodgingServices_CommercantId",
                table: "lodgingServices",
                column: "CommercantId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosActivities_ActivitiyId",
                table: "PhotosActivities",
                column: "ActivitiyId");

            migrationBuilder.CreateIndex(
                name: "IX_photosExperiences_ExperienceIDFK",
                table: "photosExperiences",
                column: "ExperienceIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_photosFoodExps_FoodxperineceId",
                table: "photosFoodExps",
                column: "FoodxperineceId");

            migrationBuilder.CreateIndex(
                name: "IX_photosFoods_FoodServId",
                table: "photosFoods",
                column: "FoodServId");

            migrationBuilder.CreateIndex(
                name: "IX_photosLodgings_LodgingId",
                table: "photosLodgings",
                column: "LodgingId");

            migrationBuilder.CreateIndex(
                name: "IX_photosLodgingsExps_LodgingExperineceId",
                table: "photosLodgingsExps",
                column: "LodgingExperineceId");

            migrationBuilder.CreateIndex(
                name: "IX_photosRestaurants_FoodServId",
                table: "photosRestaurants",
                column: "FoodServId");

            migrationBuilder.CreateIndex(
                name: "IX_photosTransports_TransportId",
                table: "photosTransports",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_photosTransportsExps_TransportExperineceId",
                table: "photosTransportsExps",
                column: "TransportExperineceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesLikes_ExperienceId",
                table: "ServicesLikes",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesLikes_FoodServId",
                table: "ServicesLikes",
                column: "FoodServId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesLikes_Id",
                table: "ServicesLikes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesLikes_LodgingId",
                table: "ServicesLikes",
                column: "LodgingId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesLikes_TransportId",
                table: "ServicesLikes",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_SubThemes_ThemeID",
                table: "SubThemes",
                column: "ThemeID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportExperience_ExperienceId",
                table: "TransportExperience",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportReservation_ClientID",
                table: "TransportReservation",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportReservation_TransportServiceId",
                table: "TransportReservation",
                column: "TransportServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_transportServices_CommercantId",
                table: "transportServices",
                column: "CommercantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_ClientId",
                table: "UserLikes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_Id",
                table: "UserLikes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "ExperienceDates");

            migrationBuilder.DropTable(
                name: "ExperienceReservations");

            migrationBuilder.DropTable(
                name: "FoodReservation");

            migrationBuilder.DropTable(
                name: "LodgingReservation");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "PhotosActivities");

            migrationBuilder.DropTable(
                name: "photosExperiences");

            migrationBuilder.DropTable(
                name: "photosFoodExps");

            migrationBuilder.DropTable(
                name: "photosFoods");

            migrationBuilder.DropTable(
                name: "photosLodgings");

            migrationBuilder.DropTable(
                name: "photosLodgingsExps");

            migrationBuilder.DropTable(
                name: "photosRestaurants");

            migrationBuilder.DropTable(
                name: "photosTransports");

            migrationBuilder.DropTable(
                name: "photosTransportsExps");

            migrationBuilder.DropTable(
                name: "ServicesLikes");

            migrationBuilder.DropTable(
                name: "SubThemes");

            migrationBuilder.DropTable(
                name: "TransportReservation");

            migrationBuilder.DropTable(
                name: "UserLikes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Foodxperience");

            migrationBuilder.DropTable(
                name: "LodgingExperience");

            migrationBuilder.DropTable(
                name: "TransportExperience");

            migrationBuilder.DropTable(
                name: "foodServices");

            migrationBuilder.DropTable(
                name: "lodgingServices");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "transportServices");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
