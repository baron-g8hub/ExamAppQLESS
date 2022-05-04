using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Migrations
{
    public partial class InitialMigration : Migration
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
                    { "cc43a088-f4b7-4b23-9c7d-473962e57db5", "fc16153c-980f-4609-9fc9-33f4460a065c", "Administrator", "ADMINISTRATOR", 100 },
                    { "cdaa4378-93b0-400a-b426-51a0c14ed63f", "bac3ce0a-f43f-449c-be75-ac1a6faedf5c", "Manager", "MANAGER", 200 },
                    { "e05134ec-ae18-4c07-a637-8d521fb2acda", "1dcf5388-86e4-41b5-8ea4-06fd14a84502", "Clerk", "CLERK", 300 },
                    { "e3bc7747-cb11-4c48-aad6-3043321977cf", "4fc7f7be-ab84-486b-a48d-a8834b30ca55", "User", "USER", 400 }
                });

            migrationBuilder.InsertData(
                table: "TrainStations",
                columns: new[] { "TrainStationID", "CreatedBy", "CreatedDate", "IsActive", "TrainStationCode", "TrainStationNumber", "TransportCardTripID", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("27630e56-51f4-48df-ba1c-3647eafe2e4d"), "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1034), true, "ST5", 5, null, "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1034) },
                    { new Guid("33357c80-189c-43e2-92ed-e2dbe360fd15"), "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1052), true, "ST7", 7, null, "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1052) },
                    { new Guid("58787f77-7da4-4e94-bf39-b8119c06ac84"), "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1004), true, "ST2", 2, null, "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1004) },
                    { new Guid("58a0d9d2-2899-4d40-ae05-8e49567964ea"), "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1059), true, "ST8", 8, null, "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1060) },
                    { new Guid("a1554584-56fd-418f-82ca-949109103912"), "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1014), true, "ST3", 3, null, "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1014) },
                    { new Guid("b4023a1e-75a7-49fc-9fdc-a06336c388d4"), "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1044), true, "ST6", 6, null, "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1044) },
                    { new Guid("ba94e749-ebcc-4c89-b27f-9810795c0dbc"), "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1077), true, "ST10", 10, null, "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1078) },
                    { new Guid("ce715ee6-d6d7-43f0-9dcb-49e2bb120b33"), "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1067), true, "ST9", 9, null, "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1067) },
                    { new Guid("d4f46165-e0df-4df8-a1be-a3e97ae0fdaf"), "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(990), true, "ST1", 1, null, "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(993) },
                    { new Guid("eae681f8-c45f-491d-9a09-e0029a3ef8c1"), "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1022), true, "ST4", 4, null, "ADMIN", new DateTime(2022, 5, 4, 15, 31, 28, 650, DateTimeKind.Utc).AddTicks(1022) }
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
