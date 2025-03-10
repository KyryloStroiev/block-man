//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGunCube;

    public static Entitas.IMatcher<GameEntity> GunCube {
        get {
            if (_matcherGunCube == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GunCube);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGunCube = matcher;
            }

            return _matcherGunCube;
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

    static readonly Code.Gameplay.Features.Armaments.GunCube gunCubeComponent = new Code.Gameplay.Features.Armaments.GunCube();

    public bool isGunCube {
        get { return HasComponent(GameComponentsLookup.GunCube); }
        set {
            if (value != isGunCube) {
                var index = GameComponentsLookup.GunCube;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : gunCubeComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
