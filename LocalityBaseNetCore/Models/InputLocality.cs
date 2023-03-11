namespace LocalityBaseNetCore.Models
{
    public class InputLocality
    {
        public int id { get; set; }
        
        public string Type { get; set; }
        
        public string Name { get; set; }
        
        public string Submission { get; set; }
        
        public string PeopleCount { get; set; }
        
        public string Budget { get; set; }
        
        public string Headman { get; set; }

        public InputLocality() {}

        public InputLocality(Locality loc)
        {
            id = loc.id;
            Type = loc.Type;
            Name = loc.Name;
            Submission = loc.Submission;
            PeopleCount = loc.PeopleCount.ToString();
            Budget = loc.Budget.ToString();
            Headman = loc.Headman;
        }
    }
}