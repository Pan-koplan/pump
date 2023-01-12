using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

[ExecuteAlways]
public class Move_car : MonoBehaviour
{

    public Transform P0;
    public Transform P1;
    public Transform P2;
    public Transform P3;

    public Transform Car;
    public GameObject Line;

    public float v = 0.01f;

    public GameObject Camera;
    public GameObject Fin;
    public Image load;
    float dirload = 1;


    public float t = 0;
    int circ = 0;
    public int circ_finish = 15;

    void Start()
    {
        load.fillAmount = 0;
    }
    void FixedUpdate()
    {
        //движение тормоз
        if(Timer.flow == true)
        {
            Car.position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, t);
            Car.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(P0.position, P1.position, P2.position, P3.position, t));
        }
        else
        {
            Car.position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, t);
            v = Mathf.Lerp(v, 0, 0.05f);
        }
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
                Fin.transform.rotation = Car.transform.rotation;
                Fin.transform.position = Car.transform.position;
                Timer.flow = false;
                
            }
        }

        // stopometr
        load.fillAmount += v * dirload;


        //cameramove
        if(Camera != null)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x, Car.position.y, Camera.transform.position.z);
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
