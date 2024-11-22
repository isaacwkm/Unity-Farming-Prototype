using UnityEngine;
using System.Collections;

public class ObjectivesManager : MonoBehaviour
{
    public static ObjectivesManager Instance { get; private set; }
    public GameObject[] objectives; // Array to hold objective GameObjects
    private int currentObjectiveIndex = 0; // Tracks the current objective
    private float animationDuration = 2f; // Duration for displaying checkmark/strikethrough

    void Awake()
    {
        // Ensure only one instance of the ObjectivesManager exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        // Ensure only the first objective is active at the start
        for (int i = 0; i < objectives.Length; i++)
        {
            SetObjectiveActive(i, i == currentObjectiveIndex);
        }
    }

    public void CompleteObjective(int objectiveIndex)
    {
        if (objectiveIndex != currentObjectiveIndex) return;

        // Mark the current objective as complete and show the checkmark/strikethrough
        if (currentObjectiveIndex < objectives.Length)
        {
            StartCoroutine(AnimateObjectiveCompletion(currentObjectiveIndex));
        }
    }

    private IEnumerator AnimateObjectiveCompletion(int index)
    {
        // Activate the checkmark and strikethrough
        GameObject objective = objectives[index];
        Transform checkmark = objective.transform.Find("Checkmark");
        Transform strikethrough = objective.transform.Find("Strikethrough");

        if (checkmark) checkmark.gameObject.SetActive(true);
        if (strikethrough) strikethrough.gameObject.SetActive(true);

        // Wait for the specified animation duration (e.g., 2 seconds)
        yield return new WaitForSeconds(animationDuration);

        // After 2 seconds, hide the checkmark/strikethrough and move to the next objective
        if (checkmark) checkmark.gameObject.SetActive(false);
        if (strikethrough) strikethrough.gameObject.SetActive(false);

        // Move to the next objective
        currentObjectiveIndex++;

        // Deactivate the current objective and activate the next one
        if (currentObjectiveIndex < objectives.Length)
        {
            SetObjectiveActive(index, false); // Deactivate the current objective
            SetObjectiveActive(currentObjectiveIndex, true); // Activate the next objective
        }
    }

    private void SetObjectiveActive(int index, bool isActive)
    {
        GameObject objective = objectives[index];
        Transform bodyText = objective.transform.Find("Body");
        if (index >= 0 && index < objectives.Length)
        {
            bodyText.gameObject.SetActive(isActive);
        }
    }
}
