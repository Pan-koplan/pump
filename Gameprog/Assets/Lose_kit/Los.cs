using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Los : MonoBehaviour
{
    public string restart;
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(restart);
    }
}
