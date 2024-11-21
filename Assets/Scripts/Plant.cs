using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject[] growthStages; // Array of growth stage models
    public int currentStage = 0;      // Current growth stage
    public int daysPerStage = 2;      // Days required to move to the next stage
    private int daysSinceLastGrowth = 0;

    private void Start()
    {
        TimeManager timeManager = FindObjectOfType<TimeManager>();
        timeManager.OnNextDay.AddListener(AdvanceGrowth);
    }


    // Advance Growth runs every time a day is passed. The lines of code withing AdvanceGrowth() will determine
    // if the plant gets to advance or be stagnant in growth.
    public void AdvanceGrowth()
    {
        // Condition 1: Water level
        // Condition 2: Sun level
        // If conditions 1 and 2 are met, then below line may run
        daysSinceLastGrowth++; // f0.f add more conditions for this line to be able to run (check sunlight and water)

        if (daysSinceLastGrowth >= daysPerStage && currentStage < growthStages.Length - 1)
        {
            daysSinceLastGrowth = 0;
            currentStage++;
            UpdateGrowthStage();
        }
    }

    private void UpdateGrowthStage()
    {
        // Activate the current growth stage and deactivate others
        for (int i = 0; i < growthStages.Length; i++)
        {
            growthStages[i].SetActive(i == currentStage);
        }
    }
}
