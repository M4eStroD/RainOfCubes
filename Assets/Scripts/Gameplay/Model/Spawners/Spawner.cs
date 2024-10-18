using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Entity _entityPrefab;

    [SerializeField] private Transform _container;

    protected EntityFactory EntityFactory;

    public int EntityAllTime { get; private set; } = 0;
    public int EntityCreated { get; private set; } = 0;
    public int EntityActive { get; private set; } = 0;

    public event Action InfoChanged;
    
    protected virtual void Awake()
    {
        EntityFactory = new EntityFactory(_entityPrefab);

        EntityFactory.EntityAdded += IncreaseAll;
        EntityFactory.EntitySpawned += IncreaseSpawnInfo;
        EntityFactory.EntityRemoved += (entity) => DecreaseActiveItem();
    }

    protected void Spawn(Vector3 position)
    {
        EntityFactory.Create(position, _container);
    }

    private void IncreaseAll()
    {
        IncreaseActiveEntity();
        IncreaseCreatedItem();
        IncreaseItemAllTime();
    }

    private void IncreaseSpawnInfo()
    {
        IncreaseItemAllTime();
        IncreaseActiveEntity();
    }
    
    private void IncreaseActiveEntity()
    {
        EntityActive++;
        InfoChanged?.Invoke();
    }

    private void DecreaseActiveItem()
    {
        EntityActive--;
        InfoChanged?.Invoke();
    }

    private void IncreaseCreatedItem()
    {
        EntityCreated++;
        InfoChanged?.Invoke();
    }

    private void IncreaseItemAllTime()
    {
        EntityAllTime++;
        InfoChanged?.Invoke();
    }
}