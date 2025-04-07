using Zenject;

public class LoadingInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ISaveSystem>().To<PlayerPrefsSaveSystem>().AsSingle();

        Container.Bind<LoadingController>().FromComponentInHierarchy().AsSingle();
    }
}