namespace ado6_3
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=CURRENCY")
        {
        }

        public virtual DbSet<curs> curs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<curs>()
                .Property(e => e.title)
                .IsUnicode(false);
        }
    }
}
