using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Migrations
{
    public partial class Trips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_CardTransactions_TransportCards_TransportCardID",
            //    table: "CardTransactions");

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("103580e7-9745-4478-b615-f91c0e3b7cce"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("10b17efc-ed6f-4a55-90bb-2426cceb971e"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("1a639ece-f89d-4dbe-a2c0-77e18167ab20"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("27acfeb2-82f6-4601-bd01-feceeea36b56"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("70ac4f66-7b07-4f61-99cf-ca5c8f2fd47f"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("a01ccf75-99ee-4f84-ad3e-a3100b1becb3"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("a2d1e49b-89b3-4b08-ae13-d2d15c8fad1a"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("cf78f8b5-6396-4c61-9505-d477ab55d87c"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("cfbebb1d-b650-4008-86cf-e5fef21ff39a"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("e30f5299-0441-4cf5-89a4-083a33d74d2f"));

            migrationBuilder.AlterColumn<int>(
                name: "TransportCardID",
                table: "CardTransactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "TransportCardTripID",
                table: "CardTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "TrainStations",
                columns: new[] { "TrainStationID", "CreatedBy", "CreatedDate", "IsActive", "TrainStationCode", "TrainStationNumber", "TransportCardTripID", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("01b05b3d-1bc4-4799-97b9-0544bc62d6bb"), "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8486), true, "ST9", 9, null, "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8486) },
                    { new Guid("24823ea3-cded-4cc6-8883-b00bd5337c53"), "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8457), true, "ST6", 6, null, "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8458) },
                    { new Guid("426d1f8a-b0b9-4cd4-aa3f-06c3613618c8"), "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8446), true, "ST5", 5, null, "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8447) },
                    { new Guid("4e5f651a-74b1-4003-a766-7aad6606ff6a"), "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8476), true, "ST8", 8, null, "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8476) },
                    { new Guid("85e33ee2-fbbc-4ee6-8251-b513f5a93f02"), "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8429), true, "ST3", 3, null, "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8430) },
                    { new Guid("8bf2005e-b99d-4f4f-bcd6-6a6fb7645950"), "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8418), true, "ST2", 2, null, "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8418) },
                    { new Guid("b492bbfe-ca87-421d-a995-25cc07c67c91"), "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8438), true, "ST4", 4, null, "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8438) },
                    { new Guid("bf6b46ab-2481-4827-9ae3-26a2a0ce8fbc"), "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8498), true, "ST10", 10, null, "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8498) },
                    { new Guid("d5a29648-cc69-4de0-b48d-28a46904602b"), "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8303), true, "ST1", 1, null, "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8305) },
                    { new Guid("da335b27-f13f-4438-b2dc-e63f3989bbb5"), "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8467), true, "ST7", 7, null, "ADMIN", new DateTime(2022, 5, 3, 22, 6, 10, 645, DateTimeKind.Utc).AddTicks(8467) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardTransactions_TransportCardTripID",
                table: "CardTransactions",
                column: "TransportCardTripID");

            migrationBuilder.AddForeignKey(
                name: "FK_CardTransactions_TransportCards_TransportCardID",
                table: "CardTransactions",
                column: "TransportCardID",
                principalTable: "TransportCards",
                principalColumn: "TransportCardID");

            migrationBuilder.AddForeignKey(
                name: "FK_CardTransactions_TransportCardTrips_TransportCardTripID",
                table: "CardTransactions",
                column: "TransportCardTripID",
                principalTable: "TransportCardTrips",
                principalColumn: "TransportCardTripID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_CardTransactions_TransportCards_TransportCardID",
            //    table: "CardTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_CardTransactions_TransportCardTrips_TransportCardTripID",
                table: "CardTransactions");

            migrationBuilder.DropIndex(
                name: "IX_CardTransactions_TransportCardTripID",
                table: "CardTransactions");

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("01b05b3d-1bc4-4799-97b9-0544bc62d6bb"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("24823ea3-cded-4cc6-8883-b00bd5337c53"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("426d1f8a-b0b9-4cd4-aa3f-06c3613618c8"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("4e5f651a-74b1-4003-a766-7aad6606ff6a"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("85e33ee2-fbbc-4ee6-8251-b513f5a93f02"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("8bf2005e-b99d-4f4f-bcd6-6a6fb7645950"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("b492bbfe-ca87-421d-a995-25cc07c67c91"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("bf6b46ab-2481-4827-9ae3-26a2a0ce8fbc"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("d5a29648-cc69-4de0-b48d-28a46904602b"));

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "TrainStationID",
                keyValue: new Guid("da335b27-f13f-4438-b2dc-e63f3989bbb5"));

            migrationBuilder.DropColumn(
                name: "TransportCardTripID",
                table: "CardTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "TransportCardID",
                table: "CardTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CardTransactions_TransportCards_TransportCardID",
                table: "CardTransactions",
                column: "TransportCardID",
                principalTable: "TransportCards",
                principalColumn: "TransportCardID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
