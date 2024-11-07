using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public interface IHeroFactory
    {
        GameEntity CreateHero(Vector3 at);
        GameEntity CreateCrosshair(Vector3 at);
    }
}