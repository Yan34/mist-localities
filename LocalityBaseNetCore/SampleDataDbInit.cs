using System.Linq;
using LocalityBaseNetCore.Models;

namespace LocalityBaseNetCore
{
    public class SampleDataDbInit
    {
        public static void Initialize(LocalitiesContext context)
        {
            if (!context.GetLocalities().Any())
            {
                context.AddLocalities(
                    new Locality
                    {
                        Name = "Ленинск",
                        Type = "Город",
                        Submission = "Саратовская область",
                        PeopleCount = 25,
                        Budget = 48,
                        Headman = "Петров Сергей Иванович"
                    },
                    new Locality
                    {
                        Name = "Дальний",
                        Type = "Посёлок",
                        Submission = "Воронежская область",
                        PeopleCount = 5,
                        Budget = new decimal(8.4),
                        Headman = "Сидоров Эдуард Николаевич"
                    },
                    new Locality
                    {
                        Name = "Отрадное",
                        Type = "Сельское поселение",
                        Submission = "Пензенская область",
                        PeopleCount = new decimal(1.3),
                        Budget = new decimal(1.8),
                        Headman = "Коровин "
                    },
                    new Locality
                    {
                        Name = "Энгельс",
                        Type = "Город",
                        Submission = "Саратовская область",
                        PeopleCount = 227,
                        Budget = 510,
                        Headman = "Горевский Сергей Евгеньевич"
                    }
                );
            }
        }
    }
}