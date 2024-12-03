using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUpgradeScript : MonoBehaviour
{
    [SerializeField] BulletScript bulletScript;
    public static UnityEvent OnTriggerEvent = new UnityEvent();
    public int bulletDamage = 10;
    public float fireRate = 2;
    public float playerSpeed = 4.0f;
    public float bulletForce = 10.0f;
    public void UpgradeRandomStat()
    {
        int stat = Random.Range(0, 5);
        switch (stat)
        {
            case 0:
                bulletDamage += 5;
                Debug.Log("Damage upgraded: " + bulletDamage);
                break;
            case 1:
                if (fireRate >= 0.2f)
                {
                    fireRate -= 0.2f;
                    Debug.Log("Fire Rate upgraded: " + fireRate);
                }
                else
                {
                    UpgradeRandomStat();
                }
                break;
            case 2:
                playerSpeed += 1.0f;
                Debug.Log("Player Speed upgraded: " + playerSpeed);
                break;
            case 3:
                bulletForce += 2.0f;
                Debug.Log("Bullet Force upgraded: " + bulletForce);
                break;
        }
        UpdateValues();
    }


    public void UpdateValues()
    {
        OnTriggerEvent.Invoke();
    }
}
