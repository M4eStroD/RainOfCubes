using UnityEngine;

public class BombSpawner : Spawner
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    
    protected override void Awake()
    {
        base.Awake();

        _cubeSpawner.CubeRemoved += cube => Spawn(cube.transform.position);
    }
}