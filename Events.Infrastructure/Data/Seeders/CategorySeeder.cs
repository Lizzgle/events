using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Infrastructure.Data.Seeders
{
    public static class CategorySeeder
    {
        public static void SeedCategories(this EntityTypeBuilder<Category> builder)
        {
            builder.HasData([Category.Concert, Category.Conference, Category.Training, Category.Sports, Category.Festival]);
        }
    }
}
