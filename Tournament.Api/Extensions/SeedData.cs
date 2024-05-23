using Bogus;
using Microsoft.EntityFrameworkCore;
using Tournament.Core;
using Tournament.Data;

namespace Tournament.Api.Extensions
{
    public class SeedData
    {
        private static Faker faker;

        public static async Task InitAsync(TournmentDbContext context)
        {
            if (await context.Tournaments.AnyAsync()) return;

            faker = new Faker("sv");

            var g = new Game
            {

                Title = "game xxx",
                Time = DateTime.Now
            };
            var t = new Tournament.Core.Tournament
            {
                Title = "tournament yyyy",
                StartTime = DateTime.Now,
                Games = new[] {g}
            };

            await context.AddRangeAsync(t);

            await context.SaveChangesAsync();
            /*
            var customers = GenerateCustomers(1000);
            var (vehicles, vtypes) = GenerateVehicles(customers);

            await context.AddRangeAsync(customers);
            await context.AddRangeAsync(vtypes);
            await context.AddRangeAsync(vehicles);

            await context.SaveChangesAsync();
        */
        }

    }
}
