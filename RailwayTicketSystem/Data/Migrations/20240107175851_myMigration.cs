using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayTicketSystem.Data.Migrations
{
    public partial class myMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FareDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    TypeOfCompartment = table.Column<int>(type: "int", nullable: false),
                    TypeOfTrain = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FareDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StationDetails",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    RailwayDivisionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationDetails", x => x.StationId);
                });

            migrationBuilder.CreateTable(
                name: "TicketDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PnrNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatNo = table.Column<int>(type: "int", nullable: false),
                    CoachNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainDetails",
                columns: table => new
                {
                    TrainNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    NumberOfCompartments = table.Column<int>(type: "int", nullable: false),
                    AC1 = table.Column<int>(type: "int", nullable: false),
                    AC2 = table.Column<int>(type: "int", nullable: false),
                    AC3 = table.Column<int>(type: "int", nullable: false),
                    Sleeper = table.Column<int>(type: "int", nullable: false),
                    General = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainDetails", x => x.TrainNo);
                });

            migrationBuilder.CreateTable(
                name: "StationDistances",
                columns: table => new
                {
                    StationDistanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromStationId = table.Column<int>(type: "int", nullable: false),
                    ToStationId = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationDistances", x => x.StationDistanceId);
                    table.ForeignKey(
                        name: "FK_StationDistances_StationDetails_FromStationId",
                        column: x => x.FromStationId,
                        principalTable: "StationDetails",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StationDistances_StationDetails_ToStationId",
                        column: x => x.ToStationId,
                        principalTable: "StationDetails",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PassengerDetails",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPassenger = table.Column<int>(type: "int", nullable: false),
                    DateOfTravel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainNo = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerDetails", x => x.PassengerId);
                    table.ForeignKey(
                        name: "FK_PassengerDetails_TrainDetails_TrainNo",
                        column: x => x.TrainNo,
                        principalTable: "TrainDetails",
                        principalColumn: "TrainNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainSchedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DepartureTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TrainNo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainSchedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_TrainSchedules_StationDetails_StationId",
                        column: x => x.StationId,
                        principalTable: "StationDetails",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainSchedules_TrainDetails_TrainNo",
                        column: x => x.TrainNo,
                        principalTable: "TrainDetails",
                        principalColumn: "TrainNo");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainScheduleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PNRNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    CoachNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fare = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_TrainSchedules_TrainScheduleId",
                        column: x => x.TrainScheduleId,
                        principalTable: "TrainSchedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerDetails_TrainNo",
                table: "PassengerDetails",
                column: "TrainNo");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TrainScheduleId",
                table: "Reservations",
                column: "TrainScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StationDistances_FromStationId",
                table: "StationDistances",
                column: "FromStationId");

            migrationBuilder.CreateIndex(
                name: "IX_StationDistances_ToStationId",
                table: "StationDistances",
                column: "ToStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainSchedules_StationId",
                table: "TrainSchedules",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainSchedules_TrainNo",
                table: "TrainSchedules",
                column: "TrainNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FareDetails");

            migrationBuilder.DropTable(
                name: "PassengerDetails");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "StationDistances");

            migrationBuilder.DropTable(
                name: "TicketDetails");

            migrationBuilder.DropTable(
                name: "TrainSchedules");

            migrationBuilder.DropTable(
                name: "StationDetails");

            migrationBuilder.DropTable(
                name: "TrainDetails");
        }
    }
}
