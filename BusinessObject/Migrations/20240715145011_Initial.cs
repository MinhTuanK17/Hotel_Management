using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerBirthday = table.Column<DateOnly>(type: "date", nullable: true),
                    CustomerStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.CheckConstraint("CK_Customer_Status", "[CustomerStatus] = 'Active' OR [CustomerStatus] = 'Deleted'");
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    RoomTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.RoomTypeID);
                });

            migrationBuilder.CreateTable(
                name: "BookingReservations",
                columns: table => new
                {
                    BookingReservationID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingReservations", x => x.BookingReservationID);
                    table.CheckConstraint("CK_BookingReservation_Status", "[BookingStatus] = 'Pending' OR [BookingStatus] = 'Confirmed' OR [BookingStatus] = 'Cancelled'");
                    table.ForeignKey(
                        name: "FK_BookingReservations_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                });

            migrationBuilder.CreateTable(
                name: "RoomInformations",
                columns: table => new
                {
                    RoomID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    RoomDetailDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomMaxCapacity = table.Column<int>(type: "int", nullable: false),
                    RoomPricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoomStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoomTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomInformations", x => x.RoomID);
                    table.CheckConstraint("CK_Room_Status", "[RoomStatus] = 'Active' OR [RoomStatus] = 'Rented' OR [RoomStatus] = 'Disable'");
                    table.ForeignKey(
                        name: "FK_RoomInformations_RoomTypes_RoomTypeID",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeID");
                });

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingReservationID = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    RoomID = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => new { x.BookingReservationID, x.RoomID });
                    table.ForeignKey(
                        name: "FK_BookingDetails_BookingReservations_BookingReservationID",
                        column: x => x.BookingReservationID,
                        principalTable: "BookingReservations",
                        principalColumn: "BookingReservationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetails_RoomInformations_RoomID",
                        column: x => x.RoomID,
                        principalTable: "RoomInformations",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "CustomerBirthday", "CustomerFullName", "CustomerStatus", "EmailAddress", "Password", "Telephone" },
                values: new object[,]
                {
                    { 1, new DateOnly(2003, 11, 23), "Nguyễn Minh Tuấn", "Active", "tuannm.dev@gmail.com", "password123", "0941673660" },
                    { 2, new DateOnly(2000, 5, 20), "Trần Văn A", "Active", "vana.tran@example.com", "password456", "0912345678" },
                    { 3, new DateOnly(1998, 8, 15), "Lê Thị B", "Deleted", "lethib@example.com", "password789", "0934567890" },
                    { 4, new DateOnly(1995, 12, 5), "Phạm Quốc C", "Active", "quocc.pham@example.com", "password321", "0908765432" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeID", "RoomTypeName", "TypeDescription", "TypeNote" },
                values: new object[,]
                {
                    { 1, "Single", "A single room with one bed.", "Ideal for solo travelers." },
                    { 2, "Double", "A double room with two beds.", "Perfect for couples or friends." },
                    { 3, "Suite", "A luxurious suite with multiple amenities.", "Suitable for a lavish stay." },
                    { 4, "Family", "A spacious room for families.", "Comfortable for family stays." }
                });

            migrationBuilder.InsertData(
                table: "BookingReservations",
                columns: new[] { "BookingReservationID", "BookingDate", "BookingStatus", "CustomerID", "TotalPrice" },
                values: new object[,]
                {
                    { "BOOK00001", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed", 1, 150.50m },
                    { "BOOK00002", new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed", 1, 200.00m },
                    { "BOOK00003", new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 2, 250.75m }
                });

            migrationBuilder.InsertData(
                table: "RoomInformations",
                columns: new[] { "RoomID", "RoomDetailDescription", "RoomMaxCapacity", "RoomNumber", "RoomPricePerDay", "RoomStatus", "RoomTypeID" },
                values: new object[,]
                {
                    { "ROOM1001", "A cozy single room with all basic amenities.", 1, 101, 250.00m, "Rented", 1 },
                    { "ROOM1002", "", 2, 102, 400.00m, "Active", 1 },
                    { "ROOM1003", "", 1, 103, 320.00m, "Active", 1 },
                    { "ROOM1004", "", 5, 104, 500.00m, "Active", 1 },
                    { "ROOM1005", "", 4, 105, 470.00m, "Active", 1 },
                    { "ROOM2001", "A spacious double room with a beautiful view.", 3, 201, 550.00m, "Active", 2 },
                    { "ROOM2002", "", 1, 202, 250.00m, "Rented", 2 },
                    { "ROOM2003", "", 3, 203, 385.00m, "Active", 2 },
                    { "ROOM3001", "A luxurious suite with a separate living area.", 4, 301, 492.00m, "Active", 3 },
                    { "ROOM3002", "", 1, 302, 200.00m, "Rented", 3 },
                    { "ROOM3003", "", 1, 303, 180.00m, "Active", 3 },
                    { "ROOM4001", "A family room with multiple beds and a kitchenette.", 7, 401, 700.00m, "Active", 4 },
                    { "ROOM4002", "", 3, 402, 580.00m, "Active", 4 },
                    { "ROOM4003", "", 4, 403, 620.00m, "Active", 4 }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "BookingReservationID", "RoomID", "ActualPrice", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { "BOOK00001", "ROOM1001", 875.00m, new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "BOOK00002", "ROOM2002", 1290.00m, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "BOOK00003", "ROOM3002", 1800.00m, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_RoomID",
                table: "BookingDetails",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingReservations_CustomerID",
                table: "BookingReservations",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomInformations_RoomTypeID",
                table: "RoomInformations",
                column: "RoomTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "BookingReservations");

            migrationBuilder.DropTable(
                name: "RoomInformations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
