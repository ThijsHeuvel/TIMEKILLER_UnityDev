using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeDamageHandler : MonoBehaviour
{
    public static bool IsDead = false;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject killsUntilUpgradeText;
    private ScoreScript scoreScript;
    private TimerScript timerScript;

    private void Start()
    {
        timerScript = timer.GetComponent<TimerScript>();
        scoreScript = scoreText.GetComponent<ScoreScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If player collides with enemy, game over
        if (collision.gameObject.CompareTag("Enemy"))
        {
            timerScript.timerActive = false;
            IsDead = true;
            scoreText.GetComponent<TextMeshProUGUI>().text = scoreScript.totalScore.ToString();
            if (scoreScript.totalScore > PlayerPrefs.GetInt("Highscore", 0))
            {
                PlayerPrefs.SetInt("Highscore", scoreScript.totalScore);
                killsUntilUpgradeText.GetComponent<TextMeshProUGUI>().text = "NEW HIGHSCORE!";
            }
            else
            {
                killsUntilUpgradeText.GetComponent<TextMeshProUGUI>().text = "Total Score";
            }

            Debug.Log("enemy collission");
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            Destroy(gameObject);
        }
    }


}
