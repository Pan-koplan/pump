
using UnityEngine;

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
