using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    public static string sc_exit;
    public GameObject pause_menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause_menu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
