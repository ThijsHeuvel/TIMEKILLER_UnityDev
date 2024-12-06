using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    private float force;
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        force = player.GetComponent<PlayerUpgradeScript>().bulletForce;

        PlayerUpgradeScript.OnTriggerEvent.AddListener(Update);
        
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        // Get the mouse position and set the direction of the bullet
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        // Set the velocity of the bullet
        rb.velocity = new Vector2(dir.x, dir.y).normalized * force;
        // Set the rotation of the bullet
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the bullet after a certain amount of time
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateForce()
    {

    }
}
