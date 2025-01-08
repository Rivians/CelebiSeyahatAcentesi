using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebiSeyahat.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class minimalsss2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HotelReservationId",
                table: "Guests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_HotelReservationId",
                table: "Guests",
                column: "HotelReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_HotelReservations_HotelReservationId",
                table: "Guests",
                column: "HotelReservationId",
                principalTable: "HotelReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_HotelReservations_HotelReservationId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_HotelReservationId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "HotelReservationId",
                table: "Guests");
        }
    }
}
