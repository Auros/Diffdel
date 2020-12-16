using System.Collections.Generic;
using IPA.Config.Stores.Attributes;
using IPA.Config.Stores.Converters;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(IPA.Config.Stores.GeneratedStore.AssemblyVisibilityTarget)]
namespace Diffdel
{
    internal class Config
    {
        [UseConverter(typeof(DictionaryConverter<MapSet>)), NonNullable]
        public virtual Dictionary<string, MapSet> Levels { get; set; } = new Dictionary<string, MapSet>();

        public class MapSet
        {
            [NonNullable]
            public virtual string Name { get; set; } = null!;

            [UseConverter(typeof(ListConverter<BeatmapDifficulty, EnumConverter<BeatmapDifficulty>>)), NonNullable]
            public virtual List<BeatmapDifficulty> Difficulties { get; set; } = new List<BeatmapDifficulty>();
        }

        public virtual void Changed() { }
    }
}