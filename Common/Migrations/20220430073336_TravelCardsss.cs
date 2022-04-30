using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Migrations
{
    public partial class TravelCardsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "UserName",
            //    table: "AspNetUsers");

            //migrationBuilder.RenameColumn(
            //    name: "Username",
            //    table: "AspNetUsers",
            //    newName: "UserName");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserName",
            //    table: "AspNetUsers",
            //    type: "nvarchar(256)",
            //    maxLength: 256,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TravelCards",
                columns: table => new
                {
                    TravelCardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardHolder = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LoadBalance = table.Column<decimal>(type: "smallmoney", nullable: true),
                    LastUsedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValidityDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsPWDCard = table.Column<bool>(type: "bit", nullable: false),
                    IsSeniorCard = table.Column<bool>(type: "bit", nullable: false),
                    SCCNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PWDNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelCards", x => x.TravelCardID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelCards");

            //migrationBuilder.RenameColumn(
            //    name: "UserName",
            //    table: "AspNetUsers",
            //    newName: "Username");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Username",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(256)",
            //    oldMaxLength: 256,
            //    oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "UserName",
            //    table: "AspNetUsers",
            //    type: "nvarchar(256)",
            //    maxLength: 256,
            //    nullable: true);
        }
    }
}
