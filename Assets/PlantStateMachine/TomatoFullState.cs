using UnityEngine;

public class TomatoFullState : TomatoBaseState
{
    Rigidbody rigidbody;
    float explodeCounter = 0f;
    float timeToExplode = 5f;
    
    Color brown = new Color(0.325f, 0.15f, 0.075f, 1f);
    public override void EnterState(TomatoStateManager tomato)
    {
        Renderer renderer = tomato.GetComponent<Renderer>();
        renderer.materials[1].color = brown;
    }

    public override void UpdateState(TomatoStateManager tomato)
    {
       
    }
}

