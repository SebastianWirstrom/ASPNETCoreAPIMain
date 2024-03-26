using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Infrastructure.Contexts
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<SubscriberEntity> Subscribers { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
    }
}
