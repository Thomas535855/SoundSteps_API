using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

#nullable disable

namespace SoundSteps.DAL.Migrations
{
    public partial class RenameTablesAndColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ExerciseDtoUserDto",
                newName: "ExerciseUser");
            
            migrationBuilder.RenameTable(
                name: "InstrumentDtoUserDto",
                newName: "InstrumentUser");
            

        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ExerciseUser",
                newName: "ExerciseDtoUserDto");
            
            migrationBuilder.RenameTable(
                name: "InstrumentUser",
                newName: "InstrumentDtoUserDto");
        }
    }
}
