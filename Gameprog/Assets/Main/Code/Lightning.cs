using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lightning : NPC_EDU
{
    Text TextHolder;
    float secunds = 0.1f;
    public float rise;
    float i = 0;
    void Awake()
    {
        TextHolder = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        
        if(secunds >= 1)
        {
            i = -rise;
        }
        else if(secunds <= 0.3) 
        {
            i = rise;
        }
        secunds += i;
        TextHolder.color = new Color(1, 1, 1, secunds);
    }
}
