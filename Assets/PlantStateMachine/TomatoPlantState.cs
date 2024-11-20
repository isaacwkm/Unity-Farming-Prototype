using UnityEngine;

public class TomatoPlantState : TomatoBaseState
{
    Vector3 growthSpeed = new Vector3(0.5f, 0.5f, 0.5f);
    Vector3 startScale = new Vector3(2f, 2f, 2f);
    Vector3 endScale = new Vector3(6f, 6f, 6f);
    public override void EnterState(TomatoStateManager tomato)
    {
       tomato.transform.localScale = startScale;
    }

    public override void UpdateState(TomatoStateManager tomato)
    {
        if (tomato.transform.localScale.x < endScale.x){
            tomato.transform.localScale += growthSpeed * Time.deltaTime;
        } else {
            tomato.SwitchState(tomato.GrowthState);
        }
    }
}