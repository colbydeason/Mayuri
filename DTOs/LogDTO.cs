using Mayuri.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.DTOs
{
    public class LogDTO
    {
        [Key]
        public Guid LogId { get; set; }
        public int SourceId { get; set; }
        public int Duration { get; set; }
    }
}
