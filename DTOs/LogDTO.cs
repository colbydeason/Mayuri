using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mayuri.DTOs
{
    public class LogDTO
    {
        [Key]
        public Guid LogId { get; set; }
        public Guid SourceId { get; set; }
        public int Duration { get; set; }
        public DateTime LoggedAt { get; set; }
        [ForeignKey(nameof(SourceId))]
        public SourceDTO? Source { get; set; } = null;
    }
}
