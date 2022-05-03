using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Migrations
{
    public partial class DestinationsStaT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportCardTrips",
                columns: table => new
                {
                    TransportCardTripID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportCardTripDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AmountTripCharge = table.Column<decimal>(type: "smallmoney", nullable: true),
                    TransportCardTripOperatorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginStationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationStationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasGateIN = table.Column<bool>(type: "bit", nullable: false),
                    HasGateOUT = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    TransportCardID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportCardTrips", x => x.TransportCardTripID);
                    table.ForeignKey(
                        name: "FK_TransportCardTrips_TransportCards_TransportCardID",
                        column: x => x.TransportCardID,
                        principalTable: "TransportCards",
                        principalColumn: "TransportCardID");
                });

            migrationBuilder.CreateTable(
                name: "TrainStations",
                columns: table => new
                {
                    TrainStationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainStationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainStationNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    TransportCardTripID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainStations", x => x.TrainStationID);
                    table.ForeignKey(
                        name: "FK_TrainStations_TransportCardTrips_TransportCardTripID",
                        column: x => x.TransportCardTripID,
                        principalTable: "TransportCardTrips",
                        principalColumn: "TransportCardTripID");
                });

            migrationBuilder.InsertData(
                table: "TrainStations",
                columns: new[] { "TrainStationID", "CreatedBy", "CreatedDate", "IsActive", "TrainStationCode", "TrainStationNumber", "TransportCardTripID", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("103580e7-9745-4478-b615-f91c0e3b7cce"), "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9289), true, "ST9", 9, null, "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9289) },
                    { new Guid("10b17efc-ed6f-4a55-90bb-2426cceb971e"), "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9307), true, "ST10", 10, null, "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9308) },
                    { new Guid("1a639ece-f89d-4dbe-a2c0-77e18167ab20"), "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9180), true, "ST4", 4, null, "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9180) },
                    { new Guid("27acfeb2-82f6-4601-bd01-feceeea36b56"), "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9196), true, "ST5", 5, null, "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9197) },
                    { new Guid("70ac4f66-7b07-4f61-99cf-ca5c8f2fd47f"), "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9050), true, "ST1", 1, null, "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9053) },
                    { new Guid("a01ccf75-99ee-4f84-ad3e-a3100b1becb3"), "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9255), true, "ST7", 7, null, "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9256) },
                    { new Guid("a2d1e49b-89b3-4b08-ae13-d2d15c8fad1a"), "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9272), true, "ST8", 8, null, "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9273) },
                    { new Guid("cf78f8b5-6396-4c61-9505-d477ab55d87c"), "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9142), true, "ST2", 2, null, "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9142) },
                    { new Guid("cfbebb1d-b650-4008-86cf-e5fef21ff39a"), "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9217), true, "ST6", 6, null, "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9218) },
                    { new Guid("e30f5299-0441-4cf5-89a4-083a33d74d2f"), "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9162), true, "ST3", 3, null, "ADMIN", new DateTime(2022, 5, 3, 14, 55, 16, 90, DateTimeKind.Utc).AddTicks(9163) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainStations_TransportCardTripID",
                table: "TrainStations",
                column: "TransportCardTripID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportCardTrips_TransportCardID",
                table: "TransportCardTrips",
                column: "TransportCardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainStations");

            migrationBuilder.DropTable(
                name: "TransportCardTrips");
        }
    }
}
