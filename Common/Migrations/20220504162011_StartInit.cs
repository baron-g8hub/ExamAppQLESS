using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Migrations
{
    public partial class StartInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleLevel = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenEmpUIDs",
                columns: table => new
                {
                    GeneratedUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GeneratedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1001, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenEmpUIDs", x => x.GeneratedUID);
                });

            migrationBuilder.CreateTable(
                name: "RAWSMARTCARDs",
                columns: table => new
                {
                    SmartCardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmartCardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ActivatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeactivatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAWSMARTCARDs", x => x.SmartCardID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeUID);
                    table.ForeignKey(
                        name: "FK_Employees_GenEmpUIDs_EmployeeUID",
                        column: x => x.EmployeeUID,
                        principalTable: "GenEmpUIDs",
                        principalColumn: "GeneratedUID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    RAWSMARTCARDSmartCardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportCards", x => x.TransportCardID);
                    table.ForeignKey(
                        name: "FK_TransportCards_RAWSMARTCARDs_RAWSMARTCARDSmartCardID",
                        column: x => x.RAWSMARTCARDSmartCardID,
                        principalTable: "RAWSMARTCARDs",
                        principalColumn: "SmartCardID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "CardTransactions",
                columns: table => new
                {
                    CardTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AmountTotal = table.Column<decimal>(type: "smallmoney", nullable: true),
                    AmountReceived = table.Column<decimal>(type: "smallmoney", nullable: true),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: true),
                    AmountDiscounted = table.Column<decimal>(type: "smallmoney", nullable: true),
                    AmountChange = table.Column<decimal>(type: "smallmoney", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    TransportCardID = table.Column<int>(type: "int", nullable: true),
                    TransportCardTripID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTransactions", x => x.CardTransactionID);
                    table.ForeignKey(
                        name: "FK_CardTransactions_TransportCards_TransportCardID",
                        column: x => x.TransportCardID,
                        principalTable: "TransportCards",
                        principalColumn: "TransportCardID");
                    table.ForeignKey(
                        name: "FK_CardTransactions_TransportCardTrips_TransportCardTripID",
                        column: x => x.TransportCardTripID,
                        principalTable: "TransportCardTrips",
                        principalColumn: "TransportCardTripID");
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleLevel" },
                values: new object[,]
                {
                    { "0a69c526-ed99-4cdc-9207-d981dbe380cd", "597acb76-16e4-47ba-b2d4-5e2973eb983d", "User", "USER", 400 },
                    { "3d0e536b-4df8-4e34-96fa-5c0a2a2c23de", "22102af4-688e-4f90-b015-b8b3fe399a5c", "Manager", "MANAGER", 200 },
                    { "8a9feb7d-7c54-4f89-887a-7c6c40437783", "4fd945ea-6ea9-4590-b476-c958a8545c54", "Administrator", "ADMINISTRATOR", 100 },
                    { "d2a1d8c3-b654-476a-b1d9-1d42e6ff69f6", "f0b4e969-54de-47f6-86bc-a9c3a3d7a850", "Clerk", "CLERK", 300 }
                });

            migrationBuilder.InsertData(
                table: "TrainStations",
                columns: new[] { "TrainStationID", "CreatedBy", "CreatedDate", "IsActive", "TrainStationCode", "TrainStationNumber", "TransportCardTripID", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("169fe3a1-5eca-483b-8e84-8f0d8ed35d97"), "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8559), true, "ST9", 9, null, "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8559) },
                    { new Guid("1d5ba6aa-69e6-4cfa-9eba-a3308f916864"), "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8533), true, "ST6", 6, null, "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8533) },
                    { new Guid("30894685-fb9f-4c85-b191-1599eeb3ae56"), "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8430), true, "ST2", 2, null, "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8430) },
                    { new Guid("60512051-4ee0-458e-badb-f2c852a9b06b"), "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8439), true, "ST3", 3, null, "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8440) },
                    { new Guid("8fb3b0c6-4c8a-423c-b8df-510ecdc90cfe"), "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8520), true, "ST5", 5, null, "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8521) },
                    { new Guid("8fb9416c-abfe-4183-952c-356367ae7a66"), "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8568), true, "ST10", 10, null, "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8568) },
                    { new Guid("9b29500b-cc4c-4139-9a89-1ef8a1c0022f"), "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8542), true, "ST7", 7, null, "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8542) },
                    { new Guid("b38da52d-6c33-49f3-897b-e2c5c8ce3d62"), "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8550), true, "ST8", 8, null, "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8550) },
                    { new Guid("ee97077a-415a-429e-b90e-8feeb048d8c0"), "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8448), true, "ST4", 4, null, "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8448) },
                    { new Guid("f2a7ee06-64a8-4f8d-979c-9684532169ab"), "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8411), true, "ST1", 1, null, "ADMIN", new DateTime(2022, 5, 4, 16, 20, 11, 104, DateTimeKind.Utc).AddTicks(8413) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CardTransactions_TransportCardID",
                table: "CardTransactions",
                column: "TransportCardID");

            migrationBuilder.CreateIndex(
                name: "IX_CardTransactions_TransportCardTripID",
                table: "CardTransactions",
                column: "TransportCardTripID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainStations_TransportCardTripID",
                table: "TrainStations",
                column: "TransportCardTripID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportCards_RAWSMARTCARDSmartCardID",
                table: "TransportCards",
                column: "RAWSMARTCARDSmartCardID");

            migrationBuilder.CreateIndex(
                name: "IX_TransportCardTrips_TransportCardID",
                table: "TransportCardTrips",
                column: "TransportCardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CardTransactions");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TrainStations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GenEmpUIDs");

            migrationBuilder.DropTable(
                name: "TransportCardTrips");

            migrationBuilder.DropTable(
                name: "TransportCards");

            migrationBuilder.DropTable(
                name: "RAWSMARTCARDs");
        }
    }
}
