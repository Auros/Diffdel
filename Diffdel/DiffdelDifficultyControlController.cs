using System;

namespace Diffdel
{
    internal class DiffdelDifficultyControlController : BeatmapDifficultySegmentedControlController
    {
        public event Func<IDifficultyBeatmap[], IDifficultyBeatmap[]>? BeatmapSelected;

        public override void SetData(IDifficultyBeatmap[] difficultyBeatmaps, BeatmapDifficulty selectedDifficulty)
        {
            var beatmaps = BeatmapSelected?.Invoke(difficultyBeatmaps);
            base.SetData(beatmaps ?? difficultyBeatmaps, selectedDifficulty);
        }
    }
}