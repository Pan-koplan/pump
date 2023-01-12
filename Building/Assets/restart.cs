using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
    //[Hearder("SampleScene")]
    //public int sceneIndex;
    //void OnTriggerEnter(Collider myCollider)
    //{
    //    if (myCollider.tag == ("Platform") 
    //    {
    //        SceneManager.LoadScene(sceneIndex);
    //    }
    //}
   
}
