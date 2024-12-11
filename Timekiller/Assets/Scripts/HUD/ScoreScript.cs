using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tweens;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int totalScore = 0;
    private int score = 0;
    public int ScoreToGo = 1;
    private PlayerUpgradeScript upgradeScript;
    private int scoreToUpgrade = 1;
    private TextMeshProUGUI totalKillsTmp;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject totalKillsText;
    [SerializeField] private GameObject untilUpgradeText;

    private LocalScaleTween localScaleTween = new LocalScaleTween // Tween for bottom left indicator
    {
        from = new Vector3(3.94f, 3.94f, 3.94f),
        to = new Vector3(2.94f, 2.94f, 2.94f),
        duration = 0.8f,
        easeType = EaseType.CubicInOut,
    };

    private LocalPositionYTween localPositionYTween = new LocalPositionYTween 
    {
        duration = 0.8f,
        easeType = EaseType.CubicInOut,
    };

    void Start() // Get the player upgrade script
    {
        localPositionYTween.from = (untilUpgradeText.transform.localPosition.y + 100f);
        localPositionYTween.to = untilUpgradeText.transform.localPosition.y;
        totalKillsTmp = totalKillsText.GetComponent<TextMeshProUGUI>();
        scoreText.text = ScoreToGo.ToString();
        upgradeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUpgradeScript>();
    }

    public void AddScore(int scoreToAdd)
    {
        gameObject.CancelTweens(); // Cancel all tweens to avoid overlapping
        gameObject.AddTween(localScaleTween); // Play the tween

        untilUpgradeText.CancelTweens();
        untilUpgradeText.AddTween(localPositionYTween);
        score += scoreToAdd; // change data in scores
        totalScore++;
        if (totalKillsTmp != null)
        {
            totalKillsTmp.text = "Total kills: " + totalScore.ToString();
        }
        ScoreToGo -= scoreToAdd;

        if (ScoreToGo <= 0) // If the score is less than or equal to 0, upgrade a random stat
        {
            upgradeScript.UpgradeRandomStat();
            scoreToUpgrade = scoreToUpgrade += 1;
            ScoreToGo = scoreToUpgrade;
        }
        scoreText.text = ScoreToGo.ToString();
    }
}
