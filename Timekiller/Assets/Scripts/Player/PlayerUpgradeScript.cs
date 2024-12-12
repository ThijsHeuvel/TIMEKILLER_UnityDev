using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Tweens;

public class PlayerUpgradeScript : MonoBehaviour
{
    private TextMeshProUGUI upgradeTextContent;
    private float textDelay = 3f;
    [SerializeField] GameObject upgradeText; 
    public static UnityEvent OnTriggerEvent = new UnityEvent();
    public int bulletDamage = 10;
    public float fireRate = 1.3f;
    public float playerSpeed = 7.5f;
    public float bulletForce = 10.0f;

    LocalScaleTween localScaleTweenUpgrade = new LocalScaleTween
    {
        from = new Vector3(1.7f, 1.7f, 1.7f),
        to = new Vector3(1f, 1f, 1f),
        duration = 1.4f,
        easeType = EaseType.CubicInOut
    };

    private void Start()
    {
        upgradeTextContent = upgradeText.GetComponent<TextMeshProUGUI>();
    }

    public void UpgradeRandomStat()
    {
        int stat = Random.Range(0, 4); // get random stat to increase
        switch (stat) // choose the stat to increase
        {
            case 0: // Damage
                bulletDamage += 5;
                ShowMessage("Damage upgraded: " + bulletDamage);
                break;
            case 1: // Fire rate
                if (fireRate > 0.1f)
                {
                    fireRate -= 0.1f;
                    ShowMessage("Fire Rate upgraded: " + fireRate + "s");
                }
                else
                {
                    UpgradeRandomStat();
                }
                break;
            case 2: // Player travel speed
                playerSpeed += 1f;
                Mathf.CeilToInt(playerSpeed);
                ShowMessage("Player Speed upgraded: " + playerSpeed + "M/s");
                break;
            case 3: // Bullet travel speed
                bulletForce += 2.0f;
                Mathf.CeilToInt(playerSpeed);
                ShowMessage("Bullet Speed upgraded: " + bulletForce + "M/s");
                break;
        }
        UpdateValues();
    }



    private void Update() // Popup timer code
    {
        if (textDelay > 0)
        {
            textDelay -= Time.deltaTime;
        }
        else
        {
            upgradeText.SetActive(false);
        }
    }

    private void ShowMessage(string content) // Popup code
    {
        textDelay = 3f;
        upgradeText.CancelTweens();
        upgradeText.AddTween(localScaleTweenUpgrade);
        upgradeTextContent.text = content;
        upgradeText.SetActive(true);
    }


    public void UpdateValues() // event trigger code
    {
        OnTriggerEvent.Invoke();
    }
}
