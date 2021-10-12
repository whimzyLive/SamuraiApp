using SamuraiApp.Domain;
using SamuraiApp.Data;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace SamuraiApp.UI
{
    class Program
    {
        private static SamuraiContext _context = new();
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter a Samurai Name To Save to DB:");
            //string samuraiName = Console.ReadLine();
            //AddSamurai(samuraiName);
            //AddBattle(samuraiName);


            Console.WriteLine("Samurai Operations: ");
            //GetSamurais();
            //QueryFilter();
            //RetriveAndUpdateSamurai();
            //DeleteSamurai();


            // Relation inserts
            //SamuraiWithAQuote();
            //EagerLoadingRelatedData();
            //ProjectSamuraiWithQuotes();
            FilteringWithRelatedData();

        }

        private static Samurai AddSamurai(string SamuraiName)
        {
            var samurai = new Samurai { Name = SamuraiName };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();

            return samurai;
        }

        private static void AddBattle(string Name)
        {
            var battle = new Battle { Name = $"Battle of {Name}" };
            _context.Battles.Add(battle);
            _context.SaveChanges();
        }

        private static void GetSamurais()
        {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine("GetSamurais:");
            samurais.ForEach(sam => Console.WriteLine(sam.Name));
        }

        private static void QueryFilter()
        {
            var samurais = _context.Samurais.Where(s => s.Name != null).ToList();
            Console.WriteLine("GetSamuraisWithFilter:");
            samurais.ForEach(sam => Console.WriteLine(sam.Name));

        }

        private static void RetriveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "Sam";
            Console.WriteLine($"Updated {samurai.Name}");
            _context.SaveChanges();
        }

        private static void DeleteSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();

            if (samurai != null)
            {
                _context.Remove(samurai);
                Console.WriteLine($"Deleted {samurai.Name}");
                _context.SaveChanges();

            }
        }

        private static void SamuraiWithAQuote()
        {
            var samurai = new Samurai
            {
                Name = "Kambi Shimbi",
                Quotes = new System.Collections.Generic.List<Quote>
                {
                    new Quote{ Text = "I am samurai" }
                }
            };
            _context.Add(samurai);
            _context.SaveChanges();
        }

        private static void EagerLoadingRelatedData()
        {
            var samurais = _context.Samurais.Include(s => s.Quotes).ToList();
        }

        private static void ProjectSamuraiWithQuotes()
        {
            var data = _context.Samurais.Select(s => new { Id = s.Id, Name = s.Name }).ToList();
        }

        private static void FilteringWithRelatedData()
        {
            var samurais = _context.Samurais.Where(s => s.Quotes.Any(q => q.Text.Contains("Happy"))).ToList();
        }
    }
}
