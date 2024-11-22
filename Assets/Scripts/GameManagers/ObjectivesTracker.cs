using UnityEngine;
using UnityEngine.UI;

public class ObjectivesTracker : MonoBehaviour
{
    public GameObject[] objectives; // Array to hold the objective objects
    private int currentObjectiveIndex = 0; // Tracks the current objective

    void Start()
    {
        // Ensure only the first objective is active at the start
        for (int i = 0; i < objectives.Length; i++)
        {
            objectives[i].gameObject.SetActive(i == currentObjectiveIndex);
        }
    }

    public void CompleteObjective()
    {
        // Deactivate the current objective
        if (currentObjectiveIndex < objectives.Length)
        {
            objectives[currentObjectiveIndex].gameObject.SetActive(false);
        }

        // Move to the next objective
        currentObjectiveIndex++;

        // Activate the next objective, if any
        if (currentObjectiveIndex < objectives.Length)
        {
            objectives[currentObjectiveIndex].gameObject.SetActive(true);
        }
    }
}
