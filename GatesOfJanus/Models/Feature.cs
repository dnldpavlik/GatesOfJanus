using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GatesOfJanus.Models
{
    public class Feature
    {
        public long ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public long EnvironmentID { get; set; }
        
        [DefaultValue(false)]
        public bool Enabled { get; set; }
    }
}
