//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLastDirection;

    public static Entitas.IMatcher<GameEntity> LastDirection {
        get {
            if (_matcherLastDirection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LastDirection);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLastDirection = matcher;
            }

            return _matcherLastDirection;
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

    public Code.Gameplay.Features.Movement.MovementComponents.LastDirection lastDirection { get { return (Code.Gameplay.Features.Movement.MovementComponents.LastDirection)GetComponent(GameComponentsLookup.LastDirection); } }
    public float LastDirection { get { return lastDirection.Value; } }
    public bool hasLastDirection { get { return HasComponent(GameComponentsLookup.LastDirection); } }

    public GameEntity AddLastDirection(float newValue) {
        var index = GameComponentsLookup.LastDirection;
        var component = (Code.Gameplay.Features.Movement.MovementComponents.LastDirection)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.MovementComponents.LastDirection));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceLastDirection(float newValue) {
        var index = GameComponentsLookup.LastDirection;
        var component = (Code.Gameplay.Features.Movement.MovementComponents.LastDirection)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.MovementComponents.LastDirection));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveLastDirection() {
        RemoveComponent(GameComponentsLookup.LastDirection);
        return this;
    }
}
