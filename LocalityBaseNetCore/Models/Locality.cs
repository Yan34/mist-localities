using System;

namespace LocalityBaseNetCore.Models
{
    public class Locality
    {
        public int id { get; set; }
        
        public string Type { get; set; }
        
        public string Name { get; set; }
        
        public string Submission { get; set; }
        
        public decimal PeopleCount { get; set; }
        
        public decimal Budget { get; set; }
        
        public string Headman { get; set; }
    }
}