using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApp.Test
{
    [TestClass]
    public class DatabseTests
    {
        [TestMethod]
        public void CanInsertSamuraiIntoDatabase()
        {
            DbContextOptionsBuilder<SamuraiContext> builder = new();
            builder.UseInMemoryDatabase("CanInsertSamurai");

            using (SamuraiContext context = new(builder.Options))
            {
                var samurai = new Samurai();
                context.Samurais.Add(samurai);
                Assert.AreEqual(EntityState.Added, context.Entry(samurai).State);
            }

        }
    }
}
