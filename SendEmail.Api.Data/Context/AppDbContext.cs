using Microsoft.EntityFrameworkCore;
using SendEmail.Api.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<EmailModel> Emails { get; set; }
        public DbSet<UserPreferencesModel> UserPreferences { get; set; }
        public DbSet<LogEmail> EmailLogs { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("Users");
            modelBuilder.Entity<EmailModel>().ToTable("Emails");
            modelBuilder.Entity<UserPreferencesModel>().ToTable("UserPreferences");
            modelBuilder.Entity<LogEmail>().ToTable("EmailLogs");
        }
    }
}
