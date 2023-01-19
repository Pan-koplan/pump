using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontr : MonoBehaviour
{
    public GameObject winn;
    public float time;
    bool grounded;
    void Update()
    {
        time += 1 * Time.deltaTime;
        if(time > 5 && grounded)
        {
            GameObject.FindWithTag("Winn").SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            grounded= true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            grounded= false;
        }
    }
}
