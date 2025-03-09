using UnityEngine;

namespace Code.Gameplay.UI.Factory
{
    public interface IUIFactory
    {
        GameEntity CreateFlagGameOver(Vector3 at);
        GameEntity CreateGameTimer();
        GameEntity CreateDeathCollider(Vector3 at);
    }
}