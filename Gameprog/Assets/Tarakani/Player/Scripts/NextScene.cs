using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject winn;
    void Start()
    {
        
    }

    void Update()
    {
        if(Shetchik.enemys == 13)
        {
            winn.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player") && Shetchik.enemys == 13)
        {
            SceneManager.LoadScene("4_floor");
        }
    }
}
