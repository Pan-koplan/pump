using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
    int sec = 0;
    int min = 0;
    public int lose;
    static public bool winn = true;
    Text timerText;
    public GameObject timer;
    public static bool flow = true;


    void Awake()
    {
        timerText = timer.GetComponent<Text>();
        StartCoroutine(TimeFlow());
    }

    IEnumerator TimeFlow()
    {
        while(flow)
        {
            if(sec == 59)
            {
                Debug.Log("1");
                min++;
                sec = -1;
            }
            sec += 1;
            if(sec >= lose)
            {
                winn = false;
            }
            timerText.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }

}
