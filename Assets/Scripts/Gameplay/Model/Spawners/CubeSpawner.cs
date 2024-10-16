using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    [SerializeField] private float _offsetY;
    [SerializeField] private float _interval;

    [SerializeField] private Transform _spawnPlane;
    [SerializeField] private Transform _container;

    public EntityFactory СubeFactory { get; private set; }

    private void Awake()
    {
        СubeFactory = new EntityFactory(_cubePrefab);
    }

    private void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    private void SpawnCube()
    {
        СubeFactory.Create(GetRandomPosition(), _container);
    }

    private IEnumerator SpawnTimer()
    {
        WaitForSeconds wait = new WaitForSeconds(_interval);

        while (true)
        {
            SpawnCube();
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