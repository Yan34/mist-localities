using System;

namespace LocalityBaseNetCore.Models
{
    public class Locality
    {
        public int id { get; set; }
        
        public string Name { get; set; }
        
        public string Submission { get; set; }
        
        public int PeopleCount { get; set; }
        
        public int Budget { get; set; }
        
        public string Headman { get; set; }
    }
}