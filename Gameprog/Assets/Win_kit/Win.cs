using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public string exit;
    public void Exit()
    {
        if(exit != "")
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(exit);
        }
        else
        {
            Debug.Log("s");
            GameObject.FindGameObjectWithTag("Winn").SetActive(false);
        }
        
    }
}
