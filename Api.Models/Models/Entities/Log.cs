using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    [Table("Logs")]
    public class Log
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        
        [Column("Origin")]
        [Required]
        public string Origin { get; set; }

        [Column("Level")]
        [Required]
        public string Level { get; set; }

        [Column("Description")]
        [StringLength(250)]
        [Required]
        public string Description { get; set; }

        [Column("Frequency")]
        [Required]
        public int Frequency { get; set; }

        [Column("Box")]
        [Required]
        public string Box { get; set; }

        public static IList<Log> ObterDados()
        {
            IList<Log> Logs = new List<Log>();

            for (int i = 1; i < 10000; i++)
            {
                Logs.Add(new Log()
                {
                    Id = i,
                    Description = $"Description {i}",
                    Frequency = (i * 1),
                    Level = "High",
                    Origin = "OnModelCreating",
                    Box = i % 2 == 0 ? "primary" : "archive"
                });
            }

            return Logs;
        }
    }
}
