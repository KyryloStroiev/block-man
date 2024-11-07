using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        public Transform StartHeroPont;
        public Camera MainCamera;
        private ILevelDataProvider _levelDataProvider;
        private ICameraProvider _cameraProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _levelDataProvider = levelDataProvider;
        }
        
        public void Initialize()
        {
            _levelDataProvider.SetStartPoint(StartHeroPont.position);
            _cameraProvider.SetMainCamera(MainCamera);
           
        }
    }
}