using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.CollisionRegistry;
using Code.Gameplay.Common.PhysicsService;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Block.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Input;
using Code.Gameplay.Input.Service;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Infrastructure;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Factory;
using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
{
    public override void InstallBindings()
    {
        BindInputService();
        BindStaticDataService();
        BindInfrastructureServices();
        BindContext();
        BindStateFactory();
        BindGameStateMachine();
        BindCameraProvider();
        BindCommonService();
        BindGameState();
        BindAssetManagementServices();
        BindSystemFactory();
        BindGameFactory();
    }

    private void BindCameraProvider() => 
        Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();

    private void BindInputService() => 
        Container.Bind<IInputService>().To<InputService>().AsSingle();

    private void BindStaticDataService() => 
        Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();

    private void BindSystemFactory() => 
        Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();

    private void BindStateFactory() =>
        Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();

    private void BindGameStateMachine() => 
        Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

    private void BindGameState()
    {
        Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
        Container.BindInterfacesAndSelfTo<LoadingBattleState>().AsSingle();
        Container.BindInterfacesAndSelfTo<BattleEnterState>().AsSingle();
        Container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
    }

    private void BindGameFactory()
    {
       Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
       Container.Bind<IBlockFactory>().To<BlockFactory>().AsSingle();
       Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
    }

    private void BindContext()
    {
        Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();

        Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
    }

    private void BindAssetManagementServices() => 
        Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

    private void BindCommonService()
    {
        Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
        Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        Container.Bind<ITimeService>().To<TimeService>().AsSingle();
        Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
        Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
    }
    
    
    
    
    private void BindInfrastructureServices()
    {
        Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
    }

    public void Initialize()
    {
        Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
    }
}