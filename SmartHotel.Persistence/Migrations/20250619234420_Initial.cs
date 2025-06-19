using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHotel.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Variables",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    Reference = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lights",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Unit = table.Column<int>(type: "integer", nullable: false),
                    TurnOn = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lights_Variables_Id",
                        column: x => x.Id,
                        principalSchema: "public",
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Smokes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Unit = table.Column<int>(type: "integer", nullable: false),
                    Danger = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smokes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Smokes_Variables_Id",
                        column: x => x.Id,
                        principalSchema: "public",
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Unit = table.Column<int>(type: "integer", nullable: false),
                    TurnOn = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperatures_Variables_Id",
                        column: x => x.Id,
                        principalSchema: "public",
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    IsRentable = table.Column<bool>(type: "boolean", nullable: false),
                    IsOcupated = table.Column<bool>(type: "boolean", nullable: false),
                    RentalPrice_Value = table.Column<double>(type: "double precision", nullable: false),
                    RentalPrice_MoneyType = table.Column<int>(type: "integer", nullable: false),
                    IsClimatizationOn = table.Column<bool>(type: "boolean", nullable: false),
                    IsIluminationOn = table.Column<bool>(type: "boolean", nullable: false),
                    RoomType_Category = table.Column<int>(type: "integer", nullable: false),
                    RoomType_Capacity = table.Column<int>(type: "integer", nullable: false),
                    SmokeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TemperatureId = table.Column<Guid>(type: "uuid", nullable: false),
                    LightId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Lights_LightId",
                        column: x => x.LightId,
                        principalSchema: "public",
                        principalTable: "Lights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_Smokes_SmokeId",
                        column: x => x.SmokeId,
                        principalSchema: "public",
                        principalTable: "Smokes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_Temperatures_TemperatureId",
                        column: x => x.TemperatureId,
                        principalSchema: "public",
                        principalTable: "Temperatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agreements",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientName = table.Column<string>(type: "text", nullable: false),
                    Clientemail = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price_Value = table.Column<double>(type: "double precision", nullable: false),
                    Price_MoneyType = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agreements_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "public",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_RoomId",
                schema: "public",
                table: "Agreements",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LightId",
                schema: "public",
                table: "Rooms",
                column: "LightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SmokeId",
                schema: "public",
                table: "Rooms",
                column: "SmokeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_TemperatureId",
                schema: "public",
                table: "Rooms",
                column: "TemperatureId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Lights",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Smokes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Temperatures",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Variables",
                schema: "public");
        }
    }
}
