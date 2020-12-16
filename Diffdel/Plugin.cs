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
                var npsText = Accessors.NPSText(ref levelParams);
                var upg = npsText.Upgrade<TextMeshProUGUI, ButtonText>();
                levelParams.SetField<LevelParamsPanel, TextMeshProUGUI>("_notesPerSecondText", upg);
            });
        }

        [OnEnable, OnDisable]
        public void OnState()
        {
            
        }
    }
}