using System;
using Zenject;

namespace Diffdel
{
    internal class DiffdelController : IInitializable, IDisposable
    {
        private readonly ButtonText _buttonText;
        private readonly DiffdelDifficultyControlController _diffdelDifficultyControlController;

        public DiffdelController(StandardLevelDetailViewController standardLevelDetailViewController)
        {
            StandardLevelDetailView detailView = Accessors.LevelDetailView(ref standardLevelDetailViewController)!;

            _buttonText = (Accessors.NPSText(ref Accessors.ParamsPanel(ref detailView)) as ButtonText)!;
            _diffdelDifficultyControlController = (Accessors.DifficultySegment(ref detailView) as DiffdelDifficultyControlController)!;
        }

        public void Initialize()
        {
            _buttonText.OnClickEvent += ClickedHiddenText;
            _diffdelDifficultyControlController.BeatmapSelected += BeatmapSelected;
        }

        private IDifficultyBeatmap[] BeatmapSelected(IDifficultyBeatmap[] beatmaps)
        {
            return beatmaps;
        }

        private void ClickedHiddenText()
        {
            Plugin.Log?.Info("clicked");
        }

        public void Dispose()
        {
            _buttonText.OnClickEvent -= ClickedHiddenText;
            _diffdelDifficultyControlController.BeatmapSelected -= BeatmapSelected;
        }
    }
}