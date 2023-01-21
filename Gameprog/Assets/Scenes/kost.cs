using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kost : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene(12);

        Destroy(this);
    }
}
