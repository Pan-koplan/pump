using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    int sec = 0;
    int min = 0;
    Text timerText;


    void Awake()
    {
        timerText = GameObject.Find("timer").GetComponent<Text>();
        Debug.Log(GameObject.Find("timer"));
        StartCoroutine(TimeFlow());
    }

    IEnumerator TimeFlow()
    {
        while(true)
        {
            if(sec == 59)
            {
                Debug.Log("1");
                min++;
                sec = -1;
            }
            sec += 1;
            timerText.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }

}
