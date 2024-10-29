using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundSteps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExercisesExerciseId",
                table: "UserExercise",
                newName: "ExerciseId");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "UserExercise",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "InstrumentsInstrumentId",
                table: "UserInstrument",
                newName: "InstrumentId");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "UserInstrument",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
