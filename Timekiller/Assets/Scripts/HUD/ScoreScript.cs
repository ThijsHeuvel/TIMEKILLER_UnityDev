using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private int score = 0;
    public int ScoreToGo = 10;
    private float difficulty = 1f;
    private PlayerUpgradeScript upgradeScript;
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = ScoreToGo.ToString();
        upgradeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUpgradeScript>();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ScoreToGo -= scoreToAdd;

        if (ScoreToGo <= 0)
        {
            upgradeScript.UpgradeRandomStat();
            difficulty = difficulty / 100f * 120f;
            ScoreToGo = Mathf.CeilToInt(difficulty / 10f);
        }
        scoreText.text = ScoreToGo.ToString();
    }
}
