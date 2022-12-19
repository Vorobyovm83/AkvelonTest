using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskesOfProjects.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "strTaskName",
                table: "PrTasks",
                newName: "strPrTaskName");

            migrationBuilder.RenameColumn(
                name: "strDescription",
                table: "PrTasks",
                newName: "strPrTaskDescription");

            migrationBuilder.RenameColumn(
                name: "intPriorityTask",
                table: "PrTasks",
                newName: "intPrTaskPriority");

            migrationBuilder.RenameColumn(
                name: "enumTaskStatus",
                table: "PrTasks",
                newName: "enumPrTaskStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "strPrTaskName",
                table: "PrTasks",
                newName: "strTaskName");

            migrationBuilder.RenameColumn(
                name: "strPrTaskDescription",
                table: "PrTasks",
                newName: "strDescription");

            migrationBuilder.RenameColumn(
                name: "intPrTaskPriority",
                table: "PrTasks",
                newName: "intPriorityTask");

            migrationBuilder.RenameColumn(
                name: "enumPrTaskStatus",
                table: "PrTasks",
                newName: "enumTaskStatus");
        }
    }
}
