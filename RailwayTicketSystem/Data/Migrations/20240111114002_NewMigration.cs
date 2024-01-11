using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayTicketSystem.Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    RailwayDivisionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    T_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainNo = table.Column<int>(type: "int", nullable: false),
                    TrainName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.T_Id);
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
                        name: "FK_StationDistances_Stations_FromStationId",
                        column: x => x.FromStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StationDistances_Stations_ToStationId",
                        column: x => x.ToStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    CoachId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(type: "int", nullable: false),
                    CompartmentId = table.Column<int>(type: "int", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.CoachId);
                    table.ForeignKey(
                        name: "FK_Coaches_Compartments_CompartmentId",
                        column: x => x.CompartmentId,
                        principalTable: "Compartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coaches_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "T_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FareDetails",
                columns: table => new
                {
                    fd_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Train = table.Column<int>(type: "int", nullable: false),
                    Compartment = table.Column<int>(type: "int", nullable: false),
                    BaseCharges = table.Column<int>(type: "int", nullable: false),
                    DistanceCharges = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FareDetails", x => x.fd_id);
                    table.ForeignKey(
                        name: "FK_FareDetails_Compartments_Compartment",
                        column: x => x.Compartment,
                        principalTable: "Compartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FareDetails_Trains_Train",
                        column: x => x.Train,
                        principalTable: "Trains",
                        principalColumn: "T_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainCompartments",
                columns: table => new
                {
                    TC_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(type: "int", nullable: false),
                    CompartmentId = table.Column<int>(type: "int", nullable: false),
                    CompartmentCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainCompartments", x => x.TC_Id);
                    table.ForeignKey(
                        name: "FK_TrainCompartments_Compartments_CompartmentId",
                        column: x => x.CompartmentId,
                        principalTable: "Compartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainCompartments_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "T_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainRoutes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(type: "int", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    StopOrder = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainRoutes", x => x.RouteId);
                    table.ForeignKey(
                        name: "FK_TrainRoutes_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainRoutes_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "T_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainSchedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainSchedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_TrainSchedules_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "StationId");
                    table.ForeignKey(
                        name: "FK_TrainSchedules_TrainRoutes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "TrainRoutes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainSchedules_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "T_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainScheduleId = table.Column<int>(type: "int", nullable: false),
                    PNRNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatNumber = table.Column<int>(type: "int", nullable: true),
                    CoachNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fare = table.Column<int>(type: "int", nullable: true),
                    ReservationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainT_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Trains_TrainT_Id",
                        column: x => x.TrainT_Id,
                        principalTable: "Trains",
                        principalColumn: "T_Id");
                    table.ForeignKey(
                        name: "FK_Reservations_TrainSchedules_TrainScheduleId",
                        column: x => x.TrainScheduleId,
                        principalTable: "TrainSchedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassengerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PNRNumber = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassengerDetails_Reservations_PNRNumber",
                        column: x => x.PNRNumber,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_CompartmentId",
                table: "Coaches",
                column: "CompartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_TrainId",
                table: "Coaches",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_FareDetails_Compartment",
                table: "FareDetails",
                column: "Compartment");

            migrationBuilder.CreateIndex(
                name: "IX_FareDetails_Train",
                table: "FareDetails",
                column: "Train");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerDetails_PNRNumber",
                table: "PassengerDetails",
                column: "PNRNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TrainScheduleId",
                table: "Reservations",
                column: "TrainScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TrainT_Id",
                table: "Reservations",
                column: "TrainT_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StationDistances_FromStationId",
                table: "StationDistances",
                column: "FromStationId");

            migrationBuilder.CreateIndex(
                name: "IX_StationDistances_ToStationId",
                table: "StationDistances",
                column: "ToStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainCompartments_CompartmentId",
                table: "TrainCompartments",
                column: "CompartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainCompartments_TrainId",
                table: "TrainCompartments",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainRoutes_StationId",
                table: "TrainRoutes",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainRoutes_TrainId",
                table: "TrainRoutes",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainSchedules_RouteId",
                table: "TrainSchedules",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainSchedules_StationId",
                table: "TrainSchedules",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainSchedules_TrainId",
                table: "TrainSchedules",
                column: "TrainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "FareDetails");

            migrationBuilder.DropTable(
                name: "PassengerDetails");

            migrationBuilder.DropTable(
                name: "StationDistances");

            migrationBuilder.DropTable(
                name: "TrainCompartments");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Compartments");

            migrationBuilder.DropTable(
                name: "TrainSchedules");

            migrationBuilder.DropTable(
                name: "TrainRoutes");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Trains");
        }
    }
}
