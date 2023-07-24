using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
namespace GymDB.Models
{
    public partial class GymContext : DbContext
    {
        public GymContext()
        {

        }
        public GymContext(DbContextOptions<GymContext> options) : base(options)
        {

        }
        public virtual DbSet<People> Peoples { get; set; }
    }
}
