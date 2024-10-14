using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundSteps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Exercises_ExerciseId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "CommentUser");

            migrationBuilder.DropTable(
                name: "ExerciseUser");

            migrationBuilder.DropTable(
                name: "InstrumentUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ExerciseId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseDTOExerciseId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.CreateTable(
                name: "ExerciseDTOUserDTO",
                columns: table => new
                {
                    ExercisesExerciseId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDTOUserDTO", x => new { x.ExercisesExerciseId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_ExerciseDTOUserDTO_Exercises_ExercisesExerciseId",
                        column: x => x.ExercisesExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseDTOUserDTO_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentDTOUserDTO",
                columns: table => new
                {
                    InstrumentsInstrumentId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentDTOUserDTO", x => new { x.InstrumentsInstrumentId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_InstrumentDTOUserDTO_Instruments_InstrumentsInstrumentId",
                        column: x => x.InstrumentsInstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstrumentDTOUserDTO_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ExerciseDTOExerciseId",
                table: "Comments",
                column: "ExerciseDTOExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDTOUserDTO_UsersUserId",
                table: "ExerciseDTOUserDTO",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentDTOUserDTO_UsersUserId",
                table: "InstrumentDTOUserDTO",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Exercises_ExerciseDTOExerciseId",
                table: "Comments",
                column: "ExerciseDTOExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Exercises_ExerciseDTOExerciseId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "ExerciseDTOUserDTO");

            migrationBuilder.DropTable(
                name: "InstrumentDTOUserDTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ExerciseDTOExerciseId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ExerciseDTOExerciseId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CommentUser",
                columns: table => new
                {
                    CommentsCommentId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentUser", x => new { x.CommentsCommentId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_CommentUser_Comments_CommentsCommentId",
                        column: x => x.CommentsCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseUser",
                columns: table => new
                {
                    ExercisesExerciseId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseUser", x => new { x.ExercisesExerciseId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_ExerciseUser_Exercises_ExercisesExerciseId",
                        column: x => x.ExercisesExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Comments_ExerciseId",
                table: "Comments",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentUser_UsersUserId",
                table: "CommentUser",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseUser_UsersUserId",
                table: "ExerciseUser",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentUser_UsersUserId",
                table: "InstrumentUser",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Exercises_ExerciseId",
                table: "Comments",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
