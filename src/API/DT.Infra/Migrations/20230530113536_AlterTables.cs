using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DT.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Posts",
                newName: "body");

            migrationBuilder.AddColumn<string>(
                name: "cardType",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Posts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    todo = table.Column<string>(type: "text", nullable: false),
                    userId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Todos_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_userId",
                table: "Posts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_userId",
                table: "Todos",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_userId",
                table: "Posts",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_userId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Posts_userId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "cardType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "body",
                table: "Posts",
                newName: "userName");
        }
    }
}
