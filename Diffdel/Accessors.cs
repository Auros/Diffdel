using TMPro;
using IPA.Utilities;

namespace Diffdel
{
    internal static class Accessors
    {
        public static FieldAccessor<StandardLevelDetailViewController, StandardLevelDetailView>.Accessor LevelDetailView = FieldAccessor<StandardLevelDetailViewController, StandardLevelDetailView>.GetAccessor("_standardLevelDetailView");
        public static FieldAccessor<StandardLevelDetailView, LevelParamsPanel>.Accessor ParamsPanel = FieldAccessor<StandardLevelDetailView, LevelParamsPanel>.GetAccessor("_levelParamsPanel");
        public static FieldAccessor<LevelParamsPanel, TextMeshProUGUI>.Accessor NPSText = FieldAccessor<LevelParamsPanel, TextMeshProUGUI>.GetAccessor("_notesPerSecondText");
    }
}