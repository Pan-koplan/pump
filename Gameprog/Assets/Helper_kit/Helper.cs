using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Helper : MonoBehaviour
{
    public void Exit()
    {
        Time.timeScale = 1;
        Debug.Log("a");
        GameObject.FindGameObjectWithTag("Helper").SetActive(false);
    }
}
