using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Bomb _bombPrefab;

    [SerializeField] private Transform _container;

    public EntityFactory BombFactory { get; private set; }

    private void Awake()
    {
        BombFactory = new EntityFactory(_bombPrefab);
    }

    public void Spawn(Vector3 position)
    {
        BombFactory.Create(position, _container);
    }
}