using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NYHApp.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_IdGroup",
                table: "Users");

            migrationBuilder.DropTable(
                name: "RolesGroups");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdGroup",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdGroup",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdGroup",
                table: "Users",
                nullable: true);

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
                name: "IX_Users_IdGroup",
                table: "Users",
                column: "IdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_RolesGroups_IdRole",
                table: "RolesGroups",
                column: "IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_IdGroup",
                table: "Users",
                column: "IdGroup",
                principalTable: "Groups",
                principalColumn: "IdGroup",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
