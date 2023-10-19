using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mayuri.DTOs
{
    public class SourceDTO
    {
        [Key]
        public Guid SourceId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public bool OneTime { get; set; }
        public bool Completed { get; set; }
        public int TotalDuration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<LogDTO> Logs { get; set; } = new();
    }
}
