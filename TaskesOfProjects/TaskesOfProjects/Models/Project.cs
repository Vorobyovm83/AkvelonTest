using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectsTaskes.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        //Allow up to 100 symbols.Start symbol uppercase, other uppercase and lowercase
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9_]{1,100}$",
         ErrorMessage = "Characters are not allowed.")]
        public string? strProjectName { get; set; }
        public DateTime dtStartDate { get; set; }
        public DateTime dtCompletionDate { get; set; }
        [Range(0, 2)]
        public TaskesOfProjects.ProjectStatus enumCurrentProjectStatus { get; set; }
        public int intPriorityProject { get; set; }
        [JsonIgnore]
        public List<PrTask>? PrTasks { get; set; }
    }
 
}
