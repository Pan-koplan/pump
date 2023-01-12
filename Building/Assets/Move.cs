using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float Xposition;//позиция по икас
    public float Xtransition = 0.1f;// скорость в один кадр
    private float Xoffset;// вспомогательная переменная для изменения стороны движения
    
    private void Start()
    {
        Xoffset = Xtransition;
    }

    private void FixedUpdate()
    {
        if(Xposition >= 8)
        {
            Xoffset = -Xtransition;
        }
        else if(Xposition <= -8)
        {
            Xoffset = Xtransition;
        }
        Xposition += Xoffset;
        transform.position = new Vector3(Xposition, transform.position.y, transform.position.z);
    }
}
