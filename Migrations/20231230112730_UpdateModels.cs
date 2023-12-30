using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieHubCore.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Repertoires",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SessionId",
                table: "Seats",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Repertoires_MovieId",
                table: "Repertoires",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repertoires_Movies_MovieId",
                table: "Repertoires",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Repertoires_SessionId",
                table: "Seats",
                column: "SessionId",
                principalTable: "Repertoires",
                principalColumn: "SessionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repertoires_Movies_MovieId",
                table: "Repertoires");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Repertoires_SessionId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_SessionId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Repertoires_MovieId",
                table: "Repertoires");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Repertoires");
        }
    }
}
