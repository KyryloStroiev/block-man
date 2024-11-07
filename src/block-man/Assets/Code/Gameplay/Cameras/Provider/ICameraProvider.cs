using UnityEngine;

namespace Code.Gameplay.Cameras.Provider
{
    public interface ICameraProvider
    {
        Camera MainCamera { get; }
        void SetMainCamera(Camera camera);
    }
}