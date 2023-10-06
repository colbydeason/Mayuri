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
        public bool Completed { get; }
        public int TotalDuration {  get; }
    }
}
