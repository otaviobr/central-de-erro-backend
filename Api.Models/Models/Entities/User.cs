using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class User
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Email")]
        [StringLength(250)]
        [Required]
        public string Email { get; set; }

        [Column("Password")]
        [Required]
        public string Password { get; set; }

        public static IList<User> ObterDados()
        {
            List<User> users = new List<User>();

            for (var i = 1; i < 10; i++)
            {
                users.Add(new User() { Id = i, Email = $"otavio{i}@otavio.com", Password = $"{i}123" });
            }

            return users;
        }
    }
}
