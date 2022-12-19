using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjectsTaskes.Models;

namespace TaskesOfProjects.Data
{
    public class ProjectsContext : DbContext
    {
        public ProjectsContext(DbContextOptions<ProjectsContext> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<PrTask> PrTasks { get; set; }
    }

}