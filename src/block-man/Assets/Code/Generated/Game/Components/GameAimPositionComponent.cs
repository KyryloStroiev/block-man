//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAimPosition;

    public static Entitas.IMatcher<GameEntity> AimPosition {
        get {
            if (_matcherAimPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AimPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAimPosition = matcher;
            }

            return _matcherAimPosition;
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

    public Code.Gameplay.Input.AimPosition aimPosition { get { return (Code.Gameplay.Input.AimPosition)GetComponent(GameComponentsLookup.AimPosition); } }
    public UnityEngine.Vector2 AimPosition { get { return aimPosition.Value; } }
    public bool hasAimPosition { get { return HasComponent(GameComponentsLookup.AimPosition); } }

    public GameEntity AddAimPosition(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.AimPosition;
        var component = (Code.Gameplay.Input.AimPosition)CreateComponent(index, typeof(Code.Gameplay.Input.AimPosition));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAimPosition(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.AimPosition;
        var component = (Code.Gameplay.Input.AimPosition)CreateComponent(index, typeof(Code.Gameplay.Input.AimPosition));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAimPosition() {
        RemoveComponent(GameComponentsLookup.AimPosition);
        return this;
    }
}
