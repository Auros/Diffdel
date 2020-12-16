using IPA;
using TMPro;
using Polyglot;
using UnityEngine;
using IPA.Utilities;
using UnityEngine.UI;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;
using HMUI;
using SiraUtil;

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

                /*Button button = ctx.Container.InstantiatePrefabForComponent<Button>(levelDetail.practiceButton);
                ContentSizeFitter contentSizeFitter = button.gameObject.AddComponent<ContentSizeFitter>();
                Object.Destroy(button.transform.Find("Content").GetComponent<LayoutElement>());
                contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
                contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                LayoutElement element = button.gameObject.GetComponent<LayoutElement>();

                element.preferredWidth = 2f;
                element.preferredHeight = 10f;

                button.gameObject.transform.SetParent(levelDetail.practiceButton.transform.parent, false);

                LocalizedTextMeshProUGUI localizer = button.GetComponentInChildren<LocalizedTextMeshProUGUI>(true);
                if (localizer != null)
                {
                    Object.Destroy(localizer);
                }

                TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
                text.text = "DD";*/
            });
        }

        [OnEnable, OnDisable]
        public void OnState()
        {
            
        }
    }
}