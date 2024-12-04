using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private int score = 0;
    public int ScoreToGo = 1;
    private PlayerUpgradeScript upgradeScript;
    private int scoreToUpgrade = 1;
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
            scoreToUpgrade = scoreToUpgrade += 1;
            ScoreToGo = scoreToUpgrade;
        }
        scoreText.text = ScoreToGo.ToString();
    }
}
