using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DataAccess.Migrations
{
    public partial class fixed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Locations_LocationId",
                table: "Apartments");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Apartments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Locations_LocationId",
                table: "Apartments",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Locations_LocationId",
                table: "Apartments");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Apartments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Locations_LocationId",
                table: "Apartments",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
