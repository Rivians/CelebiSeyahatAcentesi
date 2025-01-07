using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebiSeyahat.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changedpricecolumnplace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "HotelRooms");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "RoomTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "RoomTypes");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "HotelRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
