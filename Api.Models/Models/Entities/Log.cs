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

        [Column("Created_at")]
        [Required]
        public DateTime Created_at { get; set; }

        public Log()
        {

        }

        public Log(string origin, string level, string description, int frequency, string box)
        {
            Origin = origin;
            Level = level;
            Description = description;
            Frequency = frequency;
            Box = box;
        }

        public static IList<Log> ObterDados()
        {
            IList<Log> Logs = new List<Log>();

            for (int i = 1; i <= 1000; i++)
            {
                Logs.Add(new Log()
                {
                    Id = i,
                    Description = "warning",
                    Level = "warning",
                    Origin = "Homologation",
                    Box = "primary",
                    Created_at = DateTime.Now
                });

                Logs.Add(new Log()
                {
                    Id = i + 2100,
                    Description = "error",
                    Level = "error",
                    Origin = "Production",
                    Box = "primary",
                    Created_at = DateTime.Now
                });

                Logs.Add(new Log()
                {
                    Id = i + 3100,
                    Description = "debug",
                    Level = "debug",
                    Origin = "Development",
                    Box = "primary",
                    Created_at = DateTime.Now
                });

            }

            return Logs;
        }
    }
}
