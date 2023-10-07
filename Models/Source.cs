using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Models
{
    public enum SourceType
    {
        Book,
        Anime,
        Manga,
        VisualNovel,
        VideoGame,
        Reading,
        Listening,
        Other
    };
    public class Source
    {
        public string Name { get; }
        public string Description { get; }
        public SourceType Type { get; }
        public bool OneTime { get; }
        public bool Completed { get; set; }
        public int TotalDuration { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; set; }
        public Source(string name, string description, SourceType type, bool oneTime, bool completed, int totalDuration)
        {
            Name = name;
            Description = description;
            Type = type;
            OneTime = oneTime;
            Completed = completed;
            TotalDuration = totalDuration;
            CreatedAt = DateTime.Now;
            UpdatedAt = CreatedAt;
        }
    }
}
