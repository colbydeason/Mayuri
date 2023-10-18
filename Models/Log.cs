using Mayuri.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Models
{
    public class Log
    {
        public int Duration { get; }
        public Guid SourceId {  get; } 
        public DateTime LoggedAt { get; }
        public Source LogSource { get; }
        public Log(int duration, Guid sourceId)
        {
            Duration = duration;
            SourceId = sourceId;
            LoggedAt = DateTime.Now;
        }
        public Log(int duration, Guid sourceId, DateTime loggedAt, Source source)
        {
            Duration = duration;
            SourceId = sourceId;
            LoggedAt = loggedAt;
            LogSource = source;
        }
    }
}
