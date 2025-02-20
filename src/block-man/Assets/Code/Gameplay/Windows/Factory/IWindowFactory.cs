using Code.Gameplay.UI.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Windows.Factory
{
    public interface IWindowFactory
    {
        void SetUIRoot(RectTransform uiRoot);
        BaseWindow CreateWindows(WindowsId windowsId);
        RectTransform UIRoot { get; }
        PointsCounter CreatePointsCounter();
    }
}