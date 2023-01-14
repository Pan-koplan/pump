using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_fix : MonoBehaviour
{
    public string sc_exit;
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sc_exit);
    }

    // Update is called once per frame
    public void unpause()
    {
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Pause").SetActive(false);
    }
}
