//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCrosshair;

    public static Entitas.IMatcher<GameEntity> Crosshair {
        get {
            if (_matcherCrosshair == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Crosshair);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCrosshair = matcher;
            }

            return _matcherCrosshair;
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

    static readonly Code.Gameplay.Features.Crosshair.Crosshair crosshairComponent = new Code.Gameplay.Features.Crosshair.Crosshair();

    public bool isCrosshair {
        get { return HasComponent(GameComponentsLookup.Crosshair); }
        set {
            if (value != isCrosshair) {
                var index = GameComponentsLookup.Crosshair;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : crosshairComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}