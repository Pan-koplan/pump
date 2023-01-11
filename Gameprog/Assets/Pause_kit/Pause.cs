using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    public string sc_exit;
    public GameObject pause_menu;
    bool paused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instantiate(pause_menu);
            Time.timeScale = 0;
        }
    }
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sc_exit);
    }

    // Update is called once per frame
    public void unpause()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
