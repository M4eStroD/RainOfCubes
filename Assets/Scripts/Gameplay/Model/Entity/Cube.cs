using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CollisionDetector))]
public class Cube : Entity
{
    private CollisionDetector _detector;
        
    protected override void Awake()
    {
        base.Awake();
        
        _detector = GetComponent<CollisionDetector>();
    }

    public override void Initialize()
    {
        base.Initialize();
        
        _detector.CollidedEvent += Die;
    }

    protected override void Die()
    {
        base.Die();
        
        _detector.CollidedEvent -= Die;
        Renderer.material.color = DeadColor;
    }

    protected override IEnumerator TimerDead()
    {
        yield return base.TimerDead();
        
        EntityDestroy();
    }
}