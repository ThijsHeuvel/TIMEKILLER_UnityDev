using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject basicCircleEnemy;
    private Transform player;
    [SerializeField] private float spawnRadiusMin = 10.0f;
    [SerializeField] private float spawnRadiusMax = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
