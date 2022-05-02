using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Migrations
{
    public partial class CardTransactionxxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardTransactions",
                columns: table => new
                {
                    CardTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportCardID = table.Column<int>(type: "int", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AmountTotal = table.Column<decimal>(type: "smallmoney", nullable: true),
                    AmountReceived = table.Column<decimal>(type: "smallmoney", nullable: true),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: true),
                    AmountDiscounted = table.Column<decimal>(type: "smallmoney", nullable: true),
                    AmountChange = table.Column<decimal>(type: "smallmoney", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTransactions", x => x.CardTransactionID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardTransactions");
        }
    }
}
