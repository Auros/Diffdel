using System;
using Zenject;
using System.Collections.Generic;
using System.Linq;

namespace Diffdel
{
    internal class DiffdelController : IInitializable, IDisposable
    {
        private bool _hidElements;
        private readonly Config _config;
        private readonly ButtonText _buttonText;
        private readonly StandardLevelDetailView _standardLevelDetailView;
        private readonly PlatformLeaderboardViewController _platformLeaderboardViewController;
        private readonly DiffdelDifficultyControlController _diffdelDifficultyControlController;
        private readonly BeatmapCharacteristicSegmentedControlController _beatmapCharacteristicSegmentedControlController;

        public DiffdelController(Config config, PlatformLeaderboardViewController platformLeaderboardViewController, StandardLevelDetailViewController standardLevelDetailViewController)
        {
            _config = config;
            _platformLeaderboardViewController = platformLeaderboardViewController;
            _standardLevelDetailView = Accessors.LevelDetailView(ref standardLevelDetailViewController)!;
            _buttonText = (Accessors.NPSText(ref Accessors.ParamsPanel(ref _standardLevelDetailView)) as ButtonText)!;
            _beatmapCharacteristicSegmentedControlController = (Accessors.CharacteristicSegment(ref _standardLevelDetailView))!;
            _diffdelDifficultyControlController = (Accessors.DifficultySegment(ref _standardLevelDetailView) as DiffdelDifficultyControlController)!;
        }

        public void Initialize()
        {
            _buttonText.OnClickEvent += ClickedHiddenText;
            _diffdelDifficultyControlController.BeatmapSelected += BeatmapSelected;
        }

        private IDifficultyBeatmap[] BeatmapSelected(IDifficultyBeatmap[] beatmaps)
        {
            List<IDifficultyBeatmap> allowedBeatmaps = new List<IDifficultyBeatmap>();
            if (_config.Levels.TryGetValue($"{beatmaps[0].level.levelID}_{_beatmapCharacteristicSegmentedControlController.selectedBeatmapCharacteristic.serializedName}", out Config.MapSet mapSet))
            {
                foreach (var beatmap in beatmaps)
                {
                    if (!mapSet.Difficulties.Contains(beatmap.difficulty))
                    {
                        allowedBeatmaps.Add(beatmap);
                    }
                }
                allowedBeatmaps = allowedBeatmaps.Where(bm => !_config.Globals.Contains(bm.difficulty)).ToList();
                if (allowedBeatmaps.Count == 0)
                {
                    SetPlayable(false);
                    return beatmaps;
                }
                if (_hidElements) SetPlayable(true);
                return allowedBeatmaps.ToArray();
            }
            allowedBeatmaps = beatmaps.Where(bm => !_config.Globals.Contains(bm.difficulty)).ToList();
            if (allowedBeatmaps.Count == 0)
            {
                SetPlayable(false);
                return beatmaps;
            }
            if (_hidElements) SetPlayable(true);
            return allowedBeatmaps.ToArray();
        }

        private void SetPlayable(bool canPlay)
        {
            _standardLevelDetailView.actionButton.transform.parent.gameObject.SetActive(canPlay);
            _diffdelDifficultyControlController.gameObject.SetActive(canPlay);
            _hidElements = !canPlay;
        }

        private void ClickedHiddenText()
        {
            var detail = _standardLevelDetailView;
            var level = _standardLevelDetailView.selectedDifficultyBeatmap.level;
            if (!_config.Levels.TryGetValue($"{level.levelID}_{_beatmapCharacteristicSegmentedControlController.selectedBeatmapCharacteristic.serializedName}", out Config.MapSet mapSet))
            {
                mapSet = new Config.MapSet { Name = level.songName };
                _config.Levels.Add($"{level.levelID}_{_beatmapCharacteristicSegmentedControlController.selectedBeatmapCharacteristic.serializedName}", mapSet);
            }
            mapSet.Difficulties.Add(_standardLevelDetailView.selectedDifficultyBeatmap.difficulty);
            _config.Changed();

            /*var diffController = _diffdelDifficultyControlController as BeatmapDifficultySegmentedControlController;
            Accessors.Diffs(ref diffController).Remove(_standardLevelDetailView.selectedDifficultyBeatmap.difficulty);
            var closestIndex = diffController.GetClosestDifficultyIndex(_standardLevelDetailView.selectedDifficultyBeatmap.difficulty);*/

            var set = level.beatmapLevelData.GetDifficultyBeatmapSet(_beatmapCharacteristicSegmentedControlController.selectedBeatmapCharacteristic).difficultyBeatmaps.Where(diff => !mapSet.Difficulties.Contains(diff.difficulty));
            if (set.Count() != 0)
            {
                _diffdelDifficultyControlController.SetData(set.ToArray(), _standardLevelDetailView.selectedDifficultyBeatmap.difficulty);
            }

            _standardLevelDetailView.SetContent(level, _diffdelDifficultyControlController.selectedDifficulty, null,
                Accessors.Player(ref detail),
                Accessors.Stats(ref detail)
                );
            _platformLeaderboardViewController.SetData(_standardLevelDetailView.selectedDifficultyBeatmap);

        }

        public void Dispose()
        {
            _buttonText.OnClickEvent -= ClickedHiddenText;
            _diffdelDifficultyControlController.BeatmapSelected -= BeatmapSelected;
        }
    }
}