using UnityEngine;
using Zenject;

public class LobbyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<LobbyController>().FromComponentInHierarchy().AsSingle();
    }
}