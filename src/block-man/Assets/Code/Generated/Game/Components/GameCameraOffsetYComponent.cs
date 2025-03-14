//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCameraOffsetY;

    public static Entitas.IMatcher<GameEntity> CameraOffsetY {
        get {
            if (_matcherCameraOffsetY == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CameraOffsetY);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCameraOffsetY = matcher;
            }

            return _matcherCameraOffsetY;
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

    public Code.Gameplay.Features.Hero.CameraOffsetY cameraOffsetY { get { return (Code.Gameplay.Features.Hero.CameraOffsetY)GetComponent(GameComponentsLookup.CameraOffsetY); } }
    public float CameraOffsetY { get { return cameraOffsetY.Value; } }
    public bool hasCameraOffsetY { get { return HasComponent(GameComponentsLookup.CameraOffsetY); } }

    public GameEntity AddCameraOffsetY(float newValue) {
        var index = GameComponentsLookup.CameraOffsetY;
        var component = (Code.Gameplay.Features.Hero.CameraOffsetY)CreateComponent(index, typeof(Code.Gameplay.Features.Hero.CameraOffsetY));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceCameraOffsetY(float newValue) {
        var index = GameComponentsLookup.CameraOffsetY;
        var component = (Code.Gameplay.Features.Hero.CameraOffsetY)CreateComponent(index, typeof(Code.Gameplay.Features.Hero.CameraOffsetY));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveCameraOffsetY() {
        RemoveComponent(GameComponentsLookup.CameraOffsetY);
        return this;
    }
}
