using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;

    public GameObject bullet;
    public Transform shot;
    private float cd;
    public float cooldown;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        Vector3 Local = Vector3.one;

        if (rotateZ > 90 || rotateZ < -90)
        {
            Local.y = -1f;
        }
        else
        {
            Local.y = +1f;
        }

        transform.localScale = Local;

        if (cd <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, shot.position, transform.rotation);
                cd = cooldown;
            }
        }
        else
        {
            cd -= Time.deltaTime;
        }
    }
}
