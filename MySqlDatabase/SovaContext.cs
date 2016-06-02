using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainModel;

namespace MySqlDatabase
{
    public class SovaContext : DbContext
    {
        public SovaContext() : base("sova")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<WordIdf> WordIdfs { get; set; }
        public DbSet<WordTf> WordTfs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("userid");
            modelBuilder.Entity<User>().Property(u => u.Age).HasColumnName("userage");
            modelBuilder.Entity<User>().Property(u => u.CreationDate).HasColumnName("usercreationdate");
            modelBuilder.Entity<User>().Property(u => u.DisplayName).HasColumnName("userdisplayname");
            modelBuilder.Entity<User>().Property(u => u.Location).HasColumnName("userlocation");

            modelBuilder.Entity<History>().ToTable("history");
            modelBuilder.Entity<History>().Property(u => u.Id).HasColumnName("historyid");
            modelBuilder.Entity<History>().Property(u => u.Statement).HasColumnName("statement");
            modelBuilder.Entity<History>().Property(u => u.SearchDate).HasColumnName("searchdate");

            modelBuilder.Entity<Comment>().ToTable("comment");
            modelBuilder.Entity<Comment>().Property(c => c.Id).HasColumnName("commentid");
            modelBuilder.Entity<Comment>().Property(c => c.Score).HasColumnName("commentscore");
            modelBuilder.Entity<Comment>().Property(c => c.Text).HasColumnName("commenttext");
            modelBuilder.Entity<Comment>().Property(c => c.CreationDate).HasColumnName("commentcreatedate");
            modelBuilder.Entity<Comment>().Property(c => c.UserId).HasColumnName("owneruserid");



            modelBuilder.Entity<Post>().ToTable("post");
            modelBuilder.Entity<Post>().Property(p => p.Id).HasColumnName("postid");
            modelBuilder.Entity<Post>().Property(p => p.UserId).HasColumnName("owneruserid");


            modelBuilder.Entity<Mark>().ToTable("mark");
            modelBuilder.Entity<Mark>().Property(m => m.Id).HasColumnName("markid");
            modelBuilder.Entity<WordIdf>().ToTable("wordidf");

            modelBuilder.Entity<WordTf>().ToTable("wordTf").HasKey(pc => new { pc.Contentid, pc.Tf, pc.WordId });

            base.OnModelCreating(modelBuilder);
        }


    }
}
