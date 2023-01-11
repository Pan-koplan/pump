using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem
{
    public class DialogBaseClass : MonoBehaviour
    {
        /*public static GameObject table;
        protected IEnumerator WriteText(string input1, string input2, string input3, string input4, string input5, Text textHolder, Color textColor, float delay, float delay2, AudioClip sound)
        {
            string[] input = {input1, input2, input3, input4, input5};
            table = GameObject.FindWithTag("Dialog_table");
            textHolder.color = textColor;
           
            
            foreach (string i in input)
            {
                if (i != "")
                {
                    for (int j = 0; j < i.Length; j++)
                    {
                        textHolder.text += i[j];
                        SoundManager.instance.PlaySound(sound);

                        yield return new WaitForSeconds(delay);

                    }
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
                    textHolder.text = "";
                }
            }
            Destroy(table);
        }*/
    }
}

