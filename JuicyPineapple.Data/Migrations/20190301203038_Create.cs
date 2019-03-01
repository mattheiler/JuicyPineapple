using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JuicyPineapple.Data.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Organizations",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        "FK_Organizations_Organizations_ParentId",
                        x => x.ParentId,
                        "Organizations",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                "OrganizationMembership",
                table => new
                {
                    OrganizationId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationMembership", x => new { x.OrganizationId, x.UserId });
                    table.ForeignKey(
                        "FK_OrganizationMembership_Organizations_OrganizationId",
                        x => x.OrganizationId,
                        "Organizations",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_OrganizationMembership_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_OrganizationMembership_UserId",
                "OrganizationMembership",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_Organizations_ParentId",
                "Organizations",
                "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "OrganizationMembership");

            migrationBuilder.DropTable(
                "Organizations");

            migrationBuilder.DropTable(
                "Users");
        }
    }
}