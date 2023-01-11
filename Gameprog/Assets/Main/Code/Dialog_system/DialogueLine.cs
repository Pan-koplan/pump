using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueLine : MonoBehaviour
{
    internal Text DiaHolderGet;
    private void Awake()
    {
        DiaHolderGet = GetComponent<Text>();
        
        //corountine
    }
}

