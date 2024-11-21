using System.Collections;
using System.Collections.Generic;
using Tweens;
using UnityEngine;

public class MainAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    private GameObject gun;

    LocalScaleTween gunAnimTween = new LocalScaleTween
    {
        duration = 0.3f,
        easeType = EaseType.CircOut,
    };

    // Start is called before the first frame update
    void Start()
    {
        gun = bulletTransform.gameObject;
        gunAnimTween.to = gun.transform.localScale;
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

        if (Input.GetMouseButton(0) && canFire)
        {

            canFire = false;
            gun.CancelTweens();
            gun.transform.localScale = new Vector3(0.55f, 0.5f, 1f);
            gun.AddTween(gunAnimTween);
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
