using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NYHApp.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_Provinces_IdProvince",
                table: "Enterprises");

            migrationBuilder.DropForeignKey(
                name: "FK_Helps_Provinces_IdProvince",
                table: "Helps");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Provinces_IdProvince",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdProvince",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Helps_IdProvince",
                table: "Helps");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_IdProvince",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "IdProvince",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdProvince",
                table: "Helps");

            migrationBuilder.DropColumn(
                name: "IdProvince",
                table: "Enterprises");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Helps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Enterprises",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Helps");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Enterprises");

            migrationBuilder.AddColumn<int>(
                name: "IdProvince",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProvince",
                table: "Helps",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProvince",
                table: "Enterprises",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdProvince",
                table: "Users",
                column: "IdProvince");

            migrationBuilder.CreateIndex(
                name: "IX_Helps_IdProvince",
                table: "Helps",
                column: "IdProvince");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_IdProvince",
                table: "Enterprises",
                column: "IdProvince");

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises_Provinces_IdProvince",
                table: "Enterprises",
                column: "IdProvince",
                principalTable: "Provinces",
                principalColumn: "IdProvince",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Helps_Provinces_IdProvince",
                table: "Helps",
                column: "IdProvince",
                principalTable: "Provinces",
                principalColumn: "IdProvince",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Provinces_IdProvince",
                table: "Users",
                column: "IdProvince",
                principalTable: "Provinces",
                principalColumn: "IdProvince",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
