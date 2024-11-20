using UnityEngine;

public class TomatoStateManager : MonoBehaviour
{

    TomatoBaseState currentState;

    public TomatoPlantState PlantState = new TomatoPlantState();
    public TomatoGrowthState GrowthState = new TomatoGrowthState();
    public TomatoFullState FullState = new TomatoFullState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlantState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(TomatoBaseState state){
        currentState = state;
        state.EnterState(this);
    }
}
