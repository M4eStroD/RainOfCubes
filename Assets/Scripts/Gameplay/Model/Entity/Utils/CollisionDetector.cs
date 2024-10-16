using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action CollidedEvent;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Platform _))
            CollidedEvent?.Invoke();
    }
}