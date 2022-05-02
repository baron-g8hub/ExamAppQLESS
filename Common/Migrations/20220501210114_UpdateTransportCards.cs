using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Migrations
{
    public partial class UpdateTransportCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportCards_RAWSMARTCARDs_SmartCardID",
                table: "TransportCards");

            migrationBuilder.DropIndex(
                name: "IX_TransportCards_SmartCardID",
                table: "TransportCards");

            migrationBuilder.RenameColumn(
                name: "SmartCardID",
                table: "TransportCards",
                newName: "RAWSMARTCARDSmartCardID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportCards_RAWSMARTCARDSmartCardID",
                table: "TransportCards",
                column: "RAWSMARTCARDSmartCardID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportCards_RAWSMARTCARDs_RAWSMARTCARDSmartCardID",
                table: "TransportCards",
                column: "RAWSMARTCARDSmartCardID",
                principalTable: "RAWSMARTCARDs",
                principalColumn: "SmartCardID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportCards_RAWSMARTCARDs_RAWSMARTCARDSmartCardID",
                table: "TransportCards");

            migrationBuilder.DropIndex(
                name: "IX_TransportCards_RAWSMARTCARDSmartCardID",
                table: "TransportCards");

            migrationBuilder.RenameColumn(
                name: "RAWSMARTCARDSmartCardID",
                table: "TransportCards",
                newName: "SmartCardID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportCards_SmartCardID",
                table: "TransportCards",
                column: "SmartCardID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportCards_RAWSMARTCARDs_SmartCardID",
                table: "TransportCards",
                column: "SmartCardID",
                principalTable: "RAWSMARTCARDs",
                principalColumn: "SmartCardID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
