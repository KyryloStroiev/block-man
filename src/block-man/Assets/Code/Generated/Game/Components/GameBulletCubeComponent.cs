//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBulletCube;

    public static Entitas.IMatcher<GameEntity> BulletCube {
        get {
            if (_matcherBulletCube == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BulletCube);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBulletCube = matcher;
            }

            return _matcherBulletCube;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.Gameplay.Features.Armaments.BulletCube bulletCubeComponent = new Code.Gameplay.Features.Armaments.BulletCube();

    public bool isBulletCube {
        get { return HasComponent(GameComponentsLookup.BulletCube); }
        set {
            if (value != isBulletCube) {
                var index = GameComponentsLookup.BulletCube;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : bulletCubeComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
