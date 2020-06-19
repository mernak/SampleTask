using Microsoft.EntityFrameworkCore;
using SampleTaskServerSide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide
{
    public class SampleWebProjectDbContext : DbContext
    {
        public SampleWebProjectDbContext(DbContextOptions options)
    : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberEntity>().HasOne(o => o.Package);
            modelBuilder.Entity<MemberEntity>().HasOne(o => o.Trainer);
            modelBuilder.Entity<FeedbackEntity>().HasMany(o => o.Trainers);
            modelBuilder.Entity<FeedbackEntity>().HasMany(o => o.Members);
            modelBuilder.Entity<PaymentEntity>().HasOne(o => o.Member);

        }
        public DbSet<PackageEntity> Packages { get; set; }
        public DbSet<FeedbackEntity> Feedbacks { get; set; }
        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }
        public DbSet<TrainerEntity> Trainers { get; set; }
         public DbSet<UserEntity> Users { get; set; }
    }
}
