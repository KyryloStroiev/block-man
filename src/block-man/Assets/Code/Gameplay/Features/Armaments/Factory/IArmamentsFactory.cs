using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public interface IArmamentsFactory
    {
        GameEntity CreateBulletCube( Vector3 at, float verticalDirection);
 
        GameEntity CreateArmaments(ArmamentsTypeId typeId, Vector3 at, bool isLookRight );
    }
}