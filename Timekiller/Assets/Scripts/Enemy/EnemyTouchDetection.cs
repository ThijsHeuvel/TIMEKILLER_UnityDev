using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTouchDetection : MonoBehaviour
{
    [SerializeField] private int hp = 100;
    [SerializeField] private float damagePopupDelay = 0.5f;
    [SerializeField] private Image healthCircle;
    private GameObject player;
    private GameObject scoreObject;
    private GameObject canvas;
    private GameObject dmgPopupTxt;
    private PlayerUpgradeScript playerUpgradeScript;
    ScoreScript _scoreScript;
    private void Start()
    {
        canvas = transform.GetChild(0).GetChild(0).gameObject;

        dmgPopupTxt = canvas.transform.GetChild(0).gameObject;

        scoreObject = GameObject.FindGameObjectWithTag("HudScoreText");
        _scoreScript = scoreObject.GetComponent<ScoreScript>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerUpgradeScript = player.GetComponent<PlayerUpgradeScript>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletScript bullet = collision.gameObject.GetComponent<BulletScript>();

            int fluctuatingDamage = playerUpgradeScript.bulletDamage + UnityEngine.Random.Range(-2, 3); // Random between -2 and +2
            fluctuatingDamage = Mathf.Max(1, fluctuatingDamage); // Ensure the damage is always at least 1

            hp -= fluctuatingDamage;
            ShowDamagePopup(fluctuatingDamage);
            healthCircle.fillAmount = hp / 100f;

            // Destroy the bullet
            if (hp <= 0)
            {
                _scoreScript.AddScore(1);
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        if (damagePopupDelay > 0)
        {
            damagePopupDelay -= Time.deltaTime;
        }
        else
        {
            dmgPopupTxt.SetActive(false);
        }

    }

    private void ShowDamagePopup(int damage)
    {
        damagePopupDelay = 0.5f;
        dmgPopupTxt.SetActive(true);
        dmgPopupTxt.GetComponent<TextMeshProUGUI>().text = damage.ToString();
    }
}
