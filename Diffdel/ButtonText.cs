using HMUI;
using System;
using UnityEngine.EventSystems;

namespace Diffdel
{
    internal class ButtonText : CurvedTextMeshPro, IPointerClickHandler, IEventSystemHandler
    {
        public event Action? OnClickEvent = null!;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickEvent?.Invoke();
        }
    }
}