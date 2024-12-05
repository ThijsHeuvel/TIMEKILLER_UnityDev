using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageHandler : MonoBehaviour
{
    public static bool IsDead = false;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject timer;
    private TimerScript timerScript;

    private void Start()
    {
        timerScript = timer.GetComponent<TimerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            timerScript.timerActive = false;
            IsDead = true;
            Debug.Log("enemy collission");
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            Destroy(gameObject);
        }
    }


}
