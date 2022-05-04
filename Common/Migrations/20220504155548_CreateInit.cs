using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Migrations
{
    public partial class CreateInit : Migration
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
                    { "56e329b2-a1ff-4211-9893-979d691f11cc", "d328a59f-1fdb-4d4a-bcee-852ae8c6f49f", "Manager", "MANAGER", 200 },
                    { "9dff8b12-8915-4b34-bcbb-7f0ecedd1129", "245bed92-c73f-4428-a9a5-7fa85f05b3fb", "Clerk", "CLERK", 300 },
                    { "a4cae062-f7c8-42ae-97c8-c2038cc58937", "adbf7237-b20d-4ae1-bc6e-d08f04c20fd0", "Administrator", "ADMINISTRATOR", 100 },
                    { "e5351832-2511-41d5-96ef-fb3a4e58e975", "0fedff64-5ac8-411f-a6ce-fe5bfd07df35", "User", "USER", 400 }
                });

            migrationBuilder.InsertData(
                table: "TrainStations",
                columns: new[] { "TrainStationID", "CreatedBy", "CreatedDate", "IsActive", "TrainStationCode", "TrainStationNumber", "TransportCardTripID", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0550f021-e5bf-474b-9b01-914fbcd251de"), "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5164), true, "ST5", 5, null, "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5164) },
                    { new Guid("06a017bf-6228-4c2b-81ce-77bbb772226d"), "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5190), true, "ST7", 7, null, "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5191) },
                    { new Guid("17e4c44b-cac4-4ac9-9978-f9369d9088b6"), "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5154), true, "ST4", 4, null, "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5155) },
                    { new Guid("2760da89-f9bd-42ad-9e51-9a5a4dc4e98c"), "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5179), true, "ST6", 6, null, "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5180) },
                    { new Guid("2a336f84-9030-4952-888c-93bf102f3a0c"), "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5114), true, "ST1", 1, null, "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5117) },
                    { new Guid("2b0c21fb-689a-4d8a-9537-4adc1c0cf040"), "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5222), true, "ST10", 10, null, "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5222) },
                    { new Guid("629cab4d-51e9-41de-a28d-5943124e48b6"), "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5133), true, "ST2", 2, null, "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5133) },
                    { new Guid("641b09a9-16c7-46bd-a717-441133399d7b"), "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5210), true, "ST9", 9, null, "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5211) },
                    { new Guid("68bdee88-f25b-4045-80fe-100202f1601f"), "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5144), true, "ST3", 3, null, "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5144) },
                    { new Guid("ccd58bb3-d32c-44e9-8c39-6602fe8c0d67"), "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5200), true, "ST8", 8, null, "ADMIN", new DateTime(2022, 5, 4, 15, 55, 48, 288, DateTimeKind.Utc).AddTicks(5200) }
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
