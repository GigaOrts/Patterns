using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Health _prefab;

    public void Spawn()
    {
        Instantiate(_prefab);
    }
}
