using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 right = new Vector3(1, 0, 0);
    Vector3 up = new Vector3(0, 1, 0);

    public int dir = 0;//направление, 0 - вниз, 1 - вправо, 2 - вверх, 3 - влево


    void Start()
    {
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += right * 0.1f;
            dir = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= right * 0.1f;
            dir = 3;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += up * 0.1f;
            dir = 2;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= up * 0.1f;
            dir = 0;
        }
    }
}
