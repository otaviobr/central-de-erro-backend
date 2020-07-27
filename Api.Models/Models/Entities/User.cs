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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

            return users;
        }
    }
}
