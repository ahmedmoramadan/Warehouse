using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WarehouseProject.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
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
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpiritionProcces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Createon = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpiritionProcces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceiveProcces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOnly = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiveProcces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.id);
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
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOnly = table.Column<DateOnly>(type: "date", nullable: false),
                    DateFinitished = table.Column<DateOnly>(type: "date", nullable: true),
                    Finitished = table.Column<bool>(type: "bit", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenders_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "expireCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpiritionProccesID = table.Column<int>(type: "int", nullable: false),
                    HeadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expireCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_expireCommittees_ExpiritionProcces_ExpiritionProccesID",
                        column: x => x.ExpiritionProccesID,
                        principalTable: "ExpiritionProcces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "covenantItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_covenantItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_covenantItems_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    ReceiveproccesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivedItems_ReceiveProcces_ReceiveproccesId",
                        column: x => x.ReceiveproccesId,
                        principalTable: "ReceiveProcces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reciveCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiveproccesID = table.Column<int>(type: "int", nullable: false),
                    HeadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reciveCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reciveCommittees_ReceiveProcces_ReceiveproccesID",
                        column: x => x.ReceiveproccesID,
                        principalTable: "ReceiveProcces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "specifictionTechnicalCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiveproccesId = table.Column<int>(type: "int", nullable: false),
                    HeadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specifictionTechnicalCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_specifictionTechnicalCommittees_ReceiveProcces_ReceiveproccesId",
                        column: x => x.ReceiveproccesId,
                        principalTable: "ReceiveProcces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    CreateOn = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Offers_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequiredItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialPrice = table.Column<int>(type: "int", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    DATEName = table.Column<DateOnly>(type: "date", nullable: true),
                    DATESAndP = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequiredItems_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectionCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    HeadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectionCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectionCommittees_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecifictionCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    HeadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecifictionCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecifictionCommittees_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    HeadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalCommittees_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "expireCommitteeMembers",
                columns: table => new
                {
                    ExpireCommitteeId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expireCommitteeMembers", x => new { x.MemberId, x.ExpireCommitteeId });
                    table.ForeignKey(
                        name: "FK_expireCommitteeMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_expireCommitteeMembers_expireCommittees_ExpireCommitteeId",
                        column: x => x.ExpireCommitteeId,
                        principalTable: "expireCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reciveCommitteeMembers",
                columns: table => new
                {
                    ReciveCommitteeId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reciveCommitteeMembers", x => new { x.MemberId, x.ReciveCommitteeId });
                    table.ForeignKey(
                        name: "FK_reciveCommitteeMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reciveCommitteeMembers_reciveCommittees_ReciveCommitteeId",
                        column: x => x.ReciveCommitteeId,
                        principalTable: "reciveCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "specifictionTechnicalCommitteeMembers",
                columns: table => new
                {
                    SpecifictionTechnicalCommitteeId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specifictionTechnicalCommitteeMembers", x => new { x.MemberId, x.SpecifictionTechnicalCommitteeId });
                    table.ForeignKey(
                        name: "FK_specifictionTechnicalCommitteeMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_specifictionTechnicalCommitteeMembers_specifictionTechnicalCommittees_SpecifictionTechnicalCommitteeId",
                        column: x => x.SpecifictionTechnicalCommitteeId,
                        principalTable: "specifictionTechnicalCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlternativeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    RequiredItemId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlternativeItems_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlternativeItems_RequiredItems_RequiredItemId",
                        column: x => x.RequiredItemId,
                        principalTable: "RequiredItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequiredItemOffers",
                columns: table => new
                {
                    RequiredItemId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredItemOffers", x => new { x.OfferId, x.RequiredItemId });
                    table.ForeignKey(
                        name: "FK_RequiredItemOffers_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequiredItemOffers_RequiredItems_RequiredItemId",
                        column: x => x.RequiredItemId,
                        principalTable: "RequiredItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectionCommitteeMembers",
                columns: table => new
                {
                    SelectionCommitteeId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectionCommitteeMembers", x => new { x.MemberId, x.SelectionCommitteeId });
                    table.ForeignKey(
                        name: "FK_SelectionCommitteeMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectionCommitteeMembers_SelectionCommittees_SelectionCommitteeId",
                        column: x => x.SelectionCommitteeId,
                        principalTable: "SelectionCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecifictionCommitteeMembers",
                columns: table => new
                {
                    SpecifictionCommitteeId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecifictionCommitteeMembers", x => new { x.MemberId, x.SpecifictionCommitteeId });
                    table.ForeignKey(
                        name: "FK_SpecifictionCommitteeMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecifictionCommitteeMembers_SpecifictionCommittees_SpecifictionCommitteeId",
                        column: x => x.SpecifictionCommitteeId,
                        principalTable: "SpecifictionCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalCommitteeMembers",
                columns: table => new
                {
                    TechnicalCommitteeId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalCommitteeMembers", x => new { x.MemberId, x.TechnicalCommitteeId });
                    table.ForeignKey(
                        name: "FK_TechnicalCommitteeMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicalCommitteeMembers_TechnicalCommittees_TechnicalCommitteeId",
                        column: x => x.TechnicalCommitteeId,
                        principalTable: "TechnicalCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ea49f11-5933-47c9-8f99-c31e80c80e00", null, "Warehouse_manager", "WAREHOUSE_MANAGER" },
                    { "1fc81189-3e7f-4a2b-b3c8-fb3e80fdc6d0", null, "Technical_Head", "TECHNICAL_HEAD" },
                    { "220df9dd-d4dc-4a3f-a080-4e7e7816fa2c", null, "Recive_Head", "RECIVE_HEAD" },
                    { "29b1feb4-f6e8-433f-bfbb-4be8f55b7f6a", null, "SpecificationTechnical_Head", "SPECIFICATIONTECHNICAL_HEAD" },
                    { "4edfac9b-c3a8-4365-9fcb-3ff9b129b98e", null, "Expire_Head", "EXPIRE_HEAD" },
                    { "a2be9f7e-c263-4be8-a4f2-c6c45acc0841", null, "Specification_Head", "SPECIFICATION_HEAD" },
                    { "d0c62d3a-3c8e-4b7c-8a61-80c1f16593ec", null, "Header", "HEADER" },
                    { "e14c35d2-8c04-40b8-b4a1-f75e694cbfc0", null, "Selection_Head", "SELECTION_HEAD" },
                    { "e9f87e27-9f6a-47ea-9e04-fdda5141666e", null, "Purchases_Manager", "PURCHASES_MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Entities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Faculty of Engineering, Shoubra" },
                    { 2, "Faculty of Medicine" },
                    { 3, "Faculty of Veterinary Medicine" },
                    { 4, "Faculty of Science" },
                    { 5, "Faculty of Agriculture" },
                    { 6, "Faculty of Commerce" },
                    { 7, "Faculty of Education" },
                    { 8, "Faculty of Law" },
                    { 9, "Faculty of Arts" },
                    { 10, "Faculty of Physical Education" },
                    { 11, "Faculty of Nursing" },
                    { 12, "Faculty of Specific Education" },
                    { 13, "Faculty of Computers and Artificial Intelligence" },
                    { 14, "Faculty of Applied Arts" },
                    { 15, "Faculty of Engineering, Benha" },
                    { 16, "Faculty of Al - Alsun(Languages)" },
                    { 17, "Faculty of Biotechnology" },
                    { 18, "Faculty of Physical Therap" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Name", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Ahmed Mohamed", "Ahmed000@111", "01142003939" },
                    { 2, "Ahmed Shapaan", "Ahmed000@111", "01252003939" },
                    { 3, "Ahmed Tamer", "Ahmed000@111", "01542213939" },
                    { 4, "Safwa Mohamed", "Safwa000@111", "01142006739" },
                    { 5, "Sohila Amr", "Sohila000@111", "01142003955" },
                    { 6, "Yasmine Abdelrhman", "Yasmine000@111", "01142004439" },
                    { 7, "Zaid Adel", "Zaid000@111", "01042223939" },
                    { 8, "Amal Sabry", "Amal000@111", "01242003933" },
                    { 9, "Dr Tarek Elsheshtawy", "Tarek000@111", "01123458983" },
                    { 10, "Eng Amainy Saaed", "Amainy000@111", "01242234939" },
                    { 11, "Dr Fady", "Fady000@111", "01542003939" },
                    { 12, "Dr Mohamed Abdelfataah", "Mohamed000@111", "01142003939" },
                    { 13, "Dr Karam", "Ahmed000@111", "01242002109" },
                    { 14, "Dr Ahmed Shalaby", "Ahmed000@111", "01240000039" },
                    { 15, "Dr Ahmed Taha", "Ahmed000@111", "01011200121" },
                    { 16, "Mahmmud Ghonam", null, "01241100023" },
                    { 17, "Rayan Ghonam", null, "01242200067" },
                    { 18, "Yousef Hiatham", null, "01244400000" },
                    { 19, "Ahmed Hosny", null, "01246700048" },
                    { 20, "Mohamed agami", null, "01242400000" },
                    { 21, "mahmoud roqa", null, "01296700048" }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "id", "Name", "number" },
                values: new object[,]
                {
                    { 1, "microsystem", "01142003939" },
                    { 2, "Arab Business", "01252003939" },
                    { 3, "PC Powerhouse", "01542213939" },
                    { 4, "LaptopLand", "01142006739" },
                    { 5, "Computers Partners", "01142003955" },
                    { 6, "ElitePC Technologies", "01142004439" },
                    { 7, "Circuit City Computers", "01042223939" },
                    { 8, "ProPanel Partners", "01242003939" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeItems_OfferId",
                table: "AlternativeItems",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeItems_RequiredItemId",
                table: "AlternativeItems",
                column: "RequiredItemId");

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
                name: "IX_covenantItems_MemberId",
                table: "covenantItems",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_expireCommitteeMembers_ExpireCommitteeId",
                table: "expireCommitteeMembers",
                column: "ExpireCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_expireCommittees_ExpiritionProccesID",
                table: "expireCommittees",
                column: "ExpiritionProccesID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_VendorId",
                table: "Offers",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedItems_ReceiveproccesId",
                table: "ReceivedItems",
                column: "ReceiveproccesId");

            migrationBuilder.CreateIndex(
                name: "IX_reciveCommitteeMembers_ReciveCommitteeId",
                table: "reciveCommitteeMembers",
                column: "ReciveCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_reciveCommittees_ReceiveproccesID",
                table: "reciveCommittees",
                column: "ReceiveproccesID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequiredItemOffers_RequiredItemId",
                table: "RequiredItemOffers",
                column: "RequiredItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredItems_TenderId",
                table: "RequiredItems",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectionCommitteeMembers_SelectionCommitteeId",
                table: "SelectionCommitteeMembers",
                column: "SelectionCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectionCommittees_TenderId",
                table: "SelectionCommittees",
                column: "TenderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecifictionCommitteeMembers_SpecifictionCommitteeId",
                table: "SpecifictionCommitteeMembers",
                column: "SpecifictionCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecifictionCommittees_TenderId",
                table: "SpecifictionCommittees",
                column: "TenderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_specifictionTechnicalCommitteeMembers_SpecifictionTechnicalCommitteeId",
                table: "specifictionTechnicalCommitteeMembers",
                column: "SpecifictionTechnicalCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_specifictionTechnicalCommittees_ReceiveproccesId",
                table: "specifictionTechnicalCommittees",
                column: "ReceiveproccesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalCommitteeMembers_TechnicalCommitteeId",
                table: "TechnicalCommitteeMembers",
                column: "TechnicalCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalCommittees_TenderId",
                table: "TechnicalCommittees",
                column: "TenderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_EntityId",
                table: "Tenders",
                column: "EntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlternativeItems");

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
                name: "covenantItems");

            migrationBuilder.DropTable(
                name: "expireCommitteeMembers");

            migrationBuilder.DropTable(
                name: "ReceivedItems");

            migrationBuilder.DropTable(
                name: "reciveCommitteeMembers");

            migrationBuilder.DropTable(
                name: "RequiredItemOffers");

            migrationBuilder.DropTable(
                name: "SelectionCommitteeMembers");

            migrationBuilder.DropTable(
                name: "SpecifictionCommitteeMembers");

            migrationBuilder.DropTable(
                name: "specifictionTechnicalCommitteeMembers");

            migrationBuilder.DropTable(
                name: "TechnicalCommitteeMembers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "expireCommittees");

            migrationBuilder.DropTable(
                name: "reciveCommittees");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "RequiredItems");

            migrationBuilder.DropTable(
                name: "SelectionCommittees");

            migrationBuilder.DropTable(
                name: "SpecifictionCommittees");

            migrationBuilder.DropTable(
                name: "specifictionTechnicalCommittees");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "TechnicalCommittees");

            migrationBuilder.DropTable(
                name: "ExpiritionProcces");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "ReceiveProcces");

            migrationBuilder.DropTable(
                name: "Tenders");

            migrationBuilder.DropTable(
                name: "Entities");
        }
    }
}
