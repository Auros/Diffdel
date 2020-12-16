using IPA;
using TMPro;
using SiraUtil;
using IPA.Utilities;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;

namespace Diffdel
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static IPALogger? Log { get; private set; }

        [Init]
        public Plugin(IPALogger logger, Zenjector zenjector)
        {
            Log = logger;

            zenjector
            .On<MenuInstaller>()
            .Pseudo((Container) => Container.BindInterfacesTo<DiffdelController>().AsSingle())
            .Mutate<StandardLevelDetailViewController>((ctx, levelDetailViewController) =>
            {
                var levelDetail = Accessors.LevelDetailView(ref levelDetailViewController);
                var levelParams = Accessors.ParamsPanel(ref levelDetail);
                Accessors.NPSText(ref levelParams) = Accessors.NPSText(ref levelParams).Upgrade<TextMeshProUGUI, ButtonText>();
                Accessors.DifficultySegment(ref levelDetail) = Accessors.DifficultySegment(ref levelDetail).Upgrade<BeatmapDifficultySegmentedControlController, DiffdelDifficultyControlController>();
            });
        }

        [OnEnable, OnDisable]
        public void OnState()
        {
            
        }
    }
}