using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    public GameObject weapoin_long;
    public GameObject weapoin_short;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (weapoin_long.activeInHierarchy == true)
            {
                weapoin_long.SetActive(false);
                weapoin_short.SetActive(true);
            }
            else if (weapoin_short.activeInHierarchy == true)
            {
                weapoin_short.SetActive(false);
                weapoin_long.SetActive(true);
            }
        }
    }
}
