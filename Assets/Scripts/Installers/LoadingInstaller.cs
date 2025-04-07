using Zenject;

public class LoadingInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IGameState>().To<GameStateMachine>().AsSingle();
        Container.Bind<ISaveSystem>().To<PlayerPrefsSaveSystem>().AsSingle();
    }
}