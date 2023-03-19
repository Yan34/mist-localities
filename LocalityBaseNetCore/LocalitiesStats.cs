using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using LocalityBaseNetCore.Models;

namespace LocalityBaseNetCore
{
    public static class LocalitiesStats
    {
        public static decimal GetOverallPeople(IEnumerable<Locality> locs)
        {
            decimal overallPeople=0;
            if (locs != null)
            {
                if(locs.Count()!=0)
                {
                    foreach (var loc in locs)
                    {
                        overallPeople += loc.PeopleCount;
                    }
                }
            }
            
            return overallPeople;
        }

        public static decimal GetOverallBudget(IEnumerable<Locality> locs)
        {
            decimal overallBudget=0;
            if (locs != null)
            {
                if(locs.Count()!=0)
                {
                    foreach (var loc in locs)
                    {
                        overallBudget += loc.Budget;
                    }
                }
            }
            
            return overallBudget;
        }

        public static decimal GetAveragePeople(IEnumerable<Locality> locs)
        {
            decimal averagePeople = 0;
            if (locs != null)
            {
                if (locs.Count() != 0)
                {
                    averagePeople = decimal.Round( decimal.Divide(GetOverallPeople(locs), locs.Count()), 3 );
                }
            }

            return averagePeople;
        }

        public static decimal GetAverageBudget(IEnumerable<Locality> locs)
        {
            decimal averageBudget = 0;
            if (locs != null)
            {
                if (locs.Count() != 0)
                {
                    averageBudget = decimal.Round( decimal.Divide(GetOverallBudget(locs), locs.Count()), 3 );
                }
            }

            return averageBudget;
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