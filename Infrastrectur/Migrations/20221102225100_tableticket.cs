using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrectur.Migrations
{
    public partial class tableticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.AddColumn<string>(
                name: "PassengerPassportNumber",
                table: "Flights",
                type: "nvarchar(7)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    FlightFk = table.Column<int>(type: "int", nullable: false),
                    PassengerFk = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    Siege = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vip = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.PassengerFk, x.FlightFk });
                    table.ForeignKey(
                        name: "FK_Tickets_Flights_FlightFk",
                        column: x => x.FlightFk,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerFk",
                        column: x => x.PassengerFk,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PassengerPassportNumber",
                table: "Flights",
                column: "PassengerPassportNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FlightFk",
                table: "Tickets",
                column: "FlightFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Passengers_PassengerPassportNumber",
                table: "Flights",
                column: "PassengerPassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Passengers_PassengerPassportNumber",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PassengerPassportNumber",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "PassengerPassportNumber",
                table: "Flights");

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    FlightsFlightId = table.Column<int>(type: "int", nullable: false),
                    PassengersPassportNumber = table.Column<string>(type: "nvarchar(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => new { x.FlightsFlightId, x.PassengersPassportNumber });
                    table.ForeignKey(
                        name: "FK_Reservation_Flights_FlightsFlightId",
                        column: x => x.FlightsFlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Passengers_PassengersPassportNumber",
                        column: x => x.PassengersPassportNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PassengersPassportNumber",
                table: "Reservation",
                column: "PassengersPassportNumber");
        }
    }
}
