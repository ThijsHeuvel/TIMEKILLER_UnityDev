using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tweens;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private int score = 0;
    LocalScaleTween localScaleTween = new LocalScaleTween
    {
        to = new Vector3(2.94f, 2.94f, 2.94f),
        duration = 0.4f,
        easeType = EaseType.QuartOut
    };

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        gameObject.CancelTweens();
        gameObject.transform.localScale = new Vector3(3.94f, 3.94f, 3.94f);
        gameObject.AddTween(localScaleTween);
        score += scoreToAdd;
        gameObject.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
