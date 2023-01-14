using UnityEngine;
using UnityEngine.UI;

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
    float dirload = 1;

    public Slider stopom;
    public GameObject nit;
    private bool nit_active;
    float v_shared;
    bool qw;


    public float t = 0;
    public int circ = 0;
    public int circ_finish = 15;

    private void Start()
    {
        v_shared = v;
    }
    void FixedUpdate()
    {
        //движение тормоз
        if(Timer.flow == true)
        {
            if(qw == false)
            {
                Car.position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, t);
                Car.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(P0.position, P1.position, P2.position, P3.position, t));
            }
            else
            {
                Car.rotation = Quaternion.Euler(Mathf.Lerp(Car.rotation.x, 5f, 1f), Car.rotation.y, Car.rotation.z);
            }
           

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
                Timer.flow = false;  
            }
        }

        // stopometr
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (t >= 0.4f && t <= 0.6f)
            {
                if(nit_active == false)
                {
                    nit.GetComponent<TrailRenderer>().time = 0.5f;
                    nit_active = true;
                }
                v = Mathf.Lerp(v*1.3f, v, 0.5f);
                
            }
            else
            {
                qw = true;
                v = Mathf.Lerp(v, 0, 0.1f);
            }
        }
        stopom.value += v * dirload;


        //nit-stop
        if(t<=0.4f || t >= 0.6f)
        {
            nit.GetComponent<TrailRenderer>().time = Mathf.Lerp(nit.GetComponent<TrailRenderer>().time,0,0.2f);
            nit_active = false;
        }


        //cameramove
        if(Camera != null)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x, Mathf.Clamp(Car.position.y, 0, 10000000000000000000), Camera.transform.position.z);

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
