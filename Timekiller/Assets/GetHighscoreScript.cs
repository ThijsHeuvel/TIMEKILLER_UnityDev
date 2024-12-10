using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetHighscoreScript : MonoBehaviour
{
    private TextMeshProUGUI highscoreText;
    void Start()
    {
        highscoreText = gameObject.GetComponent<TextMeshProUGUI>();

        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
    }
}
