using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class UserContext : DbContext
    {
        public UserContext()
            : base("UserContext")
        { }

        public DbSet<User> Users { get; set; }
    }
}