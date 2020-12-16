using System;
using Zenject;

namespace Diffdel
{
    internal class DiffdelController : IInitializable, IDisposable
    {
        private readonly ButtonText _buttonText;

        public DiffdelController(StandardLevelDetailViewController standardLevelDetailViewController)
        {
            _buttonText = (Accessors.NPSText(ref Accessors.ParamsPanel(ref Accessors.LevelDetailView(ref standardLevelDetailViewController))) as ButtonText)!;
        }

        public void Initialize()
        {
            _buttonText.OnClickEvent += ClickedHiddenText;
        }

        private void ClickedHiddenText()
        {
            Plugin.Log?.Info("clicked");
        }

        public void Dispose()
        {
            _buttonText.OnClickEvent -= ClickedHiddenText;
        }
    }
}