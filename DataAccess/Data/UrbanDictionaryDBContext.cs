using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.DataAccess.Data
{
    public class UrbanDictionaryDBContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public UrbanDictionaryDBContext(DbContextOptions<UrbanDictionaryDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Word> Word { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<WordTag> WordTags { get; set; }
        public DbSet<UserSavedWord> UserSavedWords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WordTag>()
               .HasOne<Word>(wt => wt.Word)
               .WithMany(w => w.WordTags)
               .HasForeignKey(wt => wt.WordId);

            modelBuilder.Entity<WordTag>()
                .HasOne<Tag>(wt => wt.Tag)
                .WithMany(t => t.WordTags)
                .HasForeignKey(wt => wt.TagId);


            modelBuilder.Entity<UserSavedWord>()
               .HasOne<User>(uw => uw.User)
               .WithMany(u => u.UserSavedWords)
               .HasForeignKey(uw => uw.UserId);

            modelBuilder.Entity<UserSavedWord>()
                .HasOne<Word>(uw => uw.SavedWord)
                .WithMany(w => w.UserSavedWords)
                .HasForeignKey(uw => uw.SavedWordId);
        }
    }
}
