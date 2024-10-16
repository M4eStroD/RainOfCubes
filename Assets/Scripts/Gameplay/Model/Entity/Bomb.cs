using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Exploder))]
public class Bomb : Entity
{
    private Exploder _exploder;
    
    protected override void Awake()
    {
        base.Awake();
        
        _exploder = GetComponent<Exploder>();
    }

    public override void Initialize()
    {
        base.Initialize();
        
        Die();
    }

    protected override IEnumerator TimerDead()
    {
        int timeLife = GetRandomTimeLife();

        float currentTime = timeLife;
        float intervalTime = 0.01f;

        WaitForSeconds wait = new WaitForSeconds(intervalTime);
        
        Color color = Renderer.material.color;
        
        while (currentTime > 0)
        {
            color.a = currentTime / timeLife;
            Renderer.material.color = color;
            
            currentTime -= intervalTime;
            yield return wait;
        }

        _exploder.Explode(transform);
        
        EntityDestroy();
    }
}
