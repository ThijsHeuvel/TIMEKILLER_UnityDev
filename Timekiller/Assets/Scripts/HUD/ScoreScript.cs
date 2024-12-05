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
    [SerializeField] private TextMeshProUGUI scoreText;

    private LocalScaleTween localScaleTween = new LocalScaleTween
    {
        from = new Vector3(3.94f, 3.94f, 3.94f),
        to = new Vector3(2.94f, 2.94f, 2.94f),
        duration = 0.8f,
        easeType = EaseType.CubicInOut,
    };
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = ScoreToGo.ToString();
        upgradeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUpgradeScript>();
    }

    public void AddScore(int scoreToAdd)
    {
        gameObject.CancelTweens();
        gameObject.AddTween(localScaleTween);
        score += scoreToAdd;
        totalScore++;
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
