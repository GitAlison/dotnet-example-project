using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appflow.Migrations
{
    /// <inheritdoc />
    public partial class AddTableHistoryCustomerCustomerService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColumnFlows",
                columns: table => new
                {
                    ColumnFlowId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    userId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnFlows", x => x.ColumnFlowId);
                    table.ForeignKey(
                        name: "FK_ColumnFlows_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerServices",
                columns: table => new
                {
                    CustomerServiceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Protocol = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ColumnFlowId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerServices", x => x.CustomerServiceId);
                    table.ForeignKey(
                        name: "FK_CustomerServices_ColumnFlows_ColumnFlowId",
                        column: x => x.ColumnFlowId,
                        principalTable: "ColumnFlows",
                        principalColumn: "ColumnFlowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryCustomerServices",
                columns: table => new
                {
                    HistoryCustomerServiceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    FromColumn = table.Column<string>(type: "TEXT", nullable: true),
                    ToColumn = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryCustomerServices", x => x.HistoryCustomerServiceId);
                    table.ForeignKey(
                        name: "FK_HistoryCustomerServices_CustomerServices_CustomerServiceId",
                        column: x => x.CustomerServiceId,
                        principalTable: "CustomerServices",
                        principalColumn: "CustomerServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColumnFlows_userId",
                table: "ColumnFlows",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServices_ColumnFlowId",
                table: "CustomerServices",
                column: "ColumnFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryCustomerServices_CustomerServiceId",
                table: "HistoryCustomerServices",
                column: "CustomerServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryCustomerServices");

            migrationBuilder.DropTable(
                name: "CustomerServices");

            migrationBuilder.DropTable(
                name: "ColumnFlows");
        }
    }
}
