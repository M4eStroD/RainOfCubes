using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : Spawner
{
    [SerializeField] private float _offsetY;
    [SerializeField] private float _interval;

    [SerializeField] private Transform _spawnPlane;
    
    public event Action<Entity> CubeRemoved;

    protected override void Awake()
    {
        base.Awake();

        EntityFactory.EntityRemoved += cube => CubeRemoved?.Invoke(cube);
    }

    private void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    private IEnumerator SpawnTimer()
    {
        WaitForSeconds wait = new WaitForSeconds(_interval);

        while (true)
        {
            Spawn(GetRandomPosition());
            yield return wait;
        }
    }

    private Vector3 GetRandomPosition()
    {
        float halfWidthPlane = _spawnPlane.localScale.x / 2;
        float halfLengthPlane = _spawnPlane.localScale.x / 2;
        
        float randomX = Random.Range(-halfWidthPlane, halfWidthPlane);
        float randomZ = Random.Range(-halfLengthPlane, halfLengthPlane);

        return new Vector3(randomX, _offsetY, randomZ);
    }
}