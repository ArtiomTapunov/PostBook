using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostBook.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostBook.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Message>()
                .HasOne<User>(x => x.Sender)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.UserId);

/*            builder.Entity<ChatUser>()
                .HasKey(x => new { x.ChatId, x.UserId });*/
        }

        public DbSet<User> ApplicationUsers { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<ChatUser> ChatUsers { get; set; }
    }
}
