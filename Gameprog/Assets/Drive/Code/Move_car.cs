using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    bool qw = false;
    Animator Ani;
    public Animator Cube;
    public GameObject pause_menu;


    public float t = 0;
    public int circ = 0;
    public int circ_finish = 15;
    public GameObject winn;
    public GameObject los;

    private void Start()
    {
        v_shared = v;
        Ani = GetComponent<Animator>();
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
                GetComponent<Animator>().enabled = true;
                if (circ % 2 == 0) Ani.Play("Rotation_left");
                else Ani.Play("Rotation_right");
                v = Mathf.Lerp(v, 0, 0.03f);
                Car.position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, t);
                
            }
            


        }
        else
        {
            Car.position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, t);
            v = Mathf.Lerp(v, 0, 0.1f);
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
            if (stopom.value >= 0.47f && stopom.value <= 0.53f)
            {
                if(nit_active == false)
                {
                    nit.GetComponent<TrailRenderer>().time = 0.5f;
                    nit_active = true;
                }
                v = Mathf.Lerp(v*1.4f, v, 0.2f);
                Debug.Log("a");
                
            }
            else
            {
                qw = true;
                v = Mathf.Lerp(v, 0, 0.1f);
                Debug.Log("b");
            }
        }
        stopom.value += v * dirload;


        //nit-stop
        if(t <= 0.4f || t >= 0.6f)
        {
            nit.GetComponent<TrailRenderer>().time = Mathf.Lerp(nit.GetComponent<TrailRenderer>().time,0,0.2f);
            nit_active = false;

        }


        //cameramove
        if(Camera != null)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x, Mathf.Clamp(Car.position.y, 0, 10000000000000000000), Camera.transform.position.z);

        }

        //Gameover
        if (v <= 0.001)
        {
            if(circ == circ_finish && Timer.winn)
            {
                winn.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                los.SetActive(true);
                Time.timeScale = 0;
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
