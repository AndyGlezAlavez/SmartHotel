using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHotel.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Variables",
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
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Smokes",
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
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
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
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
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
                        principalTable: "Lights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_Smokes_SmokeId",
                        column: x => x.SmokeId,
                        principalTable: "Smokes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_Temperatures_TemperatureId",
                        column: x => x.TemperatureId,
                        principalTable: "Temperatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agreements",
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
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_RoomId",
                table: "Agreements",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LightId",
                table: "Rooms",
                column: "LightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SmokeId",
                table: "Rooms",
                column: "SmokeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_TemperatureId",
                table: "Rooms",
                column: "TemperatureId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Lights");

            migrationBuilder.DropTable(
                name: "Smokes");

            migrationBuilder.DropTable(
                name: "Temperatures");

            migrationBuilder.DropTable(
                name: "Variables");
        }
    }
}
