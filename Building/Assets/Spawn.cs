using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject enemyPrefab;      
    public float timeSpawn = 0f;
    private float timer; 


    private void Start()
    {
        timer = timeSpawn;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {


        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeSpawn;
            Instantiate(enemyPrefab);
            
        }

        enemyPrefab.transform.position = transform.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }

}
