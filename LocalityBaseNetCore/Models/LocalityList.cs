using System;
using System.Collections;
using System.Collections.Generic;

namespace LocalityBaseNetCore.Models
{
    public class LocalityList
    {
        public List<Locality> Localities { get; set; }

        public decimal OverallPeople { get; set; }
        public decimal AveragePeople { get; set; }
        
        public decimal OverallBudget { get; set; }
        public decimal AverageBudget { get; set; }
    }
}