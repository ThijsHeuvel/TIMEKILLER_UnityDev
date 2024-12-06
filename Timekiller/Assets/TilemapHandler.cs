using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapHandler : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Transform playerTransform;
    private SpriteRenderer tileSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.transform;
        tileSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        tileSpriteRenderer.size = new Vector2(Mathf.Abs(playerTransform.position.x)+1, Mathf.Abs(playerTransform.position.y)+1) * 20;
    }
}
