using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Expenses.Any() && context.LkpCategories.Any()) return;
            var categories = new List<LkpCategory>
            {new LkpCategory
                {
                    Id = Guid.NewGuid(),
                    CategoryTypeId = 1,
                    Name = "Food"
                },
                new LkpCategory()
                {
                    Id = Guid.NewGuid(),
                    CategoryTypeId = 2,
                    Name = "Rent/Mortgage"
                },
                new LkpCategory()
                {
                    Id = Guid.NewGuid(),
                    CategoryTypeId = 3,
                    Name = "Transportation"
                },
                new LkpCategory()
                {
                    Id = Guid.NewGuid(),
                    CategoryTypeId = 4,
                    Name = "Healthcare"
                },
                new LkpCategory()
                {
                    Id = Guid.NewGuid(),
                    CategoryTypeId = 5,
                    Name = "Education"
                },
                new LkpCategory()
                {
                    Id = Guid.NewGuid(),
                    CategoryTypeId = 6,
                    Name = "Miscellaneous"
                }
            };

            var expenses = new List<Expense>()
            {
                new Expense()
                {
                    Id = Guid.NewGuid(),
                    Amount = 10.00m,
                    LkpCategory = 1,
                    Description = "Hot Dog, ya it was 10 bucks",
                    Date = DateTime.UtcNow
                },
                new Expense()
                {
                    Id = Guid.NewGuid(),
                    Amount = 1100.00m,
                    LkpCategory = 2,
                    Description = "Rent payment",
                    Date = DateTime.UtcNow
                },
                new Expense()
                {
                    Id = Guid.NewGuid(),
                    Amount = 30.00m,
                    LkpCategory = 3,
                    Description = "Gas",
                    Date = DateTime.UtcNow
                },
            };

            await context.Expenses.AddRangeAsync(expenses);
            await context.LkpCategories.AddRangeAsync(categories);
            
            await context.SaveChangesAsync();
        }
    }
}