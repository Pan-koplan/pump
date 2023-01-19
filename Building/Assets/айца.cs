using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class айца : MonoBehaviour
{
    public GameObject enemyPrefab;
    int count = 0;
    public int win_count;
    public GameObject Kontr;
    void Start()
    {

    }


    void Update()
    {
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
