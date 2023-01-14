using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

[ExecuteAlways]
public class Move_road: MonoBehaviour
{

    public Transform P0;
    public Transform P1;
    public Transform P2;
    public Transform P3;

    public Transform Car;
    public GameObject Line;

    public float v = 0.01f;

    public GameObject Fin;
    bool finish = false;
    float dirload = 1;


    public float t = 0;
    int circ = 0;
    public int circ_finish = 15;
    void FixedUpdate()
    {
        //движение тормоз

        Car.position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, t);
        Car.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(P0.position, P1.position, P2.position, P3.position, t));

        t += v;
        

        // движение формирование дороги и фишина
        if(t >= 1.0f)
        {
            circ++;
            t = 0.0f;
            Line.transform.position = Car.transform.position;
            Line.transform.localScale = new Vector3(Line.transform.localScale.x * -1, Line.transform.localScale.y, Line.transform.localScale.z);
            dirload = dirload * -1;
            if (circ == circ_finish)
            {
                Instantiate(Fin);
                Fin.transform.position = Car.position;
                finish = true;
                v = 0;
            }
        }
    }

    private void OnDrawGizmos() {

        int sigmentsNumber = 20;
        Vector3 preveousePoint = P0.position;

        for (int i = 0; i < sigmentsNumber + 1; i++) {
            float paremeter = (float)i / sigmentsNumber;
            Vector3 point = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, paremeter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }

    }


}
