using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksProject.Migrations
{
    /// <inheritdoc />
    public partial class TaskTitle_IsDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Tasks");
        }
    }
}
