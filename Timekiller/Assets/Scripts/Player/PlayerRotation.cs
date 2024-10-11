using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    Camera cam;
    private Transform playerTransform;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float camDis = cam.transform.position.y - playerTransform.position.y;
        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2(mouse.y - playerTransform.position.y, mouse.x - playerTransform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        rb.rotation = angle - 90;
    }
}
