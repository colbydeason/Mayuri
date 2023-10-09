using Mayuri.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.DTOs
{
    public class SourceDTO
    {
        [Key]
        public Guid SourceId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public SourceType Type { get; set; }
        public bool OneTime { get; set; }
        public bool Completed { get; set; }
        public int TotalDuration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
