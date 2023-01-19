using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject enemyPrefab;      
    public float timeSpawn = 0f;
    private float timer;

    public int win_count;
    int count;
    public GameObject Kontr;




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
            count++;
            if (count == win_count)
            {
                Instantiate(Kontr, transform.position, Quaternion.identity);
            }
            if (count < win_count)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            }
            else;
            
        }
    }

}
