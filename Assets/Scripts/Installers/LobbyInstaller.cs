using UnityEngine;
using Zenject;

public class LobbyInstaller : MonoInstaller
{
    [SerializeField] private LobbyRankUI _rankUI;

    public override void InstallBindings()
    {
        Container.BindInstance(_rankUI).AsSingle();
        Container.Bind<LobbyController>().FromComponentInHierarchy().AsSingle();
    }
}