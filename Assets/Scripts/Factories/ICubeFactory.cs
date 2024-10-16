using UnityEngine;

public interface ICubeFactory
{
    void Clear();
    Cube Create(Vector3 position, Transform container = null);
}