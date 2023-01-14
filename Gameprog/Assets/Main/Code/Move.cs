using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    Vector3 right = new Vector3(1, 0, 0);
    Vector3 up = new Vector3(0, 1, 0);
    public Sprite t0;
    /*public Sprite t1;
    public Sprite t2;
    public Sprite t3;
    public SpriteRenderer gg;*/

    Animator Ani;
    public string curanim;
    

    public int dir = 0;//направление, 0 - вниз, 1 - вправо, 2 - вверх, 3 - влево


    void Start()
    {
        Ani = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += right * 0.1f;
            dir = 1;
            Ani.SetBool("speed", true);
            Ani.SetInteger("dir", 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= right * 0.1f;
            dir = 3;
            Ani.SetBool("speed", true);
            Ani.SetInteger("dir", 3);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += up * 0.1f;
            dir = 2;
            ChangeAnim("Up");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= up * 0.1f;
            dir = 0;
            ChangeAnim("Down");
        }
        else
        {
            ChangeAnim("Idle");
        }

        //направление
       /* if(dir == 0) { gg.sprite = t0; }
        if (dir == 1) { gg.sprite = t1; }
        if (dir == 2) { gg.sprite = t2; }
        if (dir == 3) { gg.sprite = t3; }*/

    }
    
   public void ChangeAnim(string anim)
    {
        if(curanim == anim)
        {
            return;
        }
        Ani.Play(anim);
        curanim = anim;
    }
}
