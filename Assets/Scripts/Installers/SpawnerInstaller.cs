using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnerInstaller : MonoInstaller
{
    [Header("Fruits")]
    public List<FruitsTypeConfig> fruits;

    [Header("Obstacles")]
    public List<SpawnableItemConfig> obstacles;

    public override void InstallBindings()
    {
        Container.Bind<IFruitSpawner>().To<FruitSpawner>().AsSingle().WithArguments(fruits, Container);
        Container.Bind<IObstacleSpawner>().To<ObstacleSpawner>().AsSingle().WithArguments(obstacles, Container);
    }
}