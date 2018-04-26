using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NYHApp.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastModified",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Door",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCountry",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdGroup",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProvince",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTypeRoad",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIF",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone1",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone2",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname1",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname2",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnstructuredAddress",
                table: "Users",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdCountry",
                table: "Users",
                column: "IdCountry");

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
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_Roles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Users_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Users_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Roles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Users_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Users_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_IdCountry",
                table: "Users",
                column: "IdCountry",
                principalTable: "Countries",
                principalColumn: "IdCountry",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_IdGroup",
                table: "Users",
                column: "IdGroup",
                principalTable: "Groups",
                principalColumn: "IdGroup",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Provinces_IdProvince",
                table: "Users",
                column: "IdProvince",
                principalTable: "Provinces",
                principalColumn: "IdProvince",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TypesRoads_IdTypeRoad",
                table: "Users",
                column: "IdTypeRoad",
                principalTable: "TypesRoads",
                principalColumn: "IdTypeRoad",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_Roles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_Users_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_Users_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Roles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Users_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_Users_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_IdCountry",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_IdGroup",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Provinces_IdProvince",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_TypesRoads_IdTypeRoad",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "RolesGroups");

            migrationBuilder.DropTable(
                name: "TypesRoads");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdCountry",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdGroup",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdProvince",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdTypeRoad",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Door",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdCountry",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdGroup",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdProvince",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdTypeRoad",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NIF",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone2",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Surname1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Surname2",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UnstructuredAddress",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "AspNetUsers",
                newName: "PasswordHash");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
