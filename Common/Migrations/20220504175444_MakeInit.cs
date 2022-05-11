using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Migrations
{
    public partial class MakeInit : Migration
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
                    { "5ef268dc-c6b1-4331-b4fd-b82e8fec7b7d", "72f94dd3-153f-4eec-a562-cdc1d95e96cc", "Manager", "MANAGER", 200 },
                    { "92a7cf92-3402-48dd-8355-1de4bd082d6f", "dd85844e-dd4f-407e-8cb9-3c2975e9f88a", "Clerk", "CLERK", 300 },
                    { "e5c5fe49-57e7-435a-9eb7-19b2780d61ba", "9adc83d0-f1dc-4bb6-9a53-a2eb992a52af", "User", "USER", 400 },
                    { "f900568e-9c20-4fb3-9492-74b289fdea7e", "a914e8cb-831c-416f-89eb-ecb81669b980", "Administrator", "ADMINISTRATOR", 100 }
                });

            migrationBuilder.InsertData(
                table: "RAWSMARTCARDs",
                columns: new[] { "SmartCardID", "ActivatedDate", "DeactivatedDate", "IsActive", "IsValid", "SerialNumber", "SmartCardName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(4025), null, false, true, 111, "RFID111" },
                    { 2, new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(4037), null, false, true, 222, "RFID222" },
                    { 3, new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(4046), null, false, true, 333, "RFID333" },
                    { 4, new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(4054), null, false, true, 444, "RFID444" },
                    { 5, new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(4063), null, false, true, 555, "RFID555" }
                });

            migrationBuilder.InsertData(
                table: "TrainStations",
                columns: new[] { "TrainStationID", "CreatedBy", "CreatedDate", "IsActive", "TrainStationCode", "TrainStationNumber", "TransportCardTripID", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0e425127-a70e-4862-b86e-4de8130c95bd"), "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3924), true, "ST10", 10, null, "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3925) },
                    { new Guid("30e20419-9d37-40a1-9d7a-bbc117e5d1dd"), "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3900), true, "ST8", 8, null, "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3900) },
                    { new Guid("48ebf47e-e168-46b7-a122-ae451f026a96"), "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3890), true, "ST7", 7, null, "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3890) },
                    { new Guid("6396c2a3-167e-4067-a08a-c9b905b5adeb"), "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3734), true, "ST1", 1, null, "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3737) },
                    { new Guid("7dabc179-48c3-4ec6-a6bc-843f48321124"), "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3836), true, "ST2", 2, null, "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3837) },
                    { new Guid("84c120fa-93ff-4f1d-9f9d-1159d0469db9"), "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3880), true, "ST6", 6, null, "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3881) },
                    { new Guid("97a9fc28-7ec0-46f4-95df-2d2c4f6e2f3f"), "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3909), true, "ST9", 9, null, "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3910) },
                    { new Guid("bfc555cb-671f-4bcd-a89f-bd902c83057e"), "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3858), true, "ST4", 4, null, "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3858) },
                    { new Guid("d8b09dc3-9e5b-4cf2-83f1-55a31f044414"), "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3868), true, "ST5", 5, null, "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3868) },
                    { new Guid("dcf46702-fab8-4b3a-950f-3a87dc02c8f7"), "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3849), true, "ST3", 3, null, "ADMIN", new DateTime(2022, 5, 4, 17, 54, 44, 139, DateTimeKind.Utc).AddTicks(3849) }
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
