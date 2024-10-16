using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class CubeFactory
{
    private readonly ObjectPool<Cube> _objectPoolCube;
    private readonly HashSet<Cube> _cubes;

    private readonly Cube _cubePrefab;

    public CubeFactory(Cube cubePrefab)
    {
        _objectPoolCube = new ObjectPool<Cube>();
        _cubes = new HashSet<Cube>();

        _cubePrefab = cubePrefab;
    }

    public Cube Create(Vector3 position, Transform container = null)
    {
        Cube tempCube = _objectPoolCube.GetObject();

        if (tempCube == null)
        {
            tempCube = Object.Instantiate(_cubePrefab);
            _cubes.Add(tempCube);

            tempCube.Destryed += cube => _objectPoolCube.PutObject(cube);
        }
        else
        {
            tempCube.gameObject.SetActive(true);
        }

        tempCube.Initialize();
        
        tempCube.transform.position = position;
        tempCube.transform.SetParent(container);

        return tempCube;
    }

    public void Clear()
    {
        foreach (Cube cube in _cubes)
            Object.Destroy(cube.gameObject);
        
        _objectPoolCube.Clear();
        _cubes.Clear();
    }
}