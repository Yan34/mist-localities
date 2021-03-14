using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using LocalityBaseNetCore.Models;

namespace LocalityBaseNetCore
{
    public static class LocalitiesStats
    {
        public static decimal GetOverallPeople(List<Locality> locs)
        {
            decimal OverallPeople=0;
            if (locs != null)
            {
                if(locs.Count!=0)
                {
                    foreach (var loc in locs)
                    {
                        OverallPeople += loc.PeopleCount;
                    }
                }
            }
            
            return OverallPeople;
        }

        public static decimal GetOverallBudget(List<Locality> locs)
        {
            decimal OverallBudget=0;
            if (locs != null)
            {
                if(locs.Count!=0)
                {
                    foreach (var loc in locs)
                    {
                        OverallBudget += loc.Budget;
                    }
                }
            }
            
            return OverallBudget;
        }

        public static decimal GetAveragePeople(List<Locality> locs)
        {
            decimal AveragePeople = 0;
            if (locs != null)
            {
                if (locs.Count != 0)
                {
                    AveragePeople = decimal.Round( decimal.Divide(GetOverallPeople(locs), locs.Count), 3 );
                }
            }

            return AveragePeople;
        }

        public static decimal GetAverageBudget(List<Locality> locs)
        {
            decimal AverageBudget = 0;
            if (locs != null)
            {
                if (locs.Count != 0)
                {
                    AverageBudget = decimal.Round( decimal.Divide(GetOverallBudget(locs), locs.Count), 3 );
                }
            }

            return AverageBudget;
        }

        public static string GetFormattedDecimal(decimal val)
        {
            string formatted = "";
            string unformatted = val.ToString(CultureInfo.InvariantCulture);
            if(Regex.Matches(unformatted, "\\.\\d*0+").Count != 0)
                formatted = val.ToString(CultureInfo.InvariantCulture).TrimEnd('0').TrimEnd('.');
            else
                formatted = unformatted;
            
            return formatted;
        }
    }
}