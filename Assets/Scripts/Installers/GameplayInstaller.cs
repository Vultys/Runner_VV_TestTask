using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private Transform _player;

    public override void InstallBindings()
    {
        Container.BindInstance(_player);
        Container.Bind<IPlayerInput>().To<PlayerInput>().AsSingle();
        Container.Bind<IScoreSystem>().To<ScoreSystem>().AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerMovement>().AsSingle();
    }
}