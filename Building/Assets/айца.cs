using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class айца : MonoBehaviour
{
    public GameObject enemyPrefab;
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
