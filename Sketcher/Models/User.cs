using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sketcher.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserPhotoPath { get; set; }

        public virtual List<Sketch> Sketches {get ; set;}
    }

    public class Sketch
    {
        [Key]
        public int SketchId { get; set; }
        public string Description { get; set; }
        
        
        public int UserId { get; set; }
        public User User { get; set; }
    }

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class UserContext : DbContext
    {
        public UserContext()
            : base("UserContext")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Sketch> Sketches { get; set; }
    }
}