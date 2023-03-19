using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LocalityBaseAPI.Models
{
    [Table("Localities")]
    public class Locality
    {
        [Key]
        public int id { get; set; }
        
        public string Type { get; set; }
        
        public string Name { get; set; }
        
        public string Submission { get; set; }
        
        [NotNull]
        public decimal PeopleCount { get; set; }

        [NotNull]
        public decimal Budget { get; set; }
        
        public string Headman { get; set; }
    }
}