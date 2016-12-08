using MvcApplication5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MemberShip.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("Test")
        {
        }

        public DbSet<Employee> UserProfiles { get; set; }
    }

    //[Table("userprofile")]
    //public class userprofile
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int userid { get; set; }
    //    public string username { get; set; }
    //}

    public class LoginModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}