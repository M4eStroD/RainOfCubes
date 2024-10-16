using System;
using UnityEngine;

public class SpawnersLogic : MonoBehaviour
{
    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private CubeSpawner _cubeSpawner;

    public event Action CubeAdded;
    public event Action CubeSpawned;
    public event Action CubeRemoved; 
    
    public event Action BombAdded;
    public event Action BombSpawned;
    public event Action BombRemoved;
    
    private void Start()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        _cubeSpawner.СubeFactory.EntityRemoved += cube => _bombSpawner.Spawn(cube.transform.position);

        _cubeSpawner.СubeFactory.EntityAdded += () => CubeAdded?.Invoke();
        _cubeSpawner.СubeFactory.EntitySpawned += () => CubeSpawned?.Invoke();
        _cubeSpawner.СubeFactory.EntityRemoved += entity => CubeRemoved?.Invoke();

        _bombSpawner.BombFactory.EntityAdded += () => BombAdded?.Invoke();
        _bombSpawner.BombFactory.EntitySpawned += () => BombSpawned?.Invoke();
        _bombSpawner.BombFactory.EntityRemoved += entity => BombRemoved?.Invoke();
    }
}