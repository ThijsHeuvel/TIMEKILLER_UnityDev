using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] GameObject TimeText;
    [SerializeField] float timeRemaining = 10f;
    private int mins;
    private int seconds;
    private int milliseconds;

    void Update()
    {
        if (PauseMenuScript.GameIsPaused)
        {
            return;
        }

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
        }

        mins = Mathf.FloorToInt(timeRemaining / 60f);
        seconds = Mathf.FloorToInt(timeRemaining % 60f);
        milliseconds = Mathf.FloorToInt((timeRemaining * 1000f) % 100f); // Always 3-digit milliseconds


        // Update the TextMeshProUGUI component
        TimeText.GetComponent<TextMeshProUGUI>().text = $"{mins:D2}:{seconds:D2}:{milliseconds:D2}";
    }
}
