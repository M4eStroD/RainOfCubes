using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class EntityFactory
{
    private readonly ObjectPool<Entity> _objectPool;
    private readonly HashSet<Entity> _entities;

    private readonly Entity _entityPrefab;

    public event Action<Entity> EntityRemoved;
    public event Action EntityAdded;
    public event Action EntitySpawned;
    
    public EntityFactory(Entity entityPrefab)
    {
        _objectPool = new ObjectPool<Entity>();
        _entities = new HashSet<Entity>();

        _entityPrefab = entityPrefab;
    }

    public void Create(Vector3 position, Transform container = null)
    {
        Entity tempEntity = _objectPool.GetObject();

        if (tempEntity == null)
        {
            tempEntity = Object.Instantiate(_entityPrefab);
            _entities.Add(tempEntity);

            tempEntity.Destryed += PutEntity;

            EntityAdded?.Invoke();
        }
        else
        {
            EntitySpawned?.Invoke();
            tempEntity.gameObject.SetActive(true);
        }

        tempEntity.Initialize();
        
        tempEntity.transform.position = position;
        tempEntity.transform.SetParent(container);
    }

    private void PutEntity(Entity entity)
    {
        EntityRemoved?.Invoke(entity);
        _objectPool.PutObject(entity);
    }

    private void Clear()
    {
        foreach (Entity entity in _entities)
        {
            entity.Destryed -= PutEntity;
            Object.Destroy(entity.gameObject);
        }
        
        _objectPool.Clear();
        _entities.Clear();
    }
}