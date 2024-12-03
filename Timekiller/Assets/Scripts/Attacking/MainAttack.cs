using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    private float timeBetweenFiring;
    private PlayerUpgradeScript playerUpgradeScript;
    // Start is called before the first frame update
    void Start()
    {
        playerUpgradeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUpgradeScript>();
        timeBetweenFiring = playerUpgradeScript.fireRate;
        PlayerUpgradeScript.OnTriggerEvent.AddListener(UpdateDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire && !PauseMenuScript.GameIsPaused && !TakeDamageHandler.IsDead)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }

    void UpdateDelay()
    {
        timeBetweenFiring = playerUpgradeScript.fireRate;
    }
}
