using Code.Gameplay.StaticData;
using Code.Gameplay.UI.Behaviours;
using Code.Infrastructure.View;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Windows.Factory
{
    public class WindowFactory : IWindowFactory
    {
        public RectTransform UIRoot {get; private set;}
        
        private readonly IStaticDataService _staticData;
        private readonly IInstantiator _instantiator;

        public WindowFactory(IStaticDataService staticData, IInstantiator instantiator)
        {
            _staticData = staticData;
            _instantiator = instantiator;
        }
        
        public void SetUIRoot(RectTransform uiRoot) =>
            UIRoot = uiRoot;
        
        public BaseWindow CreateWindows(WindowsId windowsId)=>
        _instantiator.InstantiatePrefabForComponent<BaseWindow>(PrefabFor(windowsId), UIRoot);

        public PointsCounter CreatePointsCounter() => 
        _instantiator.InstantiatePrefabForComponent<PointsCounter>(_staticData.GetUIElementsConfig().GameplayHUD, UIRoot);
        private GameObject PrefabFor(WindowsId windowsId) => 
            _staticData.GetWindowPrefab(windowsId);
    }
}