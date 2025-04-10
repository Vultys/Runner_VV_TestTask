using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private PlatformSpawnerSettings _platformSpawnerSettings;

    [SerializeField] private Transform _player;

    [SerializeField] private LoseScreen _loseScreen;

    [SerializeField] private FruitScoreUI _fruitScoreUI;

    public override void InstallBindings()
    {
        Container.BindInstance(_player);
        Container.BindInstance(_platformSpawnerSettings);
        Container.BindInstance(_loseScreen).AsSingle();
        Container.BindInstance(_fruitScoreUI).AsSingle();

        
        Container.Bind<IPlayerInput>().To<KeyboardInput>().AsSingle();
        Container.Bind<IPlatformSpawner>().To<PlatformSpawner>().AsSingle();
        Container.Bind<IFruitScoreSystem>().To<FruitScoreSystem>().AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerMovement>().AsSingle();
    }
}