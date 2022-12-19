using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace ProjectsTaskes.Models
{

    public class PrTask
    {
        public int PrTaskId { get; set; }
        [Required]
        //Allow up to 100 symbols.Start symbol uppercase, other uppercase and lowercase
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9_]{1,100}$",
         ErrorMessage = "Characters are not allowed.")]
        public string? strPrTaskName { get; set; }
        [Range(0, 2)] 
        public TaskesOfProjects.PrTaskStatus enumPrTaskStatus { get; set; }
        public string? strPrTaskDescription { get; set; }
        public int intPrTaskPriority { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [JsonIgnore]
        public Project? Project { get; set; }
    }
}
