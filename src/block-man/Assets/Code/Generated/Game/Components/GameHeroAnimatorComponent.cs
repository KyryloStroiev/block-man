//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHeroAnimator;

    public static Entitas.IMatcher<GameEntity> HeroAnimator {
        get {
            if (_matcherHeroAnimator == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HeroAnimator);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHeroAnimator = matcher;
            }

            return _matcherHeroAnimator;
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

    public Code.Gameplay.Features.Hero.HeroComponents.HeroAnimatorComponent heroAnimator { get { return (Code.Gameplay.Features.Hero.HeroComponents.HeroAnimatorComponent)GetComponent(GameComponentsLookup.HeroAnimator); } }
    public Code.Gameplay.Features.Hero.Behaviours.HeroAnimator HeroAnimator { get { return heroAnimator.Value; } }
    public bool hasHeroAnimator { get { return HasComponent(GameComponentsLookup.HeroAnimator); } }

    public GameEntity AddHeroAnimator(Code.Gameplay.Features.Hero.Behaviours.HeroAnimator newValue) {
        var index = GameComponentsLookup.HeroAnimator;
        var component = (Code.Gameplay.Features.Hero.HeroComponents.HeroAnimatorComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Hero.HeroComponents.HeroAnimatorComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceHeroAnimator(Code.Gameplay.Features.Hero.Behaviours.HeroAnimator newValue) {
        var index = GameComponentsLookup.HeroAnimator;
        var component = (Code.Gameplay.Features.Hero.HeroComponents.HeroAnimatorComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Hero.HeroComponents.HeroAnimatorComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveHeroAnimator() {
        RemoveComponent(GameComponentsLookup.HeroAnimator);
        return this;
    }
}