using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundSteps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
               name: "InstrumentDTOUserDTO",
               newName: "UserInstrument");

            migrationBuilder.RenameTable(
               name: "ExerciseDTOUserDTO",
               newName: "UserExercise");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
               name: "UserInstrument",
               newName: "InstrumentDTOUserDTO");

            migrationBuilder.RenameTable(
               name: "UserExercise",
               newName: "ExerciseDTOUserDTO");
        }
    }
}
