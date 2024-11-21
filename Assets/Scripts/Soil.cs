using System;
using UnityEngine;

public class SoilScript : MonoBehaviour
{
    // Define the properties that determine if a crop can be planted
    public GameObject[] fertilityStages; // Array of growth stage models
    public int currentStage = 0;      // Current growth stage
    public int waterLevel = 5;          
    public int waterLevelThreshold = 10;                    
    public bool canPlant = true;                    // Whether the player can plant on this terrain

    private Renderer cubeRenderer;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        TimeManager timeManager = FindObjectOfType<TimeManager>();
        timeManager.OnNextDay.AddListener(AdvanceFertility);
    }

    // This function checks if the conditions are right for planting a crop
    /*public bool CanPlayerPlant()
    {
        return canPlant;
    }*/

    void Update()
    {
        // Optionally, you could update the terrain properties over time (e.g., changing water level or fertility)
        // For simplicity, let's check if the player can plant during each frame:
        //CanPlayerPlant();
    }

    // Advance Growth runs every time a day is passed. The lines of code withing AdvanceGrowth() will determine
    // if the plant gets to advance or be stagnant in growth.
    public void AdvanceFertility()
    {
        // Condition 1: Water level
        // If conditions 1 and 2 are met, then below line may run
        // f0.f add more conditions for this line to be able to run (check sunlight and water)
        System.Random rnd = new System.Random();
        int randomWaterIncrease = rnd.Next(0, 2);
        waterLevel += randomWaterIncrease;
        if ((waterLevel >= waterLevelThreshold * (currentStage + 1)) && currentStage < fertilityStages.Length - 1)
        {
            currentStage++;
            UpdateFertilityStage();
        }
    }

    private void UpdateFertilityStage()
    {
        // Activate the current growth stage and deactivate others
        for (int i = 0; i < fertilityStages.Length; i++)
        {
            fertilityStages[i].SetActive(i == currentStage);
        }
    }
}