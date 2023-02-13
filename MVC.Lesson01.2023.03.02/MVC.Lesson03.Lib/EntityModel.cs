using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MVC.Lesson03.Lib
{
    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
        }

        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<SliderArea> SliderAreas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .Property(e => e.Square)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RoomType>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.RoomType)
                .WillCascadeOnDelete(false);
        }
    }
}
