using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_ : MonoBehaviour
{
    public string st;
    public void Star()
    {
        SceneManager.LoadScene(st);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
