using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NYHApp.Migrations
{
    public partial class TypesJobsEnterprise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExtension",
                table: "Helps");

            migrationBuilder.RenameColumn(
                name: "IsReform",
                table: "Helps",
                newName: "IsPlumbing");

            migrationBuilder.RenameColumn(
                name: "IsNewWork",
                table: "Helps",
                newName: "IsElectricity");

            migrationBuilder.AddColumn<bool>(
                name: "IsElectricity",
                table: "Enterprises",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMansonry",
                table: "Enterprises",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPainting",
                table: "Enterprises",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPlumbing",
                table: "Enterprises",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsElectricity",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "IsMansonry",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "IsPainting",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "IsPlumbing",
                table: "Enterprises");

            migrationBuilder.RenameColumn(
                name: "IsPlumbing",
                table: "Helps",
                newName: "IsReform");

            migrationBuilder.RenameColumn(
                name: "IsElectricity",
                table: "Helps",
                newName: "IsNewWork");

            migrationBuilder.AddColumn<bool>(
                name: "IsExtension",
                table: "Helps",
                nullable: false,
                defaultValue: false);
        }
    }
}
