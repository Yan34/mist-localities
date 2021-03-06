using System;
using System.Collections;
using System.Collections.Generic;
using static LocalityBaseNetCore.Models.Locality;

namespace LocalityBaseNetCore.Models
{
    public class LocalityList
    {
        public List<Locality> Localities { get; set; }

        public int OverallPeople { get; set; }
        public decimal AveragePeople { get; set; }
        
        public int OverallBudget { get; set; }
        public decimal AverageBudget { get; set; }
    }
}