using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DataAccess.Migrations
{
    public partial class @fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApartmentId",
                table: "ApartmentReviews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentReviews_ApartmentId",
                table: "ApartmentReviews",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentReviews_Apartments_ApartmentId",
                table: "ApartmentReviews",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentReviews_Apartments_ApartmentId",
                table: "ApartmentReviews");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentReviews_ApartmentId",
                table: "ApartmentReviews");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "ApartmentReviews");
        }
    }
}
