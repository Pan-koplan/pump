using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontr : MonoBehaviour
{
    public GameObject winn;
    public float time;
    bool grounded;
    bool win = false;
    void Update()
    {
        time += 1 * Time.deltaTime;
        if(time > 3 && grounded == true)
        {
            if(win != true)
            {
                Instantiate(winn);
                win = true;
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("a");
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
