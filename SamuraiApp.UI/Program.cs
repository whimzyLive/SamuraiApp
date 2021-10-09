using SamuraiApp.Domain;
using SamuraiApp.Data;
using System.Linq;
using System;

namespace SamuraiApp.UI
{
    class Program
    {
        private static SamuraiContext _context = new();
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Samurai Name To Save to DB:");
            string samurai = Console.ReadLine();
            AddSamurai(samurai);

            Console.WriteLine("All Samuraies: ");
            GetSamurais();


        }

        private static void AddSamurai(string SamuraiName)
        {
            var samurai = new Samurai { Name = SamuraiName };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void GetSamurais()
        {
            var samurais = _context.Samurais.ToList();

            samurais.ForEach(sam => Console.WriteLine(sam.Name));
        }
    }
}
