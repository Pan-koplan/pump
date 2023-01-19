using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject car;
    void Update()
    {
        gameObject.transform.position = car.transform.position;
        gameObject.transform.rotation = car.transform.rotation;
    }
}
