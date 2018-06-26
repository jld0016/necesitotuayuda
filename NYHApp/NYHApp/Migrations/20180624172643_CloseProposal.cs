using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NYHApp.Migrations
{
    public partial class CloseProposal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdProposalClose",
                table: "Helps",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Helps_IdProposalClose",
                table: "Helps",
                column: "IdProposalClose");

            migrationBuilder.AddForeignKey(
                name: "FK_Helps_Proposals_IdProposalClose",
                table: "Helps",
                column: "IdProposalClose",
                principalTable: "Proposals",
                principalColumn: "IdProposal",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Helps_Proposals_IdProposalClose",
                table: "Helps");

            migrationBuilder.DropIndex(
                name: "IX_Helps_IdProposalClose",
                table: "Helps");

            migrationBuilder.DropColumn(
                name: "IdProposalClose",
                table: "Helps");
        }
    }
}
