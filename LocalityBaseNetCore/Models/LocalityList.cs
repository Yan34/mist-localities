using System;
using System.Collections;
using System.Collections.Generic;

namespace LocalityBaseNetCore.Models
{
    public class LocalityList
    {
        public List<Locality> Localities { get; set; }
        public int locsCount { get; set; }

        public string OverallPeople { get; set; }
        public string AveragePeople { get; set; }
        
        public string OverallBudget { get; set; }
        public string AverageBudget { get; set; }
    }
}