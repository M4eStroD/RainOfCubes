using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CollisionDetector))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _deadColor;

    private MeshRenderer _renderer;
    private CollisionDetector _detector;
    
    private readonly int _minTimeLife = 2;
    private readonly int _maxTimeLife = 5;

    public event Action<Cube> Destryed;

    private void Awake()
    {
        _detector = GetComponent<CollisionDetector>();
        _renderer = GetComponent<MeshRenderer>();
    }

    public void Initialize()
    {
        _detector.CollidedEvent += Die;
        _renderer.material.color = _startColor;
    }

    private void Die()
    {
        _detector.CollidedEvent -= Die;
        StartCoroutine(TimerDead());
        _renderer.material.color = _deadColor;
    }

    private IEnumerator TimerDead()
    {
        yield return new WaitForSeconds(Random.Range(_minTimeLife, _maxTimeLife));

        Destryed?.Invoke(this);
    }
}