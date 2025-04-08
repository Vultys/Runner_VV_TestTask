using UnityEngine;
using Zenject;

public class PlayerTracker : MonoBehaviour
{
    [Inject] private IPlatformSpawner _platformSpawner;

    public float triggerDistance = 10f;
    private float _lastSpawnZ;

    private void Update()
    {
        if(transform.position.z + triggerDistance > _lastSpawnZ)
        {
            _platformSpawner.SpawnNext();
            _lastSpawnZ += 20f;
        }
    }
}
