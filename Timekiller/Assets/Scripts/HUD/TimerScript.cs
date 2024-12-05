using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float time = 0f;
    public bool timerActive = true;

    private int mins;
    private int secs;
    private int millisecs;
    void Start()
    {
        timerText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (timerActive)
        {
            time += Time.deltaTime;
            mins = Mathf.FloorToInt(time / 60f);
            secs = Mathf.FloorToInt(time % 60f);
            millisecs = Mathf.FloorToInt((time * 1000) % 1000);

            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", mins, secs, millisecs);
        }
    }
}