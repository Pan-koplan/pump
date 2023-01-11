using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_EDU : NPC
{
    [SerializeField]public GameObject Edu1;
    GameObject Edu;
    bool being = false;

    void Update()
    {
        Edu = GameObject.FindWithTag("Edu_bar");
        if (arround_npc == true && being == false)
        {
            Debug.Log(arround_npc);
            being = true;
            Instantiate(Edu1);
        }
        if (arround_npc == false && being == true)
        {
            Debug.Log("del");
            being = false;
            Destroy(Edu);
        }
    }
}
