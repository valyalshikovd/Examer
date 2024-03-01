using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examer.Server.Migrations
{
    /// <inheritdoc />
    public partial class upd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AnswerPhoto",
                table: "Task",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "MEDIUMTEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AnswerPhoto",
                table: "Task",
                type: "MEDIUMTEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
