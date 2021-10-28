using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lab3._1
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Table> Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Table>()
                .Property(e => e.EyesColor)
                .IsFixedLength();

            modelBuilder.Entity<Table>()
                .Property(e => e.FlatAvailability)
                .IsFixedLength();
        }
    }
}
