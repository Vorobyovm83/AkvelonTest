using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskesOfProjects.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strProjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dtStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    enumCurrentProjectStatus = table.Column<int>(type: "int", nullable: false),
                    intPriorityProject = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "PrTasks",
                columns: table => new
                {
                    PrTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strTaskName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    enumTaskStatus = table.Column<int>(type: "int", nullable: false),
                    strDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    intPriorityTask = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrTasks", x => x.PrTaskId);
                    table.ForeignKey(
                        name: "FK_PrTasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrTasks_ProjectId",
                table: "PrTasks",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrTasks");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
