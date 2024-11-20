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


    public void AdvanceGrowth()
    {
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
