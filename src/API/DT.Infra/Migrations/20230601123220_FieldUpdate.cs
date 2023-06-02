using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DT.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FieldUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hasMoreThanOneReaction",
                table: "Posts",
                newName: "hasMoreThanTwoReaction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hasMoreThanTwoReaction",
                table: "Posts",
                newName: "hasMoreThanOneReaction");
        }
    }
}
