using TMPro;
using IPA.Utilities;

namespace Diffdel
{
    internal static class Accessors
    {
        public static FieldAccessor<StandardLevelDetailView, BeatmapCharacteristicSegmentedControlController>.Accessor CharacteristicSegment = FieldAccessor<StandardLevelDetailView, BeatmapCharacteristicSegmentedControlController>.GetAccessor("_beatmapCharacteristicSegmentedControlController");
        public static FieldAccessor<StandardLevelDetailView, BeatmapDifficultySegmentedControlController>.Accessor DifficultySegment = FieldAccessor<StandardLevelDetailView, BeatmapDifficultySegmentedControlController>.GetAccessor("_beatmapDifficultySegmentedControlController");
        public static FieldAccessor<StandardLevelDetailViewController, StandardLevelDetailView>.Accessor LevelDetailView = FieldAccessor<StandardLevelDetailViewController, StandardLevelDetailView>.GetAccessor("_standardLevelDetailView");
        public static FieldAccessor<StandardLevelDetailView, LevelParamsPanel>.Accessor ParamsPanel = FieldAccessor<StandardLevelDetailView, LevelParamsPanel>.GetAccessor("_levelParamsPanel");
        public static FieldAccessor<LevelParamsPanel, TextMeshProUGUI>.Accessor NPSText = FieldAccessor<LevelParamsPanel, TextMeshProUGUI>.GetAccessor("_notesPerSecondText");
        public static FieldAccessor<StandardLevelDetailView, PlayerData>.Accessor Player = FieldAccessor<StandardLevelDetailView, PlayerData>.GetAccessor("_playerData");
        public static FieldAccessor<StandardLevelDetailView, bool>.Accessor Stats = FieldAccessor<StandardLevelDetailView, bool>.GetAccessor("_showPlayerStats");
    }
}