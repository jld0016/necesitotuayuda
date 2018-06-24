using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NYHApp.Migrations
{
    public partial class editproposal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_Helps_IdHelp",
                table: "Proposals");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_Helps_IdHelp",
                table: "Proposals",
                column: "IdHelp",
                principalTable: "Helps",
                principalColumn: "IdHelp",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_Helps_IdHelp",
                table: "Proposals");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_Helps_IdHelp",
                table: "Proposals",
                column: "IdHelp",
                principalTable: "Helps",
                principalColumn: "IdHelp",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
