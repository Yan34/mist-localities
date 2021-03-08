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

        public Locality()
        {
            
        }
        
        public Locality(InputLocality inLoc)
        {
            id = inLoc.id;
            Type = inLoc.Type;
            Name = inLoc.Name;
            Submission = inLoc.Submission;
            PeopleCount = decimal.Parse(inLoc.PeopleCount.Replace('.', ','));
            Budget = decimal.Parse(inLoc.Budget.Replace('.', ','));
            Headman = inLoc.Headman;
        }
    }
}