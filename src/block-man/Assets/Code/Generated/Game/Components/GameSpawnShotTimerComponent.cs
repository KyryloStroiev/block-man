//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSpawnShotTimer;

    public static Entitas.IMatcher<GameEntity> SpawnShotTimer {
        get {
            if (_matcherSpawnShotTimer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SpawnShotTimer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpawnShotTimer = matcher;
            }

            return _matcherSpawnShotTimer;
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

    public Code.Gameplay.Features.Armaments.SpawnShotTimer spawnShotTimer { get { return (Code.Gameplay.Features.Armaments.SpawnShotTimer)GetComponent(GameComponentsLookup.SpawnShotTimer); } }
    public float SpawnShotTimer { get { return spawnShotTimer.Value; } }
    public bool hasSpawnShotTimer { get { return HasComponent(GameComponentsLookup.SpawnShotTimer); } }

    public GameEntity AddSpawnShotTimer(float newValue) {
        var index = GameComponentsLookup.SpawnShotTimer;
        var component = (Code.Gameplay.Features.Armaments.SpawnShotTimer)CreateComponent(index, typeof(Code.Gameplay.Features.Armaments.SpawnShotTimer));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceSpawnShotTimer(float newValue) {
        var index = GameComponentsLookup.SpawnShotTimer;
        var component = (Code.Gameplay.Features.Armaments.SpawnShotTimer)CreateComponent(index, typeof(Code.Gameplay.Features.Armaments.SpawnShotTimer));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveSpawnShotTimer() {
        RemoveComponent(GameComponentsLookup.SpawnShotTimer);
        return this;
    }
}
