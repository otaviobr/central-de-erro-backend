using Application.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Entities
{
    [Table("Archived")]
    public class Archive : IBox
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
        public User User{ get; set; }

        [Column("DataHora")]
        [Required]
        public DateTime DataHora { get; set; }

    }
}
