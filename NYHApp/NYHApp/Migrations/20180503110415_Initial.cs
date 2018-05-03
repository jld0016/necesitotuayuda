using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NYHApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    IdCountry = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.IdCountry);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    IdGroup = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.IdGroup);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    IdProvince = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.IdProvince);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesRoads",
                columns: table => new
                {
                    IdTypeRoad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesRoads", x => x.IdTypeRoad);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolesGroups",
                columns: table => new
                {
                    IdGroup = table.Column<int>(nullable: false),
                    IdRole = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesGroups", x => new { x.IdGroup, x.IdRole });
                    table.ForeignKey(
                        name: "FK_RolesGroups_Groups_IdGroup",
                        column: x => x.IdGroup,
                        principalTable: "Groups",
                        principalColumn: "IdGroup",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesGroups_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    IdEnterprise = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    CIF = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    CodeEnterprise = table.Column<string>(nullable: false),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    Door = table.Column<string>(nullable: true),
                    FiscalName = table.Column<string>(nullable: true),
                    Floor = table.Column<string>(nullable: true),
                    IdCountry = table.Column<int>(nullable: false),
                    IdProvince = table.Column<int>(nullable: true),
                    IdTypeRoad = table.Column<int>(nullable: false),
                    IdUserAdministrator = table.Column<string>(nullable: true),
                    IdUserLastModified = table.Column<string>(nullable: true),
                    Latitute = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Phone1 = table.Column<string>(nullable: false),
                    Phone2 = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    UnstructuredAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprises", x => x.IdEnterprise);
                    table.ForeignKey(
                        name: "FK_Enterprises_Countries_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Countries",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enterprises_Provinces_IdProvince",
                        column: x => x.IdProvince,
                        principalTable: "Provinces",
                        principalColumn: "IdProvince",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enterprises_TypesRoads_IdTypeRoad",
                        column: x => x.IdTypeRoad,
                        principalTable: "TypesRoads",
                        principalColumn: "IdTypeRoad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    Door = table.Column<string>(nullable: true),
                    Floor = table.Column<string>(nullable: true),
                    IdCountry = table.Column<int>(nullable: true),
                    IdEnterprise = table.Column<long>(nullable: true),
                    IdGroup = table.Column<int>(nullable: true),
                    IdProvince = table.Column<int>(nullable: true),
                    IdTypeRoad = table.Column<int>(nullable: true),
                    NIF = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Phone1 = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Surname1 = table.Column<string>(nullable: true),
                    Surname2 = table.Column<string>(nullable: true),
                    UnstructuredAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Countries_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Countries",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Enterprises_IdEnterprise",
                        column: x => x.IdEnterprise,
                        principalTable: "Enterprises",
                        principalColumn: "IdEnterprise",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Groups_IdGroup",
                        column: x => x.IdGroup,
                        principalTable: "Groups",
                        principalColumn: "IdGroup",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Provinces_IdProvince",
                        column: x => x.IdProvince,
                        principalTable: "Provinces",
                        principalColumn: "IdProvince",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_TypesRoads_IdTypeRoad",
                        column: x => x.IdTypeRoad,
                        principalTable: "TypesRoads",
                        principalColumn: "IdTypeRoad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Helps",
                columns: table => new
                {
                    IdHelp = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Close = table.Column<bool>(nullable: false),
                    CloseDate = table.Column<DateTime>(nullable: true),
                    CodeHelp = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Door = table.Column<string>(nullable: true),
                    Floor = table.Column<string>(nullable: true),
                    IdCountry = table.Column<int>(nullable: false),
                    IdProvince = table.Column<int>(nullable: true),
                    IdTypeRoad = table.Column<int>(nullable: false),
                    IdUser = table.Column<string>(nullable: false),
                    IdUserLastModified = table.Column<string>(nullable: true),
                    IsExtension = table.Column<bool>(nullable: false),
                    IsMansonry = table.Column<bool>(nullable: false),
                    IsNewWork = table.Column<bool>(nullable: false),
                    IsPainting = table.Column<bool>(nullable: false),
                    IsReform = table.Column<bool>(nullable: false),
                    Latitute = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Phone1 = table.Column<string>(nullable: false),
                    Phone2 = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    UnstructuredAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helps", x => x.IdHelp);
                    table.ForeignKey(
                        name: "FK_Helps_Countries_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Countries",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Helps_Provinces_IdProvince",
                        column: x => x.IdProvince,
                        principalTable: "Provinces",
                        principalColumn: "IdProvince",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Helps_TypesRoads_IdTypeRoad",
                        column: x => x.IdTypeRoad,
                        principalTable: "TypesRoads",
                        principalColumn: "IdTypeRoad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Helps_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Helps_Users_IdUserLastModified",
                        column: x => x.IdUserLastModified,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    IdPhoto = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    DateUpload = table.Column<DateTime>(nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    IdHelp = table.Column<long>(nullable: false),
                    IdUserLastModified = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.IdPhoto);
                    table.ForeignKey(
                        name: "FK_Photos_Helps_IdHelp",
                        column: x => x.IdHelp,
                        principalTable: "Helps",
                        principalColumn: "IdHelp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photos_Users_IdUserLastModified",
                        column: x => x.IdUserLastModified,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    IdProposal = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IdEnterprise = table.Column<long>(nullable: false),
                    IdHelp = table.Column<long>(nullable: false),
                    IdUserLastModified = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.IdProposal);
                    table.ForeignKey(
                        name: "FK_Proposals_Enterprises_IdEnterprise",
                        column: x => x.IdEnterprise,
                        principalTable: "Enterprises",
                        principalColumn: "IdEnterprise",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proposals_Helps_IdHelp",
                        column: x => x.IdHelp,
                        principalTable: "Helps",
                        principalColumn: "IdHelp",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proposals_Users_IdUserLastModified",
                        column: x => x.IdUserLastModified,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinesProposals",
                columns: table => new
                {
                    IdLineProposal = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IdProposal = table.Column<long>(nullable: false),
                    IdUserLastModified = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    UserLastModifiedId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinesProposals", x => x.IdLineProposal);
                    table.ForeignKey(
                        name: "FK_LinesProposals_Proposals_IdProposal",
                        column: x => x.IdProposal,
                        principalTable: "Proposals",
                        principalColumn: "IdProposal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinesProposals_Users_UserLastModifiedId",
                        column: x => x.UserLastModifiedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

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
                name: "IX_Enterprises_IdCountry",
                table: "Enterprises",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_IdProvince",
                table: "Enterprises",
                column: "IdProvince");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_IdTypeRoad",
                table: "Enterprises",
                column: "IdTypeRoad");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_IdUserAdministrator",
                table: "Enterprises",
                column: "IdUserAdministrator");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_IdUserLastModified",
                table: "Enterprises",
                column: "IdUserLastModified");

            migrationBuilder.CreateIndex(
                name: "IX_Helps_IdCountry",
                table: "Helps",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Helps_IdProvince",
                table: "Helps",
                column: "IdProvince");

            migrationBuilder.CreateIndex(
                name: "IX_Helps_IdTypeRoad",
                table: "Helps",
                column: "IdTypeRoad");

            migrationBuilder.CreateIndex(
                name: "IX_Helps_IdUser",
                table: "Helps",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Helps_IdUserLastModified",
                table: "Helps",
                column: "IdUserLastModified");

            migrationBuilder.CreateIndex(
                name: "IX_LinesProposals_IdProposal",
                table: "LinesProposals",
                column: "IdProposal");

            migrationBuilder.CreateIndex(
                name: "IX_LinesProposals_UserLastModifiedId",
                table: "LinesProposals",
                column: "UserLastModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_IdHelp",
                table: "Photos",
                column: "IdHelp");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_IdUserLastModified",
                table: "Photos",
                column: "IdUserLastModified");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_IdEnterprise",
                table: "Proposals",
                column: "IdEnterprise");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_IdHelp",
                table: "Proposals",
                column: "IdHelp");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_IdUserLastModified",
                table: "Proposals",
                column: "IdUserLastModified");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RolesGroups_IdRole",
                table: "RolesGroups",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdCountry",
                table: "Users",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdEnterprise",
                table: "Users",
                column: "IdEnterprise");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdGroup",
                table: "Users",
                column: "IdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdProvince",
                table: "Users",
                column: "IdProvince");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdTypeRoad",
                table: "Users",
                column: "IdTypeRoad");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises_Users_IdUserAdministrator",
                table: "Enterprises",
                column: "IdUserAdministrator",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises_Users_IdUserLastModified",
                table: "Enterprises",
                column: "IdUserLastModified",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_Users_IdUserAdministrator",
                table: "Enterprises");

            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_Users_IdUserLastModified",
                table: "Enterprises");

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
                name: "LinesProposals");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "RolesGroups");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Helps");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "TypesRoads");
        }
    }
}
