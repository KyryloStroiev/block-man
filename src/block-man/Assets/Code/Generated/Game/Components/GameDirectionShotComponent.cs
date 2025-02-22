//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDirectionShot;

    public static Entitas.IMatcher<GameEntity> DirectionShot {
        get {
            if (_matcherDirectionShot == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DirectionShot);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDirectionShot = matcher;
            }

            return _matcherDirectionShot;
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

    public Code.Gameplay.Features.Armaments.DirectionShot directionShot { get { return (Code.Gameplay.Features.Armaments.DirectionShot)GetComponent(GameComponentsLookup.DirectionShot); } }
    public int DirectionShot { get { return directionShot.Value; } }
    public bool hasDirectionShot { get { return HasComponent(GameComponentsLookup.DirectionShot); } }

    public GameEntity AddDirectionShot(int newValue) {
        var index = GameComponentsLookup.DirectionShot;
        var component = (Code.Gameplay.Features.Armaments.DirectionShot)CreateComponent(index, typeof(Code.Gameplay.Features.Armaments.DirectionShot));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceDirectionShot(int newValue) {
        var index = GameComponentsLookup.DirectionShot;
        var component = (Code.Gameplay.Features.Armaments.DirectionShot)CreateComponent(index, typeof(Code.Gameplay.Features.Armaments.DirectionShot));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveDirectionShot() {
        RemoveComponent(GameComponentsLookup.DirectionShot);
        return this;
    }
}
