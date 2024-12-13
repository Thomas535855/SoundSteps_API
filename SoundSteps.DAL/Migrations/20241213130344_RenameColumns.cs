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
                table: "ExerciseUser",
                name: "ExercisesExerciseId",
                newName: "ExerciseId");
            
            migrationBuilder.RenameColumn(
                table: "ExerciseUser",
                name: "UsersUserId",
                newName: "UserId");
            
            migrationBuilder.RenameColumn(
                table: "InstrumentUser",
                name: "InstrumentsInstrumentId",
                newName: "InstrumentId");
            
            migrationBuilder.RenameColumn(
                table: "InstrumentUser",
                name: "UsersUserId",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
