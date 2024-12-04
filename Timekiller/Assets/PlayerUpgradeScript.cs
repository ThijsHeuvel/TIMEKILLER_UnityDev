using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUpgradeScript : MonoBehaviour
{
    private TextMeshProUGUI upgradeTextContent;
    private float textDelay = 1f;
    [SerializeField] GameObject upgradeText; 
    public static UnityEvent OnTriggerEvent = new UnityEvent();
    public int bulletDamage = 10;
    public float fireRate = 1.3f;
    public float playerSpeed = 7.5f;
    public float bulletForce = 10.0f;

    private void Start()
    {
        upgradeTextContent = upgradeText.GetComponent<TextMeshProUGUI>();
    }

    public void UpgradeRandomStat()
    {
        int stat = Random.Range(0, 4);
        switch (stat)
        {
            case 0:
                bulletDamage += 5;
                ShowMessage("Damage upgraded: " + bulletDamage);
                break;
            case 1:
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
            case 2:
                playerSpeed += 0.2f;
                ShowMessage("Player Speed upgraded: " + playerSpeed + "M/s");
                break;
            case 3:
                bulletForce += 2.0f;
                ShowMessage("Bullet Speed upgraded: " + bulletForce + "M/s");
                break;
        }
        UpdateValues();
    }



    private void Update()
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

    private void ShowMessage(string content)
    {
        textDelay = 1f;
        upgradeTextContent.text = content;
        upgradeText.SetActive(true);
    }


    public void UpdateValues()
    {
        OnTriggerEvent.Invoke();
    }
}
