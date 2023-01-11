using DialogSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject Dialogue;


    [SerializeField] public Color textColor;

    [SerializeField] public float delay;
    [SerializeField] public float delay2;

    [SerializeField] public AudioClip sound;
    [Header("Textholders")]
    [SerializeField] public string input1;
    [SerializeField] public string input2;
    [SerializeField] public string input3;
    [SerializeField] public string input4;
    [SerializeField] public string input5;
    [HideInInspector]
    public bool arround_npc = false;
    public Text DiaHolder;
    public static GameObject table;
    public static GameObject txt;
    public string sc;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            arround_npc = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            arround_npc = false;
        }
    }
    private void Update()
    {
        if (arround_npc == true)
        {
            
            if (Input.GetKeyDown(KeyCode.E) && table == null)
            {
                Instantiate(Dialogue);
                table = GameObject.FindWithTag("Dialog_table");
                txt = GameObject.FindWithTag("Diahold");
                DiaHolder = txt.GetComponent<Text>();
                StartCoroutine(WriteText(input1, input2, input3, input4, input5, DiaHolder, textColor, delay, delay2, sound));
            }

        }
    }
    protected IEnumerator WriteText(string input1, string input2, string input3, string input4, string input5, Text DiaHolder, Color textColor, float delay, float delay2, AudioClip sound)
    {
        string[] input = { input1, input2, input3, input4, input5 };

        DiaHolder.color = textColor;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(table);
            yield break;

        }


        foreach (string i in input)
        {
            if (i != "")
            {
                for (int j = 0; j < i.Length; j++)
                {
                    DiaHolder.text += i[j];
                    SoundManager.instance.PlaySound(sound);

                    yield return new WaitForSeconds(delay);

                }
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
                DiaHolder.text = "";
            }
        }
        Destroy(table);
        if (sc != null)
        {
            SceneManager.LoadScene(sc);
        }
    }
}