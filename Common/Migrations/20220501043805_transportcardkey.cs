using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Migrations
{
    public partial class transportcardkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportCards",
                columns: table => new
                {
                    TransportCardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardHolder = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LoadBalance = table.Column<decimal>(type: "smallmoney", nullable: true),
                    LastUsedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValidityDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsPWDCard = table.Column<bool>(type: "bit", nullable: true),
                    IsSeniorCard = table.Column<bool>(type: "bit", nullable: true),
                    SCCNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PWDNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SmartCardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportCards", x => x.TransportCardID);
                    table.ForeignKey(
                        name: "FK_TransportCards_RAWSMARTCARDs_SmartCardID",
                        column: x => x.SmartCardID,
                        principalTable: "RAWSMARTCARDs",
                        principalColumn: "SmartCardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportCards_SmartCardID",
                table: "TransportCards",
                column: "SmartCardID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportCards");
        }
    }
}
