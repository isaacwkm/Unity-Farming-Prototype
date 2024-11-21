using TMPro; // Import for TextMeshPro support
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    public int currentDay = 1;
    public TextMeshProUGUI dayCounterText; // Reference to the Text UI for the day counter
    public UnityEvent OnNextDay;

    private void Start()
    {
        UpdateDayText();
    }

    public void NextDay()
    {
        currentDay++;
        OnNextDay.Invoke(); // This is what invokes the OnNextDay event, and causes all other commands that listen in on this event to run.
        UpdateDayText();
    }

    private void UpdateDayText()
    {
        if (dayCounterText != null)
            dayCounterText.text = "Day " + currentDay;
    }
}
