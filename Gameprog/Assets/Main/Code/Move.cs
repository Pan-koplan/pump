using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    Vector3 right = new Vector3(1, 0, 0);
    Vector3 up = new Vector3(0, 1, 0);
    //public Sprite t0;
    /*public Sprite t1;
    public Sprite t2;
    public Sprite t3;
    public SpriteRenderer gg;*/

    Animator Ani;
    public string curanim;
    

    public int dir = 0;//направление, 0 - вниз, 1 - вправо, 2 - вверх, 3 - влево
    private bool speed;

    void Start()
    {
        Ani = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        speed = false;
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += right * 0.1f;
            dir = 1;
            speed = true;
            ChangeAnim("Right");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= right * 0.1f;
            dir = 3;
            speed = true;
            ChangeAnim("Left");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += up * 0.1f;
            dir = 2;
            speed = true;
            ChangeAnim("Up");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= up * 0.1f;
            dir = 0;
            speed = true;
            ChangeAnim("Down");
        }

        //направление
        if (speed != true && dir == 0) { ChangeAnim("Idle"); }
        if (speed != true && dir == 1) { ChangeAnim("Idle_right"); }
        if (speed != true && dir == 2) { ChangeAnim("Idle_up"); }
        if (speed != true && dir == 3) { ChangeAnim("Idle_left"); }

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
