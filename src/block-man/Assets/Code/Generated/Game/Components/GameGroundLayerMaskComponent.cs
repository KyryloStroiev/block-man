//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGroundLayerMask;

    public static Entitas.IMatcher<GameEntity> GroundLayerMask {
        get {
            if (_matcherGroundLayerMask == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GroundLayerMask);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGroundLayerMask = matcher;
            }

            return _matcherGroundLayerMask;
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

    public Code.Gameplay.Features.TargetCollection.GroundLayerMask groundLayerMask { get { return (Code.Gameplay.Features.TargetCollection.GroundLayerMask)GetComponent(GameComponentsLookup.GroundLayerMask); } }
    public int GroundLayerMask { get { return groundLayerMask.Value; } }
    public bool hasGroundLayerMask { get { return HasComponent(GameComponentsLookup.GroundLayerMask); } }

    public GameEntity AddGroundLayerMask(int newValue) {
        var index = GameComponentsLookup.GroundLayerMask;
        var component = (Code.Gameplay.Features.TargetCollection.GroundLayerMask)CreateComponent(index, typeof(Code.Gameplay.Features.TargetCollection.GroundLayerMask));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceGroundLayerMask(int newValue) {
        var index = GameComponentsLookup.GroundLayerMask;
        var component = (Code.Gameplay.Features.TargetCollection.GroundLayerMask)CreateComponent(index, typeof(Code.Gameplay.Features.TargetCollection.GroundLayerMask));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveGroundLayerMask() {
        RemoveComponent(GameComponentsLookup.GroundLayerMask);
        return this;
    }
}