using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebiSeyahat.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changedminorchangesinhotelRomm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelRoomTypeId",
                table: "HotelRooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HotelRoomTypeId",
                table: "HotelRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
