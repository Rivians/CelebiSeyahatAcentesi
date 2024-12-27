using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebiSeyahat.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changedtablenamestypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Citys_CityId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TransportationCompanys_TransportationCompanyId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_TransportationCompanys_TransportationCompanyId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransportationCompanys",
                table: "TransportationCompanys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Citys",
                table: "Citys");

            migrationBuilder.RenameTable(
                name: "TransportationCompanys",
                newName: "TransportationCompanies");

            migrationBuilder.RenameTable(
                name: "Citys",
                newName: "Cities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransportationCompanies",
                table: "TransportationCompanies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TransportationCompanies_TransportationCompanyId",
                table: "Tickets",
                column: "TransportationCompanyId",
                principalTable: "TransportationCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_TransportationCompanies_TransportationCompanyId",
                table: "Trips",
                column: "TransportationCompanyId",
                principalTable: "TransportationCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TransportationCompanies_TransportationCompanyId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_TransportationCompanies_TransportationCompanyId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransportationCompanies",
                table: "TransportationCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "TransportationCompanies",
                newName: "TransportationCompanys");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "Citys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransportationCompanys",
                table: "TransportationCompanys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Citys",
                table: "Citys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Citys_CityId",
                table: "Districts",
                column: "CityId",
                principalTable: "Citys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TransportationCompanys_TransportationCompanyId",
                table: "Tickets",
                column: "TransportationCompanyId",
                principalTable: "TransportationCompanys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_TransportationCompanys_TransportationCompanyId",
                table: "Trips",
                column: "TransportationCompanyId",
                principalTable: "TransportationCompanys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
