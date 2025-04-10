using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private PlatformSpawnerSettings _platformSpawnerSettings;

    [SerializeField] private Transform _player;

    public override void InstallBindings()
    {
        Container.BindInstance(_player);
        Container.BindInstance(_platformSpawnerSettings);
        
        Container.Bind<IPlayerInput>().To<KeyboardInput>().AsSingle();
        Container.Bind<IScoreSystem>().To<ScoreSystem>().AsSingle();
        Container.Bind<IPlatformSpawner>().To<PlatformSpawner>().AsSingle();
        Container.Bind<IFruitScoreSystem>().To<FruitScoreSystem>().AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerMovement>().AsSingle();
    }
}