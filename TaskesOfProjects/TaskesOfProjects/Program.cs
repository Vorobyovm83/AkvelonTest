

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskesOfProjects.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.IdentityModel.Tokens;
using ProjectsTaskes.Models;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;

//Task: Implement Web API for entering project data into the database (task tracker)
//You need to implement task storage by the project. “Task” is an instance that contains at least 3 fields listed below:
//1.Id
//2.Task name
//3.Task description
//The solution should provide an ability to easily add new fields to the Task entity.
//Each task should be a part of only one project. Project is an entity that contains name, id (and also keeps Tasks entities). The program must be a Web API.
//Functional requirements:
//Ability to create / view / edit / delete information about projects
//Ability to create / view / edit / delete task information
//Ability to add and remove tasks from a project (one project can contain several tasks)
//Ability to view all tasks in the project
//WIll be a plus to have an ability to filter and sort projects with various methods (start at, end at, range, exact value, etc.) and by various fields (start date, priority, etc.)
//Project information that should be stored:
//the name of the project
//project start date
//project completion date
//the current status of the project (enum: NotStarted, Active, Completed)
//priority(int)
//Task information that should be stored:
//task name
//task status (enum: ToDo / InProgress / Done)
//description
//priority(int)

//Info about desition:
//https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0
//https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio
//https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations?view=aspnetcore-6.0
//https://learn.microsoft.com/ru-ru/aspnet/core/data/ef-mvc/complex-data-model?view=aspnetcore-6.0
//https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
//Used comades:
//dotnet tool install --global dotnet-ef
//Install-Package Microsoft.EntityFrameworkCore.SqlServer
//Install-Package Microsoft.EntityFrameworkCore.Design
//dotnet ef database drop              //if nessesary drop previus DB
//dotnet ef migrations add InitialCreate
//After change models
//dotnet ef migrations add NextChange..
//dotnet ef database update
//For other PC
//https://localhost:<port>/swagger/index.html
//Install-Package NSwag.AspNetCore
//dotnet tool install --global dotnet-ef
//dotnet ef database update

namespace TaskesOfProjects
{
    public enum ProjectStatus { NotStarted, Active, Completed };
    public enum PrTaskStatus { ToDo, InProgress, Done };

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            // Register the Swagger services
            builder.Services.AddSwaggerDocument();
            //Connect SqlServer
            builder.Services.AddDbContext<ProjectsContext>(options =>
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProjectsTasks;Trusted_Connection=True"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Register the Swagger generator and the Swagger UI middlewares
                app.UseSwaggerUI();
                app.UseOpenApi();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}