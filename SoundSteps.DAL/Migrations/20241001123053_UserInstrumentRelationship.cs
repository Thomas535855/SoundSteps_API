using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundSteps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserInstrumentRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Users_UserId",
                table: "Instruments");

            migrationBuilder.DropIndex(
                name: "IX_Instruments_UserId",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Instruments");

            migrationBuilder.CreateTable(
                name: "InstrumentUser",
                columns: table => new
                {
                    InstrumentsInstrumentId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentUser", x => new { x.InstrumentsInstrumentId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_InstrumentUser_Instruments_InstrumentsInstrumentId",
                        column: x => x.InstrumentsInstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstrumentUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentUser_UsersUserId",
                table: "InstrumentUser",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstrumentUser");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Instruments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_UserId",
                table: "Instruments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Users_UserId",
                table: "Instruments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
