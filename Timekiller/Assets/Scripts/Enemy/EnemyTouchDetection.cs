using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyTouchDetection : MonoBehaviour
{
    [SerializeField] private int hp = 100;
    [SerializeField] private float textDelay = 0.5f;
    private GameObject dmgPopUp;
    private GameObject canvas;
    private GameObject dmgPopupTxt;
    private void Start()
    {
        dmgPopUp = gameObject.transform.GetChild(0).gameObject;
        canvas = dmgPopUp.transform.GetChild(0).gameObject;
        dmgPopupTxt = canvas.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the enemy collides with the player, the player will take damage
        if (collision.gameObject.CompareTag("Player"))
        {
            // Lose time
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletScript bullet = collision.gameObject.GetComponent<BulletScript>();
            hp -= bullet.damage;
            ShowDamagePopup(bullet.damage);

            // Destroy the bullet
            Destroy(collision.gameObject);
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Lose time
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletScript bullet = collision.gameObject.GetComponent<BulletScript>();
            hp -= bullet.damage;
            ShowDamagePopup(bullet.damage);

            // Destroy the bullet
            Destroy(collision.gameObject);
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        if (textDelay > 0)
        {
            textDelay -= Time.deltaTime;
        }
        else
        {
            dmgPopUp.SetActive(false);
        }

    }

    private void ShowDamagePopup(int damage)
    {
        textDelay = 0.5f;
        dmgPopUp.SetActive(true);
        dmgPopupTxt.GetComponent<TextMeshProUGUI>().text = damage.ToString();
    }
}
