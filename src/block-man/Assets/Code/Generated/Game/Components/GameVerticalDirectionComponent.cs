//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherVerticalDirection;

    public static Entitas.IMatcher<GameEntity> VerticalDirection {
        get {
            if (_matcherVerticalDirection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.VerticalDirection);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVerticalDirection = matcher;
            }

            return _matcherVerticalDirection;
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

    public Code.Gameplay.Features.Movement.MovementComponents.VerticalDirection verticalDirection { get { return (Code.Gameplay.Features.Movement.MovementComponents.VerticalDirection)GetComponent(GameComponentsLookup.VerticalDirection); } }
    public float VerticalDirection { get { return verticalDirection.Value; } }
    public bool hasVerticalDirection { get { return HasComponent(GameComponentsLookup.VerticalDirection); } }

    public GameEntity AddVerticalDirection(float newValue) {
        var index = GameComponentsLookup.VerticalDirection;
        var component = (Code.Gameplay.Features.Movement.MovementComponents.VerticalDirection)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.MovementComponents.VerticalDirection));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceVerticalDirection(float newValue) {
        var index = GameComponentsLookup.VerticalDirection;
        var component = (Code.Gameplay.Features.Movement.MovementComponents.VerticalDirection)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.MovementComponents.VerticalDirection));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveVerticalDirection() {
        RemoveComponent(GameComponentsLookup.VerticalDirection);
        return this;
    }
}