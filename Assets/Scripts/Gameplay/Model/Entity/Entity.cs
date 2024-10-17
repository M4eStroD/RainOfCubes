using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Entity : MonoBehaviour
{
    [SerializeField] protected Color StartColor;
    [SerializeField] protected Color DeadColor;
    
    protected MeshRenderer Renderer;
    
    private readonly int _minTimeLife = 2;
    private readonly int _maxTimeLife = 5;

    private Rigidbody _rigidbody;
    
    public event Action<Entity> Destryed;

    protected virtual void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Initialize()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.localRotation = new Quaternion(0, 0, 0, 0);
        
        Renderer.material.color = StartColor;
    }

    protected virtual void Die()
    {
        StartCoroutine(TimerDead());
    }
    
    protected virtual IEnumerator TimerDead()
    {
        yield return new WaitForSeconds(GetRandomTimeLife());
    }

    protected void OnDestroy()
    {
        Destryed?.Invoke(this);
    }

    protected int GetRandomTimeLife()
    {
        return Random.Range(_minTimeLife, _maxTimeLife);
    }
}