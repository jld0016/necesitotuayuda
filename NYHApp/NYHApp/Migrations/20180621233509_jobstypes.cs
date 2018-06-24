using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NYHApp.Migrations
{
    public partial class jobstypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    IdJob = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.IdJob);
                });

            migrationBuilder.CreateTable(
                name: "EnterprisesJobs",
                columns: table => new
                {
                    IdEnterprise = table.Column<long>(nullable: false),
                    IdJob = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterprisesJobs", x => new { x.IdEnterprise, x.IdJob });
                    table.ForeignKey(
                        name: "FK_EnterprisesJobs_Enterprises_IdEnterprise",
                        column: x => x.IdEnterprise,
                        principalTable: "Enterprises",
                        principalColumn: "IdEnterprise",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnterprisesJobs_Jobs_IdJob",
                        column: x => x.IdJob,
                        principalTable: "Jobs",
                        principalColumn: "IdJob",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HelpsJobs",
                columns: table => new
                {
                    IdHelp = table.Column<long>(nullable: false),
                    IdJob = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpsJobs", x => new { x.IdHelp, x.IdJob });
                    table.ForeignKey(
                        name: "FK_HelpsJobs_Helps_IdHelp",
                        column: x => x.IdHelp,
                        principalTable: "Helps",
                        principalColumn: "IdHelp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HelpsJobs_Jobs_IdJob",
                        column: x => x.IdJob,
                        principalTable: "Jobs",
                        principalColumn: "IdJob",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypesJobs",
                columns: table => new
                {
                    IdTypeJob = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdJob = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesJobs", x => x.IdTypeJob);
                    table.ForeignKey(
                        name: "FK_TypesJobs_Jobs_IdJob",
                        column: x => x.IdJob,
                        principalTable: "Jobs",
                        principalColumn: "IdJob",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnterprisesTypesJob",
                columns: table => new
                {
                    IdTypeJob = table.Column<long>(nullable: false),
                    IdEnterprise = table.Column<long>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterprisesTypesJob", x => new { x.IdTypeJob, x.IdEnterprise });
                    table.ForeignKey(
                        name: "FK_EnterprisesTypesJob_Enterprises_IdEnterprise",
                        column: x => x.IdEnterprise,
                        principalTable: "Enterprises",
                        principalColumn: "IdEnterprise",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnterprisesTypesJob_TypesJobs_IdTypeJob",
                        column: x => x.IdTypeJob,
                        principalTable: "TypesJobs",
                        principalColumn: "IdTypeJob",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HelpsTypesJob",
                columns: table => new
                {
                    IdHelp = table.Column<long>(nullable: false),
                    IdTypeJob = table.Column<long>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpsTypesJob", x => new { x.IdHelp, x.IdTypeJob });
                    table.ForeignKey(
                        name: "FK_HelpsTypesJob_Helps_IdHelp",
                        column: x => x.IdHelp,
                        principalTable: "Helps",
                        principalColumn: "IdHelp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HelpsTypesJob_TypesJobs_IdTypeJob",
                        column: x => x.IdTypeJob,
                        principalTable: "TypesJobs",
                        principalColumn: "IdTypeJob",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnterprisesJobs_IdJob",
                table: "EnterprisesJobs",
                column: "IdJob");

            migrationBuilder.CreateIndex(
                name: "IX_EnterprisesTypesJob_IdEnterprise",
                table: "EnterprisesTypesJob",
                column: "IdEnterprise");

            migrationBuilder.CreateIndex(
                name: "IX_HelpsJobs_IdJob",
                table: "HelpsJobs",
                column: "IdJob");

            migrationBuilder.CreateIndex(
                name: "IX_HelpsTypesJob_IdTypeJob",
                table: "HelpsTypesJob",
                column: "IdTypeJob");

            migrationBuilder.CreateIndex(
                name: "IX_TypesJobs_IdJob",
                table: "TypesJobs",
                column: "IdJob");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnterprisesJobs");

            migrationBuilder.DropTable(
                name: "EnterprisesTypesJob");

            migrationBuilder.DropTable(
                name: "HelpsJobs");

            migrationBuilder.DropTable(
                name: "HelpsTypesJob");

            migrationBuilder.DropTable(
                name: "TypesJobs");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
