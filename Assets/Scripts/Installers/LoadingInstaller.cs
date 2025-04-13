using Zenject;

public class LoadingInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<LoadingController>().FromComponentInHierarchy().AsSingle();
    }
}