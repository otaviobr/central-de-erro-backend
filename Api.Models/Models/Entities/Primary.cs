using Application.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    [Table("Primaries")]
    public class Primary : IBox
    {
        [Column("Id")]
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Column("Log")]
        [Required]
        public Log Log { get; set; }

        [Column("User")]
        [Required]
        public User User { get; set; }

        [Column("DataHora")]
        [Required]
        public DateTime DataHora { get; set; }
    }
}
