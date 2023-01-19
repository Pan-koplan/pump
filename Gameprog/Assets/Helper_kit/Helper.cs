using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Helper : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void Exit()
    {
        Time.timeScale = 1;
        Debug.Log("a");
        GameObject.FindGameObjectWithTag("Helper").SetActive(false);
    }
}
